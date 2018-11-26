
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace KanubiZ
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();

        }

        #region MoveContro
        //สร้างคุณสมบัติ Click & Drag 

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        //ใส่ MoveContro_MouseDown ใน >> Evens ของ object ใดๆ ที่ต้องการโดนลาก 
        private void MoveContro_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion


        TextWriter _writer = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Instantiate the writer
            _writer = new TextBoxStreamWriter(cmdBox);
            // Redirect the out Console stream
            Console.SetOut(_writer);

            Console.WriteLine("Now redirecting output to the text box");



        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Console.WriteLine(inputBox.Text);
          

            //Console.WriteLine("Hi!! Wow");

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
