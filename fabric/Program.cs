using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabric
{
    class Program
    {
        static void Main(string[] args)
        {
            int I;
            Console.Write(@"Type in integer value: ");

            while (!int.TryParse(Console.ReadLine(), out I))
            {
                /*Do nothing*/
            }
            CounterGeneratorFabric Faba = new CounterGeneratorFabric();
            ConstGeneratorFabric Fabb = new ConstGeneratorFabric();
            IGenerator gena = Faba.FactoryMethod(I);
            IGenerator genb = Fabb.FactoryMethod(I);

            while (true)
            {
                Console.WriteLine("{0}", genb.Next);
                Console.ReadKey();
            }
        }

        interface IGenerator
        {
            int Next { get; }
        }

        interface IGeneratorFabric
        {
            IGenerator FactoryMethod(int init);
        }

        class ConstGenerator : IGenerator
        {
            private int _a;

            public int Next => _a;

            public ConstGenerator(int init = 0)
            {
                _a = init;
            }
        }

        class CounterGenerator : IGenerator
        {
            private int _a;

            public int Next => ++_a;

            public CounterGenerator(int init = 0)
            {
                _a = init;
            }
        }

        class ConstGeneratorFabric : IGeneratorFabric
        {
            public IGenerator FactoryMethod(int init)
            {
                return new ConstGenerator(init);
            }
        }

        class CounterGeneratorFabric : IGeneratorFabric
        {
            public IGenerator FactoryMethod(int init)
            {
                return new CounterGenerator(init);
            }
        }
    }
}