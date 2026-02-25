using System;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        //Question 1:
        static int[] MaxSubarray(int[] a)
        {
            int[] res;
            int sum = 0;
            int SumMax = int.MinValue;
            int StartMax = 0;
            int EndMax = 0;
            int tempStart = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (sum+a[i] < a[i])
                {
                    sum=a[i];
                    tempStart = i;
                }
                else
                {
                    sum += a[i];
                }
                if (sum > SumMax)
                {
                    SumMax = sum;
                    StartMax = tempStart;
                    EndMax = i;
                }
            }
            res = new int[EndMax - StartMax + 1];
            Array.Copy(a, StartMax,res,0, res.Length);
            return res;
        }
        //Question 2:
        public class FastAllMap
        {
            class Cell
            {
                public int Value;
                public long TimesCounter;
            }
            Dictionary<int, Cell> data = new Dictionary<int, Cell>();
            long currentCounter = 0;     
            int globalValue = 0;     
            long globalCounter = -1;  

            public void Set(int key, int val)
            {
                currentCounter++; 
                data[key] = new Cell
                {
                    Value = val,
                    TimesCounter = currentCounter
                };
            }

            public int Get(int key)
            {
                if (!data.ContainsKey(key))
                {
                    return globalCounter != -1 ? globalValue : 0;
                }
                Cell cell = data[key];
                if (globalCounter > cell.TimesCounter)
                {
                    return globalValue;
                }
                return cell.Value;
            }

            public void SetAll(int val)
            {
                currentCounter++;
                globalValue = val;
                globalCounter = currentCounter; 
            }
        }

        //Question 3:
        static int NotDownList(ListNode n)
        {
            if (n == null) return 0;
            List<int> nums = new List<int>();
            ListNode temp = n;
            while (temp != null)
            {
                nums.Add(temp.val);
                temp = temp.next;
            }
            List<int> tails = new List<int>();
            foreach (int x in nums)
            {
                int left = 0, right = tails.Count;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (tails[mid] <= x)
                        left = mid + 1;
                    else
                        right = mid;
                }
                if (left == tails.Count)
                    tails.Add(x); 
                else
                    tails[left] = x; 
            }
            return nums.Count - tails.Count;
        }
       
        //Question 4:
        public int CountSubarraysWithSumX(int[] nums, int x)
        {
            int count = 0;
            int currentSum = 0;
            Dictionary<int, int> SumCounts = new Dictionary<int, int>();
            SumCounts[0] = 1;
            foreach (int num in nums)
            {
                currentSum += num;
                if (SumCounts.ContainsKey(currentSum - x))
                {
                    count += SumCounts[currentSum - x];
                }
                if (SumCounts.ContainsKey(currentSum))
                    SumCounts[currentSum]++;
                else
                    SumCounts[currentSum] = 1;
            }
            return count;
        }

        //Question 5:
        static int MinEgg(int N,int T,int S)
        {
            int Stickers = N - T;
            int Toys = N - S;
            return Math.Max(Stickers, Toys) + 1;
        }
    }
}

      
