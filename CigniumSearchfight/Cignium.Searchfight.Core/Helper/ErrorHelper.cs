using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Core.Helper
{
    public static class ErrorHelper
    {
        private static string GetTypeHeader(Type type)
        {
            return $"{(type != null ? $"[{type.Name}]" : "")}";
        }

        public static string GetRegexGroupEmptyError(Type type = null)
        {
            return $"{GetTypeHeader(type)} {ConstantHelpers.Error.REGEX_GROUP_EMPTY}";
        }
    }
}
