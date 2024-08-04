using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Peer
{
    private TcpListener listener;
    private List<TcpClient> peers;
    private readonly int port;

    public Peer(int port)
    {
        this.port = port;
        this.peers = new List<TcpClient>();
        this.listener = new TcpListener(IPAddress.Any, port);
    }

    public void Start()
    {
        listener.Start();
        Console.WriteLine($"Listening on port {port}");
        Thread acceptThread = new Thread(AcceptPeers);
        acceptThread.Start();
        Thread sendThread = new Thread(SendMessages);
        sendThread.Start();
    }

    private void AcceptPeers()
    {
        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            lock (peers)
            {
                peers.Add(client);
            }
            Console.WriteLine($"Connected to {client.Client.RemoteEndPoint}");
            Thread receiveThread = new Thread(() => ReceiveMessages(client));
            receiveThread.Start();
        }
    }

    private void ReceiveMessages(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine(message);
            Broadcast(message, client);
        }
        lock (peers)
        {
            peers.Remove(client);
        }
    }

    private void Broadcast(string message, TcpClient excludeClient)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        lock (peers)
        {
            foreach (TcpClient client in peers)
            {
                if (client != excludeClient)
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }

    private void SendMessages()
    {
        while (true)
        {
            string message = Console.ReadLine();
            Broadcast(message, null);
        }
    }

    public void Connect(TcpClient client)
    {
        lock (peers)
        {
            peers.Add(client);
        }
        Console.WriteLine($"Connected to {client.Client.RemoteEndPoint}");
        Thread receiveThread = new Thread(() => ReceiveMessages(client));
        receiveThread.Start();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter port to listen on: ");
        int port = int.Parse(Console.ReadLine());
        Peer peer = new Peer(port);
        peer.Start();

        Console.Write("Enter peer to connect to (host:port): ");
        string peerAddress = Console.ReadLine();
        if (!string.IsNullOrEmpty(peerAddress))
        {
            string[] parts = peerAddress.Split(':');
            string host = parts[0];
            int peerPort = int.Parse(parts[1]);

            TcpClient client = new TcpClient(host, peerPort);
            peer.Connect(client);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}