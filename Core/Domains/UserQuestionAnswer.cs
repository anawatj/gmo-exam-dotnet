using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public  class UserQuestionAnswer : BaseDomain<int>
    {
        public virtual UserQuestion UserQuestion { get; set; }
        public virtual Answer Answer { get; set; }

        public virtual int UserQuestionID { get; set; }

        public virtual int AnswerID { get; set; }
    }
}
