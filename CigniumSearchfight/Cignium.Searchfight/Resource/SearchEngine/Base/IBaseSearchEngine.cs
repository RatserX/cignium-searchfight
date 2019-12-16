using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.SearchEngine.Base
{
    interface IBaseSearchEngine
    {
        Task<string> GetDefaultResource(string searchValue);
    }
}
