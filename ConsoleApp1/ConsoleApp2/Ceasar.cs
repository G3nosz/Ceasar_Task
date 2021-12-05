using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace ConsoleApp1
{
    public class Ceasar
    {
        private int shift;
        private char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private Dictionary<char, char> shrift;

        public Ceasar()
        {
            shift = 0;
            shrift = new Dictionary<char, char>();
            InitShrift();
        }
        /// <summary>
        /// Put letters to dictionary
        /// </summary>
        public void InitShrift()
        {
            foreach (char a in letters)
            {
                shrift.Add(a, a);
            }
        }
        /// <summary>
        /// Takes input as a string, ant cipher it from dictionary values.
        /// </summary>
        /// <param name="input">String to cipher</param>
        /// <returns></returns>
        public string Cipher(string input)
        {
            if (shift == 0) return input;
            char[] fullInput = input.ToCharArray();

            for (int i = 0;  i < fullInput.Length; i++)
            {
                if (shrift.ContainsKey(Char.ToLower(fullInput[i])))
                {
                    if (Char.IsUpper(fullInput[i])) fullInput[i] = Char.ToUpper(shrift[Char.ToLower(fullInput[i])]);
                    else fullInput[i] = shrift[fullInput[i]];

                }
            }

            return new string(fullInput);
        }

        /// <summary>
        /// Check and assign new shift value.
        /// Also, do left or right shift of dictionary
        /// </summary>
        /// <param name="val"> value of a shift</param>
        /// <param name="left"> is this value for left shift</param>
        public void SetShift(int val, bool left)
        {
            if (val < 1 || val > letters.Length)
            {
                Console.WriteLine("Shift is not possible, the input: {0} is not in set range ", val);
                return;
            }
            else
            {
                shift = val;
            }

            if (left) ShiftLettersLeft();
            else if(!left) ShiftLettersRight();
        }

        /// <summary>
        /// Change letter values in dictionary, where input letter is key in dictionary.
        /// Shift letter values from, letter array to left by shift value.
        /// </summary>
        private void ShiftLettersLeft()
        {
            int start = shift;

            for (int i = 0; i < letters.Length; i++)
            {
                if (start > 0)
                {
                    shrift[letters[i]] = letters[letters.Length - start];
                    start--;
                }
                else shrift[letters[i]] = letters[i - shift];
            }
        }
        /// <summary>
        /// Change letter values in dictionary, where input letter is key in dictionary.
        /// Shift letter values from, letter array to right by shift value.
        /// </summary>
        private void ShiftLettersRight()
        {
            int start = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                if (i + shift >= letters.Length)
                {
                    shrift[letters[i]] = letters[start];
                    start++;
                }
                else shrift[letters[i]] = letters[i + shift];
            }
        }
    }
}
