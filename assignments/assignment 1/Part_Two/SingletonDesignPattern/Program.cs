using System;

namespace SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance1 = Singleton.CreateInstance;
            instance1.PrintMessage("Singleton instance 1");

            Singleton instance2 = Singleton.CreateInstance;
            instance2.PrintMessage("Singleton instance 2");
        }
    }
}
