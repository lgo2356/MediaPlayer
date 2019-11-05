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
        /* 페이지 flag 시작 */
        bool page_1 = true;
        bool page_2 = false;
        bool page_3 = false;
        /* 페이지 flag 끝 */
        
        /* Class 정의 */
        Video video;
        Form2 form2;

        public Form1()
        {
            InitializeComponent();

            /* 마우스 이벤트 핸들러 시작 */
            panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);  // 오른쪽 화살표
            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);  // 오른쪽 화살표
            panel2.MouseUp += new MouseEventHandler(panel2_MouseUp);  // 왼쪽 화살표
            panel2.MouseDown += new MouseEventHandler(panel2_MouseDown);  // 왼쪽 화살표
            panel3.MouseUp += new MouseEventHandler(panel3_MouseUp);  // 1페이지 그림
            panel3.MouseDown += new MouseEventHandler(panel3_MouseDown);  // 1페이지 그림
            panel4.MouseUp += new MouseEventHandler(panel4_MouseUp);  // 2페이지 그림
            panel4.MouseDown += new MouseEventHandler(panel4_MouseDown);  // 2페이지 그림
            panel5.MouseUp += new MouseEventHandler(panel5_MouseUp);  // 3페이지 그림
            panel5.MouseDown += new MouseEventHandler(panel5_MouseDown);  // 3페이지 그림
            /* 마우스 이벤트 핸들러 끝 */

            Console.WriteLine("모니터 숫자: " + Screen.AllScreens.Count());
            Screen[] screens = Screen.AllScreens;

            /* Form2 객체 생성 및 설정 */
            form2 = new Form2();
            form2.Owner = this;
            form2.Show();  // Form2 창 실행
            form2.Location = screens[1].Bounds.Location;  // Form2 창 위치를 2번 모니터로 설정
            form2.FormBorderStyle = FormBorderStyle.None;  // Form2 테두리 제거(완전한 전체화면)
            form2.WindowState = FormWindowState.Maximized;  // From2 전체화면으로 설정
        }

        /* 오른쪽 화살표 시작 */
        /* Right 화살표 버튼 이미지 */
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\arrow_right.png");  // 패널 이미지 적용(화살표)
            graphics.DrawImage(img, 0, 0);
        }

        /* Right 화살표 Mouse up 처리 */
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 오른쪽 Mouse up.");

            /* 1페이지일 경우 */
            if (page_1 == true && page_2 == false && page_3 == false)
            {
                panel4.Visible = true;
                panel3.Visible = false;

                page_1 = false;
                page_2 = true;
                return;
            }

            /* 2페이지일 경우 */
            if (page_2 == true && page_1 == false && page_3 == false)
            {
                panel5.Visible = true;
                panel4.Visible = false;

                page_2 = false;
                page_3 = true;
                return;
            }

            /* 3페이지일 경우 */
            if (page_3 == true && page_1 == false && page_2 == false)
            {
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
        /* 오른쪽 화살표 끝 */

        /* 왼쪽 화살표 시작 */
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

            /* 1페이지일 경우 */
            if (page_1 == true && page_2 == false && page_3 == false)
            {
                panel5.Visible = true;
                panel3.Visible = false;

                page_1 = false;
                page_3 = true;
                return;
            }

            /* 2페이지일 경우 */
            if (page_2 == true && page_1 == false && page_3 == false)
            {
                panel3.Visible = true;
                panel4.Visible = false;

                page_2 = false;
                page_1 = true;
                return;
            }

            /* 3페이지일 경우 */
            if (page_3 == true && page_1 == false && page_2 == false)
            {
                panel4.Visible = true;
                panel5.Visible = false;

                page_3 = false;
                page_2 = true;
                return;
            }
        }

        /* Left 화살표 Mouse down 처리 */
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 왼쪽 화살표 Mouse down.");
        }
        /* 왼쪽 화살표 끝 */

        /* 1페이지 시작 */
        /* 1페이지 아이콘 이미지 */
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("1 page icon");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\1page.jpg");  // 패널 이미지 적용
            graphics.DrawImage(img, 0, 0, panel3.Width, panel3.Height);
        }

        /* 1페이지 아이콘 Mouse up */
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 그림 mouse up.");

            form2.PlayVideo(0);
        }

        /* 1페이지 아이콘 Mouse down */
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 그림 mouse down.");
        }
        /* 1페이지 끝 */

        /* 2페이지 시작 */
        /* 2페이지 아이콘 이미지 */
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("2 page icon");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\2page.jpg");
            graphics.DrawImage(img, 0, 0, panel4.Width, panel4.Height);
        }

        /* 2페이지 아이콘 Mouse up */
        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("2페이지 그림 mouse up.");

            form2.PlayVideo(1);
        }

        /* 2페이지 아이콘 Mouse down */
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("2페이지 그림 mouse down.");
        }
        /* 2페이지 끝 */

        /* 3페이지 시작 */
        /* 3페이지 아이콘 이미지 */
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("3 page icon");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\3page.jpg");
            graphics.DrawImage(img, 0, 0, panel5.Width, panel5.Height);
        }

        /* 3페이지 아이콘 Mouse up */
        private void panel5_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("3페이지 그림 mouse up.");

            form2.PlayVideo(2);
        }

        /* 3페이지 아이콘 Mouse down */
        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("3페이지 그림 mouse down.");
        }
        /* 3페이지 끝 */
    }
}
