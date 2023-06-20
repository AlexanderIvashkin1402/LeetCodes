using System;
using System.Net.Sockets;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TestApp.Sorting;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] {99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0};
            //new Bubble().Sort(numbers);
            //new Selections().Sort(numbers);
            //new Insertion().Sort(numbers);
            //new Merge().Sort(numbers);
            new Quick().Sort(numbers);

            var result = new Solution().QueensAttacktheKing(new int[][] { new int[] { 5, 6 }, new int[] { 7, 7 }, new int[] { 2, 1 }, new int[] { 0, 7 }, new int[] { 1, 6 }, new int[] { 5, 1 }, new int[] { 3, 7 }, new int[] { 0, 3 }, new int[] { 4, 0 }, new int[] { 1, 2 }, new int[] { 6, 3 }, new int[] { 5, 0 }, new int[] { 0, 4 }, new int[] { 2, 2 }, new int[] { 1, 1 }, new int[] { 6, 4 }, new int[] { 5, 4 }, new int[] { 0, 0 }, new int[] { 2, 6 }, new int[] { 4, 5 }, new int[] { 5, 2 }, new int[] { 1, 4 }, new int[] { 7, 5 }, new int[] { 2, 3 }, new int[] { 0, 5 }, new int[] { 4, 2 }, new int[] { 1, 0 }, new int[] { 2, 7 }, new int[] { 0, 1 }, new int[] { 4, 6 }, new int[] { 6, 1 }, new int[] { 0, 6 }, new int[] { 4, 3 }, new int[] { 1, 7 } }, new int[] { 3, 4 });
                //new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 4, 0 }, new int[] { 0, 4 }, new int[] { 3, 3 }, new int[] { 2, 4 }}, new int[] { 0, 0 });

            //var result = new Solution().Partition("cdd");
            //var result2 = new Solution().Partition("aab");            
            //var result3 = new Solution().Partition("aaba");
            
            //var k = 2; var n = 3;
            //var dp = Enumerable.Range(0, k+1)
            //    .Select(row => Enumerable.Range(0, n).Select(column => new double?[n]).ToArray())
            //    .ToArray();
            ////Enumerable.Range(0, k + 1).Select(x => new double[n][]).ToArray();

            //var distances = Enumerable.Repeat(int.MaxValue, 5).ToArray();
            //var minutes = new Solution().NumOfMinutes(8, 4, new int[] { 2, 2, 4, 6, -1, 4, 4, 5 }, new int[] { 0, 0, 4, 0, 7, 3, 6, 0 });
            //var minutes = new Solution().NumOfMinutes(6, 2, new int[] { 2, 2, -1, 2, 2, 2 }, new int[] { 0, 0, 1, 0, 0, 0 });
            /*
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 12 };

            var toFind = 11;
            int left  = 0, right = array.Length - 1;
            var found = false;

            while(left <= right)
            {
                var mid = left + (right - left) / 2;
                //var mid = (int)Math.Floor((right + left) / 2.0);
                if (array[mid] == toFind)
                {
                    found = true;
                    break;
                }
                else if (array[mid] > toFind)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            */


            //var result = new Solution().LengthOfLongestSubstring("abcabcbb");
            //var result = new Solution().BackspaceCompare("a###", "b");
            //long r = 10; //500000; //50;
            //long d = 365; //1825; //730;
            //         long Y = r * d * 3600 * 24;

            //         var n = Math.Log(Y, 62);
            //var result = new Solution().ReverseBetween(new ListNode(3, new ListNode(5)), 1, 2);

            //var result = new Solution().ReverseBetween(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), 2, 4);
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
    public class Solution
    {
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
        var output = new List<IList<int>>();
        var result = Enumerable.Range(0, 8).Select(i => new List<int>()).ToList();
        var distances = Enumerable.Repeat(int.MaxValue, 8).ToArray();

        foreach (var queen in queens)
        {
            // same row
            if (queen[0] == king[0])
            {
                // to left
                if (queen[1] < king[1])
                {
                    if (Math.Abs(queen[1]-king[1]) < distances[0])
                    {
                        distances[0] = Math.Abs(queen[1] - king[1]);
                        if (!result[0].Any())
                        {
                            result[0].AddRange(queen);
                        }
                        else
                        {
                            result[0][0] = queen[0];
                            result[0][1] = queen[1];
                        }
                    }
                }
                // to right
                if (queen[1] > king[1])
                {
                    if (Math.Abs(queen[1] - king[1]) < distances[1])
                    {
                        distances[1] = Math.Abs(queen[1] - king[1]);
                        if (!result[1].Any())
                        {
                            result[1].AddRange(queen);
                        }
                        else
                        {
                            result[1][0] = queen[0];
                            result[1][1] = queen[1];
                        }
                    }
                }
            }
            // same column
            else if (queen[1] == king[1])
            {
                // up
                if (queen[0] < king[0])
                {
                    if (Math.Abs(queen[0] - king[0]) < distances[2])
                    {
                        distances[2] = Math.Abs(queen[0] - king[0]);
                        if (!result[2].Any())
                        {
                            result[2].AddRange(queen);
                        }
                        else
                        {
                            result[2][0] = queen[0];
                            result[2][1] = queen[1];
                        }
                    }
                }
                // down
                if (queen[0] > king[0])
                {
                    if (Math.Abs(queen[0] - king[0]) < distances[3])
                    {
                        distances[3] = Math.Abs(queen[0] - king[0]);
                        if (!result[3].Any())
                        {
                            result[3].AddRange(queen);
                        }
                        else
                        {
                            result[3][0] = queen[0];
                            result[3][1] = queen[1];
                        }
                    }
                }
            }
            // diagonal
            else if (Math.Abs(queen[0] - king[0]) == Math.Abs(queen[1] - king[1]))
            {
                var tmpDistance = Math.Abs(queen[0] - king[0]);
                // left up
                if (queen[0] - king[0] < 0 && queen[1] - king[1] < 0)
                {
                    if (tmpDistance < distances[4])
                    {
                        distances[4] = tmpDistance;
                        if (!result[4].Any())
                        {
                            result[4].AddRange(queen);
                        }
                        else
                        {
                            result[4][0] = queen[0];
                            result[4][1] = queen[1];
                        }
                    }
                }
                // right up
                else if (queen[0] - king[0] < 0 && queen[1] - king[1] > 0)
                {
                    if (tmpDistance < distances[5])
                    {
                        distances[5] = tmpDistance;
                        if (!result[5].Any())
                        {
                            result[5].AddRange(queen);
                        }
                        else
                        {
                            result[5][0] = queen[0];
                            result[5][1] = queen[1];
                        }
                    }
                }
                // right down
                else if (queen[0] - king[0] > 0 && queen[1] - king[1] > 0)
                {
                    if (tmpDistance < distances[6])
                    {
                        distances[6] = tmpDistance;
                        if (!result[6].Any())
                        {
                            result[6].AddRange(queen);
                        }
                        else
                        {
                            result[6][0] = queen[0];
                            result[6][1] = queen[1];
                        }
                    }
                }
                // left down
                else if (queen[0] - king[0] > 0 && queen[1] - king[1] < 0)
                {
                    if (tmpDistance < distances[7])
                    {
                        distances[7] = tmpDistance;
                        if (!result[7].Any())
                        {
                            result[7].AddRange(queen);
                        }
                        else
                        {
                            result[7][0] = queen[0];
                            result[7][1] = queen[1];
                        }
                    }
                }
            }
        }

            /*
            var board = new int[8,8];

            foreach (var q in queens)
            {
                board[q[0],q[1]] = 1;
            }

            for (var col = king[1] + 1; col < 8; col++)
            {
                if (board[king[0], col] == 1)
                {
                    result.Add(new int[2] { king[0], col });
                    break;
                }
            }

            for (var col = king[1] - 1; col >= 0; col--)
            {
                if (board[king[0], col] == 1)
                {
                    result.Add(new int[2] { king[0], col });
                    break;
                }
            }

            for (var row = king[0] + 1; row < 8; row++)
            {
                if (board[row, king[1]] == 1)
                {
                    result.Add(new int[2] { row, king[1] });
                    break;
                }
            }

            for (var row = king[0] - 1; row >= 0; row--)
            {
                if (board[row, king[1]] == 1)
                {
                    result.Add(new int[2] { row, king[1] });
                    break;
                }
            }

            // up left
            for (int row = king[0] - 1, col = king[1] - 1; row >= 0 && col >= 0; row--, col--)
            {
                if (board[row, col] == 1)
                {
                    result.Add(new int[2] { row, col });
                    break;
                }
            }

            // up right
            for (int row = king[0] - 1, col = king[1] + 1; row >= 0 && col < 8; row--, col++)
            {
                if (board[row, col] == 1)
                {
                    result.Add(new int[2] { row, col });
                    break;
                }
            }

            // down right
            for (int row = king[0] + 1, col = king[1] + 1; row < 8 && col < 8; row++, col++)
            {
                if (board[row, col] == 1)
                {
                    result.Add(new int[2] { row, col });
                    break;
                }
            }

            // down left
            for (int row = king[0] + 1, col = king[1] - 1; row < 8 && col >= 0; row++, col--)
            {
                if (board[row, col] == 1)
                {
                    result.Add(new int[2] { row, col });
                    break;
                }
            }
            */
            foreach (var res in result)
            {
                if (res.Any()) output.Add(res);
            }

            return output;
        }

        public IList<IList<string>> Partition(string s)
        {
            //var result = new List<IList<string>>();

            //for (var len = 1; len <= s.Length; len++)
            //{
            //    var seen = new HashSet<string>();
            //    var pos = 0;
            //    do
            //    {
            //        var candidate = pos + len < s.Length ? s.Substring(pos, len) : s.Substring(pos);
            //        if (!seen.Contains(candidate) && IsPalindrom(candidate))
            //        {
            //            if (result.Count < len) result.Add(new List<string>());
            //            result[len - 1].Add(candidate);
            //        }
            //        pos += len;
            //    }
            //    while (pos < s.Length);
            //}

            //return result;
            List<IList<string>> result = new();
            var partition = new List<string>();
            FindPartition(s, ref partition, result);
            return result;
        }
        private static void FindPartition(string s, ref List<string> partition, List<IList<string>> res)
        {
            Console.WriteLine($"input s '{s}'");
            if (string.IsNullOrEmpty(s))
            {
                res.Add(new List<string>(partition));
                //partition = new List<string>();
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                var substring = s[..(i + 1)];
                var reversed = new string(substring.Reverse().ToArray());
                Console.WriteLine($"s '{substring}'");
                if (substring == reversed)
                {
                    partition.Add(substring);

                    FindPartition(s[(i + 1)..], ref partition, res);

                    partition.RemoveAt(partition.Count - 1);
                }
            }
        }

        private bool IsPalindrom(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1) return true;

            for (int start = 0, end = s.Length - 1; start <= end; start++, end--)
            {
                if (s[start] != s[end]) return false;
            }

            return true;
        }

        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            //var adjList = new List<List<int>>();//new List<List<int>>(Enumerable.Repeat(new List<int>(), n).ToArray());
            //for (var i = 0; i < n; i++) adjList.Add(new List<int>());
            //var adjList = new List<List<int>>(List<int>()[]);
            var adjList = Enumerable.Range(0, n).Select(i => new List<int>()).ToList();

            for (var employee = 0; employee < n; employee++)
            {
                var reportTo = manager[employee];
                if (reportTo == -1) continue;
                adjList[reportTo].Add(employee);
            }

            return Dfs(headID, adjList, informTime);
        }

        private int Dfs(int currentId, List<List<int>> adjList, int[] informTime)
        {
            if (!adjList[currentId].Any()) return 0;

            var max = 0;

            for (var subordinate = 0; subordinate < adjList[currentId].Count; subordinate++)
            {
                max = Math.Max(max, Dfs(adjList[currentId][subordinate], adjList, informTime));
            }

            return max + informTime[currentId];
        }

        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            ListNode currentNode = head, start = head;
            var currentPos = 1;

            while (currentPos < left)
            {
                start = currentNode;
                currentNode = currentNode.next;
                currentPos++;
            }

            ListNode newList = null, tail = currentNode;

            while (currentPos >= left && currentPos <= right)
            {
                ListNode next = currentNode.next;
                currentNode.next = newList;
                newList = currentNode;
                currentNode = next;
                currentPos++;
            }

            start.next = newList;
            tail.next = currentNode;

            return left > 1 ? head : newList;
        }

        /*
        ListNode cur = head, prev = null, tail = null, before = null;

        for (var counter = 1; counter <= right; counter++)
        {
            if (counter < left)
            {
                prev = cur;
                cur = cur.next;
            }
            else
            {
                if (counter == left)
                {
                    tail = cur;
                    before = prev;
                }
                var tmp = cur.next;
                cur.next = prev;
                prev = cur;
                cur = tmp;
            }
        }
        if (before != null)
        {
            before.next = prev;
        }
        else
        {
            head = prev;
        }
        tail.next = cur;

        return head;
       
    }
 */
        public int LengthOfLongestSubstring(string s)
        {
            var charSet = new HashSet<char>();
            int left = 0, right = 0, maxLength = 0;
            while (right < s.Length)
            {
                if (!charSet.Contains(s[right]))
                {
                    charSet.Add(s[right]);
                    right++;
                    maxLength = Math.Max(maxLength, charSet.Count);
                }
                else
                {
                    charSet.Remove(s[left]);
                    left++;
                }
            }
            return maxLength;
        }

        /*
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length < 2) return s.Length;

            int maxLength = 0;
            //var left = 0;
            //var right = 0;
            var hash = new Dictionary<char, int>();

            for (int right = 0, left = 0; right < s.Length; right++)
            {
                if (!hash.ContainsKey(s[right]))
                {
                    hash[s[right]] = right;
                    maxLength = Math.Max(maxLength, right - left + 1);
                }
                else
                {
                    if (hash[s[right]] > left)
                    {
                        left = hash[s[right]] + 1;
                    }
                    maxLength = Math.Max(maxLength, right - left);
                    hash[s[right]] = right;
                }
                //right++;
            }

            return maxLength;
        }
        */
        public bool BackspaceCompare(string s, string t)
        {
            //var first = BuildString(s);
            //var second = BuildString(t);

            //return first.Length == second.Length && first.Equals(second);

            var sP = s.Length - 1;
            var tP = t.Length - 1;

            while (sP >= 0 || tP >= 0)
            {
                if ((sP >= 0 && s[sP] == '#') || (tP >= 0 && t[tP] == '#'))
                {
                    if (sP >= 0 && s[sP] == '#')
                    {
                        var backCount = 2;
                        while (backCount > 0)
                        {
                            sP--;
                            backCount--;
                            if (sP >= 0 && s[sP] == '#') backCount += 2;
                        }
                    }
                    if (tP >= 0 && t[tP] == '#')
                    {
                        var backCount = 2;
                        while (backCount > 0)
                        {
                            tP--;
                            backCount--;
                            if (tP >= 0 && t[tP] == '#') backCount += 2;
                        }
                    }
                }
                //if (sP < 0 && tP < 0) break;
                ////}
                else
                {
                    if ((sP < 0 && tP >= 0) || (sP >= 0 && tP < 0) || s[sP] != t[tP])
                    {
                        return false;
                    }
                    else
                    {
                        sP--;
                        tP--;
                    }
                }
            }

            return true;
        }

        //private string BuildString(string str)
        //{
        //    var arr = new char[str.Length];
        //    var pointer = 0;
        //    foreach (var c in str)
        //    {
        //        if (c != '#')
        //        {
        //            arr[pointer++] = c;
        //        }
        //        else
        //        {
        //            pointer = pointer > 0 ? pointer - 1 : 0;
        //            arr[pointer] = '\0';
        //        }
        //    }
        //    return new string(arr).Substring(0, pointer);
        //}
    }

    public class SolutionAnagram
    {
        // english letter only
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var frequency = new int[26];

            foreach (var c in s) frequency[c - 'a']++;
            foreach (var c in t) frequency[c - 'a']--;

            return frequency.Sum() == 0;
        }
    }
}

