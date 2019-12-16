using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.SearchEngine.Google
{
    interface IGoogle
    {
        Task<string> GetApiResource(string searchValue);
    }
}
