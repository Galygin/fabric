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
            private int _a;
            public int Next { get { return _a; } }
            public ConstGenerator(int init = 0)
            {
                int _a = init;
            }
        }

        class CounterGenerator : IGenerator
        {
            private int _a;
            public int Next { get {  return _a++; } }
            public CounterGenerator(int init = 0)
            {
                int _a = init;
            }
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
