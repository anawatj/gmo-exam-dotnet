using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class UserGroup : BaseDomain<int>
    {
            public virtual string UserGroupName { get; set; }
            public virtual IList<User> Users { get; set; }
    }
}
