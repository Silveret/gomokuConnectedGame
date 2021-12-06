using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform4Gomoku
{
    class BlackPiece:Piece//繼承piece
    {
        public BlackPiece(int x, int y) : base(x, y)//將黑子的值傳回給piece
        {
            this.Image = Client.Properties.Resources.black;//將專案資源黑子匯入
        }
        public override PieceType GetPieceType()
        {
            return PieceType.Black;
        }
    }
}
