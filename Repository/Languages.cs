using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMLEditor.Models;
using Dapper;

namespace XMLEditor.Repository
{
    public class Languages : ILanguages
    {
        public void InsertLanguages(List<Translation> translations)
        {
            var command = "INSERT INTO translations.translations() VALUES(@Key,@Lng,@Value)";
            using (var myconn = MySqlConnString.GetConnection())
            {
                foreach (var t in translations)
                {
                    try
                    {
                        var deleteComm = "DELETE FROM translations.translations WHERE (translations.Key=@Key AND Lng=@Lng);";
                        myconn.Execute(deleteComm, t);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        t.User = new User() { Name = "Sys", Login = "sys" };
                        myconn.Execute(command, t);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }




        public void InsertLanguage(Translation translation)
        {
            
            using (var myconn = MySqlConnString.GetConnection())
            {
                var logComm = "INSERT INTO translations.changelog(UserId,ChangedKey,ChangedLanguage,NewValue,TimeStamp) VALUES (@UserId,@ChangedKey,@ChangedLanguage,@NewValue,@TimeStamp)";
                var log = new ChangeLog() { UserId = translation.User.UserId, ChangedKey = translation.Key, ChangedLanguage = translation.Lng, NewValue = translation.Value, TimeStamp = DateTime.Now };
                myconn.Execute(logComm, log);
                var deleteComm = "DELETE FROM translations.translations WHERE (translations.Key=@Key AND Lng=@Lng);";
                myconn.Execute(deleteComm, translation);
                var command = "INSERT INTO translations.translations() VALUES(@Key,@Lng,@Value)";
                try
                {
                    myconn.Execute(command, translation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public void InsertKeys(List<KeyV> translations)
        {
            using (var myconn = MySqlConnString.GetConnection())
            {

                myconn.Execute("DELETE FROM translations.Keys");
                var command = "INSERT INTO translations.Keys() VALUES(@Key)";

                foreach (var t in translations)
                {
                    try
                    {
                        myconn.Execute(command, t);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void ClearAllLanguages()
        {
            using (var myconn = MySqlConnString.GetConnection())
            {
                myconn.Execute("DELETE FROM translations");
            }
        }


        public List<Translation> GetAllTranslationsForAllLanguages()
        {

            using (var myconn = MySqlConnString.GetConnection())
            {
                var command = "SELECT * FROM translations";

                try
                {
                    return myconn.Query<Translation>(command).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }


        }
        public List<KeyV> GetKeysAllLanguages()
        {

            using (var myconn = MySqlConnString.GetConnection())
            {
                var command = "SELECT * FROM translations.Keys";


                try
                {
                    return myconn.Query<KeyV>(command).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }

        }
    }
}
