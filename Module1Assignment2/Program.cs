using System;
using System.Numerics;

namespace Module1Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any number up to twenty one digits long: ");
            string input = Console.ReadLine();
            if (input.Length > 21)
            {
                Console.WriteLine("I cannot do more than twenty one digits!");
                return;
            }
            var number = BigInteger.Parse(input);
            Console.WriteLine($"{number:N0} in words is {number.ToWords()}.");
        }
    }
    public static class ExtendBigInteger
    {
        public static string ToWords(this BigInteger number)
        {
            if (number == 0)
                return "zero";
            if (number < 0)
                return "minus " + ToWords(number);
            string words = "";
            
            if ((number / 10000000000000000000) > 0)
            {
                words += ToWords(number / 10000000000000000000) + " quintillion ";
                number %= 10000000000000000000;
            }
            if ((number / 1000000000000000) > 0)
            {
                words += ToWords(number / 1000000000000000) + " quadrillion ";
                number %= 1000000000000000;
            }
            if ((number / 1000000000000) > 0)
            {
                words += ToWords(number / 1000000000000) + " trillion ";
                number %= 1000000000000;
            }
            if ((number / 1000000000) > 0)
            {
                words += ToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }
            if ((number / 1000000) > 0)
            {
                words += ToWords(number / 1000000) + " million ";
                number %= 1000000;
            }
            if ((number / 100000) > 0)
            {
                words += ToWords(number / 100000) + " hundred thousand ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ToWords(number / 1000) + " thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ToWords(number / 100) + " hundred ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", 
                                        "nine", "ten", "eleven", "twelve", "thrirteen", "fourteen", "fifteen", 
                                        "sixteen", "seventeen", "eighteen", "ninteen", "twenty"};
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninty" };
                if (number < 20)
                {
                    int intnumber = (int)number;
                    words += unitsMap[intnumber];
                }
                else
                {
                    int intnumber = (int)number;
                    words += tensMap[intnumber / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[intnumber % 10];
                }
            }
            return words;
        }
    }
}
