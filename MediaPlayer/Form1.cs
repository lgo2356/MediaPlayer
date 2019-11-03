using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /* 마우스 이벤트 핸들러 */
            panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);
            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            panel2.MouseUp += new MouseEventHandler(panel2_MouseUp);
            panel2.MouseDown += new MouseEventHandler(panel2_MouseDown);
        }

        /* 오른쪽 화살표 버튼 이미지 */
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\arrow_right.png");  // 패널 이미지 적용(화살표)
            graphics.DrawImage(img, 0, 0);
        }

        /* 오른쪽 화살표 Mouse up 처리 */
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("오른쪽 Mouse up.");
            //this.Visible = false;
            //Form2 form2 = new Form2();
            //form2.Owner = this;
            //form2.Show();
            //panel3.Visible = true;
            System.Diagnostics.Process.Start("..\\..\\Resources\\MediaPlayer.mp4");
        }

        /* 오른쪽 화살표 Mouse down 처리 */
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("오른쪽 Mouse down.");
        }

        /* 왼쪽 화살표 버튼 이미지 */
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\arrow_left.png");  // 패널 이미지 적용(화살표)
            graphics.DrawImage(img, 0, 0);
        }

        /* 왼쪽 화살표 Mouse up 처리 */
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("왼쪽 화살표 Mouse up.");
        }

        /* 왼쪽 화살표 Mouse down 처리 */
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("왼쪽 화살표 Mouse down.");
        }

        /* 1페이지 그림 */
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\1page.jpg");
            graphics.DrawImage(img, 0, 0, panel3.Width, panel3.Height);
        }

        /* 2페이지 그림 */
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\2page.jpg");
            graphics.DrawImage(img, 0, 0, panel3.Width, panel3.Height);

            panel4.Visible = false;  // 처음에 안 보이게
        }

        /* 3페이지 그림 */
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\2page.jpg");
            graphics.DrawImage(img, 0, 0, panel3.Width, panel3.Height);

            panel5.Visible = false;  // 처음에 안 보이게
        }
    }
}
