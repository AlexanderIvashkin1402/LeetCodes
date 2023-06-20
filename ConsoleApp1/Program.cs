namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1);
            head.next = new ListNode(0);
            head.next.next = new ListNode(1);

            var isPalindrome = new Solution().IsPalindrome(head);
        }
    }

     //Definition for singly-linked list.
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
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return false;

            if (head.next == null) return true;

            var stack = new Stack<int>();

            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                stack.Push(slow.val);
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast != null)
            {
                slow = slow.next;
            }

            while (slow != null)
            {
                var val = stack.Pop();
                if (val != slow.val) return false;
                slow = slow.next;
            }

            return true;
        }
    }

}