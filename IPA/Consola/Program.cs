using System;
using CoreLibrary;
using System.Collections.Generic;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IPA";
            
            Mock mock = new Mock("cmudict/cmudict.dict");

            try
            {
                mock.Mocking();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Finish!");
            Console.ReadKey();
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
