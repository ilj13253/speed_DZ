using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TOPOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string file = "Текстовый документ (2).txt";
            string text;
            using (StreamReader sr = new StreamReader(file))
            {
                text = sr.ReadToEnd();
            }

            int sentenceCount = CountSentences(text);
            Console.WriteLine($"Количество предложений: {sentenceCount}");

            int wordCount = CountWords(text);
            Console.WriteLine($"Количество слов: {wordCount}");

            int vowelCount = CountVowels(text);
            Console.WriteLine($"Количество гласных: {vowelCount}");

            int consonantCount = CountConsonants(text);
            Console.WriteLine($"Количество согласных: {consonantCount}");

            int numberCount = CountNumbers(text);
            Console.WriteLine($"Количество чисел: {numberCount}");

            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"Время выполнения: {elapsedTime}");
            stopwatch.Stop();
            Console.ReadKey();
        }

        static int CountSentences(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (c == '.' || c == '!' || c == '?')
                    count++;
            }
            return count;
        }

        static int CountWords(string text)
        {
            int count = 0;
            bool inWord = false;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    if (!inWord)
                    {
                        count++;
                        inWord = true;
                    }
                }
                else
                {
                    inWord = false;
                }
            }
            return count;
        }

        static int CountVowels(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if ("aeiouAEIOU".IndexOf(c) != -1)
                    count++;
            }
            return count;
        }

        static int CountConsonants(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c) && "aeiouAEIOU".IndexOf(c) == -1)
                    count++;
            }
            return count;
        }

        static int CountNumbers(string text)
        {
            int count = 0;
            foreach (char c in text.ToString())
            {
                if (char.IsDigit(c))
                    count++;
            }
            return count;
        }
    }
}