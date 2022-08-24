using Core.Domains;
using Core.Dtos;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using Core.Exceptions;

namespace Implements.Services
{
    public class Services : IServices
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        private IUserGroupRepository userGroupRepository;
        private IUserRepository userRepository;
        private IQuestionRepository questionRepository;
        private IAnswerRepository answerRepository;
        private IUserQuestionRepository userQuestionRepository;
        private IUserQuestionAnswerRepository userQuestionAnswerRepository;
        public Services(ApplicationDbContext db,
            IMapper mapper,
            IUserGroupRepository userGroupRepository,
            IUserRepository userRepository,
            IQuestionRepository questionRepository,
            IAnswerRepository answerRepository,
            IUserQuestionRepository userQuestionRepository,
            IUserQuestionAnswerRepository userQuestionAnswerRepository)
        {
            this.db = db;
            this.mapper = mapper;
            this.userGroupRepository = userGroupRepository;
            this.userRepository = userRepository;
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
            this.userQuestionRepository = userQuestionRepository;
            this.userQuestionAnswerRepository = userQuestionAnswerRepository;
        }
        public IList<QuestionDto> LoadQuestion()
        {
          
            try
            {
                var questions = questionRepository.GetAll();
                var dtos = questions.Select(t =>
                {
                    var dto = mapper.Map<Question, QuestionDto>(t);
                    var answers = mapper.Map<IList<Answer>, IList<AnswerDto>>(t.Answers);
                    dto.Answers = answers;
                    return dto;
                }).ToList();
                if (dtos.Count == 0)
                {
                    throw new NotFoundException("Not found data");
                }
                return dtos;
            }
            catch(NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<UserQuestionDto> LoadUserAnswer(string username)
        {
           
            try
            {
                var userQuestions = userQuestionRepository.GetUserQuestionByUserName(username);
                var dtos = userQuestions.Select(t =>
                {
                    UserQuestionDto dto = mapper.Map<UserQuestion, UserQuestionDto>(t);
                    dto.UserName = t.User.UserName;
                    IList<UserQuestionAnswerDto> answers = mapper.Map<IList<UserQuestionAnswer>, IList<UserQuestionAnswerDto>>(t.UserQuestionAnswers);
                    dto.Answers = answers;
                    return dto;
                }).ToList();
                if (userQuestions.Count == 0)
                {
                    throw new NotFoundException("Not Found Data");
                }
                return dtos;
            }
            catch(NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<UserGroupDto> LoadUserGroup()
        {
            try
            {
                var userGroups = userGroupRepository.GetAll();
                if(userGroups.Count == 0)
                {
                    throw new NotFoundException("Not found data");
                }
                return mapper.Map<IList<UserGroup>, IList<UserGroupDto>>(userGroups);
            }
            catch(NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        public RegisterDto Register(RegisterDto dto)
        {
          
            try
            {
                this.db.Database.BeginTransaction();
                List<string> errors = new List<string>();
                if (dto.UserGroupID.HasValue==false || dto.UserGroupID == 0)
                {
                    errors.Add("User Group is Required");
                }
                if (string.IsNullOrEmpty(dto.UserName))
                {
                    errors.Add("User Name is Required");
                }
                User? existUser = userRepository.GetByUserName(dto.UserName);
                if (existUser != null)
                {
                    errors.Add("User Name is exists");
                }
                if (errors.Count > 0)
                {
                    throw new BadRequestException(string.Join(",", errors));
                }
                User user = mapper.Map<RegisterDto, User>(dto);
               
                var savedUser = userRepository.Create(user);
                this.db.SaveChanges();
                if(savedUser.Id == 0)
                {
                    throw new Exception("Can not save db");
                }
                this.db.Database.CommitTransaction();
                return dto;
                
               
            }
            catch(BadRequestException ex)
            {
                this.db.Database.RollbackTransaction();
                throw new BadRequestException(ex.Message);
            }
            catch(Exception ex)
            {

                this.db.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public IList<UserQuestionDto> SaveUserAnswer(IList<UserQuestionDto> dtos)
        {
            try
            {

                this.db.Database.BeginTransaction();
                var questions = dtos.Select(dto =>
                {
                    var question = mapper.Map<UserQuestionDto, UserQuestion>(dto);
                    question.UserQuestionAnswers = mapper.Map<IList<UserQuestionAnswerDto>, IList<UserQuestionAnswer>>(dto.Answers);
                    return question;
                }).ToList();
                List<string> errors = new List<string>();
                if (questions.Count == 0)
                {
                    errors.Add("Please Input Question");
                }
                if (errors.Count > 0)
                {
                    throw new BadRequestException(string.Join(",", errors));
                }
                var user = userRepository.GetByUserName(dtos[0].UserName);


                foreach (var question in questions)
                {
                    if (question.Id == 0)
                    {
                      
                        question.UserID = user!.Id;
                        question.User = user;
                        question.Question = questionRepository.GetByID(question.QuestionID);
                        if(question.Question == null)
                        {
                            throw new BadRequestException("Question not found");
                        }
                        foreach(var answer in question.UserQuestionAnswers)
                        {
                            answer.Answer = answerRepository.GetByID(answer.AnswerID);
                            if (answer == null)
                            {
                                throw new BadRequestException("answer not found");
                            }
                        }
                        var saveQuestion = userQuestionRepository.Create(question);
                        if (saveQuestion.Id == 0)
                        {
                            throw new Exception("cannot save question db");
                        }
                    
                    }
                    else
                    {
                        question.UserID = user!.Id;
                        question.User = user;
                        question.Question = questionRepository.GetByID(question.QuestionID);
                        if (question.Question == null)
                        {
                            throw new BadRequestException("Question not found");
                        }
                        foreach (var answer in question.UserQuestionAnswers)
                        {
                            answer.Answer = answerRepository.GetByID(answer.AnswerID);
                            if (answer == null)
                            {
                                throw new BadRequestException("answer not found");
                            }
                        }
                        var questiondb = userQuestionRepository.Update(question, question.Id);
                       
                    }
                 

                }
                dtos = LoadUserAnswer(user!.UserName);
                this.db.Database.CommitTransaction();
                return dtos;
            }
            catch (BadRequestException ex)
            {
                throw new BadRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                this.db.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public SummaryDto SubmitUserAnswer(IList<UserQuestionDto> dtos)
        {
            try
            {

                this.db.Database.BeginTransaction();
                var questions = dtos.Select(dto =>
                {
                    var question = mapper.Map<UserQuestionDto, UserQuestion>(dto);
                    question.UserQuestionAnswers = mapper.Map<IList<UserQuestionAnswerDto>, IList<UserQuestionAnswer>>(dto.Answers);
                    return question;
                }).ToList();
                List<string> errors = new List<string>();
                if (questions.Count == 0)
                {
                    errors.Add("Please Input Question");
                }
                if (errors.Count > 0)
                {
                    throw new BadRequestException(string.Join(",", errors));
                }
                var user = userRepository.GetByUserName(dtos[0].UserName);


                foreach (var question in questions)
                {
                    if (question.Id == 0)
                    {

                        question.UserID = user!.Id;
                        question.User = user;
                        question.Question = questionRepository.GetByID(question.QuestionID);
                        if (question.Question == null)
                        {
                            throw new BadRequestException("Question not found");
                        }
                        foreach (var answer in question.UserQuestionAnswers)
                        {
                            answer.Answer = answerRepository.GetByID(answer.AnswerID);
                            if (answer == null)
                            {
                                throw new BadRequestException("answer not found");
                            }
                        }
                        var saveQuestion = userQuestionRepository.Create(question);
                        if (saveQuestion.Id == 0)
                        {
                            throw new Exception("cannot save question db");
                        }

                    }
                    else
                    {
                        question.UserID = user!.Id;
                        question.User = user;
                        question.Question = questionRepository.GetByID(question.QuestionID);
                        if (question.Question == null)
                        {
                            throw new BadRequestException("Question not found");
                        }
                        foreach (var answer in question.UserQuestionAnswers)
                        {
                            answer.Answer = answerRepository.GetByID(answer.AnswerID);
                            if (answer == null)
                            {
                                throw new BadRequestException("answer not found");
                            }
                        }
                        var questiondb = userQuestionRepository.Update(question, question.Id);

                    }


                }
               
                this.db.Database.CommitTransaction();
                var summaryDto = Summary(user!.UserName);
                return summaryDto;
              
            }
            catch(BadRequestException ex)
            {
                throw new BadRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                this.db.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public SummaryDto Summary(string username)
        {
            var summaries = userRepository.SummaryQuestion(username);
            if (summaries.Count == 0)
            {
                summaries = new List<SummaryDto>();
            }
            return summaries[0];
        }
    }
}
