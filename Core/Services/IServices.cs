using Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos;
namespace Core.Services
{
    public  interface IServices
    {
        RegisterDto Register(RegisterDto dto);

        IList<UserGroupDto> LoadUserGroup();

        IList<QuestionDto> LoadQuestion();

        IList<UserQuestionDto> LoadUserAnswer(string username);

        IList<UserQuestionDto> SaveUserAnswer(IList<UserQuestionDto> questions);

        SummaryDto SubmitUserAnswer(IList<UserQuestionDto> questions);

        SummaryDto Summary(string username);
    }
}
