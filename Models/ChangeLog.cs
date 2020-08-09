using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLEditor.Models
{
    public class ChangeLog
    {
        public int ChangeId { get; set; }
        public int UserId { get; set; }
        public String ChangedKey { get; set; }
        public String ChangedLanguage { get; set; }
        public String OldValue { get; set; }
        public String  NewValue { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
