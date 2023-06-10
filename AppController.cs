using System;
using System.IO;

namespace CSharpDistApp
{
    class AppController
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            // Check for correct usage
            if (args.Length != 2)
            {
                Console.WriteLine("Usage Error: dotnet run <port number> <file name>");
                Environment.Exit(1);
            }

            // Retrieve the port number and file name from the command-line arguments
            int port_number = Int32.Parse(args[0]);
            string file_name = args[1];

            // Access the dataset file for processing
            try
            {
                FileStream file_stream = File.Open(file_name, FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Error: \"{0}\" file could not be found", file_name);
            }
            

        }
    }
}
