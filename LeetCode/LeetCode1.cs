using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class LeetCode1
    {


        public static void Run()
        {

            var l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);


            var l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            ListNode[] lists = { l1, l2 };

            //  var result = MergeKLists(lists);

            int[] nums1 = { 1};
            //int[] nums2 = { 3, 4 };
            var str = @"()))))))))))))))))))))))()()))()))))))))()))))))()))()))))(()))))))))))))()))))))(()))))))))()()))))))))))))()))))(())()))))))(()))))()))))))()))()())))())))))))))))()))())(()()())()()())))))()))))())()))()))))))))))))))()())))()))))()))))))()))())()))())))(()))()))))))))())))())))(())()))))()((()))))))((((()())())())(())))))())())))))))())))))()(()))))()))))())))))()())())()))()))))))))()))))))))))()))))())))))(((()))))()))((())))())))))))())))()()())())))))())))())())))))(())())))))))())))()()))))))))))))(())())())))((()))))))(())))()())))()))))(())))(())))))))))))))(())))(())()))))(()))())())))))))()())(()(())())))))))))))))))))))))))((()())))())))())))((()())))()))())()))))())()())))))))))))(()))))))))))))))()))))))()))))))))))))))))(()(()))(()))()))))))()))()()))))))))))()))())()))))())))()()()))()))))(())))))))))))))()()))))(())))()))))))()))()())()))())()())())))()()(()())))))()())))))))())))())))(())))())))))))()))))))))()((()(())))))))))(())))())))())))))))))()())))()))))))))(";
            List<int> list = nums1.ToList();

            var result = HIndex(nums1);
            Console.WriteLine(result);
        }


        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode();
            var pre = result;
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                if (l1 != null)
                {
                    carry += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    carry += l2.val;
                    l2 = l2.next;
                }
                pre.next = new ListNode(carry % 10);
                pre = pre.next;
                carry = carry / 10;


            }
            return result.next;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double result = 0;
            List<int> list = new List<int>();

            list.AddRange(nums1.ToList());
            list.AddRange(nums2.ToList());

            var num3 = list.OrderBy(x => x).ToArray();

            if (num3.Length == 0)

            {
                return result;
            }
            if (num3.Length == 1)
            {
                result = num3[0];
            }
            else
            {
                var index = num3.Length / 2;
                var next = num3.Length % 2;
                if (next == 0)
                {
                    result = Math.Round((double)(num3[index - 1] + num3[index]) / 2, 5);
                }
                else
                {
                    result = Math.Round((double)num3[index], 5);
                }
            }
            return result;

        }


        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var result = new ListNode();
            var pre = result;

            while (l1 != null || l2 != null)
            {
                if (l1 != null && l2 != null)
                {
                    if (l1.val < l2.val)
                    {
                        pre.next = new ListNode(l1.val);
                        l1 = l1.next;

                    }
                    else
                    {
                        pre.next = new ListNode(l2.val);
                        l2 = l2.next;
                    }
                }

                else if (l1 != null)
                {
                    pre.next = new ListNode(l1.val);
                    l1 = l1.next;
                }
                else if (l2 != null)
                {
                    pre.next = new ListNode(l2.val);
                    l2 = l2.next;
                }
                pre = pre.next;
            }

            return result.next;
        }

        /// <summary>
        /// 删除链表的倒数第 N 个结点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            Dictionary<int, int> data = new Dictionary<int, int>();
            var result = new ListNode();
            var pre = result;
            int index = 1;
            while (head != null)
            {
                data[index] = head.val;
                head = head.next;
                index++;
            }
            data.Remove(index - n);

            foreach (var r in data)
            {
                pre.next = new ListNode(r.Value);
                pre = pre.next;
            }


            return result.next;
        }

        public void NextPermutation(int[] nums)
        {
            var reverse = true;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] > nums[i])
                {
                    int temp = nums[i + 1];
                    nums[i + 1] = nums[i];
                    nums[i] = temp;
                    reverse = false;
                    break;
                }
            }
            if (reverse)
            {
                nums.Reverse().ToArray();
            }
        }


        public static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode result = new ListNode();
            var pre = result;
            IList<int> data = new List<int>();
            foreach (var r in lists)
            {
                var temp = r;
                while (temp != null)
                {
                    data.Add(temp.val);
                    temp = temp.next;
                }
            }
            if (data.Any())
            {
                data = data.OrderBy(x => x).ToList();
                foreach (var i in data)
                {
                    pre.next = new ListNode(i);
                    pre = pre.next;
                }
            }

            return result.next ?? result;
        }
        public static int[] SearchRange(int[] nums, int target)
        {
            int[] result = { -1, -1 };

            if (nums.Length > 0)
            {
                int i = 0;
                int k = nums.Length - 1;

                while (i <= k && (result[0] < 0 || result[1] < 0))
                {
                    if (nums[i] == target)
                    {
                        result[0] = i;
                    }
                    else
                    {
                        i++;
                    }
                    if (nums[k] == target)
                    {
                        result[1] = k;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return result;
        }


        public static int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            int result = -1;
            int tempLength = -1;
            if (S.Length == 1)
            {
                if (char.IsUpper(S[0]))
                {
                    return 1;
                }
            }
            for (int i = 0; i < S.Length - 1; i++)
            {
                if (char.IsDigit(S[i]))
                {
                    continue;
                }
                else
                {
                    int temp = -1;
                    //flag means if char is UpperCase
                    var flag = false;
                    flag = char.IsUpper(S[i]);
                    for (int j = i + 1; j < S.Length; j++)
                    {

                        if (char.IsDigit(S[j]))
                        {
                            break;
                        }
                        temp = j;
                        if (!flag)
                        {
                            flag = char.IsUpper(S[j]);
                        }

                    }
                    if (flag)
                    {
                        if (temp == -1)
                        {
                            tempLength = 1;
                        }
                        else
                        {
                            tempLength = (temp - i) + 1;
                        }
                    }
                }
                if (tempLength > 0 && tempLength > result)
                {
                    result = tempLength;
                }
            }
            if (result == -1 && char.IsUpper(S[S.Length - 1]))
            {
                result = 1;
            }
            return result;
        }

        public static int solution3(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            int result = -1;
            int length = 0;
            var flag = false;
            for (int i = 0; i < S.Length; i++)
            {
                if (char.IsUpper(S[i]))
                {
                    flag = true;
                }
                if (char.IsDigit(S[i]))
                {
                    if (flag)
                    {
                        result = result < length ? length : result;
                    }
                    length = 0;
                }
                else
                {
                    length++;
                }
            }
            //in case the last character us upper
            if (flag)
            {
                result = result < length ? length : result;
            }
            return result;
        }


        public static int solution2(int[] A)
        {
            int result = 0;
            if (A.Length == 0)
            {
                return 0;
            }
            if (A.Length == 1)
            {
                return 1;
            }
            A = A.OrderBy(X => X).ToArray();
            for (int i = 0; i < A.Length; i++)
            {
                var count = 1;
                int j = i + 1;
                while (j < A.Length && (A[j] - A[i] < 2))
                {
                    count++;
                    if (A[i] == A[j])
                    {
                        i++;
                    }
                    j++;
                }
                if (result < count)
                {
                    result = count;
                }
            }
            return result;
        }

        public static int solution3(int[] A)
        {
            int result = 0;
            if (A.Length == 0)
            {
                return 0;
            }
            if (A.Length == 1)
            {
                return 1;
            }
            List<int> list = A.ToList();
            A = A.OrderBy(X => X).ToArray();
            for (int i = 0; i < A.Length; i++)
            {
                int j = i + 1;
                while (j < A.Length && (A[j] - A[i] < 2))
                {
                    j++;
                }
                if (result < j - i)
                {
                    result = j - i;
                }
            }
            return result;
        }

        public static int isPrime(long n)
        {
            var result = 1;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static int getMin(string s)
        {
            int left = 0;
            int right = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    left++;
                }
                if (s[i] == ')')
                {
                    right++;
                }
            }
            return Math.Abs(left - right);
        }

        public static int stockPairs(List<int> stocksProfit, long target)
        {
            Dictionary<long, long> list = new Dictionary<long, long>();

            foreach (var i in stocksProfit)
            {
                var num = target - i;
                if (list.ContainsKey(i) || list.ContainsKey(num))
                {
                    continue;
                }
                else
                {
                    if (num == i)
                    {
                        if (stocksProfit.Count(x => x == num) > 1)
                        {
                            list[i] = num;
                        }
                    }
                    else
                    {
                        if (stocksProfit.Exists(x => x == (num)))
                        {
                            list[i] = num;
                        }
                    }
                    
                }
            }
            return list.Count;
        }

        public static string ttt(string str)
        {
            str = "qqqqqqq@hackerrank.com";
            Regex r = new Regex(@"([a-z]{1,6})+([0-9]{0,4})+@hackerrank.com$");

            if (r.IsMatch(str))
            {
                return "yes";
            }
            return "no";
        }

        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            int temp = 0;
            if (nums.Length < 1)
            {
                return -1;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }
            else
            {
                temp = nums.Length / 2;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (list.ContainsKey(nums[i]))
                {
                    var value = list[nums[i]] + 1;
                    if(value> temp)
                    {
                        return nums[i];
                    }
                    else
                    {
                        list[nums[i]] = value;
                    }
                }
                else
                {
                    list[nums[i]] = 1;
                }
            }
            return -1;
        }


        public static int HIndex(int[] citations)
        {

            //int n = citations.length;
            //int left = 0, right = n - 1;
            //while (left <= right)
            //{
            //    int mid = left + (right - left) / 2;
            //    if (citations[mid] >= n - mid)
            //    {
            //        right = mid - 1;
            //    }
            //    else
            //    {
            //        left = mid + 1;
            //    }
            //}
            //return n - left;

            int result = 0;
            for (int i = citations.Length - 1; i >= 0; i--)
            {
                result = Math.Min(citations[i], citations.Length);
                if (citations[i] >= (citations.Length - i))
                {
                    result = citations[i];
                    break;
                }
            }
            return result;
        }
    }
    
}