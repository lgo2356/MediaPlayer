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
        //int page_number = 0;  // 0 -> 1 page
        /* 페이지 flag 끝 */

        /* 페이지 블러 처리 flag 변수 초기화 시작 */
        bool blur_page1 = false;
        bool blur_page2 = true;
        bool blur_page3 = true;
        /* 페이지 블러 처리 flag 변수 초기화 끝 */

        /* Init flag */
        bool init_page1 = false;
        bool init_page2 = false;
        bool init_page3 = false;

        /* Class 정의 시작 */
        Video video;
        Form2 form2;
        ColorMatrix colorMatrix;
        ImageAttributes imageAttributes;
        /* Class 정의 끝 */

        /* Image resources */
        private static readonly Image page1_img = Image.FromFile("Resources\\Images\\1page.jpg");  // 1 페이지 이미지 리소스
        private static readonly Image page2_img = Image.FromFile("Resources\\Images\\2page.jpg");  // 2 페이지 이미지 리소스
        private static readonly Image page3_img = Image.FromFile("Resources\\Images\\3page.jpg");  // 3 페이지 이미지 리소스
        private static readonly Image arrow_right_img = Image.FromFile("Resources\\Images\\arrow_right.png");  // 오른쪽 화살표 이미지 리소스
        private static readonly Image arrow_left_img = Image.FromFile("Resources\\Images\\arrow_left.png");  // 왼쪽 화살표 이미지 리소스

        /* Graphics objects init */
        Graphics graphics_page1;
        Graphics graphics_page2;
        Graphics graphics_page3;

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

            colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = 0.3f;  // blur 설정 값 30%

            imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        }

        /* 오른쪽 화살표 시작 */
        /* Right 화살표 버튼 이미지 */
        private void arrow_right_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(arrow_right_img, (arrow_btn_right.Width - arrow_right_img.Width) / 2, (arrow_btn_right.Height - arrow_right_img.Height) / 2);
            arrow_btn_right.BackColor = Color.Transparent;  // 배경 투명하게

            arrow_btn_right.Location = new Point(ClientSize.Width - 92, ClientSize.Height/2 - arrow_btn_right.Height/2);
        }

        /* Right 화살표 Mouse up 처리 */
        private void arrow_right_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 오른쪽 Mouse up.");

            // 1 페이지
            if (page3_panel.Location.X <= 0)
            {
                page_1 = true;
                page_2 = false;
                page_3 = false;
            }
            //
            // 2 페이지
            if (page1_panel.Location.X <= 0)
            {
                page_1 = false;
                page_2 = true;
                page_3 = false;
            }
            //
            // 3 페이지
            if (page2_panel.Location.X <= 0)
            {
                page_1 = false;
                page_2 = false;
                page_3 = true;
            }

            right_animator.Start();
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
            graphics.DrawImage(arrow_left_img, (arrow_btn_left.Width - arrow_left_img.Width)/2, (arrow_btn_left.Height - arrow_left_img.Height)/2);
            arrow_btn_left.BackColor = Color.Transparent;  // 배경 투명하게

            arrow_btn_left.Location = new Point(12, ClientSize.Height/2 - arrow_btn_left.Height/2);
        }

        /* Left 화살표 Mouse up 처리 */
        private void arrow_left_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 왼쪽 화살표 Mouse up.");

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
            left_animator.Start();
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
            Console.WriteLine("1 page image paint");
            graphics_page1 = e.Graphics;

            //ClientSize = new Size(ClientSize.Width, ClientSize.Height);

            if (!init_page1)  // Panel 초기 위치 설정
            {
                page1_panel.Location = new Point(ClientSize.Width/2 - page1_panel.Width/2, ClientSize.Height/2 - page1_panel.Height/2);
                init_page1 = true;
            }

            if (!blur_page1)
            {
                graphics_page1.DrawImage(page1_img, 0, 0, page1_panel.Width, page1_panel.Height);
            }
            else
            {
                graphics_page1.DrawImage(page1_img, new Rectangle(0, 0, page1_panel.Width, page1_panel.Height), 0, 0, page1_img.Width, page1_img.Height, GraphicsUnit.Pixel, imageAttributes);
            }
        }

        /* 1페이지 아이콘 Mouse up */
        private void page1_panel_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("1페이지 그림 mouse up.");

            if (!blur_page1)
            {
                form2.PlayVideo(0);
            }
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
            Console.WriteLine("2 page image paint");
            graphics_page2 = e.Graphics;

            if (!init_page2)  // Panel 초기 위치 설정
            {
                page2_panel.Location = new Point(ClientSize.Width - 102, ClientSize.Height / 2 - page2_panel.Height / 2);
                init_page2 = true;
            }

            if (!blur_page2)
            {
                graphics_page2.DrawImage(page2_img, 0, 0, page2_panel.Width, page2_panel.Height);
            }
            else
            {
                graphics_page2.DrawImage(page2_img, new Rectangle(0, 0, page2_panel.Width, page2_panel.Height), 0, 0, page2_img.Width, page2_img.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            //page2_panel.Refresh();
        }

        /* 2페이지 아이콘 Mouse up */
        private void page2_panel_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("2페이지 그림 mouse up.");

            if (!blur_page2)
            {
                form2.PlayVideo(1);
            }
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
            Console.WriteLine("3 page image paint");
            graphics_page3 = e.Graphics;

            if (!init_page3)  // Panel 초기 위치 설정
            {
                page3_panel.Location = new Point(-280, ClientSize.Height / 2 - page3_panel.Height / 2);
                init_page3 = true;
            }

            if (!blur_page3)
            {
                graphics_page3.DrawImage(page3_img, 0, 0, page3_panel.Width, page3_panel.Height);
            }
            else
            {
                graphics_page3.DrawImage(page3_img, new Rectangle(0, 0, page3_panel.Width, page3_panel.Height), 0, 0, page3_img.Width, page3_img.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            //page3_panel.Refresh();
        }

        /* 3페이지 아이콘 Mouse up */
        private void page3_panel_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("3페이지 그림 mouse up.");

            if (!blur_page3)
            {
                form2.PlayVideo(2);
            }
        }

        /* 3페이지 아이콘 Mouse down */
        private void page3_panel_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("3페이지 그림 mouse down.");
        }
        /* 3페이지 끝 */

        private void right_animator_Tick(object sender, EventArgs e)
        {
            // 기준 패널
            base_panel.Location = new Point(base_panel.Location.X - 90, base_panel.Location.Y);
            
            if (page_1)  // 2 페이지로 넘어가기
            {
                /* 1페이지 패널 애니메이션 */
                page1_panel.Location = new Point(page1_panel.Location.X - 90, page1_panel.Location.Y + 5);
                page1_panel.Size = new Size(page1_panel.Width, page1_panel.Height - 5);
                
                /* 2페이지 패널 애니메이션 */
                page2_panel.Location = new Point(page2_panel.Location.X - 90, page2_panel.Location.Y - 5);
                page2_panel.Size = new Size(page2_panel.Width, page2_panel.Height + 5);
                
                /* 3페이지 패널 애니메이션 */
                page3_panel.Location = new Point(page3_panel.Location.X - 90, page3_panel.Location.Y);
            }

            if (page_2)  // 3 페이지로 넘어가기
            {
                /* 1페이지 패널 애니메이션 */
                page1_panel.Location = new Point(page1_panel.Location.X - 90, page1_panel.Location.Y);

                /* 2페이지 패널 애니메이션 */
                page2_panel.Location = new Point(page2_panel.Location.X - 90, page2_panel.Location.Y + 5);
                page2_panel.Size = new Size(page2_panel.Width, page2_panel.Height - 5);

                /* 3페이지 패널 애니메이션 */
                page3_panel.Location = new Point(page3_panel.Location.X - 90, page3_panel.Location.Y - 5);
                page3_panel.Size = new Size(page3_panel.Width, page3_panel.Height + 5);
            }

            if (page_3)  // 1 페이지로 넘어가기
            {
                /* 1페이지 패널 애니메이션 */
                page1_panel.Location = new Point(page1_panel.Location.X - 90, page1_panel.Location.Y - 5);
                page1_panel.Size = new Size(page1_panel.Width, page1_panel.Height + 5);

                /* 2페이지 패널 애니메이션 */
                page2_panel.Location = new Point(page2_panel.Location.X - 90, page2_panel.Location.Y);

                /* 3페이지 패널 애니메이션 */
                page3_panel.Location = new Point(page3_panel.Location.X - 90, page3_panel.Location.Y + 5);
                page3_panel.Size = new Size(page3_panel.Width, page3_panel.Height - 5);
            }

            /* 애니메이션 정지 처리 */
            if (base_panel.Location.X <= -200)
            {
                base_panel.Location = new Point(209, base_panel.Location.Y);

                right_animator.Stop();

                /* 2페이지 구성 */
                if (page_1)
                {
                    //page_1 = false;
                    //page_2 = true;  // 2페이지 flag 설정
                    //page_3 = false;
                    /* page1 시작 */
                    blur_page1 = true;  // 1페이지 이미지 blur 처리
                    page1_panel.Size = new Size(page1_panel.Width, 140);
                    page1_panel.Location = new Point(-280, ClientSize.Height/2 - page1_panel.Height/2);
                    page1_panel.Refresh();
                    //arrow_btn_left.Parent = page1_panel;
                    //arrow_btn_left.Location = new Point(292, 82);
                    //arrow_btn_left.Visible = true;
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    blur_page2 = false;  // 2페이지 이미지 blur 해제
                    page2_panel.Size = new Size(page2_panel.Width, 234);
                    page2_panel.Location = new Point(ClientSize.Width/2 - page2_panel.Width/2, ClientSize.Height/2 - page2_panel.Height/2);
                    page2_panel.Refresh();
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    blur_page3 = true;  // 3페이지 이미지 blur 처리
                    page3_panel.Size = new Size(page3_panel.Width, 140);
                    page3_panel.Location = new Point(ClientSize.Width - 102, ClientSize.Height/2 - page3_panel.Height/2);
                    page3_panel.Refresh();
                    //arrow_btn_right.Parent = page3_panel;
                    //arrow_btn_right.Location = new Point(10, 82);
                    //arrow_btn_right.Visible = true;
                    /* page3 끝 */
                }

                /* 3페이지 구성 */
                if (page_2)
                {
                    // 3페이지로 넘어가기(3페이지 구성)
                    //page_1 = false;
                    //page_2 = false;
                    //page_3 = true;  // 3페이지 flag 설정
                    /* page1 시작 */
                    blur_page1 = true;
                    page1_panel.Size = new Size(page1_panel.Width, 140);
                    //page1_panel.Location = new Point(698, page1_panel.Location.Y);
                    page1_panel.Location = new Point(ClientSize.Width - 102, ClientSize.Height/2 - page1_panel.Height/2);
                    page1_panel.Refresh();
                    //arrow_btn_right.Parent = page1_panel;
                    //arrow_btn_right.Location = new Point(10, 82);
                    //arrow_btn_right.Visible = true;
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    blur_page2 = true;
                    page2_panel.Size = new Size(page2_panel.Width, 140);
                    //page2_panel.Location = new Point(-280, 155);
                    page2_panel.Location = new Point(-280, ClientSize.Height/2 - page2_panel.Height/2);
                    page2_panel.Refresh();
                    //arrow_btn_left.Parent = page2_panel;
                    //arrow_btn_left.Location = new Point(292, 82);
                    //arrow_btn_left.Visible = true;
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    blur_page3 = false;
                    page3_panel.Size = new Size(page3_panel.Width, 234);
                    //page3_panel.Location = new Point(209, 108);
                    page3_panel.Location = new Point(ClientSize.Width/2 - page3_panel.Width/2, ClientSize.Height/2 - page3_panel.Height/2);
                    page3_panel.Refresh();
                    /* page3 끝 */
                }

                /* 1페이지 구성 */
                if (page_3)
                {
                    // 1페이지로 넘어가기(1페이지 구성)
                    //page_1 = true;
                    //page_2 = false;
                    //page_3 = false;
                    /* page1 시작 */
                    blur_page1 = false;
                    page1_panel.Size = new Size(page1_panel.Width, 234);
                    //page1_panel.Location = new Point(209, 108);
                    page1_panel.Location = new Point(ClientSize.Width/2 - page1_panel.Width/2, ClientSize.Height/2 - page1_panel.Height/2);
                    page1_panel.Refresh();
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    blur_page2 = true;
                    page2_panel.Size = new Size(page2_panel.Width, 140);
                    //page2_panel.Location = new Point(698, page2_panel.Location.Y);
                    page2_panel.Location = new Point(ClientSize.Width - 102, ClientSize.Height/2 - page2_panel.Height/2);
                    page2_panel.Refresh();
                    //arrow_btn_right.Parent = page2_panel;
                    //arrow_btn_right.Location = new Point(10, 82);
                    //arrow_btn_right.Visible = true;
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    blur_page3 = true;
                    page3_panel.Size = new Size(page3_panel.Width, 140);
                    //page3_panel.Location = new Point(-280, 155);
                    page3_panel.Location = new Point(-280, ClientSize.Height/2 - page3_panel.Height/2);
                    page3_panel.Refresh();
                    //arrow_btn_left.Parent = page3_panel;
                    //arrow_btn_left.Location = new Point(292, 82);
                    //arrow_btn_left.Visible = true;
                    /* page3 끝 */
                }
            }
        }

        private void left_animator_Tick(object sender, EventArgs e)
        {
            base_panel.Location = new Point(base_panel.Location.X + 90, base_panel.Location.Y);

            /* 3페이지로 넘어가기 */
            if (page_1)
            {
                /* 1 페이지 애니메이션 */
                page1_panel.Location = new Point(page1_panel.Location.X + 90, page1_panel.Location.Y + 5);
                page1_panel.Size = new Size(page1_panel.Width, page1_panel.Height - 5);

                /* 2페이지 애니메이션 */
                page2_panel.Location = new Point(page2_panel.Location.X + 90, page2_panel.Location.Y);
                page2_panel.Size = new Size(page2_panel.Width, page2_panel.Height);

                /* 3페이지 애니메이션 */
                page3_panel.Location = new Point(page3_panel.Location.X + 90, page3_panel.Location.Y - 5);
                page3_panel.Size = new Size(page3_panel.Width, page3_panel.Height + 5);
            }

            /* 1페이지로 넘어가기 */
            if (page_2)
            {
                /* 1 페이지 애니메이션 */
                page1_panel.Location = new Point(page1_panel.Location.X + 90, page1_panel.Location.Y - 5);
                page1_panel.Size = new Size(page1_panel.Width, page1_panel.Height + 5);

                /* 2페이지 애니메이션 */
                page2_panel.Location = new Point(page2_panel.Location.X + 90, page2_panel.Location.Y + 5);
                page2_panel.Size = new Size(page2_panel.Width, page2_panel.Height - 5);

                /* 3페이지 애니메이션 */
                page3_panel.Location = new Point(page3_panel.Location.X + 90, page3_panel.Location.Y);
                page3_panel.Size = new Size(page3_panel.Width, page3_panel.Height);
            }
            
            /* 2페이지로 넘어가기 */
            if (page_3)
            {
                /* 1 페이지 애니메이션 */
                page1_panel.Location = new Point(page1_panel.Location.X + 90, page1_panel.Location.Y);
                page1_panel.Size = new Size(page1_panel.Width, page1_panel.Height);

                /* 2페이지 애니메이션 */
                page2_panel.Location = new Point(page2_panel.Location.X + 90, page2_panel.Location.Y - 5);
                page2_panel.Size = new Size(page2_panel.Width, page2_panel.Height + 5);

                /* 3페이지 애니메이션 */
                page3_panel.Location = new Point(page3_panel.Location.X + 90, page3_panel.Location.Y + 5);
                page3_panel.Size = new Size(page3_panel.Width, page3_panel.Height - 5);
            }

            /* 애니메이션 정지 처리 */
            if (base_panel.Location.X >= 698)
            {
                base_panel.Location = new Point(209, base_panel.Location.Y);

                left_animator.Stop();

                /* 3페이지 구성 */
                if (page_1)
                {
                    // 3페이지로 넘어가기
                    //page_1 = false;
                    //page_2 = false;
                    //page_3 = true;  // 3페이지 flag 설정
                    /* page1 시작 */
                    blur_page1 = true;
                    page1_panel.Size = new Size(page1_panel.Width, 140);
                    //page1_panel.Location = new Point(698, 155);
                    page1_panel.Location = new Point(ClientSize.Width - 102, ClientSize.Height/2 - page1_panel.Height/2);
                    page1_panel.Refresh();
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    blur_page2 = true;
                    page2_panel.Size = new Size(page2_panel.Width, page2_panel.Height);
                    //page2_panel.Location = new Point(-280, page2_panel.Location.Y);
                    page2_panel.Location = new Point(-280, ClientSize.Height/2 - page2_panel.Height/2);
                    page2_panel.Refresh();
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    blur_page3 = false;
                    page3_panel.Size = new Size(page3_panel.Width, 234);
                    //page3_panel.Location = new Point(209, 108);
                    page3_panel.Location = new Point(ClientSize.Width/2 - page3_panel.Width/2, ClientSize.Height/2 - page3_panel.Height/2);
                    page3_panel.Refresh();
                    /* page3 끝 */
                }

                /* 1페이지 구성 */
                if (page_2)
                {
                    // 1페이지로 넘어가기
                    //page_1 = true;  // 1페이지 flag 설정
                    //page_2 = false;
                    //page_3 = false;
                    /* page1 시작 */
                    blur_page1 = false;
                    page1_panel.Size = new Size(page1_panel.Width, 234);
                    //page1_panel.Location = new Point(209, 108);
                    page1_panel.Location = new Point(ClientSize.Width/2 - page1_panel.Width/2, ClientSize.Height/2 - page1_panel.Height/2);
                    page1_panel.Refresh();
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    blur_page2 = true;
                    page2_panel.Size = new Size(page2_panel.Width, 140);
                    //page2_panel.Location = new Point(698, 155);
                    page2_panel.Location = new Point(ClientSize.Width - 102, ClientSize.Height/2 - page2_panel.Height/2);
                    page2_panel.Refresh();
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    blur_page3 = true;
                    page3_panel.Size = new Size(page3_panel.Width, page3_panel.Height);
                    //page3_panel.Location = new Point(-280, page3_panel.Location.Y);
                    page3_panel.Location = new Point(-280, ClientSize.Height/2 - page3_panel.Height/2);
                    page3_panel.Refresh();
                    /* page3 끝 */
                }

                /* 2페이지 구성 */
                if (page_3)
                {
                    // 2페이지로 넘어가기
                    //page_1 = false;
                    //page_2 = true;
                    //page_3 = false;
                    /* page1 시작 */
                    blur_page1 = true;
                    page1_panel.Size = new Size(page1_panel.Width, page1_panel.Height);
                    //page1_panel.Location = new Point(-280, page1_panel.Location.Y);
                    page1_panel.Location = new Point(-280, ClientSize.Height/2 - page1_panel.Height/2);
                    page1_panel.Refresh();
                    /* page1 끝 */
                    //
                    /* page2 시작 */
                    blur_page2 = false;
                    page2_panel.Size = new Size(page2_panel.Width, 234);
                    //page2_panel.Location = new Point(209, 108);
                    page2_panel.Location = new Point(ClientSize.Width/2 - page2_panel.Width/2, ClientSize.Height/2 - page2_panel.Height/2);
                    page2_panel.Refresh();
                    /* page2 끝 */
                    //
                    /* page3 시작 */
                    blur_page3 = true;
                    page3_panel.Size = new Size(page3_panel.Width, 140);
                    //page3_panel.Location = new Point(698, 155);
                    page3_panel.Location = new Point(ClientSize.Width - 102, ClientSize.Height/2 - page3_panel.Height/2);
                    page3_panel.Refresh();
                    /* page3 끝 */
                }
            }
        }
    }
}
