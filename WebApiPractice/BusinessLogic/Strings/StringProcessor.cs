using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiPractice.BusinessLogic.Strings
{
    public class StringProcessor
    {
        public static StringBuilder GetIncorrectSymbols(string inputString)
        {
            string correctSymbols = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder incorrectSymbols = new StringBuilder();

            foreach (char ch in inputString)
            {
                if (!correctSymbols.Contains(ch))
                {
                    incorrectSymbols.AppendFormat("{0}, ", ch);
                }
            }



            return incorrectSymbols;
        }

        public static String GetProcessedString(string inputString)
        {
            string result;

            if (inputString.Length % 2 == 0)
            {
                char[] leftStr = inputString.Substring(0, inputString.Length / 2).ToCharArray();
                char[] rightStr = inputString.Substring(inputString.Length / 2).ToCharArray();
                Array.Reverse(leftStr);
                Array.Reverse(rightStr);
                result = new string(leftStr) + new string(rightStr);
            }
            else
            {
                char[] brokenStr = inputString.ToCharArray();
                Array.Reverse(brokenStr);
                result = new string(brokenStr) + inputString;
            }
            return result;
        }

        public static Dictionary<char, int> GetCountSymbols(string inputString)
        {
            var symbolCount = new Dictionary<char, int>();
            foreach (char ch in inputString)
            {
                if (symbolCount.ContainsKey(ch))
                    symbolCount[ch]++;
                else
                    symbolCount[ch] = 1;
            }
            return symbolCount;
        }

        public static string GetVowelWords(string inputString)
        {
            string correctSymbols = "aeiouy";
            int vowelCount = 0;

            foreach (char ch in inputString)
            {
                if (correctSymbols.Contains(ch))
                    vowelCount++;
            }
            Regex regex;
            if (vowelCount > 1)
                regex = new Regex(@"^[^aeiouy]*([aeiouy]{1}\w*[aeiouy]{1})[^aeiouy]*$");
            else if (vowelCount == 0)
                return "Гласные буквы не найдены.";
            else
                regex = new Regex(@"^[^aeiouy]*([aeiouy]{1})[^aeiouy]*$");

            return regex.Match(inputString).Groups[1].Value;
        }

        public static string DeleteRandomChar(string inputString)
        {
            int value = inputString.Length - 1;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://csrng.net/csrng/csrng.php?min=0&max={value}");
            request.Method = "GET";
            request.ContentType = "application/json";

            WebResponse webResponse = request.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
            using (StreamReader responseReader = new StreamReader(webStream))
            {
                string response = responseReader.ReadToEnd().TrimStart('[').TrimEnd(']');
                JsonDocument parsing = JsonDocument.Parse(response);
                RandomResponseOuter randomResponse = System.Text.Json.JsonSerializer.Deserialize<RandomResponseOuter>(response);
                if (randomResponse.status == "success")
                    return inputString.Remove(randomResponse.random, 1);
            }
            var random = new Random();
            return inputString.Remove(random.Next(0, value), 1);
        }
    }
}
