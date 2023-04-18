using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPractice.BusinessLogic.Sorts
{
    public class QuickSort
    {
        public static string Quick(char[] arr, int start, int end)
        {
            if (start < end)
            {
                var p = Partition(arr, start, end);
                Quick(arr, start, p - 1);
                Quick(arr, p + 1, end);
            }
            return new string(arr);
        }

        public static int Partition(char[] arr, int start, int end)
        {
            char pivot = arr[end];
            char n;
            int i = start - 1;
            for (var j = start; j < end; j++)
            {
                if (arr[j] < pivot)
                {
                    i += 1;
                    n = arr[j];
                    arr[j] = arr[i];
                    arr[i] = n;
                }
            }
            n = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = n;
            return i + 1;
        }
    }
}
