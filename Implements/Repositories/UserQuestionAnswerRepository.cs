using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Implements.Repositories
{
    public class UserQuestionAnswerRepository : IUserQuestionAnswerRepository
    {
        private ApplicationDbContext db;
        public UserQuestionAnswerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public UserQuestionAnswer Create(UserQuestionAnswer entity)
        {
             this.db.UserQuestionAnswers.Add(entity);
             return entity;

        }

        public void Delete(int id)
        {
              var userQuestionAnswer = this.db.UserQuestionAnswers.Where(t => t.Id == id).First<UserQuestionAnswer>();
             this.db.UserQuestionAnswers.Remove(userQuestionAnswer);

        }

        public void DeleteUserQuestionAnswerByUserQuestion(int userQuestionID)
        {
             var userQuestionAnswers = this.db.UserQuestionAnswers.Where(t => t.UserQuestionID == userQuestionID).ToArray<UserQuestionAnswer>();
             this.db.UserQuestionAnswers.RemoveRange(userQuestionAnswers);
        }

        public IList<UserQuestionAnswer> GetAll()
        {
             return this.db.UserQuestionAnswers
                 .ToList<UserQuestionAnswer>();
        }

        public UserQuestionAnswer GetByID(int id)
        {
              return this.db.UserQuestionAnswers
                   .Include("UserQuestion")
                   .Include("Answer")
                   .Where(t => t.Id == id)
                   .First<UserQuestionAnswer>();
        }

        public UserQuestionAnswer Update(UserQuestionAnswer entity, int id)
        {
            var userQuestionAnswer = this.db.UserQuestionAnswers.Where(t => t.Id == id).First<UserQuestionAnswer>();
             userQuestionAnswer.AnswerID = entity.AnswerID;
             userQuestionAnswer.UserQuestionID = entity.UserQuestionID;
              this.db.UserQuestionAnswers.Add(userQuestionAnswer);
             return userQuestionAnswer;

        }
    }
}
