using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabric
{
    class Program
    {
        public static int i = 1;

        static void Main(string[] args)
        {
            CounterGeneratorFabric Faba = new CounterGeneratorFabric();
            ConstGeneratorFabric Fabb = new ConstGeneratorFabric();
            IGenerator gena = Faba.FactoryMethod();
            IGenerator genb = Fabb.FactoryMethod();
            int k = 0;
            while (k != 27)
            {
                k = Console.Read();
                Console.WriteLine("{0}", gena.Next);
            }
        }

        interface IGenerator
        {
            int Next { get; }
        }

        interface IGeneratorFabric
        {
            IGenerator FactoryMethod();
        }

        class ConstGenerator : IGenerator
        {
            int a = i;
            public int Next { get { return a; } }
        }

        class CounterGenerator : IGenerator
        {
            int a = i;
            public int Next { get { a++; return a; } }
        }

        class ConstGeneratorFabric : IGeneratorFabric
        {
            public IGenerator FactoryMethod()
            {
                return new ConstGenerator();
            }
        }
        class CounterGeneratorFabric : IGeneratorFabric
        {
            public IGenerator FactoryMethod()
            {
                  return new CounterGenerator(); 
            }   
        }
    }
}
