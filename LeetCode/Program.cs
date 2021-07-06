using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            //t.Run();
            Console.WriteLine("Hello World!");
            LeetCode1.Run();
            int target = 6;
            //var nums = new int[] { -4, -2, 1, -5, -4, -4, 4, -2, 0, 4, 0, -2, 3, 1, -5, 0};
            //var result = TwoSum(nums, target);
            ////Console.WriteLine($"[{result[0]},{result[1]}]");
            //var strs = "2";
            //int number = 4;
            ////var result = LetterCombinations(strs);
            //var result2 = GetNumber2(number);


            //nums.Reverse();

            //ArrayList alist = new ArrayList();
            //alist.Add(1);
            

            //Console.WriteLine(result);

            Console.ReadLine();
        }

        public static int GetNumber(int m)
        {
            int result = 0;
            for (int i = 1; i <= m; i++)
            {
                if ((i % 2) == 1)
                {
                    result += i;
                }
                else
                {
                    result -= i;
                }
            }
            return result;
        }
        public static int GetNumber2(int m)
        {
            int result = 0;
            result = -1 * (m / 2);
            if ((m % 2) == 1)
            {
                result += m;
            }
            return result;
        }
        public static int GetNumber3(int m)
        {
            int result = 0;
            result = -1 * (m / 2);
            if ((m % 2) == 1)
            {
                result += m;
            }
            return result;
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
        public static bool IsPalindrome(string x)
        {
            if (string.IsNullOrEmpty(x))
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

        public static string IntToRoman(int num)
        {
           // int length = 0;
            //length = num / r.Key;
            //num = num % r.Key;
            //while (length > 0)
            //{
            //    result += r.Value;
            //    length--;
            //}
            var result = string.Empty;
            Dictionary<int, string> data = new Dictionary<int, string>();
            data.Add(1000,"M" );
            data.Add(900, "CM");
            data.Add(500, "D");
            data.Add(400, "CD");
            data.Add(100, "C");
            data.Add(90, "XC");
            data.Add(50, "L");
            data.Add(40, "XL");
            data.Add(10, "X");
            data.Add(9,"IX");
            data.Add(5, "V");
            data.Add(4, "IV");
            data.Add(1, "I");
            foreach (var r in data)
            {
                while (num >= r.Key)
                {
                    num -= r.Key;
                    result += r.Value;
                }
            }
            return result;
        }


        /// <summary>
        /// 编写一个函数来查找字符串数组中的最长公共前缀。
        /// 如果不存在公共前缀，返回空字符串 ""。
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length > 0)
            {
                if(strs.Length==1)
                {
                    return strs[0];
                }
                var stop = false;
                var prev = strs[0];
                var arr = new List<char>();
                for (int i = 0; i < prev.Length; i++)
                {
                    for (int j = 1; j < strs.Length; j++)
                    {
                        if (i < strs[j].Length && prev[i] == strs[j][i])
                        {
                            
                        }
                        else
                        {
                            stop = true;
                            break;                         
                        }
                    }
                    if(stop)
                    {
                        break;
                    }
                    else
                    {
                        arr.Add(prev[i]);
                    }
                }
                return string.Join("", arr);
            }
            else
            {
                return "";
            }
        }


        public static bool IsValid(string s)
        {

            Dictionary<char, int> charArr = new Dictionary<char, int>();
            charArr.Add('(', 1);
            charArr.Add('[', 2);
            charArr.Add('{', 3);
            charArr.Add(')', -1);
            charArr.Add(']', -2);
            charArr.Add('}', -3);
            if (s.Length % 2 == 1)
            {
               return false;
            }
            var arr = new List<char>();
            foreach(char r in s)
            {
                if (charArr[r] > 0)
                {
                    arr.Add(r);
                }
                else
                {
                    if (arr.Any() && (charArr[r] + charArr[arr.LastOrDefault()] == 0))
                    {
                        arr.RemoveAt(arr.Count - 1);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return !arr.Any();


            #region
            //Dictionary<char, int> pArr = new Dictionary<char, int>();
            //pArr.Add( '(',1);
            //pArr.Add('[',2);
            //pArr.Add('{', 3);

            //Dictionary<char, int> nArr = new Dictionary<char, int>();
            //nArr.Add(')', -1);
            //nArr.Add(']', -2);
            //nArr.Add('}', -3);

            //var result = true;
            //var arr =new List<char>();
            //if (s.Length == 1)
            //{
            //    result = false;
            //}
            //else
            //{
            //    int i = 0;
            //    while (i < s.Length)
            //    {
            //        if (arr.Any())
            //        {
            //            var last = arr.LastOrDefault();
            //            if (pArr.ContainsKey(s[i]))
            //            {
            //                arr.Add(s[i]);
            //            }
            //            else if (nArr.ContainsKey(s[i]))
            //            {
            //                if (pArr[last] + nArr[s[i]] == 0)
            //                {
            //                    arr.RemoveAt(arr.Count - 1);
            //                }
            //                else
            //                {
            //                    result = false;
            //                    break;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (pArr.ContainsKey(s[i]))
            //            {
            //                arr.Add(s[i]);
            //            }
            //            else
            //            {
            //                result = false;
            //                break;
            //            }
            //        }
            //        i++;
            //    }
            //}
            //if(arr.Any())
            //{
            //    result = false;
            //}
            //return result;
            #endregion

        }


        /// <summary>
        /// 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {


            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            int length = 0;
            int j = 0;
            Dictionary<char, int> arr = new Dictionary<char, int>();

            
            for (int i = 0; i < s.Length; i++)
            {
                if (arr.ContainsKey(s[i]))
                {
                    length = length < j ? j : length;
                    j = 0; ;
                    i = arr[s[i]];
                    arr.Clear();
                }
                else
                {
                    j++;
                    arr.Add(s[i], i);
                }
            }
            length = length < arr.Count ? arr.Count : length;
            return length;
        }



        public static string LongestPalindrome(string s)
        {
            int maxLength = 0;
            if (s.Length == 1)
            {
                return s;
            }
            Dictionary<string, int> arr = new Dictionary<string, int>();

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = s.Length - i; j > maxLength; j--)
                {
                    var str = s.Substring(i, j);
                    if (IsPalindrome(str))
                    {
                        maxLength = str.Length > maxLength ? str.Length : maxLength;
                        arr[str] = str.Length;
                    }
                }
            }
            return arr.OrderBy(x => x.Value).LastOrDefault().Key;
            // return "" ;
        }


        /// <summary>
        /// 将一个给定字符串 s 根据给定的行数 numRows ，以从上往下、从左到右进行 Z 字形排列。
        /// 之后，你的输出需要从左往右逐行读取，产生出一个新的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string Convert(string s, int numRows)
        {
            if (numRows >= s.Length || numRows == 1)
            {
                return s;
            }
            var list = new List<Data>();
            int j = 0;
            for (var i = 0; i < s.Length; i++)
            {

                var data = new Data();
                data.C = s[i];
                data.Index = i;
                data.Level = Math.Abs(j);
                if (j < numRows - 1)
                {
                    j++;
                }
                else
                {
                    j--;
                    j = 0 - j;
                }
                list.Add(data);
            }
            list = list.OrderBy(x => x.Level).ThenBy(x => x.Index).ToList();
            return string.Join("", list.Select(x => x.C));
        }

        public class Data
        {
            public char C { get; set; }
            public int Index { get; set; }

            public int Level { get; set; }
        }


        public static int MaxArea(int[] height)
        {

            int max = 0;

            //for (int i = 0; i < height.Length; i++)
            //{
            //    for (int j = i + 1; j < height.Length; j++)
            //    {
            //        var number = height[i] > height[j] ? height[j] : height[i];
            //        var total = number * (j - i);
            //        max = max < total ? total : max;
            //    }
            //}
            int i = 0;
            int j = height.Length - 1;
            while (i < j)
            {
                int left = height[i];
                int right = height[j];
                int temp = (j - i) * (left < right ? left : right);
                max = max < temp ? temp : max;
                if (left < right)
                {
                    ++i;
                }
                else
                {
                    --j;
                }
            }
            return max;

        }


        public static IList<IList<int>> ThreeSum(int[] nums)
        {


            nums = nums.OrderBy(x => x).ToArray();
            int length = nums.Length;
            IList<IList<int>> result = new List<IList<int>>();

            for(int first = 0; first < length; first++)
            {
                if (first > 0 && nums[first] == nums[first - 1])
                {
                    continue;
                }
                int third = length - 1;
                int target = -nums[first];

                for(int second = first + 1; second < length; second++)
                {
                    if (second > first + 1 && nums[second] == nums[second - 1])
                    {
                        continue;
                    }
                    while (second < third && nums[second] + nums[third] > target)
                    {
                        --third;
                    }
                    if (second == third)
                    {
                        break;
                    }
                    if (nums[second] + nums[third] == target)
                    {
                        IList<int> data = new List<int>();
                        data.Add(nums[first]);
                        data.Add(nums[second]);
                        data.Add(nums[third]);
                        result.Add(data);

                    }
                }
            }


            //Dictionary<string, int> list = new Dictionary<string, int>();
            //IList<IList<int>> result = new List<IList<int>>();

            //var plist = nums.Where(x => x >= 0).ToArray<int>();
            //var nlist= nums.Where(x => x <0).ToArray<int>();
            //if (plist.Count(x => x == 0) >= 3)
            //{
            //    IList<int> data = new List<int>();
            //    data.Add(0);
            //    data.Add(0);
            //    data.Add(0);
            //    var key = "000";
            //    if (!list.ContainsKey(key))
            //    {
            //        list[key] = 0;
            //        result.Add(data);
            //    }
            //}


            //for (int i = 0; i < nlist.Length; i++)
            //{
            //    for (int k = 0; k < plist.Length; k++)
            //    {
            //        for (int j = k + 1; j < plist.Length; j++)
            //        {
            //            if (nlist[i] + plist[k] + plist[j] == 0)
            //            {
            //                IList<int> data = new List<int>();
            //                data.Add(nlist[i]);
            //                data.Add(plist[k]);
            //                data.Add(plist[j]);
            //                var key = string.Join("", data.OrderBy(x => x).ToList());
            //                if (!list.ContainsKey(key))
            //                {
            //                    list[key] = 0;
            //                    result.Add(data);
            //                }
            //                break;
            //            }
            //        }

            //    }
            //}
            //for (int i = 0; i < nlist.Length; i++)
            //{
            //    for (int k = i + 1; k < nlist.Length; k++)
            //    {
            //        for (int j = 0; j < plist.Length; j++)
            //        {
            //            if (nlist[i] + nlist[k] + plist[j] == 0)
            //            {
            //                IList<int> data = new List<int>();
            //                data.Add(nlist[i]);
            //                data.Add(nlist[k]);
            //                data.Add(plist[j]);
            //                var key = string.Join("", data.OrderBy(x => x).ToList());
            //                if (!list.ContainsKey(key))
            //                {
            //                    list[key] = 0;
            //                    result.Add(data);
            //                }
            //                break;
            //            }
            //        }

            //    }
            //}
            return result;

        }


        /// <summary>
        /// 给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。答案可以按 任意顺序 返回
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, string> data = new Dictionary<char, string>();
            data['2'] = "adc";
            data['3'] = "def";
            data['4'] = "ghi";
            data['5'] = "jkl";
            data['6'] = "mno";
            data['7'] = "pqrs";
            data['8'] = "tuv";
            data['9'] = "wxyz"; 

            IList<string> result = new List<string>();
            backtrack(result, data, digits, 0, new StringBuilder());
            return result;            
        }

        public static void backtrack(IList<string> combinations, Dictionary<char, string> phoneMap , string digits, int index, StringBuilder combination)
        {
            if (index==digits.Length)
            {
                combinations.Add(combination.ToString());
            }
            else
            {
                char digit = digits[index];
                string letters = phoneMap[digit];
                int lettersCount = letters.Length;
                for (int i = 0; i < lettersCount; i++)
                {

                    combination.Append(letters[i]);
                    backtrack(combinations, phoneMap, digits, index + 1, combination);
                    combination.Remove(index, 1);
                }
            }
        }

        /// <summary>
        /// 给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c + d 的值与 target 相等？找出所有满足条件且不重复的四元组。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            return result;
        }
    }

}
