using AutoMapper;
using Core.Domains;
using Core.Dtos;

namespace API
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<RegisterDto, User>()
                .ForMember(t => t.UserName, t => t.MapFrom(t => t.UserName))
                .ForMember(t => t.UserGroupID, t => t.MapFrom(t => t.UserGroupID));

                config.CreateMap<User, RegisterDto>()
                .ForMember(t => t.UserName, t => t.MapFrom(t => t.UserName))
                .ForMember(t => t.UserGroupID, t => t.MapFrom(t => t.UserGroupID));

                config.CreateMap<UserGroup, UserGroupDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.UserGroupName, t => t.MapFrom(t => t.UserGroupName));

                config.CreateMap<Question, QuestionDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.QuestionDesc, t => t.MapFrom(t => t.QuestionDesc));

                config.CreateMap<Answer, AnswerDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.AnswerDesc, t => t.MapFrom(t => t.AnswerDesc));

                config.CreateMap<UserQuestion, UserQuestionDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.QuestionID, t => t.MapFrom(t => t.QuestionID))
                .ForMember(t => t.UserID, t => t.MapFrom(t => t.UserID));

                config.CreateMap<UserQuestionAnswer, UserQuestionAnswerDto>()
                .ForMember(t => t.AnswerID, t => t.MapFrom(t => t.AnswerID));


                config.CreateMap<UserQuestionDto, UserQuestion>()
               .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
               .ForMember(t => t.QuestionID, t => t.MapFrom(t => t.QuestionID))
               .ForMember(t => t.UserID, t => t.MapFrom(t => t.UserID));

                config.CreateMap<UserQuestionAnswerDto, UserQuestionAnswer>()
                .ForMember(t => t.AnswerID, t => t.MapFrom(t => t.AnswerID));
            });
            return mappingConfig;

        }
    }
}
