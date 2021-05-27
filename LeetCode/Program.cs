using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //int target = 6;
            //var nums = new int[] { 3, 3};
            //var result = TwoSum(nums, target);
            //Console.WriteLine($"[{result[0]},{result[1]}]");
            var test = Math.Pow(-2, 31);
            var result = Reverse(-2147483648);

            
            Console.WriteLine(result);

            Console.ReadLine();
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (myDictionary.ContainsKey(target - nums[i]))
                {
                    return new int[] { myDictionary[target - nums[i]], i };
                }
                else
                {
                    myDictionary.Add(nums[i], i);
                }
            }
            return new int[0];
        }

        /// <summary>
        /// 给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。
        /// 如果反转后整数超过 32 位的有符号整数的范围[−231, 231 − 1] ，就返回 0。
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            long a = Math.Abs(x);
            long ans = 0;
            while (a != 0)
            {
                ans = ans * 10 + a % 10;
                a /= 10;
            }
            if (ans > int.MaxValue || ans < int.MinValue) return 0;
            if (x < 0) return (int)ans * -1;
            else return (int)ans;
            //if (x == 0)
            //{
            //    return 0;
            //}
            //bool nagative = false;
            //if (x < 0)
            //{
            //    nagative = true;
            //    try
            //    {
            //        x = Math.Abs(x);
            //    }
            //    catch
            //    {

            //    }
            //}
            //var str = x.ToString();
            //var arr = str.ToCharArray();

            //var newarr = new List<char>();
            //for (var i = arr.Length - 1; i >= 0; i--)
            //{
            //    newarr.Add(arr[i]);
            //}
            //str = string.Join("", newarr);
            //int result = 0;
            //try
            //{
            //    result = Convert.ToInt32(str);
            //}
            //catch(Exception ex)
            //{

            //}
            //if (nagative)
            //{
            //    result = -result;
            //}
            //if (result > (Math.Pow(2, 31) - 1) || result < Math.Pow(-2, 31))
            //{
            //    return 0;
            //}
            //return result;
        }
    }
}
