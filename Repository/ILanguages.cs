using System.Collections.Generic;
using XMLEditor.Models;

namespace XMLEditor.Repository
{
    public interface ILanguages
    {
        void ClearAllLanguages();
        List<Translation> GetAllTranslationsForAllLanguages();
        List<KeyV> GetKeysAllLanguages();
        void InsertKeys(List<KeyV> translations);
        void InsertLanguage(Translation translation);
        void InsertLanguages(List<Translation> translations);
    }
}