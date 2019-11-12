using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        int page_number = 0;  // 0 -> 1 page
        /* 페이지 flag 끝 */
        
        /* Class 정의 */
        Video video;
        Form2 form2;

        public Form1()
        {
            InitializeComponent();

            /* 마우스 이벤트 핸들러 시작 */
            arrow_btn_right.MouseUp += new MouseEventHandler(arrow_right_MouseUp);  // 오른쪽 화살표
            arrow_btn_right.MouseDown += new MouseEventHandler(arrow_right_MouseDown);  // 오른쪽 화살표
            arrow_btn_left.MouseUp += new MouseEventHandler(arrow_left_MouseUp);  // 왼쪽 화살표
            arrow_btn_left.MouseDown += new MouseEventHandler(arrow_left_MouseDown);  // 왼쪽 화살표
            page1_panel.MouseUp += new MouseEventHandler(page1_panel_MouseUp);  // 1페이지 그림
            page1_panel.MouseDown += new MouseEventHandler(page1_panel_MouseDown);  // 1페이지 그림
            page2_panel.MouseUp += new MouseEventHandler(page2_panel_MouseUp);  // 2페이지 그림
            page2_panel.MouseDown += new MouseEventHandler(page2_panel_MouseDown);  // 2페이지 그림
            page3_panel.MouseUp += new MouseEventHandler(page3_panel_MouseUp);  // 3페이지 그림
            page3_panel.MouseDown += new MouseEventHandler(page3_panel_MouseDown);  // 3페이지 그림
            /* 마우스 이벤트 핸들러 끝 */

            if (Screen.AllScreens.Count() != 2)
            {
                Console.WriteLine("듀얼 모니터 환경이 아닙니다.");
                Console.WriteLine("연결된 모니터 개수: " + Screen.AllScreens.Count());
            }
            else
            {
                Screen[] screens = Screen.AllScreens;

                /* Form2 객체 생성 및 설정 (2번째 모니터에 화면 띄우기) */
                //form2 = new Form2();
                //form2.Owner = this;
                //form2.Show();  // Form2 창 실행
                //form2.Location = screens[1].Bounds.Location;  // Form2 창 위치를 2번 모니터로 설정
                //form2.FormBorderStyle = FormBorderStyle.None;  // Form2 테두리 제거(완전한 전체화면)
                //form2.WindowState = FormWindowState.Maximized;  // From2 전체화면으로 설정
            }

            //arrow_btn_right.Parent = page2_panel;
            //arrow_btn_right.Location = new Point(292, 82);
        }

        /* 오른쪽 화살표 시작 */
        /* Right 화살표 버튼 이미지 */
        private void arrow_right_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\arrow_right.png");  // 패널 이미지 적용(화살표)
            graphics.DrawImage(img, (arrow_btn_right.Width - img.Width) / 2, (arrow_btn_right.Height - img.Height) / 2);
            arrow_btn_right.BackColor = Color.Transparent;  // 배경 투명하게
        }

        /* Right 화살표 Mouse up 처리 */
        private void arrow_right_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 오른쪽 Mouse up.");
        }

        /* Right 화살표 Mouse down 처리 */
        private void arrow_right_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 오른쪽 Mouse down.");
        }
        /* 오른쪽 화살표 끝 */

        /* 왼쪽 화살표 시작 */
        /* Left 화살표 버튼 이미지 */
        private void arrow_left_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\arrow_left.png");  // 패널 이미지 적용(화살표)
            Console.WriteLine("Width: " + img.Width + "Height: " + img.Height);
            graphics.DrawImage(img, (arrow_btn_left.Width - img.Width)/2, (arrow_btn_left.Height - img.Height)/2);
            arrow_btn_left.BackColor = Color.Transparent;  // 배경 투명하게
        }

        /* Left 화살표 Mouse up 처리 */
        private void arrow_left_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 왼쪽 화살표 Mouse up.");
        }

        /* Left 화살표 Mouse down 처리 */
        private void arrow_left_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 왼쪽 화살표 Mouse down.");
        }
        /* 왼쪽 화살표 끝 */

        /* 1페이지 시작 */
        /* 1페이지 아이콘 이미지 */
        private void page1_panel_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("1 page icon");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\1page.jpg");  // 패널 이미지 적용
            //graphics.DrawImage(img, 0, 0, page1_panel.Width, page1_panel.Height);

            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = 0.3f;
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, page1_panel.Width, page1_panel.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
        }

        /* 1페이지 아이콘 Mouse up */
        private void page1_panel_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 그림 mouse up.");

            form2.PlayVideo(0);
        }

        /* 1페이지 아이콘 Mouse down */
        private void page1_panel_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 그림 mouse down.");
        }
        /* 1페이지 끝 */

        /* 2페이지 시작 */
        /* 2페이지 아이콘 이미지 */
        private void page2_panel_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("2 page icon clicked.");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\2page.jpg");
            graphics.DrawImage(img, 0, 0, page2_panel.Width, page2_panel.Height);
        }

        /* 2페이지 아이콘 Mouse up */
        private void page2_panel_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("2페이지 그림 mouse up.");

            form2.PlayVideo(1);
        }

        /* 2페이지 아이콘 Mouse down */
        private void page2_panel_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("2페이지 그림 mouse down.");
        }
        /* 2페이지 끝 */

        /* 3페이지 시작 */
        /* 3페이지 아이콘 이미지 */
        private void page3_panel_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("3 page icon clicked.");
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\Resources\\3page.jpg");
            graphics.DrawImage(img, 0, 0, page3_panel.Width, page3_panel.Height);
        }

        /* 3페이지 아이콘 Mouse up */
        private void page3_panel_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("3페이지 그림 mouse up.");

            form2.PlayVideo(2);
        }

        /* 3페이지 아이콘 Mouse down */
        private void page3_panel_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("3페이지 그림 mouse down.");
        }
        /* 3페이지 끝 */

        private void button1_Click(object sender, EventArgs e)  // previous button
        {
            if(page1_panel.Location.X <= 0)
            {
                page_1 = false;
                page_2 = true;
                page_3 = false;
            }
            if(page2_panel.Location.X <= 0)
            {
                page_1 = false;
                page_2 = false;
                page_3 = true;
            }
            if(page3_panel.Location.X <= 0)
            {
                page_1 = true;
                page_2 = false;
                page_3 = false;

                //arrow_btn_left.Parent = page1_panel;
                //arrow_btn_left.Location = new Point(292, 82);
                //arrow_btn_left.Visible = true;

                //arrow_btn_right.Parent = page3_panel;
                //arrow_btn_right.Location = new Point(10, 82);
                //arrow_btn_right.Visible = true;
            }

            //arrow_btn_right.Visible = false;
            //arrow_btn_left.Visible = false;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            base_panel.Location = new Point(base_panel.Location.X - 150, base_panel.Location.Y);
            page1_panel.Location = new Point(page1_panel.Location.X - 150, page1_panel.Location.Y);
            page2_panel.Location = new Point(page2_panel.Location.X - 150, page2_panel.Location.Y);
            page3_panel.Location = new Point(page3_panel.Location.X - 150, page3_panel.Location.Y);

            if (base_panel.Location.X <= -200)
            {
                base_panel.Location = new Point(209, base_panel.Location.Y);

                timer1.Stop();

                if (page_1)
                {
                    // 2페이지로 넘어가기(2페이지 구성)
                    /* page1 시작 */
                    page1_panel.Location = new Point(-280, page1_panel.Location.Y);
                    //arrow_btn_left.Parent = page1_panel;
                    //arrow_btn_left.Location = new Point(292, 82);
                    //arrow_btn_left.Visible = true;
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    page2_panel.Location = new Point(209, page2_panel.Location.Y);
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    page3_panel.Location = new Point(698, page3_panel.Location.Y);
                    //arrow_btn_right.Parent = page3_panel;
                    //arrow_btn_right.Location = new Point(10, 82);
                    //arrow_btn_right.Visible = true;
                    /* page3 끝 */
                }

                if (page_2)
                {
                    // 3페이지로 넘어가기(3페이지 구성)
                    /* page1 시작 */
                    page1_panel.Location = new Point(698, page1_panel.Location.Y);
                    //arrow_btn_right.Parent = page1_panel;
                    //arrow_btn_right.Location = new Point(10, 82);
                    //arrow_btn_right.Visible = true;
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    page2_panel.Location = new Point(-280, page2_panel.Location.Y);
                    //arrow_btn_left.Parent = page2_panel;
                    //arrow_btn_left.Location = new Point(292, 82);
                    //arrow_btn_left.Visible = true;
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    page3_panel.Location = new Point(209, page3_panel.Location.Y);
                    /* page3 끝 */
                }

                if (page_3)
                {
                    // 1페이지로 넘어가기(1페이지 구성)
                    /* page1 시작 */
                    page1_panel.Location = new Point(209, page1_panel.Location.Y);
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    page2_panel.Location = new Point(698, page2_panel.Location.Y);
                    //arrow_btn_right.Parent = page2_panel;
                    //arrow_btn_right.Location = new Point(10, 82);
                    //arrow_btn_right.Visible = true;
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    page3_panel.Location = new Point(-280, page3_panel.Location.Y);
                    //arrow_btn_left.Parent = page3_panel;
                    //arrow_btn_left.Location = new Point(292, 82);
                    //arrow_btn_left.Visible = true;
                    /* page3 끝 */
                }

                //if (page1_panel.Location.X < 0)
                //{
                /* page1 시작 */
                //page1_panel.Location = new Point(-280, page1_panel.Location.Y);

                ////arrow_btn_left.Parent = page1_panel;
                ////arrow_btn_left.Location = new Point(292, 82);
                ////arrow_btn_left.Visible = true;
                ///* page1 끝 */
                ////
                ///* page2 시작 */
                //page2_panel.Location = new Point(209, page2_panel.Location.Y);
                ///* page2 끝 */
                ////
                ///* page3 시작 */
                //page3_panel.Location = new Point(698, page3_panel.Location.Y);
                ///* page3 끝 */

                ////    page_number = 1;
                ////}

                //this.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)  // next button
        {
            if (page1_panel.Location.X <= 0)
            {
                page_1 = false;
                page_2 = true;
                page_3 = false;
            }
            if (page2_panel.Location.X <= 0)
            {
                page_1 = false;
                page_2 = false;
                page_3 = true;
            }
            if (page3_panel.Location.X <= 0)
            {
                page_1 = true;
                page_2 = false;
                page_3 = false;
            }
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            base_panel.Location = new Point(base_panel.Location.X + 150, base_panel.Location.Y);
            page1_panel.Location = new Point(page1_panel.Location.X + 150, page1_panel.Location.Y);
            page2_panel.Location = new Point(page2_panel.Location.X + 150, page2_panel.Location.Y);
            page3_panel.Location = new Point(page3_panel.Location.X + 150, page3_panel.Location.Y);

            if (base_panel.Location.X >= 698)
            {
                base_panel.Location = new Point(209, base_panel.Location.Y);

                timer2.Stop();

                if (page_1)
                {
                    // 2페이지로 넘어가기(2페이지 구성)
                    /* page1 시작 */
                    page1_panel.Location = new Point(698, page1_panel.Location.Y);
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    page2_panel.Location = new Point(-280, page2_panel.Location.Y);
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    page3_panel.Location = new Point(209, page3_panel.Location.Y);
                    /* page3 끝 */
                }

                if (page_2)
                {
                    // 3페이지로 넘어가기(3페이지 구성)
                    /* page1 시작 */
                    page1_panel.Location = new Point(209, page1_panel.Location.Y);
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    page2_panel.Location = new Point(698, page2_panel.Location.Y);
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    page3_panel.Location = new Point(-280, page3_panel.Location.Y);
                    /* page3 끝 */
                }

                if (page_3)
                {
                    // 1페이지로 넘어가기(1페이지 구성)
                    /* page1 시작 */
                    page1_panel.Location = new Point(-280, page1_panel.Location.Y);
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    page2_panel.Location = new Point(209, page2_panel.Location.Y);
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    page3_panel.Location = new Point(698, page3_panel.Location.Y);
                    /* page3 끝 */
                }
            }
        }

        
    }
}
