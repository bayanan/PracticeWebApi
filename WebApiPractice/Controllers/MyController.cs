using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPractice.BusinessLogic.Strings;
using WebApiPractice.BusinessLogic.Sorts;

namespace WebApiPractice.Controllers
{
    [ApiController]
    [Route("MyController/[controller]")]
    public class MyController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ObjectResult Get(string text, string sortType)
        {
            StringBuilder incorrectSymbols = StringProcessor.GetIncorrectSymbols(text);

            if (incorrectSymbols.Length > 0)
            {
                incorrectSymbols.Remove(incorrectSymbols.Length - 2, 2);
                return BadRequest($"Ошибка, введены неверные символы: {incorrectSymbols}.");
            }

            string ProcessedString = StringProcessor.GetProcessedString(text);

            return Ok(new StringResponse {
                Status = "success",
                ProcessedString = ProcessedString,
                CountLetter = StringProcessor.GetCountSymbols(ProcessedString),
                VowelString = StringProcessor.GetVowelWords(ProcessedString),
                SortedString = sortType == "q" ? QuickSort.Quick(ProcessedString.ToCharArray(), 0, ProcessedString.Length - 1) : TreeNode.TreeSort(ProcessedString),
                WithoutOneLetter = StringProcessor.DeleteRandomChar(ProcessedString)
            });
        }

        //Console.WriteLine($"Ошибка, введены неверные символы: {incorrectSymbols}.");
    }
}
