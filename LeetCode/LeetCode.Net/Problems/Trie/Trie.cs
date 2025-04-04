using System.Collections.Generic;

namespace LeetCode.Problems.Trie;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool IsEndOfWord = false;
}

public class Trie
{

    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        var currentNode = root;

        foreach (var c in word)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                currentNode.Children[c] = new TrieNode();
            }
            currentNode = currentNode.Children[c];
        }
        currentNode.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var currentNode = root;

        foreach (var c in word)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                return false;
            }
            currentNode = currentNode.Children[c];
        }

        return currentNode.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var currentNode = root;

        foreach (var c in prefix)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                return false;
            }
            currentNode = currentNode.Children[c];
        }
        
        return true;
    }
}
