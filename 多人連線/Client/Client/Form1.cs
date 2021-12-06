using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using winform4Gomoku;

namespace Client
{
    public partial class Form1 : Form
    {

        #region Gglobal Variable
        Socket socketClient;
        Thread listenThread;
        IPEndPoint EP;
        byte[] data = new byte[10024];
        bool IsConnect;
        bool isMessage2ALL = true;
        private Game game = new Game();
        Board board = new Board();
        string[] hope;
        int[] like = {0,0};
        #endregion
        #region Form Evens
        public Form1()
        {
            InitializeComponent();
        }

        private void clientForm_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void clientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(entry_Btn.Enabled == false)
            {
                socketSend("logout," + nickname_TB.Text + ",");
                socketClient.Close();
            }
        }

        private void message_TB_KeyUp(object sender, KeyEventArgs e)//傳訊息
        {           
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (message_TB.Text != "")
                    {
                        if (isMessage2ALL)
                        {
                            socketSend("message2All," + nickname_TB.Text + " : " + message_TB.Text + ",");
                            //呼叫 socketsend 方法
                           
                        }
                        else if (!isMessage2ALL)
                        {
                            socketSend("DM," + nickname_TB.Text + "," + DM2_Lab.Text + "," + nickname_TB.Text + " DM to " + DM2_Lab.Text + " : " + message_TB.Text + ",");      //呼叫 socketsend 方法
                        }
                        message_TB.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void entry_Btn_Click(object sender, EventArgs e)//連接的小玩意兒
        {
            try
            {
                if(serverIP_TB.Text != "" && port_TB.Text != "" && nickname_TB.Text != "")      //checking TB != ""
                {
                    socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    EP = new IPEndPoint(IPAddress.Parse(serverIP_TB.Text), int.Parse(port_TB.Text));
                    socketClient.Connect(EP);
                    listenThread = new Thread(socketReceive);
                    listenThread.IsBackground = true;
                    listenThread.Start();
                    IsConnect = true;
                    socketSend("login," + nickname_TB.Text + ",");

                    serverIP_TB.Enabled = false;
                    port_TB.Enabled = false;
                    nickname_TB.Enabled = false;
                    entry_Btn.Enabled = false;
                }
                else
                {
                    MessageBox.Show("別搞事");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DMoff_Click(object sender, EventArgs e)
        {
            DM2_Lab.Text = "";
            DMoff.Enabled = false;
            DMon.Enabled = true;
            isMessage2ALL = true;
        }

        private void DMon_Click(object sender, EventArgs e)
        {
            if (onlineList_LB.SelectedIndex != -1 && onlineList_LB.GetItemText(onlineList_LB.SelectedItem) != nickname_TB.Text)
            {
                DM2_Lab.Text = onlineList_LB.GetItemText(onlineList_LB.SelectedItem);
                DMoff.Enabled = true;
                DMon.Enabled = false;
                isMessage2ALL = false;
            }
        }
        #endregion

        #region receive
        public void Receive(string recvData) //接收並判斷資料
        {
            try
            {
                char token = ',';
                char token2 = ';';
                string[] pt = recvData.Split(token);        //將接收資料用 , 切割並存入陣列
                switch (pt[0])      //使用陣列中第一筆資料溝通
                {
                    case "message":
                        log_LB.Items.Add(pt[1]);
                        hope = pt[1].Split(token2);
                        int a = int.Parse(hope[0]);
                        int b = int.Parse(hope[1]);
                        piece(a, b);                    
                        break;
                    case "DM":
                        log_LB.Items.Add(pt[1]);
                        break;
                    case "deny":
                        log_LB.Items.Add("[System] : 暱稱重複，請重新輸入");

                        serverIP_TB.Enabled = true;
                        port_TB.Enabled = true;
                        nickname_TB.Enabled = true;
                        entry_Btn.Enabled = true;
                        break;
                    case "list":
                        onlineList_LB.Items.Clear();
                        for (int i = 1; i < pt.Length; i++)
                        {
                            onlineList_LB.Items.Add(pt[i]);
                        }
                        break;                                    
                }
                Array.Clear(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Socket
        public void socketReceive()//收訊息
        {
            int recvLength = 0;
            try
            {
                do
                {
                    recvLength = socketClient.Receive(data);
                    if (recvLength > 0)
                    {
                        Receive(Encoding.Default.GetString(data).Trim());       //將接收到的 byte 資料 轉換成 string 並呼叫 receive 方法
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void socketSend(string sendData)//傳訊息在用
        {
            if (IsConnect)
            {
                try
                {
                    socketClient.Send(Encoding.Default.GetBytes(sendData));     //將要傳送的 string 資料 轉換成 byte 傳送出去
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                log_LB.Items.Add("遊戲已斷線");
            }
        }
        #endregion

       private void Form1_KeyUp(object sender, KeyEventArgs e)//用不到
        {/* 
            switch(e.KeyCode)
            {
                case Keys.W:
                    socketSend("ctrl,W,");
                    break;
                case Keys.S:
                    socketSend("ctrl,S,");
                    break;
                case Keys.A:
                    socketSend("ctrl,A,");
                    break;
                case Keys.D:
                    socketSend("ctrl,D,");
                    break;
            }*/
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            socketSend("message2All,"+e.X.ToString()+";"+e.Y.ToString());
            //Piece piece = game.PlaceAPiece(int.Parse(txtshow.Text), int.Parse(txtshow1.Text));
            //if (piece != null)
            //{
            //    this.Controls.Add(piece);

            //    //檢查是否有人獲勝
            //    if (game.Winner == PieceType.Black)
            //    {
            //        MessageBox.Show("黑色獲勝");
            //    }
            //    else if (game.Winner == PieceType.White)
            //    {
            //        MessageBox.Show("白色獲勝");
            //    }
            //}
        }
        private void piece(int a ,int b)
        {

            Piece piece = game.PlaceAPiece(a, b);
            if (piece != null)
            {
                this.Invoke(new EventHandler(delegate
                {
                    this.Controls.Add(piece);
                }));
            
                //檢查是否有人獲勝
                if (game.Winner == PieceType.Black)
                {
                    MessageBox.Show("黑色獲勝");
                }
                else if (game.Winner == PieceType.White)
                {
                    MessageBox.Show("白色獲勝");
                }
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }        
        }
    }
}