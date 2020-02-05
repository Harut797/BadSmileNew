using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
            //this.Refresh();
        }




        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            string message = "Don't touch me";
            string title = "Vernagir";
            Cursor.Position = new Point(0, 0);
            MessageBox.Show(message, title);
        }
    }
}
