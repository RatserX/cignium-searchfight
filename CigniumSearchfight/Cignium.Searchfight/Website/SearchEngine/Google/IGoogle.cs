using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Website.SearchEngine.Google
{
    interface IGoogle
    {
        long GetResultNumber(string input, string pattern);
        TimeSpan GetResultTime(string input, string pattern);
    }
}
