using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDisplayClient
{
    public partial class Form1 : Form
    {

        public delegate void ShowImageDelegate(string index);
        ShowImageDelegate handler;

        public Form1()
        {
            InitializeComponent();
            handler = ShowImageInvoke;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            Global.SetForm(this);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void ShowImageInvoke(string index)
        {
            switch (index)
            {
                case "0":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._0;
                    break;
                case "1":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._1;
                    break;
                case "2":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._2;
                    break;
                case "3":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._3;
                    break;
                case "4":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._4;
                    break;
                case "5":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._5;
                    break;
                case "6":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._6;
                    break;
                case "7":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._7;
                    break;
                case "8":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._8;
                    break;
                case "9":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._9;
                    break;
                case "10":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._10;
                    break;
                case "11":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._11;
                    break;
                case "black":
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources.black;
                    break;
                default:
                    pictureBox1.Image = ImageDisplayClient.Properties.Resources._0;
                    break;
            }
            
        }


        public void ShowImage(string index)
        {
            this.Invoke(handler, index);
        }
    }
}
