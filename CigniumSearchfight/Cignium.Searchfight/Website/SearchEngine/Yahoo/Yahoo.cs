using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model;
using Cignium.Searchfight.Website.SearchEngine.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Website.SearchEngine.Yahoo
{
    public class Yahoo : BaseSearchEngine, IYahoo
    {
        public Yahoo()
        {
            website = new Core.Model.Website()
            {
                Title = ConstantHelpers.Website.Yahoo.TITLE,
                Url = new Url()
                {
                    Host = ConstantHelpers.Website.Yahoo.Url.SearchEngine.HOST,
                    PathQuery = ConstantHelpers.Website.Yahoo.Url.SearchEngine.PATH_QUERY
                }
            };
        }

        public long GetResultNumber(string input, string pattern = ConstantHelpers.Website.Yahoo.Resource.ResultNumber.REGEX_PATTERN)
        {
            var regexGroup = input.RegexGroup(pattern);

            if (regexGroup == null)
            {
                throw new Exception(ErrorHelper.GetRegexGroupEmptyError());
            }

            var valueSplit = regexGroup.Value.Split(ConstantHelpers.Website.Yahoo.Resource.ResultNumber.SPLIT_SEPARATOR);

            for (var i = 0; i < valueSplit.Length; i++)
            {
                if (valueSplit[i].TryToLong(out long result))
                {
                    return result;
                }
            }

            return 0;
        }
    }
}
