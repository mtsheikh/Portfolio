using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using mdtypes;
using System.Net;
using System.Net.Sockets;
using static System.Diagnostics.Trace;
using System.Threading;
using System.Drawing;

 namespace genericSocket
{
    public class GenericSocket
    {
        object key = null;
        public delegate void delVoidObj(object o);
        delVoidObj _goodDel = null;
        delVoidObj _errorIndicator = null;
        Thread _ThreadStuff = null;
        Queue<object> rx;
        Queue<object> tx;
        Socket sock = null;

        double _recieve;
        double _fragment;
        int byteValue;
        volatile bool running = false;

        public bool ProgramRunning
        {
            get
            {
                return running;
            }
            set
            {
                running = value;
            }
        }

        public double GetReceives { get { return _recieve; } }
        public double GetFragments { get { return _fragment; } }

        public int GetBytes { get { return byteValue; } }

        public object EnqueueStuff
        {
            set
            {
                lock (key)
                    tx.Enqueue(value);
            }
        }

        public GenericSocket(delVoidObj a, delVoidObj b, Socket sock)
        {
            _goodDel = a; 
            _errorIndicator = b; 
            rx = new Queue<object>();
            tx = new Queue<object>();
            this.sock = sock;
            key = new object();
            StartThreads();
            WriteLine("IN GENERIC CTR");
        }

        public void StartThreads()
        {
            ProgramRunning = true;

            _ThreadStuff = new Thread(ReceiveData);
            _ThreadStuff.IsBackground = true;
            _ThreadStuff.Start();

            _ThreadStuff = new Thread(SendData);
            _ThreadStuff.IsBackground = true;
            _ThreadStuff.Start();

            _ThreadStuff = new Thread(ProcessData);
            _ThreadStuff.IsBackground = true;
            _ThreadStuff.Start();
        }

        private void ReceiveData()
        {
            int numBytes = 0;
            byte[] buffer = new byte[65535];
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            //WriteLine("RECEIVING DATA THREAD RUNNING");

            while (running)
            {
                try
                {
                    numBytes = sock.Receive(buffer);

                    if (numBytes == 0)
                    {
                       // WriteLine("SOFT DISCONNECT DETECTED");
                        lock (key)
                            rx.Enqueue(Tuple.Create(new Exception("Soft Disconnect!"), this));
                        break;
                    }

                    _recieve++;
                    byteValue += numBytes;

                    long lastPos = ms.Position;
                    ms.Seek(0, SeekOrigin.End);
                    ms.Write(buffer, 0, numBytes);
                    ms.Position = lastPos;

                    do
                    {
                        long startPos = ms.Position;

                        try
                        {
                            object o = bf.Deserialize(ms);
                            lock (key)
                                rx.Enqueue(o);
                        }
                        catch (SerializationException e)
                        {
                            ms.Position = startPos;
                            _fragment++;
                            WriteLine(e.Message);
                            break;
                        }
                    }
                    while (ms.Position < ms.Length);

                    if (ms.Position == ms.Length)
                    {
                        ms.Position = 0;
                        ms.SetLength(0);
                    }
                }
                catch (Exception ex)
                {
                    //WriteLine("ERROR IN RECEIVE DATA: " + ex.Message);
                    lock (key)
                        rx.Enqueue(Tuple.Create(new Exception("Soft Disconnect!"), this));
                    break;
                }
            }
        }

        private void SendData()
        {
            object key = new object();

            //WriteLine("SEND DATA THREAD RUNNING");

            while (running)
            {
                if (tx.Count > 0)
                {
                    lock (this.key)
                        key = tx.Dequeue();

                    MemoryStream ms = new MemoryStream();
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(ms, key);
                    try
                    {
                        sock.Send(ms.GetBuffer(), 0, (int)ms.Length, SocketFlags.None);
                    }
                    catch (Exception ex)
                    {
                        lock (this.key)
                            rx.Enqueue(ex);
                        //WriteLine("Error in Sending: " + ex.Message);
                    }

                }
                else
                    Thread.Sleep(0);
            }
        }

        private void ProcessData()
        {
            object holder = new object();

           //WriteLine("PROCESS DATA THREAD RUNNING");

            while (running)
            {
                if (rx.Count > 0)
                {
                    lock (key)
                        holder = rx.Dequeue();

                    if (holder is Tuple<Exception, GenericSocket>)
                    {
                        _errorIndicator?.Invoke(holder);
                        ProgramRunning = false;
                        break;
                    }
                    else
                        _goodDel?.Invoke(holder);
                }
                else
                    Thread.Sleep(0);
            }
        }
    }
}
