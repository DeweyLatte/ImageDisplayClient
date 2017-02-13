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
            if(Global.myProjNumber == "1")
                this.pictureBox1.Image = global::ImageDisplayClient.Properties.Resources.IM_1_1;
            else if (Global.myProjNumber == "2")
                this.pictureBox1.Image = global::ImageDisplayClient.Properties.Resources.IM_1_1;
            else if (Global.myProjNumber == "3")
                this.pictureBox1.Image = global::ImageDisplayClient.Properties.Resources.IM_1_1;
            else if (Global.myProjNumber == "4")
                this.pictureBox1.Image = global::ImageDisplayClient.Properties.Resources.IM_1_1;
            Global.SetForm(this);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Global.closing = true;
                this.Close();
            }
                
        }
        private void ShowImageInvoke(string index)
        {
            if(Global.myProjNumber == "1")
            {
                switch (index)
                {
                    case "0":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    case "1":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_1;
                        break;
                    case "2":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_2;
                        break;
                    case "3":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_3;
                        break;
                    case "4":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_4;
                        break;
                    case "5":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_5;
                        break;
                    case "6":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_6;
                        break;
                    case "7":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_7;
                        break;
                    case "8":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_8;
                        break;
                    case "9":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_9;
                        break;
                    case "10":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_10;
                        break;
                    case "11":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_11;
                        break;
                    case "black":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.black;
                        break;
                    case "white":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.white;
                        break;
                    case "gray":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.gray;
                        break;
                    case "intro":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    default:
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                }
            }
            else if (Global.myProjNumber == "2")
            {
                switch (index)
                {
                    case "0":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    case "1":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_1;
                        break;
                    case "2":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_2;
                        break;
                    case "3":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_3;
                        break;
                    case "4":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_4;
                        break;
                    case "5":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_5;
                        break;
                    case "6":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_6;
                        break;
                    case "7":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_7;
                        break;
                    case "8":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_8;
                        break;
                    case "9":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_9;
                        break;
                    case "10":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_10;
                        break;
                    case "11":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_11;
                        break;
                    case "black":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.black;
                        break;
                    case "white":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.white;
                        break;
                    case "gray":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.gray;
                        break;
                    case "intro":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    default:
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                }
            }
            else if (Global.myProjNumber == "3")
            {
                switch (index)
                {
                    case "0":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    case "1":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_1;
                        break;
                    case "2":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_2;
                        break;
                    case "3":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_3;
                        break;
                    case "4":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_4;
                        break;
                    case "5":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_5;
                        break;
                    case "6":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_6;
                        break;
                    case "7":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_7;
                        break;
                    case "8":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_8;
                        break;
                    case "9":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_9;
                        break;
                    case "10":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_10;
                        break;
                    case "11":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_11;
                        break;
                    case "black":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.black;
                        break;
                    case "white":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.white;
                        break;
                    case "gray":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.gray;
                        break;
                    case "intro":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    default:
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                }
            }
            else if (Global.myProjNumber == "4")
            {
                switch (index)
                {
                    case "0":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    case "1":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_1;
                        break;
                    case "2":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_2;
                        break;
                    case "3":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_3;
                        break;
                    case "4":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_4;
                        break;
                    case "5":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_5;
                        break;
                    case "6":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_6;
                        break;
                    case "7":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_7;
                        break;
                    case "8":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_8;
                        break;
                    case "9":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_9;
                        break;
                    case "10":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_10;
                        break;
                    case "11":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_11;
                        break;
                    case "black":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.black;
                        break;
                    case "white":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.white;
                        break;
                    case "gray":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.gray;
                        break;
                    case "intro":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    default:
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                }
            }
            else if (Global.myProjNumber == "5")
            {
                switch (index)
                {
                    case "0":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    case "1":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_1;
                        break;
                    case "2":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_2;
                        break;
                    case "3":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_3;
                        break;
                    case "4":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_4;
                        break;
                    case "5":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_5;
                        break;
                    case "6":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_6;
                        break;
                    case "7":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_7;
                        break;
                    case "8":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_8;
                        break;
                    case "9":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_9;
                        break;
                    case "10":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_10;
                        break;
                    case "11":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_11;
                        break;
                    case "black":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.black;
                        break;
                    case "white":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.white;
                        break;
                    case "gray":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.gray;
                        break;
                    case "intro":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    default:
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                }
            }
            else if (Global.myProjNumber == "-1")
            {
                switch (index)
                {
                    case "0":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    case "1":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_1;
                        break;
                    case "2":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_2;
                        break;
                    case "3":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_3;
                        break;
                    case "4":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_4;
                        break;
                    case "5":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_5;
                        break;
                    case "6":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_6;
                        break;
                    case "7":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_7;
                        break;
                    case "8":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_8;
                        break;
                    case "9":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_9;
                        break;
                    case "10":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_10;
                        break;
                    case "11":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.IM_1_11;
                        break;
                    case "black":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.black;
                        break;
                    case "white":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.white;
                        break;
                    case "gray":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.gray;
                        break;
                    case "intro":
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                    default:
                        pictureBox1.Image = ImageDisplayClient.Properties.Resources.main;
                        break;
                }
            }



        }


        public void ShowImage(string index)
        {
            this.Invoke(handler, index);
        }
    }
}
