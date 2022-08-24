using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserQuestionDto
    {
        public int Id { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }

        public string UserName { get; set; }

        public IList<UserQuestionAnswerDto> Answers { get; set; }
    }
}
