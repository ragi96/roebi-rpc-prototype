using System.Text;
using System.Net.Sockets;

try
{
    Console.WriteLine("Connect to an RPC Server and send a string");
    TcpClient Tcpclient = new TcpClient();
    bool end = false;
    while (!end) { 
         Console.WriteLine("\n\rEnter IP for Connection:");
         string ip = Console.ReadLine() ?? "";
         Console.WriteLine("Enter Port:");
         int port = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Connecting");
         Tcpclient.Connect(ip, port);
         Console.WriteLine("Connected");
         Console.WriteLine("Ente the String you want to send ");
         string str = Console.ReadLine() ?? "";
         Stream stm = Tcpclient.GetStream();
         ASCIIEncoding ascnd = new();
         byte[] ba = ascnd.GetBytes(str);
         Console.WriteLine("Sending..");
         stm.Write(ba, 0, ba.Length);
         byte[] bb = new byte[100];
         int k = stm.Read(bb, 0, 100);
         for (int i = 0; i < k; i++)
         {
             Console.Write(Convert.ToChar(bb[i]));
         }

         Tcpclient.Close();
         Console.WriteLine("Restart? [y/n]");
        ConsoleKeyInfo ckey = Console.ReadKey();

        if (ckey.Key.ToString() == "y")
        {
            end = true;
        }
    }
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine("Error" + ex.StackTrace);
}
