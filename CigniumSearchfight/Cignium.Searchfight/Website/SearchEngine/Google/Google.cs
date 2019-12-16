using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model;
using Cignium.Searchfight.Website.SearchEngine.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.SearchEngine.Google
{
    public class Google : BaseSearchEngine, IGoogle
    {
        public Google() : base()
        {
            website = new Core.Model.Website()
            {
                Title = ConstantHelpers.Website.Google.TITLE,
                Url = new Url()
                {
                    Host = ConstantHelpers.Website.Google.Url.SearchEngine.HOST,
                    PathQuery = ConstantHelpers.Website.Google.Url.SearchEngine.PATH_QUERY
                }
            };
        }

        public long GetResultNumber(string input, string pattern = ConstantHelpers.Website.Google.Resource.ResultNumber.REGEX_PATTERN)
        {
            var regexGroup = input.RegexGroup(pattern);
            var index = ConstantHelpers.Website.Google.Resource.ResultNumber.SPLIT_INDEX;
            var separator = ConstantHelpers.Website.Google.Resource.ResultNumber.SPLIT_SEPARATOR;
            var resultNumber = regexGroup.Value.SplitValue(separator, index);

            if (resultNumber != null)
            {
                return resultNumber.ToLong();
            }

            return 0;
        }

        public TimeSpan GetResultTime(string input, string pattern = ConstantHelpers.Website.Google.Resource.ResultTime.REGEX_PATTERN)
        {
            var regexGroup = input.RegexGroup(pattern);
            var index = ConstantHelpers.Website.Google.Resource.ResultTime.SPLIT_INDEX;
            var separator = ConstantHelpers.Website.Google.Resource.ResultTime.SPLIT_SEPARATOR;
            var resultTime = regexGroup.Value.SplitValue(separator, index);

            if (resultTime != null)
            {
                return TimeSpan.FromSeconds(resultTime.ToDouble());
            }

            return TimeSpan.FromSeconds(0);
        }
    }
}
