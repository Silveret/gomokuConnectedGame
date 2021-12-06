using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform4Gomoku
{
    class Game
    {
        private Board board = new Board();

        private PieceType currentPlayer = PieceType.Black;

        private PieceType winner = PieceType.None;

        public PieceType Winner { get { return winner; } }
        public int[,] countPieceRecord = new int[3, 3]; // 紀錄八個方向相同顏色棋子個數
        public bool CanBePlaced(int x, int y)
        {
            return board.CanbePlaced(x, y);
        }
        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                //檢查是否現在下棋的獲勝
                CheckWinner();

                //交換選手
                if (currentPlayer == PieceType.Black)
                {
                    currentPlayer = PieceType.White;
                }
                else
                {
                    currentPlayer = PieceType.Black;
                }
                return piece;
            }
            return null;
        }
        // 判斷有無連線
        private void CheckWinner()
        {
            int centerX = board.LastPlaceNode.X;
            int centerY = board.LastPlaceNode.Y;

            // 檢查八個方向
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    // 排除檢查自己(中心)
                    if (xDir == 0 && yDir == 0)
                        continue;

                    // 紀錄相同顏色棋子個數
                    int count = 1;

                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        //Console.WriteLine("targetX:" + targetX);
                        // Console.WriteLine("targetY:" + targetY);


                        // 檢查顏色是否相同
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                        targetY < 0 || targetY >= Board.NODE_COUNT ||
                        board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;
                        count++;

                    }

                    countPieceRecord[xDir + 1, yDir + 1] = count - 1;


                    if (isWinnerExist(countPieceRecord))
                        winner = currentPlayer;
                }

            }


        }

        //check winner exist or not
        private bool isWinnerExist(int[,] record)
        {
            // int recordCenter_X = 1;
            // int recordCenter_Y = 1;

            int result1 = record[0, 1] + record[2, 1]; // 橫
            int result2 = record[1, 0] + record[1, 2]; // 直
            int result3 = record[0, 2] + record[2, 0]; // 斜
            int result4 = record[0, 0] + record[2, 2]; // 反斜

            if (result1 == 4 ||
            result2 == 4 ||
            result3 == 4 ||
            result4 == 4)
            {
                // winner exist
                return true;
            }


            return false;
        }
    }
}
