﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace winform4Gomoku
{
    abstract class Piece : PictureBox//abstract防止錯誤
    {
        private static readonly int IMAGE_WIDTH = 50;

        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x- IMAGE_WIDTH/2, y- IMAGE_WIDTH/2);//對齊點點
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
        }
        public abstract PieceType GetPieceType();
        
    }
}
