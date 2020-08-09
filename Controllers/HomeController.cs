using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XMLEditor.Domain;
using XMLEditor.Filters;
using XMLEditor.Models;
using XMLEditor.Repository;

namespace XMLEditor.Controllers
{

    [AuthFilter]
    public class HomeController : Controller
    {

        private readonly ILanguages _language;
        private readonly IUserRepository _user;

        public HomeController(ILanguages languages, IUserRepository user)
        {
            _language = languages;
            _user = user;
        }

        public IActionResult Index()
        {

            var n2 = _language.GetAllTranslationsForAllLanguages();
            var n1 = _language.GetKeysAllLanguages();
            return View(new Translations() { Keys = n1, Languages = n2 });
        }


        [Route("/Getxml/{language}")]
        public FileResult GetXml(String language)
        {
            var n2 = _language.GetAllTranslationsForAllLanguages().Where(i => i.Lng == language).ToList();
            var n = new XMLCreator();
            n.CreateXML(n2);
            byte[] fileBytes = System.IO.File.ReadAllBytes("appdata/tmp/lng-" + language + ".xml");
            string fileName = "lng-" + language + ".xml";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Xml, fileName);

        }

        [Route("/User/{login}/{password}")]
        public IActionResult GetUser(String login, String password)
        {

            var user = _user.GetUserByLoginName(login);
            if (user.VerifyPassword(password))
                return Ok();
            else
                return Error();
        }

        [Route("/Genxml/{language}")]
        public IActionResult PopulateData(String language)
        {

            _language.InsertLanguages(new XmlParser().GetTranslationFromXML(language));
            return RedirectToAction("Index");
        }

        public IActionResult ClearData()
        {
            _language.ClearAllLanguages();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateValue(Translation tl)
        {
            tl.User = HttpContext.Session.GetObjectFromJson<User>("user");
            _language.InsertLanguage(tl);
            return Ok();
        }

        public IActionResult InsertKeys()
        {
            _language.InsertKeys(new XmlParser().GetTranslationKeysFromXML());
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
