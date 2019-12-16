using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Website.SearchEngine.Bing
{
    interface IBing
    {
        long GetResultNumber(string input, string pattern);
    }
}
