using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Core.Model.SearchEngine
{
    public class Result
    {
        public long Number { get; set; } = 0L;
        public string Text { get; set; }
        public TimeSpan Time { get; set; }
    }
}
