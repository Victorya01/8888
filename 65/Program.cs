using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Linq;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;

namespace ConsoleAp0
{
    public class Program
    {


        public static HashSet<string> hashSet = new HashSet<string>();
        public static string[] randomStringArray = FillingArray(20000, hashSet);
        public static string[] FillingArray(int count, HashSet<string> hashSet)
        {
            string[] randomArray = new string[count];
            for (int i = 0; i < randomArray.Length; i++)
            {
                string randomString = GetRandomsString(11);
                randomArray[i] = randomString;
                hashSet.Add(randomString);
            }
            return randomArray;
        }
        public static string GetRandomsString(int Lenghtstring)
        {
            string randomString = "";
            Random rnd = new Random();
            for (int i = 0; i < Lenghtstring; i++)
            {
                char tmpChar = (char)rnd.Next(0, 255);
                randomString += tmpChar;
            }
            return randomString;
        }
        [Benchmark]
        public void searchStringArray()
        {
            string searchString = "Плакал он";
            for (int i = 0; i < randomStringArray.Length; i++)
            {
                if (randomStringArray[i] == searchString)
                {
                    return;
                }
            }
        }
        [Benchmark]
        public void SearchStringHashset()
        {
            string searchString = "Плакала она";
            if (hashSet.Contains(searchString)) ;

        }

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();

        }

    }


}