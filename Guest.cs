using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Guest
    {
        // private fields for Guest properties
        private string name;
        private string national_ID;

        // Auto-property for name 
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Auto-property for national ID
        public string National_ID
        {
            get { return national_ID; }
            set 
            {
                // Validate national ID format 
                if (value.Length == 3)
                {
                    national_ID = value;
                }
                else
                {
                    throw new ArgumentException("National ID must be 14 characters long.");
                }
            }

        }
    }
}
