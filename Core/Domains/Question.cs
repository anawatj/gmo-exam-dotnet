using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public  class Question : BaseDomain<int>
    {
        public virtual string QuestionDesc { get; set; }
        public virtual IList<Answer> Answers { get; set; }

        public virtual IList<UserQuestion> UserQuestions { get; set; }
    }
}
