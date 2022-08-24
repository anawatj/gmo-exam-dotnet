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
    public class QuestionRepository : IQuestionRepository
    {
        private ApplicationDbContext db;
        public QuestionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Question Create(Question entity)
        {
            this.db.Questions.Add(entity);
            return entity;
           
        }

        public void Delete(int id)
        {
             var question = this.db.Questions.Where(t => t.Id == id).First<Question>();
             this.db.Questions.Remove(question);
        }

        public IList<Question> GetAll()
        {
              return this.db.Questions
                .Include(t=>t.Answers)
                .ToList<Question>();
        }

        public Question GetByID(int id)
        {
            return this.db.Questions
                .Include("Answers")
                .Where(t => t.Id == id).First<Question>();
        }

        public Question Update(Question entity, int id)
        {
             var question = this.db.Questions.Where(t => t.Id == id).First<Question>();
              question.QuestionDesc = entity.QuestionDesc;
              this.db.Questions.Update(question);
              return question;
            throw new NotImplementedException();
        }
    }
}
