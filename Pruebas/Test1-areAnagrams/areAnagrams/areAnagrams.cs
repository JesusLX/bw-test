using System.Collections;
using System.Collections.Generic;


namespace areAnagrams {
    internal class AreAnagrams {

        /// <summary>
        /// Checks if two words are anagrams of each other.
        /// An anagram is a word formed by rearranging the letters of another word using all the letters only once.
        /// </summary>
        /// <param name="word1">The first word to check.</param>
        /// <param name="word2">The second word to check.</param>
        /// <returns>True if the words are anagrams; otherwise, false.</returns>
        public static bool AreStringsAnagrams(string a, string b) {
            bool areAnagrams = false;

            if (a.Length == b.Length) {
                string aSorted = new(
                    a.ToLower().
                    OrderBy(ch => ch).
                    ToArray()
                );
                string bSorted = new(
                    b.ToLower().
                    OrderBy(ch => ch).
                    ToArray()
                );

                areAnagrams = aSorted == bSorted;
            }
            return areAnagrams;
        }

        public static void Main(string[] args) {
            Console.WriteLine(AreStringsAnagrams("Momdad", "Dadmom"));
        }

    }
}