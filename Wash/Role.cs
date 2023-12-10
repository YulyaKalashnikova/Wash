using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wash
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("Role")]
        public virtual List<Staff> Staffs { get; set; }
    }
}
