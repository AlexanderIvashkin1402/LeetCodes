using System;
using System.Xml.Linq;

namespace Trie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();

            trie.Insert("apple");
            Console.WriteLine(trie.Search("apple"));   // returns true
            Console.WriteLine(trie.Search("app"));     // returns false
            Console.WriteLine(trie.Search("dog"));     // returns false
            Console.WriteLine(trie.StartsWith("app")); // returns true
            trie.Insert("dog");
            trie.Insert("app");
            Console.WriteLine(trie.Search("app"));     // returns true
            Console.WriteLine(trie.Search("dog"));     // returns true
        }
    }

    public class Trie
    {
        private TrieNode _root;
        public Trie() 
        { 
            _root = new TrieNode();
        }
        public void Insert(string word)
        {
            Insert(word, _root);
        }
        public bool Search(string word)
        {
            return Search(word, _root);
        }
        public bool StartsWith(string prefix)
        {
            return StartsWith(prefix, _root);
        }
        private void Insert(string word, TrieNode node)
        {
            if (string.IsNullOrEmpty(word))
            {
                node.End = true;
                return;
            }
            if (!node.Keys.ContainsKey(word[0]))
            {
                node.Keys[word[0]] = new TrieNode();
                Insert(word.Substring(1), node.Keys[word[0]]);
            }
            else
            {
                Insert(word.Substring(1), node.Keys[word[0]]);
            }
        }
        private bool Search(string word, TrieNode node)
        {
            if (string.IsNullOrEmpty(word) && node.End)
            {
                return true;
            }
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }
            if (!node.Keys.ContainsKey(word[0]))
            {
                return false;
            }
            return Search(word.Substring(1), node.Keys[word[0]]);
        }
        private bool StartsWith(string prefix, TrieNode node)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return true;
            }
            if (!node.Keys.ContainsKey(prefix[0]))
            {
                return false;
            }
            else
            {
                return StartsWith(prefix.Substring(1), node.Keys[prefix[0]]);
            }
        }
    }

    public class TrieNode
    {
        public bool End { get; set; }
        public Dictionary<char,TrieNode> Keys { get; set; }
        public TrieNode() 
        {
            End = false;
            Keys = new Dictionary<char, TrieNode>();
        }
    }
}