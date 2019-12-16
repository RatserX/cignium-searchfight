using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Website.Base
{
    interface IBaseResource
    {
        string GetRequestTitle();
        string GetRequestUrl();
    }
}
