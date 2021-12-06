using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace Server
{
    public partial class serverForm : Form
    {
        #region 全域變數
        TcpListener server;             //伺服器端接收器
        Hashtable HT = new Hashtable(); //宣告雜湊表
        Socket socketClient;            //建立 socket 物件
        Thread Th_Svr, Th_Clt;          //宣告兩個子執行續處理接聽
        #endregion

        #region Form 事件
        public serverForm()
        {
            InitializeComponent();
        }
        private void serverForm_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            //在程式一開始被執行時忽略跨執行緒的錯誤
        }
        private void serverForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            breakConnection();      //呼叫關閉方法
            //form 關閉前事件
        }
        private void connectBtn_Click(object sender, EventArgs e)
        {
            //按下"建立連線"時
            try
            {
                Th_Svr = new Thread(ServerSub);     //執行緒啟動監聽
                Th_Svr.IsBackground = true;         //啟動，最大接收數量100
                Th_Svr.Start();                     //執行緒啟動 

                //log_LB新增"伺服器Socket建立完成！"之訊息
                log_LB.Items.Add("伺服器Socket建立完成！");
                log_LB.Update();
                connectBtn.Enabled = false;
                disconnectBtn.Enabled = true;
                ip_TB.Enabled = false;
                port_TB.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //若上方程式出錯則呼叫錯誤訊息
            }
        }



        //disconnect Btn 點擊事件
        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            log_LB.Items.Add("[System] : 伺服器中斷。");
            connectBtn.Enabled = true;
            disconnectBtn.Enabled = false;
        }



        private void logLBAdd(string type, string ifo)
        {
            log_LB.Items.Add("[" + type + "] : " + ifo);
            //新增文字在log_LB的函式
        }
        #endregion

        #region 關閉處理
        private void breakConnection()
        {
            try
            {
                Application.ExitThread();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 通訊程式
        private void ServerSub()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(ip_TB.Text), int.Parse(port_TB.Text));
            server = new TcpListener(EP);       //建立伺服器端接收器(總機)
            server.Start(100);                  //啟動，最大接收數量100


            //無限迴圈
            while (true)
            {
                socketClient = server.AcceptSocket();//接收連接要求
                /*
                    每當有一台client與自己(server)做連接並且傳送訊息
                    此socketClient就會成為與那台client連接的通道
                    而之後若又有另一台client做連接此socketClient便會被覆蓋
                 */
                Th_Clt = new Thread(listen);        //執行緒啟動監聽
                Th_Clt.IsBackground = true;         //背景執行，背景執行緒不會防止進程終止
                Th_Clt.Start();                     //執行緒啟動
            }
        }

        private void listen()
        {
            Socket sck = socketClient;              //將此socket儲存起來
            Thread Th = Th_Clt;                     //將此執行續儲存起來
            string id = null;                       //宣告一個

            while (true)
            {
                byte[] B = new byte[1023];          //建立變數B
                try
                {
                    int inLen = sck.Receive(B);     //收到的訊息放至inLen
                    //切割、整理收到的訊息
                    string[] Msg = Encoding.Default.GetString(B, 0, inLen).Split(',');
                    //利用switch case判斷並處理訊息
                    switch (Msg[0])
                    {
                        case "message2All":
                            logLBAdd("MessageAll", Msg[1]);
                            sendAll("message," + Msg[1]);
                            break;
                        case "DM":
                            logLBAdd("DM", Msg[3]);
                            sendTo(Msg[1], "DM," + Msg[3]);
                            sendTo(Msg[2], "DM," + Msg[3]);
                            break;
                        case "login":
                            try
                            {
                                HT.Add(Msg[1], sck);
                                id = Msg[1];
                                onlineList_LB.Items.Add(Msg[1]);
                                logLBAdd("Login", Msg[1]);
                                sendAll(onlineList());
                            }
                            catch
                            {
                                sendTo("deny,", sck);
                            }
                            break;
                        case "logout":
                            HT.Remove(Msg[1]);
                            onlineList_LB.Items.Remove(Msg[1]);
                            sendAll(onlineList());
                            Th.Abort();
                            break;
                        case "ctrl":
                            sendAll("ctrl," + Msg[1] + ",");
                            break;                      
                    }
                }
                catch
                {
                    logLBAdd("Crash", id);
                    sendAll("message," + id + "logout.");
                }
            }
        }

        private string onlineList()
        {
            string list = "list,";
            for (int i = 0; i < onlineList_LB.Items.Count; i++)
            {
                list += onlineList_LB.Items[i] + ",";
            }
            return list;
        }
        #endregion

        #region send function
        private void sendTo(string user, string str)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            Socket sck = (Socket)HT[user];
            sck.Send(B, 0, B.Length, SocketFlags.None);
        }
        private void sendTo(string str, Socket sck)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            sck.Send(B, 0, B.Length, SocketFlags.None);
        }

        private void sendAll(string str)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            foreach (Socket s in HT.Values)
            {
                s.Send(B, 0, B.Length, SocketFlags.None);
            }
        }
        #endregion
    }
}
