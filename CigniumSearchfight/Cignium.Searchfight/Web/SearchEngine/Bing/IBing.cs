using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Web.SearchEngine.Bing
{
    interface IBing
    {
        Task LoadResponseBySearchValue(string searchValue);
        Task LoadApiResponseBySearchValue(string searchValue);
        Task LoadHttpResponseBySearchValue(string searchValue);
        void LoadResultNumber();
    }
}
