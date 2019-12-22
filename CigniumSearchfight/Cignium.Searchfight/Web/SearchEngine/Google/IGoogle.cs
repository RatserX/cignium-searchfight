using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Web.SearchEngine.Google
{
    interface IGoogle
    {
        Task LoadResponseBySearchValue(string searchValue);
        Task LoadApiResponseBySearchValue(string searchValue);
        Task LoadHttpResponseBySearchValue(string searchValue);
        void LoadResultNumber();
        void LoadResultTime();
    }
}
