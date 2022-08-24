using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class User : BaseDomain<int>
    {
        public virtual string UserName { get; set; }

        public virtual int UserGroupID { get; set; }
        public virtual UserGroup UserGroup { get; set; }

        public virtual IList<UserQuestion> UserQuestions {get;set;}
    }
}
