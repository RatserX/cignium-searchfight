using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.Base
{
    public class BaseResource : IBaseResource
    {
        protected Core.Model.Request request;

        public BaseResource()
        {

        }

        public string GetRequestTitle()
        {
            return request.Title;
        }

        public string GetRequestUrl()
        {
            return $"{request.Url.Host}{request.Url.PathQuery}";
        }
    }
}
