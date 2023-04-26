using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using WebApiPractice.BusinessLogic.Strings;
using WebApiPractice.BusinessLogic.Sorts;

namespace WebApiPractice.Tests
{
    public class StringProcessorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        // Проверка обработчика строки
        [Test]
        public void GetProcessedString_abcde_edcbaabcdereturned()
        {
            string testingStr = "abcde";
            string expectedStr = "edcbaabcde";

            string actualStr = StringProcessor.GetProcessedString(testingStr);

            Assert.AreEqual(expectedStr, actualStr);
        }

        [Test]
        public void GetProcessedString_abcd_badcreturned()
        {
            string testingStr = "abcd";
            string expectedStr = "badc";

            string actualStr = StringProcessor.GetProcessedString(testingStr);

            Assert.AreEqual(expectedStr, actualStr);
        }

        // Проверка обработчика неккоректных символов
        [Test]
        public void GetIncorrectSymbols_newYork_Yreturned()
        {
            string testingStr = "newYork";
            string expectedStr = "Y, ";

            StringBuilder actualStr = StringProcessor.GetIncorrectSymbols(testingStr);

            Assert.AreEqual(expectedStr, actualStr.ToString());
        }

        [Test]
        public void GetIncorrectSymbols_NewYork12_NY12returned()
        {
            string testingStr = "NewYork12";
            string expectedStr = "N, Y, 1, 2, ";

            StringBuilder actualStr = StringProcessor.GetIncorrectSymbols(testingStr);

            Assert.AreEqual(expectedStr, actualStr.ToString());
        }

        [Test]
        public void GetIncorrectSymbols_newyork_zeroreturned()
        {
            string testingStr = "newyork";
            int expectedLength = 0;

            StringBuilder actualLength = StringProcessor.GetIncorrectSymbols(testingStr);

            Assert.AreEqual(expectedLength, actualLength.Length);
        }

        // Проверка счетчика символов
        [Test]
        public void GetCountSymbols_qwerty_countreturned()
        {
            string testingStr = "qwerty";
            Dictionary<char, int> expectedDictionary = new Dictionary<char, int>()
            {
                ['q'] = 1,
                ['w'] = 1,
                ['e'] = 1,
                ['r'] = 1,
                ['t'] = 1,
                ['y'] = 1
            };

            Dictionary<char, int> actualDictionary = StringProcessor.GetCountSymbols(testingStr);

            Assert.AreEqual(expectedDictionary, actualDictionary);
        }

        [Test]
        public void GetCountSymbols_banana_countreturned()
        {
            string testingStr = "banana";
            Dictionary<char, int> expectedDictionary = new Dictionary<char, int>()
            {
                ['b'] = 1,
                ['a'] = 3,
                ['n'] = 2
            };

            Dictionary<char, int> actualDictionary = StringProcessor.GetCountSymbols(testingStr);

            Assert.AreEqual(expectedDictionary, actualDictionary);
        }

        // Проверка наличия гласных в начале и конце созданной строки
        [Test]
        public void GetVowelWords_abcdef_abcdereturned()
        {
            string testingString = "abcdef";
            string expectedString = "abcde";

            string actualString = StringProcessor.GetVowelWords(testingString);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void GetVowelWords_abcd_areturned()
        {
            string testingString = "abcd";
            string expectedString = "a";

            string actualString = StringProcessor.GetVowelWords(testingString);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void GetVowelWords_bcdf_notfoundreturned()
        {
            string testingString = "bcdf";
            string expectedString = "Гласные буквы не найдены.";

            string actualString = StringProcessor.GetVowelWords(testingString);

            Assert.AreEqual(expectedString, actualString);
        }

        // Проверка сортировок QuickSort
        [Test]
        public void Quick_qwerty_eqrtwyreturned()
        {
            string testingString = "qwerty";
            string expectedString = "eqrtwy";

            string actualString = QuickSort.Quick(testingString.ToCharArray(), 0, testingString.Length - 1);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void Quick_banana_aaabnnreturned()
        {
            string testingString = "banana";
            string expectedString = "aaabnn";

            string actualString = QuickSort.Quick(testingString.ToCharArray(), 0, testingString.Length - 1);

            Assert.AreEqual(expectedString, actualString);
        }

        // Проверка сортировок TreeSort
        [Test]
        public void TreeSort_qwerty_eqrtwyreturned()
        {
            string testingString = "qwerty";
            string expectedString = "eqrtwy";

            string actualString = TreeNode.TreeSort(testingString);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void TreeSort_banana_aaabnnreturned()
        {
            string testingString = "banana";
            string expectedString = "aaabnn";

            string actualString = TreeNode.TreeSort(testingString);

            Assert.AreEqual(expectedString, actualString);
        }
    }
}