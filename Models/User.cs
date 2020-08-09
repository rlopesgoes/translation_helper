using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace XMLEditor.Models
{
    public class User
    {
        public int UserId { get; set; }

        public String Login { get; set; }

        public String Name { get; set; }

        public String LastName { get; set; }

        public String Password { get; set; }

        public String EnabledLanguages { get; set; }

        public String EditableLanguages { get; set; }

        public List<String> GetEnabledLanguages()
        {
            if (String.IsNullOrEmpty(EnabledLanguages)) return new List<string>();
            return EnabledLanguages.Split('|').ToList();
        }

        public List<String> GetEditableLanguages()
        {
            if (String.IsNullOrEmpty(EditableLanguages)) return new List<string>();
            return EditableLanguages.Split('|').ToList();
        }

        public bool VerifyPassword(String plainTextPassword)
        {
            var md5Hash = MD5Functions.GetMd5Hash(plainTextPassword);
            return md5Hash == Password;

        }
    }
}
