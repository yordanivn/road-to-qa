﻿namespace Testing_string_subtractor


{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = "aaaa ccc bbbb";
            string startIndex = "aaaa";
            string endIndex = "bbbb";

            string result=SubstringExtractor(input,startIndex,endIndex);
        }

    public class SubstringExtractor
    {
        public static string ExtractSubstringBetweenMarkers(string input, string startMarker, string endMarker)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "Substring not found";
            }

            int startIndex = input.IndexOf(startMarker, StringComparison.Ordinal);
            int endIndex = input.IndexOf(endMarker, startIndex + startMarker.Length, StringComparison.Ordinal);

            if (startIndex != -1 && endIndex != -1)
            {
                return input.Substring(startIndex + startMarker.Length, endIndex - startIndex - startMarker.Length);
            }

            return "Substring not found";
        }
    }

}
    }
