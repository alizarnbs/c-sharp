using System;
namespace SingletonDesignPattern
{
    public sealed class Singleton
    {
        private static Singleton instance = null; //initially null
        private Singleton()
        {
            Console.WriteLine("Singleton constructor called!");
        }

        public static Singleton CreateInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
