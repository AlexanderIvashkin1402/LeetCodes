namespace HandOniStraight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Solution().IsNStraightHand(new int[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 }, 3);
        }
    }

    public class Solution
    {
        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            if (hand.Length % groupSize != 0 || hand.Length < groupSize)
                return false;

            if (groupSize == 1) return true;

            Array.Sort(hand);
            Dictionary<int, int> cards = new Dictionary<int, int>();
            foreach (var card in hand)
            {
                if (cards.ContainsKey(card))
                    cards[card]++;
                else
                    cards[card] = 1;
            }

            while (cards.Any())
            {
                int firstCard = cards.FirstOrDefault(x => x.Value > 0).Key;

                for (int i = firstCard; i < firstCard + groupSize; i++)
                {
                    if (!cards.ContainsKey(i) || cards[i] == 0) return false;
                    cards[i]--;
                }
            }

            return true;
        }
    }
}


//if (hand.Length % groupSize != 0 || hand.Length < groupSize) return false;

//if (groupSize == 1 || hand.Length == groupSize) return true;

//Dictionary<int, int> cards = new Dictionary<int, int>();
//foreach (int card in hand)
//{
//    if (cards.ContainsKey(card))
//        cards[card]++;
//    else
//        cards[card] = 1;
//}

//foreach (var card in hand)
//{
//    if (cards[card] < 1) continue;

//    for (var i = 0; i < groupSize; i++)
//    {
//        if (!(cards.ContainsKey(card + i) && cards[card + i] >= cards[card]))
//            return false;
//        cards[card + i]--;
//    }
//}

//return true;