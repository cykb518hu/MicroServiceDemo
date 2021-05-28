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
            var str = "MCMXCIV";
            var result = RomanToInt(str);

            
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


        /// <summary>
        /// 给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。
        /// 回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。例如，121 是回文，而 123 不是。
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            var str = x.ToString();

            int l = 0;
            int r = str.Length - 1;
            while (l < r)
            {
                if (str[l] != str[r])
                {
                    return false;
                }
                r--;
                l++;
            }
            return true;
            //char[] arr = str.ToCharArray();
            //var newArr = new List<char>();
            //for(int i = arr.Length - 1; i >= 0; i--)
            //{
            //    newArr.Add(arr[i]);
            //}
            //var newStr = string.Join("", newArr);
            //if (str == newStr)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }


        public static int RomanToInt(string s)
        {
            int result = 0;
            Dictionary<char, int> data = new Dictionary<char, int>();
            data.Add('I', 1);
            data.Add('V',5);
            data.Add('X', 10);
            data.Add('L', 50);
            data.Add('C', 100);
            data.Add('D', 500);
            data.Add('M', 1000);
            int i = 1;
            int preNum = data[s[0]];
            while(i<s.Length)
            {
                var num = data[s[i]];
                if (preNum < num)
                {
                    result -= preNum;
                }
                else
                {
                    result += preNum;
                }
                preNum = num;
                i++;
            }
            result += preNum;
            

            return result;

            //data.Add("IV", 4);
            //data.Add("IX", 9);
            //data.Add("XL", 40);
            //data.Add("XC", 90);
            //data.Add("CD", 400);
            //data.Add("CM", 900);

            //int i = 0;

            //while (i < s.Length)
            //{
            //    var key = string.Empty;
            //    if ((i + 2) > s.Length)
            //    {
            //        key = s.Substring(i, 1);
            //        if (data.ContainsKey(key))
            //        {
            //            result += data[key];
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        key = s.Substring(i, 2);
            //        if (data.ContainsKey(key))
            //        {
            //            result += data[key];
            //            i += 2;
            //        }
            //        else
            //        {
            //            key = s.Substring(i, 1);
            //            if (data.ContainsKey(key))
            //            {
            //                result += data[key];
            //                i++;
            //            }
            //        }
            //    }
            //}

            //return result;
        }
    }
}
