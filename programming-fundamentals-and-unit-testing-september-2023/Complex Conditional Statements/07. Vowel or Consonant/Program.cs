﻿namespace _07._Vowel_or_Consonant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter = (char)Console.Read();
            if(letter =='A' || letter =='a' || letter=='E' || letter=='e' || letter=='I' || letter=='i' || letter == 'O' || letter == 'o' || letter == 'U' || letter == 'u') Console.WriteLine("Vowel");
            else Console.WriteLine("Consonant");

        }
    }
}