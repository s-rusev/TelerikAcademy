﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.TrieWordsOccurances
{
    /// <summary>
    /// Trie factory to create Trie instances.
    /// </summary>
    public static class TrieFactory
    {
        /// <summary>
        /// Get a new Trie instance.
        /// </summary>
        public static ITrie GetTrie()
        {
            Trie trie = new Trie(GetTrieNode(' '));
            return trie;
        }
        /// <summary>
        /// Get a new TrieNode instance.
        /// </summary>
        /// <param name="character">Character of the TrieNode.</param>
        internal static TrieNode GetTrieNode(char character)
        {
            TrieNode trieNode = new TrieNode(character,
                new Dictionary<char, TrieNode>(),
                false,
                0);

            return trieNode;
        }
    }
}