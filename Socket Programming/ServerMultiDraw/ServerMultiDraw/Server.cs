using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Diagnostics.Trace;
using System.Threading;
using mdtypes;
using genericSocket;

namespace ServerMultiDraw
{
    public partial class Server : Form
    {
        Socket _listen = null;
        Thread _listening = null;
        Thread _stats = null;

        volatile bool isRunning;

        Dictionary<GenericSocket, object[]> _connections;

        public delegate void delVoidObj(object o);
        delVoidObj Draw = null;
        delVoidObj Error = null;

        Object Key = null;

        int _totBytes;
        int _totFrames;

        public Server()
        {
            InitializeComponent();
            isRunning = true;

            _connections = new Dictionary<GenericSocket, object[]>();

            Draw = new delVoidObj(HandleDraw);
            Error = new delVoidObj(HandleError);

            Key = new object();

            try
            {
                _listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _listen.Bind(new IPEndPoint(IPAddress.Any, 1666));
                _listen.Listen(10);
            }
            catch (Exception ex)
            {
                //WriteLine("LISTENER CTOR ERR: " + ex.Message);
            }

            _listening = new Thread(ListeningProcess);
            _listening.IsBackground = true;
            _listening.Start();

            _stats = new Thread(GetStats);
            _stats.IsBackground = true;
            _stats.Start();

            _totBytes = 0;
            _totFrames = 0;
        }


        public void ListeningProcess()
        {
            while (isRunning)
            {
                try
                {
                    Socket accepted = _listen.Accept();
                    IPEndPoint remoteIP = accepted.RemoteEndPoint as IPEndPoint;
                    object[] stats = new object[5];

                    for (int i = 0; i < stats.Length; i++)
                        stats[i] = 0;

                    GenericSocket genSock = new GenericSocket(HandleDraw, HandleError, accepted); 

                    stats[0] = remoteIP.Address.ToString();

                    lock (Key)
                        _connections.Add(genSock, stats);
                }
                catch (Exception ex)
                {
                    //WriteLine("LISTENER ERR: " + ex.Message);
                }

                Thread.Sleep(0);
            }
        }

        public void HandleDraw(object o)
        {
            lock (Key)
                foreach (var v in _connections.Keys)
                    v.EnqueueStuff = o;
        }


        public void HandleError(object o)
        {
            Tuple<Exception, GenericSocket> unpacked = (Tuple<Exception, GenericSocket>)o;

            lock (Key)
                _connections.Remove(unpacked.Item2);

            WriteLine("UNPACKED ERR: " + unpacked.Item1.Message);
        }


        private void GetStats()
        {
            while (isRunning)
            {
                lock (Key)
                    foreach (var v in _connections.Keys)
                    {
                        if ((int)_connections[v][4] != v.GetBytes)
                            _totBytes += v.GetBytes - (int)_connections[v][4];

                        if ((int)_connections[v][1] != v.GetReceives)
                            _totFrames += (int)v.GetReceives - (int)_connections[v][1];

                        _connections[v][1] = (int)v.GetReceives;
                        _connections[v][2] = v.GetFragments != 0 ? (v.GetReceives / v.GetFragments) : 0;
                        _connections[v][3] = (int)v.GetFragments;
                        _connections[v][4] = v.GetBytes;
                    }

                try
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        UI_LSB_Connections.Items.Clear();
                        UI_LBL_TBytes.Text = "Total Bytes: " + BetterUnits(_totBytes);
                        UI_LBL_TFrames.Text = "Total Frames: " + BetterUnits(_totFrames);

                        lock (Key)
                            if (_connections.Count == 0)
                            {
                                UI_LSB_Connections.Items.Clear();
                            }
                    }));
                }
                catch (Exception ex)
                {
                    WriteLine("DISPOSING: " + ex.Message);
                }

                lock (Key) 
                    foreach (var v in _connections.Keys)
                        Invoke((MethodInvoker)(() => UI_LSB_Connections.Items.Add("IP " + _connections[v][0] + " : " +
                            BetterUnits((int)_connections[v][1]) + " frames, "
                            + _connections[v][2] + ".00 destacks, "
                            + BetterUnits((int)_connections[v][3]) + " fragments")));

                Thread.Sleep(50); 
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
        }


        private string BetterUnits(int number)
        {
            double toUnit = number;
            int count = 0;

            while (toUnit > 1000)
            {
                toUnit /= 1000;
                count++;
            }
            if (count == 1)
                return toUnit.ToString("N2") + " K";
            else if (count == 2)
                return toUnit.ToString("N2") + " M";
            else if (count == 3)
                return toUnit.ToString("N2") + " B";

            return toUnit.ToString("N2");
        }
    }
}