using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
   public interface ILocalization
   {
     

      event Action<string> LanguageChanged;
      string Get(string key);
      bool Initialized { get; }
      string CurrentLanguageCode { get; }
      List<string> LanguageCodes { get; }
      void SetLanguage(string languageCode);
      bool TryGetLanguageCodes(out IEnumerable<string> codes);
      Task Initialize();
   }
}