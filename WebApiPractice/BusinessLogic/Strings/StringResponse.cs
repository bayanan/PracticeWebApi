using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPractice.BusinessLogic.Strings
{
    public class StringResponse
    {
        public string Status { get; set; }

        public string ProcessedString { get; set; }

        public Dictionary<char, int> CountLetter { get; set; }

        public string VowelString { get; set; }

        public string SortedString { get; set; }

        public string WithoutOneLetter { get; set; }
    }
}
