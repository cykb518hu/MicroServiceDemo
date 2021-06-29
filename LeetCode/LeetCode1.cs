using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            int[] nums1 = { 5,7,7,8,10};
            //int[] nums2 = { 3, 4 };
            var result = SearchRange(nums1,8);
            //Console.WriteLine(result);
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
           
            if(num3.Length==0)

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
            while(head!=null)
            {
                data[index] = head.val;
                head = head.next;
                index++;
            }
            data.Remove(index-n);

            foreach(var r in data)
            {
                pre.next = new ListNode(r.Value);
                pre = pre.next;
            }


            return result.next;
        }

        public void NextPermutation(int[] nums)
        {
            var reverse = true;
            for(int i = 0; i < nums.Length-1; i++)
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
            IList<int> data= new List<int>();
            foreach(var r in lists)
            {
                var temp = r;
                while(temp != null)
                {
                    data.Add(temp.val);
                    temp = temp.next;
                }
            }
            if(data.Any())
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
    }
}
