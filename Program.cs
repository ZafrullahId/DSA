using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {

        // Console.WriteLine(MaxArea([1, 2, 1]));

        // foreach (var x in MaxSlidingWindow([1], 1))
        // {
        //     Console.WriteLine(x);
        // }

        Console.WriteLine(GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]));

    }
    public static int MaxDistance(int[] nums1, int[] nums2)
    {
        int currentMax = 0;

        for (int i = 0; i < nums1.Length; i++)
        {
            if (i > nums2.Length - 1)
                break;
            if (nums1[i] > nums2[i])
                continue;

            int lastGreaterOrEqualIndex = Search(nums2, i, nums1[i]);

            if (lastGreaterOrEqualIndex - i > currentMax)
                currentMax = lastGreaterOrEqualIndex - i;

        }

        return currentMax;
    }

    public static int Search(int[] arr, int startIndex, int target)
    {
        int left = startIndex;
        int right = arr.Length - 1;

        int lastValidJ = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] >= target)
            {
                lastValidJ = mid;
                left = mid + 1; // go right to find farther index
            }
            else
            {
                right = mid - 1;
            }
        }

        return lastValidJ;
    }

    public static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        int mid = (right - left) / 2;

        while (left <= right)
        {
            if (target == arr[mid])
            {
                return mid;
            }
            if (target > arr[mid]) // Search right
            {
                left = mid + 1;
                mid = left + ((right - left) / 2);
            }
            else if (target < arr[mid]) // Search left
            {
                right = mid - 1;
                mid = left + ((right - left) / 2);
            }
        }
        return -1;
    }
    public static int MaxDistance(int[] colors)
    {
        int furthest = 0;
        for (int i = 0; i < colors.Length - 1; i++)
        {
            for (int j = i + 1 + furthest; j < colors.Length; j++)
            {
                if (colors[i] != colors[j])
                {
                    if (j - i > furthest)
                    {
                        furthest = j - i;
                    }
                }
            }
        }
        return furthest;
    }
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode temp1 = l1;
        ListNode temp2 = l2;
        int carry = 0;
        ListNode listNode = new();
        ListNode current = listNode;

        while (temp1 != null || temp2 != null)
        {
            int sum = (temp1 == null ? 0 : temp1.val) + (temp2 == null ? 0 : temp2.val) + carry;
            int newNodeVal = sum % 10;
            carry = sum / 10;
            current.next = new ListNode(newNodeVal);
            current = current.next;
            temp1 = temp1 != null ? temp1.next : null;
            temp2 = temp2 != null ? temp2.next : null;
        }

        if (carry != 0)
            current.next = new(carry);

        return listNode.next;
    }
    public static int Search(int[] nums, int target)
    {
        int targetIndex = nums.IndexOf(target);
        return targetIndex;
    }
    public static int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        int longestPrefix = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            string arr1Val = arr1[i].ToString();
            for (int j = 0; j < arr2.Length; j++)
            {
                string arr2Val = arr2[j].ToString();

                if (!arr1Val.StartsWith(arr1Val[0]))
                {
                    continue;
                }
                if (arr1Val.Length >= arr2Val.Length)
                {
                    int prefixCount = GetPrefixCount(arr1Val, arr2Val);

                    if (prefixCount > longestPrefix)
                    {
                        longestPrefix = prefixCount;
                    }
                }
                else if (arr2Val.Length > arr1Val.Length)
                {
                    int prefixCount = GetPrefixCount(arr2Val, arr1Val);

                    if (prefixCount > longestPrefix)
                    {
                        longestPrefix = prefixCount;
                    }
                }
            }
        }
        return longestPrefix;
    }
    public static int GetPrefixCount(string arr1Val, string arr2Val)
    {
        int currentLongestPrefix = 0;
        int arr2ValCount = arr2Val.Length;
        for (int m = 0; m < arr2ValCount; m++)
        {
            bool equalPrefix = arr1Val.StartsWith(arr2Val);
            if (equalPrefix)
            {
                if (arr2Val.Length > currentLongestPrefix)
                {
                    currentLongestPrefix = arr2Val.Length;
                }
                break;
            }
            arr2Val = arr2Val[..^1];
        }
        return currentLongestPrefix;
    }
    public static int GetStartingIndextOfLongestConsequtive(int[] nums)
    {
        int firstCurrentIndex = nums.IndexOf(nums.Min());
        int lastCurrentIndex = nums.LastIndexOf(nums.Min());
        if (nums.Length <= 2)
        {
            return firstCurrentIndex;
        }
        if (firstCurrentIndex != 0 || lastCurrentIndex != nums.Length - 1)
        {
            return firstCurrentIndex;
        }

        int value = nums[firstCurrentIndex];
        firstCurrentIndex = Array.IndexOf(nums, value, firstCurrentIndex + 2);
        return firstCurrentIndex;

    }
    public static bool Check(int[] nums)
    {
        int currentIndex = GetStartingIndextOfLongestConsequtive(nums);

        int nextIndex;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (currentIndex < nums.Length - 1)
                nextIndex = currentIndex + 1;
            else
                nextIndex = 0;
            if (nums[currentIndex] > nums[nextIndex])
            {
                return false;
            }
            currentIndex = nextIndex;
        }
        return true;
    }
    public static int MinElement(int[] nums)
    {
        int minElement = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            int digitSum = GetIndexDigitSum(nums[i].ToString());
            if (digitSum < minElement)
            {
                minElement = digitSum;
            }
        }
        return minElement;
    }
    public static int GetIndexDigitSum(string num)
    {
        int digitSum = 0;
        foreach (var digit in num)
        {
            digitSum += int.Parse(digit.ToString());
        }
        return digitSum;
    }

    public static bool AsteroidsDestroyed(int m, int[] asteroids)
    {
        long mass = m;
        Array.Sort(asteroids);

        for (int i = 0; i < asteroids.Length; i++)
        {
            if (mass >= asteroids[i])
            {
                mass += asteroids[i];
                continue;
            }
            return false;
        }
        return true;
    }
    public static int MinimumCost(int[] cost)
    {
        Array.Sort(cost);

        int minimumCost = 0;

        int count = 1;

        for (int i = cost.Length - 1; i >= 0; i--)
        {
            if (count % 3 != 0)
            {
                minimumCost += cost[i];
            }
            count++;
        }
        return minimumCost;
    }
    public static int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        int earliestFinishTime1 = SolveCase(landStartTime, landDuration, waterStartTime, waterDuration);
        int earliestFinishTime2 = SolveCase(waterStartTime, waterDuration, landStartTime, landDuration);

        return Math.Min(earliestFinishTime1, earliestFinishTime2);
    }
    private static int SolveCase(int[] start1, int[] duration1, int[] start2, int[] duration2)
    {
        int earliestFinishTime = int.MaxValue;
        for (int i = 0; i < start1.Length; i++)
        {
            int stopTime1 = start1[i] + duration1[i];
            for (int j = 0; j < start2.Length; j++)
            {
                int stopTime2;
                if (stopTime1 < start2[j])
                {
                    stopTime2 = start2[j] + duration2[j];
                }
                else
                {
                    stopTime2 = stopTime1 + duration2[j];
                }
                if (stopTime2 < earliestFinishTime)
                {
                    earliestFinishTime = stopTime2;
                }
            }
        }
        return earliestFinishTime;
    }
    public static int PairSum(ListNode head)
    {
        ListNode fast = head;
        ListNode currentNode = head;
        var neighbourValues = new List<int>
        {
            fast.val
        };

        while (fast.next != null)
        {
            neighbourValues.Add(fast.next.val);
            if (fast.next.next != null)
            {
                neighbourValues.Add(fast.next.next.val);
                fast = fast.next.next;
            }
            else
            {
                fast = fast.next;
            }
        }
        int maximumTwinSum = 0;
        for (int i = neighbourValues.Count - 1; i >= neighbourValues.Count / 2; i--)
        {
            int neighbourSum = currentNode.val + neighbourValues[i];
            if (neighbourSum > maximumTwinSum)
            {
                maximumTwinSum = neighbourSum;
            }
            currentNode = currentNode.next;
        }

        return maximumTwinSum;
    }
    public static ListNode DeleteMiddle(ListNode listNode)
    {
        ListNode fast = listNode;
        ListNode slow = listNode;
        ListNode previous = listNode;
        ListNode next = listNode;
        if (listNode.next == null)
        {
            listNode = null;
            return listNode;
        }

        while (fast.next != null)
        {
            if (fast.next.next != null)
            {
                fast = fast.next.next;
            }
            else
            {
                fast = fast.next;
            }
            previous = slow;
            slow = slow.next;
            next = slow.next;
        }
        previous.next = next;
        return listNode;
    }
    public static string ProcessStr(string s)
    {
        List<char> result = [];
        foreach (var c in s)
        {
            if (c == '*')
            {
                if (result.Count > 0)
                {
                    result.RemoveAt(result.Count - 1);
                }
            }
            else if (c == '#')
            {
                result.AddRange(result);
            }
            else if (c == '%')
            {
                result.Reverse();
            }
            else
            {
                result.Add(c);
            }
        }
        return string.Concat(result);
    }
    public static double AngleClock(int hour, int minutes)
    {
        double degreeInMins = minutes / 60.0 * 360;
        double degreeInHrs = hour == 12 ? 0 : hour / 12.0 * 360;
        double dreegreeHrsShift = minutes / 60.0 * 30;
        degreeInHrs += dreegreeHrsShift;

        double degree = Math.Abs(degreeInMins - degreeInHrs);
        double rDegree = 360 - degree;

        return Math.Min(degree, rDegree);
    }
    public static int LargestAltitude(int[] gain)
    {
        List<int> points = [0];

        for (int i = 0; i < gain.Length; i++)
        {
            int newPoint = points[i] + gain[i];
            points.Add(newPoint);
        }
        return points.Max();
    }
    public static int[] SumAndMultiply(string s, int[][] queries)
    {
        int[] answers = new int[queries.Length];

        const int MOD = 1_000_000_007;

        for (int i = 0; i < queries.Length; i++)
        {
            int[] subStrLength = queries[i];
            string subStr = s[subStrLength[0]..(subStrLength[1] + 1)];
            string concatSubStr = ConcatinateNonZeros(subStr);
            int concatSubStrDigitSum = concatSubStr.Sum(x => x - '0');
            BigInteger concatSubStrInt = BigInteger.TryParse(concatSubStr, out BigInteger result) == true ? result : 0;
            BigInteger product = concatSubStrDigitSum * concatSubStrInt;
            answers[i] = (int)(product % MOD);
        }
        return answers;
    }
    private static string ConcatinateNonZeros(string subStr)
    {
        string concatSubStr = string.Concat(subStr.Where(x => x != '0'));
        return concatSubStr;
    }
    public static long GcdSum(int[] nums)
    {
        var prefixGcd = new List<long>();

        var prefixGcdPair = new List<long>();

        long previousmxi = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            long mxi = Math.Max(previousmxi, nums[i]);

            previousmxi = mxi;

            long gcd = GetGCD(mxi, nums[i]);
            prefixGcd.Add(gcd);
        }

        prefixGcd.Sort();

        for (int i = 0; i < prefixGcd.Count / 2; i++)
        {
            long pairGcd = GetGCD(prefixGcd[prefixGcd.Count - 1 - i], prefixGcd[i]);
            prefixGcdPair.Add(pairGcd);
        }

        return prefixGcdPair.Sum();
    }
    static long GetGCD(long a, long b)
    {
        return b == 0 ? Math.Abs(a) : GetGCD(b, a % b);
    }
    public static int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int remainingValueToTarget = target - nums[i];

            if (dict.TryGetValue(remainingValueToTarget, out int value))
            {
                return [value, i];
            }

            dict[nums[i]] = i;

        }
        return [];
    }

    public static int MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        int lowestPriceBefore = prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < lowestPriceBefore)
            {
                lowestPriceBefore = prices[i];
                continue;
            }

            int profit = prices[i] - lowestPriceBefore;
            maxProfit = profit > maxProfit ? profit : maxProfit;

        }
        return maxProfit;
    }

    public static int[] ProductExceptSelf(int[] nums)
    {
        int totalProd = 1;
        var answer = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                continue;
            }
            totalProd *= nums[i];
        }
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = nums[i] != 0 ? totalProd / nums[i] : 0;
        }
        return answer;
    }
    public static int MaxSubArray(int[] nums)
    {
        int maxSubArraySum = int.MinValue;
        int currentSubArraySum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            currentSubArraySum += nums[i];
            maxSubArraySum = currentSubArraySum > maxSubArraySum ? currentSubArraySum : maxSubArraySum;
            if (currentSubArraySum < 0)
            {
                currentSubArraySum = 0;
            }
        }
        return maxSubArraySum;
    }
    public static bool ContainsDuplicate(int[] nums)
    {
        var uniqueItems = nums.ToHashSet();

        return uniqueItems.Count != nums.Length;
    }
    public static int MaxProduct(int[] nums)
    {
        int maximumSubArrayProduct = nums[0];
        int currentSubArrayProd = 1;
        int negativeProd = 1;
        int maxNegativeProd = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            negativeProd *= nums[i];
            if (nums[i] < 0)
            {
                if (negativeProd <= 0)
                {
                    currentSubArrayProd = 1;
                }
                else
                {
                    currentSubArrayProd = negativeProd;
                    maximumSubArrayProduct = currentSubArrayProd > maximumSubArrayProduct ? currentSubArrayProd : maximumSubArrayProduct;
                }
                continue;
            }
            if (currentSubArrayProd == 0)
            {
                currentSubArrayProd = 1;
                negativeProd = 1;
            }
            currentSubArrayProd *= nums[i];
            maximumSubArrayProduct = currentSubArrayProd > maximumSubArrayProduct ? currentSubArrayProd : maximumSubArrayProduct;
        }
        return maximumSubArrayProduct;
    }
    public static int MaxArea(int[] height)
    {
        int maxWater = 0;
        int i = 0;
        int j = height.Length - 1;

        while (i < j)
        {
            int leftPointer = height[i];
            int rightPointer = height[j];
            int maxWaterSoFar = Math.Min(leftPointer, rightPointer) * (j - i);

            if (leftPointer <= rightPointer)
            {
                i++;
            }
            else if (leftPointer > rightPointer)
            {
                j--;
            }
            maxWater = Math.Max(maxWater, maxWaterSoFar);
        }

        return maxWater;
    }

    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var letterOccurence = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!letterOccurence.TryGetValue(s[i], out int scount))
            {
                letterOccurence[s[i]] = 1;
            }
            else
            {
                letterOccurence[s[i]] = scount + 1;
            }

            if (!letterOccurence.TryGetValue(t[i], out int tcount))
            {
                letterOccurence[t[i]] = -1;
            }
            else
            {
                letterOccurence[t[i]] = tcount - 1;
            }
        }

        return !letterOccurence.Any(x => x.Value != 0);
    }

    public static bool IsPalindrome(string s)
    {
        int leftPointer = 0;
        int rightPointer = s.Length - 1;
        while (leftPointer <= rightPointer)
        {
            if (!char.IsLetterOrDigit(s[leftPointer]))
            {
                leftPointer++;
                continue;
            }
            if (!char.IsLetterOrDigit(s[rightPointer]))
            {
                rightPointer--;
                continue;
            }
            if (!s[leftPointer].ToString().Equals(s[rightPointer].ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            leftPointer++;
            rightPointer--;
        }
        return true;
    }
    public static int LengthOfLongestSubstring(string s)
    {
        int maxSubstringLength = 0;
        int startValidWindow = 0;
        Dictionary<char, int> subString = [];
        for (int i = 0; i < s.Length; i++)
        {
            int currentSubstringLength;
            if (subString.TryGetValue(s[i], out int index))
            {
                if (index >= startValidWindow)
                {
                    startValidWindow = index + 1;
                }
            }
            currentSubstringLength = i - startValidWindow + 1;
            maxSubstringLength = currentSubstringLength > maxSubstringLength ? currentSubstringLength : maxSubstringLength;
            subString[s[i]] = i;
        }
        return maxSubstringLength;
    }
    public static int countDroppedRequests(List<int> server)
    {
        int numThreads = 0;
        int droppedRequest = 0;

        for (int i = 0; i < server.Count; i++)
        {
            if (server[i] < 0)
            {
                if (numThreads < 1)
                {
                    droppedRequest--;
                }
            }
            else if (server[i] > 0)
            {
                numThreads += server[i];
            }
        }
        return droppedRequest;
    }
    public static int getMinMachines(List<int> start, List<int> end)
    {
        // [1,8,3,9,6], [7,9,6,14,7]

        // [1,3,6,8,9], [6,7,7,9,14]
        start.Sort();
        end.Sort();

        int minimumMachines = 0;
        int maxMachines = 0;
        int startIndex = 0;
        int endIndex = 0;

        while (startIndex < start.Count)
        {
            if (start[startIndex] <= end[endIndex])
            {
                minimumMachines++;
                maxMachines = Math.Max(maxMachines, minimumMachines);
                startIndex++;
            }
            else
            {
                minimumMachines--;
                endIndex++;
            }
        }

        return maxMachines;
    }
    public static bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<int, int> mag = [];

        StringBuilder reconsstrct = new();

        for (int i = 0; i < magazine.Length; i++)
        {
            if (mag.TryGetValue(magazine[i], out int count))
            {
                mag[magazine[i]] = count + 1;
            }
            else
            {
                mag[magazine[i]] = 1;
            }
        }

        for (int i = 0; i < ransomNote.Length; i++)
        {
            if (mag.TryGetValue(ransomNote[i], out int value))
            {
                if (value == 0)
                {
                    break;
                }
                reconsstrct.Append(ransomNote[i]);
                mag[ransomNote[i]] = value - 1;
                continue;
            }
        }
        return reconsstrct.ToString() == ransomNote;
    }
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, int> word = [];

        IList<IList<string>> result = [];

        for (int i = 0; i < strs.Length; i++)
        {
            var currentWord = strs[i].ToCharArray();
            Array.Sort(currentWord);
            string currenntWordstr = string.Concat(currentWord);

            if (word.TryGetValue(currenntWordstr, out int index))
            {
                result[index].Add(strs[i]);
            }
            else
            {
                result.Add([strs[i]]);
                word[currenntWordstr] = result.Count - 1;
            }
        }
        return result;
    }
}

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
