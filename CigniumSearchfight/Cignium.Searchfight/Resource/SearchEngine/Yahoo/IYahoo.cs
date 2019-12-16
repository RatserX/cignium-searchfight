using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Website.SearchEngine.Yahoo
{
    interface IYahoo
    {
        long GetResultNumber(string input, string pattern);
    }
}
