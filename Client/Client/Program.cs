using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{ 
    public class Counter
    {        
            public static int UserCounter { get; set; }
            static int sayim()
            {
                UserCounter = 1;
                return UserCounter++;
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            const int PORT_NO = 5000;
            const string SERVER_IP = "127.0.0.1";            
            {
                while (true)
                {                                    
                    Counter Usercounter = new Counter();
                    while (Counter.UserCounter< 4)   //made usercounter just to vote from one console
                    {                        
                        //---create a TCPClient object at the IP and port no.---
                        TcpClient client = new TcpClient(SERVER_IP, PORT_NO);                       
                        NetworkStream nwStream = client.GetStream();
                        Console.WriteLine(" 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55");
                        Console.WriteLine("Please Type Your Vote");
                        Counter.UserCounter++;                        
                        string TextToSend = Console.ReadLine();          
                        //---data to send to the server---
                            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(TextToSend);                      
                            //---send the text---                
                            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                            nwStream.Flush();
                            //---read back the text---
                            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);                                                           
                        Console.ReadLine();
                        client.Close();
                    }
                }
            }
        }
    }
}

     
    

