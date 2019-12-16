using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.SearchEngine.Bing
{
    interface IBing
    {
        Task<string> GetApiResource(string searchValue);
    }
}