/*
 import java.util.HashMap;
import java.util.Random;

public class URLShortener {
// storage for generated keys
	private HashMap<String, String> keyMap; // key-url map
	private HashMap<String, String> valueMap;// url-key map to quickly check
												// whether an url is
	// already entered in our system
	private char myChars[]; // This array is used for character to number
							// mapping
	private Random myRand; // Random object used to generate random integers
	private int keyLength; // the key length in URL defaults to 8

	// Default Constructor
	URLShortener() {
		keyMap = new HashMap<String, String>();
		valueMap = new HashMap<String, String>();
		myRand = new Random();
		keyLength = 3;
		myChars = new char[62];
		for (int i = 0; i < 62; i++) {
			int j = 0;
			if (i < 10) {
				j = i + 48;
			} else if (i > 9 && i <= 35) {
				j = i + 55;
			} else {
				j = i + 61;
			}
			myChars[i] = (char) j;
		}
	}
	
	/**
	 * Generate a 3 character short code for the given long URL. 
	 * The short code should consist of alphanumeric characters ranging from A-Z, a-z, 0-9.
	 * 
	 * If the same longURL is passed twice, we should return the same shortCode in both the instances.
	 * 
	 * We need to make sure that the same short URL is not returned for 2 different longURLs
	 * 
	 * @param longURL 
	 * @return 3-character shortCode
	 */
