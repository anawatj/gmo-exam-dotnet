using Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos;
namespace Core.Repositories
{
    public interface IUserRepository : IRepository<User,int>
    {
        IList<SummaryDto> SummaryQuestion(string username);
        User?  GetByUserName(string userName);
       
    }
}
