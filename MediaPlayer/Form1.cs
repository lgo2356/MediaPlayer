using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace MediaPlayerApp
{
    public partial class Form1 : Form
    {
        /* */
        bool page_1 = true;
        bool page_2 = false;
        bool page_3 = false;
        Video video;

        public Form1()
        {
            InitializeComponent();

            /* 마우스 이벤트 핸들러 시작 */
            panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);  // 오른쪽 화살표
            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);  // 오른쪽 화살표
            panel2.MouseUp += new MouseEventHandler(panel2_MouseUp);  // 왼쪽 화살표
            panel2.MouseDown += new MouseEventHandler(panel2_MouseDown);  // 왼쪽 화살표
            /* 마우스 이벤트 핸들러 끝 */

            Console.WriteLine("모니터 숫자: " + Screen.AllScreens.Count());
            Screen[] screens = Screen.AllScreens;

            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.Show();
            form2.Location = screens[1].Bounds.Location;
            form2.WindowState = FormWindowState.Maximized;
        }

        /* 1페이지 시작 */
        /* 1페이지 Right 화살표 버튼 이미지 */
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\arrow_right.png");  // 패널 이미지 적용(화살표)
            graphics.DrawImage(img, 0, 0);
        }

        /* 1페이지 Right 화살표 Mouse up 처리 */
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 오른쪽 Mouse up.");

            //panel7.Visible = true;
            //panel1.Visible = false;
            //this.Visible = false;
            //Form2 form2 = new Form2();
            //form2.Owner = this;
            //form2.Show();
            //panel3.Visible = true;
            //System.Diagnostics.Process.Start("..\\..\\Resources\\MediaPlayer.mp4");

            /* 1페이지일 경우 */
            if (page_1 == true && page_2 == false && page_3 == false)
            {
                Console.WriteLine("1 page");
                panel4.Visible = true;
                panel3.Visible = false;

                page_1 = false;
                page_2 = true;
                return;
            }

            /* 2페이지일 경우 */
            if (page_2 == true && page_1 == false && page_3 == false)
            {
                Console.WriteLine("2 page");
                panel5.Visible = true;
                panel4.Visible = false;

                page_2 = false;
                page_3 = true;
                return;
            }

            /* 3페이지일 경우 */
            if (page_3 == true && page_1 == false && page_2 == false)
            {
                Console.WriteLine("3 page");
                panel3.Visible = true;
                panel5.Visible = false;

                page_3 = false;
                page_1 = true;
                return;
            }
        }

        /* Right 화살표 Mouse down 처리 */
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 오른쪽 Mouse down.");
        }

        /* Left 화살표 버튼 이미지 */
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\arrow_left.png");  // 패널 이미지 적용(화살표)
            graphics.DrawImage(img, 0, 0);
        }

        /* Left 화살표 Mouse up 처리 */
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 왼쪽 화살표 Mouse up.");
        }

        /* Left 화살표 Mouse down 처리 */
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 왼쪽 화살표 Mouse down.");
        }

        /* 1페이지 아이콘 이미지 */
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("1 page icon");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\1page.jpg");  // 패널 이미지 적용
            graphics.DrawImage(img, 0, 0, panel3.Width, panel3.Height);
        }

        /* 2페이지 아이콘 이미지 */
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("2 page icon");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\2page.jpg");
            graphics.DrawImage(img, 0, 0, panel4.Width, panel4.Height);
        }

        /* 3페이지 아이콘 이미지 */
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("2 page icon");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\3page.jpg");
            graphics.DrawImage(img, 0, 0, panel5.Width, panel5.Height);
        }
        /* 1페이지 끝 */
    }
}
