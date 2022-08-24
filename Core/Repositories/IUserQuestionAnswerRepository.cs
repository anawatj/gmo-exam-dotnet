using Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserQuestionAnswerRepository : IRepository<UserQuestionAnswer,int>
    {
        void DeleteUserQuestionAnswerByUserQuestion(int userQuestionID);
    }
}
