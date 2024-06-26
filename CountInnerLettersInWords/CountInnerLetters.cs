﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountInnerLettersInWords
{
    /// <summary>
    /// Contans Methods for counting letters within words within strings
    /// </summary>
	public class CountInnerLetters
	{
        /// <summary>
        /// Examines a string for sequences of letters or words counts the unique inner letters then replaces them with that count
        /// </summary>
        /// <param name="words">String to count unique letters in words</param>
        /// <returns>Input string with inner letters replaced by a count of each words unique inner letters </returns>
        public string ConvertToLetterCount(string words)
        {
            string wordsCount = String.Empty;
            string word = String.Empty;
            char[] middleLetters;
            string alterdWord;

			for (int i = 0; i < words.Length; i++)
            {
                if (Char.IsLetter(words[i])) // If its a letter then (continue to or begin to) assemble the word
                    word += words[i];
                if (Char.IsLetter(words[i]) == false || i == words.Length - 1) // if we have reached a delimeter of the end of the string then parse and rewrite the word with the middle letters count
                {
                    if (word.Length > 1) 
                    {
                        middleLetters = new char[word.Length - 2];
                        Array.Copy(word.ToCharArray(), 1, middleLetters, 0, word.Length - 2);
                        if(middleLetters.Length < 2)
							alterdWord = word[0] + middleLetters.Length.ToString() + word[word.Length - 1];
                        else
						    alterdWord = word[0] + middleLetters.Distinct().ToArray().Length.ToString() + word[word.Length - 1];
                        wordsCount += alterdWord;
                        word = String.Empty;
                    }
                    else if (word.Length == 1)
                    {
                        wordsCount += word;
                        word = String.Empty;
                    }
                    if (Char.IsLetter(words[i]) == false)
                        wordsCount += words[i];
                }
            }
            return wordsCount;
        }
    }
}
