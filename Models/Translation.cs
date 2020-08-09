using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLEditor.Models
{
    public class Translation
    {
        public String Lng { get; set; }
        public String Key { get; set; }

        public String Value { get; set; }

        public User User { get; set; }

    }
}