//public String generateShortCode(String longURL)
//{
//    String shortURL = "";
//    if (validateURL(longURL))
//    {
//        //longURL = sanitizeURL(longURL);
//        if (valueMap.containsKey(longURL))
//        {
//            shortURL = valueMap.get(longURL);
//        }
//        else
//        {
//            shortURL = getKey(longURL);
//        }
//    }
//    // add http part
//    return shortURL;
//}

//private String getKey(String longURL)
//{
//    String key;
//    key = generateKey();
//    keyMap.put(key, longURL);
//    valueMap.put(longURL, key);
//    return key;
//}

//private String generateKey()
//{
//    String key = "";
//    boolean flag = true;
//    while (flag)
//    {
//        key = "";
//        for (int i = 0; i < keyLength; i++)
//        {
//            key += myChars[myRand.nextInt(62)];
//        }
//        // System.out.println("Iteration: "+ counter + "Key: "+ key);
//        if (!keyMap.containsKey(key))
//        {
//            flag = false;
//        }
//    }
//    return key;
//}

//String sanitizeURL(String url)
//{
//    return url;
//}

//boolean validateURL(String url)
//{
//    return true;
//}

/*
### Question:

Leetcode question link: https://leetcode.com/problems/palindrome-partitioning/

Given a string s, partition s such that every substring of the partition is a palindrome.

Return all possible palindrome partitioning of s.

Example:
Input: "aab"
Output:
[
  ["aa","b"],
  ["a","a","b"]
]

###

### Solution Walkthrough:
The first thing we need to do is understand what the question is asking us, so we can start breaking down how to approach the problem. We also ened to consider possible test cases to ensure we understand our approach properly.

We know we're going to receive a string S, and our goal is to final ALL the possible ways we can partition the string into substrings so that each substring is a palindrome.

This means that we need to figure out a way to break the string S into all possible combinations of substrings where each substring is a palindrome. We add that combination of partitioned substrings into our final output array.

An easy way to start thinking about how we would tackle this is just to think about how we would do this logically. Imagine we had the substring "aaba". We would probably start partitioning the string from left to right, and figure out all possible partitions we can make from the FIRST partition.

We would start by thinking about all possile solutions that consist of the first ONE character ("a").

* "yes" represents a valid solution, "no" represents a invalid solution *

1) "a" , "a" , "b" , "a" -> yes
2) "a", "a", "ba" -> no
3) "a", "ab", "a" -> no
4) "a", "aba" -> yes

We would then do the same for the first TWO characters ("aa")

1) "aa", "b", "a" -> yes
2) "aa", "ba" -> no

Then the same for the first THREE characters ("aab")

1) "aab", "a" -> no

Then the same for the entire string ("aaba")

1) "aaba" -> no

Grouping these together, the correct answer we would return is:
[
  ["a", "a", "b", "a"],
  ["a", "aba"],
  ["aa", "b", "a"]
]

Thinking about optimizing our solution, let's look at the first 4 solutions we came up with by partitioning with the first character included ("a").

I want us to look at solution 3, ["a", "ab", "a"], as we are partitioning from left to right, the moment we saw that the middle partition "ab" is not a palindrome, we no longer needed to continue with that solution because it already failed our logic. This gives us a hint that we don't want to pursue a solution if it fails our palindromic check in the middle.

The fact that we need ALL possible solutions, and we know we can throw away solutions if they violate our logic in the middle of a solution means that this may be a good candidate for backtracking!

We already know how to create a solution around backtracking, the general format is:

1. Add current solution
2. Decide whether to continue or not (by recursing further)
3. Remove current solution

Breaking these 3 steps down, we know that step 1 is adding the current solution. In this case we need to figure out WHAT to add, and WHERE we're adding it. The WHERE in this case is an array that holds the partitioned substrings in the current iteration S. The WHAT is the partitions themselves. 

Deciding to recurse further or not, will be based on whether or not the latest partitioned substring is a palindrome. If it is a palindrome, we continue partitioning and checking from this point onwards, if it isn't, we skip.

To start, we already know the function that helps us determine with our string is a palindrome, except we need to pass it the entire string and starting/ending indexes that represent the bounds of the substring.

const isPalindrome = (start, end, str) => {
  while(start < end) {
    if(str[start] !== str[end]) return false;
    
    start++;
    end--;
  }
  
  return true;
}

Then we need to break down the recursive function that DRIVES the solution at this decision step. Looking back at the string "aaba" and our first character partitions, particularly solution 3 and 4:

3) "a", "ab", "a"
4) "a", "aba"

When we look at it solution 3, we're partitioning "a", "ab" and at this point we know "ab" is not a palindrome. We don't need to continue partitioning the last character ("a") so we DECIDE not to continue. At this point though, we're not done with these characters because if we continue and include the next character in the partition "aba", we see this is a valid palindrome! For this reason, we need to make sure our recursive solution is able to capture all these points together.

Building out the recursive function, what are we trying to capture:

const solve = () => {}

1. We have to keep track of our starting index which represent the first character in the substring that we're partitioning:

const solve = (startingIdx) => {}

2. We need to pass the string S:

const solve = (startingIdx, S)

3. We need to pass an array containing the substrings we've partitioned so far in this current iteration:

const solve = (startingIdx, S, partialSplits) => {}

4. We need to pass the final result array that will hold ALL our CORRECT solutions

const solve = (startingIdx, S, partialSplits, result) => {}

Now fleshing out the logic and filling out the backtracking template, we first realize that if our startingIdx has reached the END of the string, all our substrings in this iteration must be valid! We can then push these accumulated substrings into our result array. 

*REMEMBER* We need to duplicate the array that we push into our result array because our existing array is still being backtracked through, meaning values are being removed and added constantly! We just want to push in the SNAPSHOT of the current state of our array.

const solve = (startingIdx, S, partialSplits, result) => {
  if(startingIdx === S.length) {
      result.push([...partialSplits]);
  }
}

Now the meat of our solution is going to be looping a second pointer through the remaining characters from our current startingIdx. This second pointer represents the last character in the current substring we're checking.

const solve = (startingIdx, S, partialSplits, result) => {
  if(startingIdx === S.length) {
      result.push([...partialSplits]);
  } else {
    for(var i = startingIdx; i < S.length; i++) {
    }
  }
}

If the current substring IS a palindrome, we want to push it into our current partialSplits array, and continue our recursive solution partitioning through all possible further solutions with the NEXT character as the new startingIdx to represent the first character of our next substring.

const solve = (startingIdx, S, partialSplits, result) => {
  if(startingIdx === S.length) {
      result.push([...partialSplits]);
  } else {
    for(var i = startingIdx; i < S.length; i++) {
      if(isPalindrome(startingIdx, i, S)) {
        const palindromeSnippet = S.slice(startingIdx, i + 1);
        partialSplits.push(palindromeSnippet);

        solve(i + 1, S, partialSplits, result);
      }
    }
  }
}

The last step is to remove the last substring we added, so we can try the next substrings that contain the existing characters.

const solve = (startingIdx, S, partialSplits, result) => {
  if(startingIdx === S.length) {
      result.push([...partialSplits]);
  } else {
    for(var i = startingIdx; i < S.length; i++) {
      if(isPalindrome(startingIdx, i, S)) {
        const palindromeSnippet = S.slice(startingIdx, i + 1);
        partialSplits.push(palindromeSnippet);

        solve(i + 1, S, partialSplits, result);
        partialSplits.pop();
      }
    }        
  }
}

Putting it all together, our final answer is below!
 */
