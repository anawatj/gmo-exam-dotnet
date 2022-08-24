using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Answer : BaseDomain<int>
    {
        public virtual string AnswerDesc { get; set; }

        public virtual Question Question { get; set; }

        public virtual int AnswerScore { get; set; }

        public virtual int QuestionID { get; set; }


        public virtual IList<UserQuestionAnswer> UserQuestionAnswers { get; set; }
    }
}
