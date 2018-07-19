using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Server
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"c:\poker\vote.txt");
            sw.Write("");
            sw.Close();                    
            //---listen at the specified IP and port no.---           
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);      
            Console.WriteLine("Listening...");
            listener.Start();
            while (true)
            {            
                //connect client
                TcpClient client = listener.AcceptTcpClient();
                //get the data with networkstream
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];
                //read the incoming stream
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                nwStream.Write(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);
                using (StreamWriter w = File.AppendText(@"c:\poker\vote.txt"))
                {                    
                    w.WriteLine(dataReceived);
                    w.Flush();
                    w.Close();
                }                
                using (StreamReader reader = new StreamReader(@"c:\poker\vote.txt"))
                {
                    int myInteger;
                    string line;
                    Sort lists = new Sort();
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] items = line.Split('\t');
                        string path = null;
                        myInteger = int.Parse(items[0]); //parsed                        
                        foreach (string item in items)
                        {
                            if (item.StartsWith("item\\") && item.EndsWith(".ddj"))
                                path = item;
                        }
                        lists.lists.Add(myInteger);                    
                        var avg = lists.lists.Average();
                        Sort Listing = new Sort();
                        if (lists.lists.Capacity == 4) //error vara count olarak değiştir
                        {
                            for (int i = 0; i < lists.lists.Count - 1; i++)
                            {
                                for (int j = i + 1; j < lists.lists.Count; j++)
                                {
                                    if (Math.Abs(lists.fibonacci.FindIndex(x => x == lists.lists[i]) - lists.fibonacci.FindIndex(x => x == lists.lists[j])) > 1)
                                    {  
                                        Console.WriteLine("Need to Start Revote");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Voting Is Succeed");
                                    }
                                }
                            }    
                        }
                    }                                                              
                }              
            }
        }
    }
}

 
     






