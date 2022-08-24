using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public abstract class BaseDomain<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
