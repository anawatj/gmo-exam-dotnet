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
    public class UserQuestionRepository : IUserQuestionRepository
    {
        private ApplicationDbContext db;
        public UserQuestionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public UserQuestion Create(UserQuestion entity)
        {
             this.db.UserQuestions.Add(entity);
            this.db.SaveChanges();
             return entity;
        }

        public void Delete(int id)
        {
            var userQuestion = this.db.UserQuestions.Where(t => t.Id == id).First<UserQuestion>();
            this.db.UserQuestions.Remove(userQuestion);
            this.db.SaveChanges();

        }

        public IList<UserQuestion> GetAll()
        {
             return this.db.UserQuestions
                 .Include(t=>t.UserQuestionAnswers)
                 .ToList<UserQuestion>();
        }

        public UserQuestion GetByID(int id)
        {
            return this.db.UserQuestions
                .Include(t => t.UserQuestionAnswers)
                .Include(t => t.Question)
                .Include(t => t.User)
                .Where(t => t.Id == id)
                .First<UserQuestion>();
        }

        public IList<UserQuestion> GetUserQuestionByUserName(string username)
        {
            return this.db.UserQuestions
                .Include(t=>t.UserQuestionAnswers)
                .Include(t=>t.Question)
                .Include(t=>t.User)
                .Where(t => t.User.UserName.Equals(username))
                .ToList<UserQuestion>();
        }

        public UserQuestion Update(UserQuestion entity, int id)
        {
             this.db.UserQuestions.Update(entity);
             this.db.SaveChanges();
             return entity;
        }
    }
}
