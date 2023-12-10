using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wash
{
    public class Staff
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        [InverseProperty("Staffs")]
        public virtual Role Role { get; set; }
        public List<Service> Services { get; set; }

        public string FullName
        {
            get => $"{LastName} {FirstName.Substring(0, 1)}.{MiddleName.Substring(0, 1)}";
        }
    }
}
