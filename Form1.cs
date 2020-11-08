using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace itv
{
    public partial class Form1 : Form
    {
        private DrawTriangle drawTriangle;
        public Form1()
        {

            InitializeComponent();
            drawTriangle = new DrawTriangle(Holst);
            this.Load += (s, e) => { drawTriangle.Draw(); };
            this.Text = drawTriangle.ColorCount.ToString();
        }

        
      
    }
}
