using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class UserQuestion : BaseDomain<int>
    {
        public virtual User User { get; set; }
        public virtual Question Question { get; set; }

        public virtual IList<UserQuestionAnswer> UserQuestionAnswers { get; set; }

        public virtual int UserID { get; set; }

        public virtual int QuestionID { get; set; }
    }
}
