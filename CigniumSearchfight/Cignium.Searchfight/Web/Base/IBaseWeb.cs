using Cignium.Searchfight.Core.Model.Web;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Web.Base
{
    interface IBaseWeb
    {
        Request GetRequest();
        Response GetResponse();
        Task LoadResponse(HttpWebRequest httpWebRequest);
    }
}
