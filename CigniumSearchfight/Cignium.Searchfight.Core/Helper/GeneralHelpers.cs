using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Core.Helper
{
    public class GeneralHelpers
    {
        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
