using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class SummaryDto
    {
        public virtual string UserName { get; set; }
        public virtual int Score { get; set; }

        public virtual int Rank { get; set; }
    }
}
