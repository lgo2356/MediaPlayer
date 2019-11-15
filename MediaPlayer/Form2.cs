using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Microsoft.DirectX.AudioVideoPlayback;

namespace MediaPlayerApp
{
    public partial class Form2 : Form
    {
        Video video1, video2, video3, video4;

        public Form2()
        {
            InitializeComponent();

            MediaPlayerInit();
        }

        /* 필수 요소 초기화 */
        private void MediaPlayerInit()
        {
            Console.WriteLine("Hello");

            //video1 = new Video(@"C:\Users\Jeon\Desktop\test\test.wmv", false);
            video1 = new Video("Resources\\Videos\\test.wmv", false);
            video1.Owner = this;

            //video2 = new Video(@"C:\Users\Jeon\Desktop\test\test2.wmv", false);
            video2 = new Video("Resources\\Videos\\test2.wmv", false);
            video2.Owner = this;

            //video3 = new Video(@"C:\Users\Jeon\Desktop\test\test3.wmv", false);
            video3 = new Video("Resources\\Videos\\test3.wmv", false);
            video3.Owner = this;

            //video4 = new Video(@"C:\Users\Jeon\Desktop\test\test4.wmv", false);
            video4 = new Video("Resources\\Videos\\test4.wmv", false);
            video4.Owner = this;
            video4.Play();
        }

        /* 비디오 재생 */
        public void PlayVideo(int index)
        {
            video4.Stop();
            video4.Dispose();

            switch (index)
            {
                case 0:
                    Console.WriteLine("1번 비디오");

                    if (video1.Disposed)
                    {
                        CreateVideo(0);
                    }

                    StopVideo(1);
                    StopVideo(2);

                    video1.Play();
                    break;
                case 1:
                    Console.WriteLine("2번 비디오");

                    if (video2.Disposed)
                    {
                        CreateVideo(1);
                    }

                    StopVideo(0);
                    StopVideo(2);

                    video2.Play();
                    break;
                case 2:
                    Console.WriteLine("3번 비디오");

                    if (video3.Disposed)
                    {
                        CreateVideo(2);
                    }

                    StopVideo(0);
                    StopVideo(1);

                    video3.Play();
                    break;
                case 3:
                    Console.WriteLine("4번 비디오");

                    if (video4.Disposed)
                    {
                        CreateVideo(2);
                    }

                    StopVideo(0);
                    StopVideo(1);

                    video3.Play();
                    break;
            }
        }

        private void StopVideo(int index)
        {
            switch (index)
            {
                case 0:
                    if(video1 != null)
                    {
                        video1.Stop();
                        video1.Dispose();
                    }
                    break;
                case 1:
                    if(video2 != null)
                    {
                        video2.Stop();
                        video2.Dispose();
                    }

                    break;
                case 2:
                    if(video3 != null)
                    {
                        video3.Stop();
                        video3.Dispose();
                    }
                    break;
            }
        }

        private void CreateVideo(int index)
        {
            switch (index)
            {
                case 0:
                    video1 = new Video("Resources\\Videos\\test.wmv", false);
                    video1.Owner = this;
                    break;
                case 1:
                    video2 = new Video("Resources\\Videos\\test2.wmv", false);
                    video2.Owner = this;
                    break;
                case 2:
                    video3 = new Video("Resources\\Videos\\test3.wmv", false);
                    video3.Owner = this;
                    break;
                case 3:
                    video4 = new Video("Resources\\Videos\\test4.wmv", false);
                    video4.Owner = this;
                    break;
            }
        }
    }
}
