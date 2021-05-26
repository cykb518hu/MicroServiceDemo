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

            int target = 6;
            var nums = new int[] { 3, 3};
            var result = TwoSum(nums, target);
            Console.WriteLine($"[{result[0]},{result[1]}]");

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
    }
}
