using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Web.SearchEngine.Yahoo
{
    interface IYahoo
    {
        Task LoadResponseBySearchValue(string searchValue);
        Task LoadHttpResponseBySearchValue(string searchValue);
        void LoadResultNumber();
    }
}
