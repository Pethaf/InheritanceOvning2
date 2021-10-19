using System;
using System.Collections.Generic;

namespace RepetitionInherticance2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmp = new List<IComputation> { new AdditionComputation(), new SubtractionComputation()};
            while (true)
            {

                Console.WriteLine("Skriv in inmatning");
                string input = Console.ReadLine();
                string[] parts = input.Split(" ");
                int[] partsAsInt = Array.ConvertAll(parts[1..], s => int.Parse(s));
                foreach(var computation in tmp)
                {
                    if (computation.CanCompute(parts[0]))
                    {
                        Console.WriteLine(computation.Compute(partsAsInt));
                    }
                }
            }
        }
    }
    interface IComputation
    {
        public bool CanCompute(string theString);
        public int Compute(int[] theArgs);
    }
    class AdditionComputation: IComputation
    {
        public bool CanCompute(string symbol)
        {
            return (symbol == "+" || symbol == "plus");
        }
        public int Compute(int[] arr)
        {
            int tmp = 0;
            foreach(var theArg in arr)
            {
                tmp += theArg;
            }
            return tmp;
        }
    }
    class SubtractionComputation: IComputation
    {
        public bool CanCompute(string symbol)
        {
            return (symbol == "-" || symbol == "minus");
        }
        public int Compute(int[] args)
        {
            int tmp = 0;
            foreach(var arg in args)
            {
                tmp -= arg;
            }
            return tmp;
        }
    }
}

