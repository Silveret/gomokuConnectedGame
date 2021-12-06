using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace winform4Gomoku
{
    class Board
    {
        public static readonly int NODE_COUNT = 9;
        private static readonly Point NO_MATCH_NODE = new Point(-1,-1);
        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;
        public Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];
        public int CoordinateX;
        public int CoordinateY;
        private Point lastPlaceNode = NO_MATCH_NODE;
        public Point LastPlaceNode { get { return lastPlaceNode; } }
        public int[] aa = new int[2];
        public PieceType GetPieceType(int nodeIDX, int nodeIDY)
        {
            if (pieces[nodeIDX, nodeIDY] == null)
            {
                return PieceType.None;
            }
            return pieces[nodeIDX, nodeIDY].GetPieceType();        
        }
        public bool CanbePlaced(int x,int y)
        {
            //找出最近的節點(NODE)
            Point nodeID = findTheCloseNode(x, y);
            //如果沒有的話，回傳false
            if (nodeID == NO_MATCH_NODE)
            {
                return false;
            }
            //TODO:如果沒有的話，檢查是否已經有棋子的存在
            if (pieces[nodeID.X, nodeID.Y] != null)
            {
                return false;
            }
            return true;
        }
        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            //找出最近的節點(NODE)
            Point nodeID = findTheCloseNode(x, y);
            //如果沒有的話，回傳false
            if (nodeID == NO_MATCH_NODE)
            {
                return null;
            }
            //如果沒有的話，檢查是否已經有棋子的存在
            if (pieces[nodeID.X, nodeID.Y] != null)
            {
                return null;
            }
            //根據type產生對應的棋子
            Point formPos = converFormPosition(nodeID);
            if (type == PieceType.Black)
            {
                pieces[nodeID.X, nodeID.Y] = new BlackPiece(formPos.X, formPos.Y);
            }
            else
            {
                pieces[nodeID.X, nodeID.Y] = new WhitePiece(formPos.X, formPos.Y);
            }
            //紀錄最後下棋子的位置
            lastPlaceNode = nodeID;               
            return pieces[nodeID.X, nodeID.Y];
        } 
        public Point converFormPosition(Point nodeID)
        {
            Point formPosition = new Point();
            formPosition.X = nodeID.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeID.Y * NODE_DISTANCE + OFFSET;
            return formPosition;
        }

        private Point findTheCloseNode(int x, int y)//判斷2維座標
        {
            int nodeIDX = findTheCloseNode(x);
            if (nodeIDX==-1||nodeIDX>=NODE_COUNT)
            {
                return NO_MATCH_NODE;
            }

            int nodeIDY = findTheCloseNode(y);
            if (nodeIDY == -1||nodeIDY>=NODE_COUNT)
            {
                return NO_MATCH_NODE;
            }
            CoordinateX = findTheCloseNode(x); 
            CoordinateX = findTheCloseNode(y);
          
            return new Point(nodeIDX, nodeIDY);
        }
        private int findTheCloseNode(int pos)//判斷1維座標
        {
            if (pos < OFFSET - NODE_RADIUS)
            {
                return -1;
            }
            pos -= OFFSET;

            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;

            if(remainder<=NODE_RADIUS)
            {
                return quotient;
            }
            else if(remainder>=NODE_DISTANCE-NODE_RADIUS)
            {
                return quotient + 1;
            }
            else
            {
                return -1;
            }

        }

    }
}
