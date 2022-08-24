using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private ApplicationDbContext db;
        public AnswerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Answer Create(Answer entity)
        {
            
            this.db.Answers.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var answer = this.db.Answers.Where(t => t.Id == id).First<Answer>();
            this.db.Answers.Remove(answer);
           
        }

        public IList<Answer> GetAll()
        {
             return this.db.Answers.ToList<Answer>();
        }

        public Answer GetByID(int id)
        {
            return this.db.Answers.Where(t => t.Id == id).First<Answer>();
        }

        public Answer Update(Answer entity, int id)
        {
            var answer = this.db.Answers.Where(t => t.Id == id).First<Answer>();
            answer.AnswerDesc = entity.AnswerDesc;
            answer.QuestionID = entity.QuestionID;
            this.db.Answers.Update(answer);
            return answer;
        }
    }
}
