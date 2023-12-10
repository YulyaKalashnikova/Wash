using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wash
{
    public class Helper
    {
        public static Staff s_staff;
        private static WashContext s_context;
        public static WashContext GetContext()
        {
            if (s_context == null)
            {
                s_context = new WashContext();
            }
            return s_context;
        }
    }
}
