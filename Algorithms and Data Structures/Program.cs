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
            private struct Cell
            {
                public int Value;
                public long TimesCounter;
            }
            private readonly Dictionary<int, Cell> data = new Dictionary<int, Cell>();
            private long currentCounter = 0;     
            private int globalValue = 0;     
            private long globalCounter = -1;  

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
            if(n==null)
                return 0;
            List<int> temp1 = new List<int>();
            ListNode temp2 = n;
            while (temp2 != null)
            {
                temp1.Add(temp2.val);
                temp2 = temp2.next;
            }
            int length = temp1.Count;
            int[] MaxSet = new int[length];
            int maxSubsequenceLen = 0;
            for (int i = 0; i < length; i++)
            {
                MaxSet[i] = 1;
                for(int j = 0; j < i; j++)
                {
                    if (temp1[j] <= temp1[i])
                    {
                        MaxSet[i] = Math.Max(MaxSet[i], MaxSet[j]+1);
                    }
                }
                maxSubsequenceLen=Math.Max(maxSubsequenceLen, MaxSet[i]);
            }
            return length - maxSubsequenceLen;
        }
        //Question 4:
        public int CountSubarraysWithSumX(int[] nums, int x)
        {
            int count = 0;
            int currentSum = 0;
            Dictionary<int, int> prefixSumCounts = new Dictionary<int, int>();

            prefixSumCounts[0] = 1;

            foreach (int num in nums)
            {
                currentSum += num;
                
                if (prefixSumCounts.ContainsKey(currentSum - x))
                {
                    count += prefixSumCounts[currentSum - x];
                }
                
                if (prefixSumCounts.ContainsKey(currentSum))
                    prefixSumCounts[currentSum]++;
                else
                    prefixSumCounts[currentSum] = 1;
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

      
