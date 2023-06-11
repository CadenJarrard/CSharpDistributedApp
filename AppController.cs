using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

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

            // Start the data slicing thread

            // Create the server socket and listen for incoming connections
            Socket? server_socket = null;
            try
            {
                // Instantiate server_socket to IPv4 address using TCP protocol
                server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Create an IPEndPoint and bind to the server_socket
                IPAddress server_ipAddress = IPAddress.Parse("127.0.0.1");
                server_socket.Bind(new IPEndPoint(server_ipAddress, port_number));

                // Designate for the server_socket to begin listening for incoming connections
                server_socket.Listen();
                Console.WriteLine("Server listening for incoming connections on port# {0}", port_number);
                
            }
            finally // Release resources used by server_socket
            {
                if (server_socket != null)
                {
                    server_socket.Close();
                }
            }
            

        }
    }
}
