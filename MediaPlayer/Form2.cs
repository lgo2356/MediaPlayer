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
        Video video;

        public Form2()
        {
            InitializeComponent();

            MediaPlayerInit();
        }

        /* 필수 요소 초기화 */
        private void MediaPlayerInit()
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
            //string filePath = openFileDialog.FileName;
            Console.WriteLine("Hello");

            video = new Video(@"C:\Users\Jeon\Desktop\test\test2.mp4", false);
            video.Owner = this;
            video.Play();
            //video.Size = panel1.Size;

            //System.Windows.Media.MediaPlayer mediaPlayer = new System.Windows.Media.MediaPlayer();
            //mediaPlayer.Open(new Uri(@"C:\Users\Jeon\Desktop\test.wmv", UriKind.Relative));

            //mediaPlayer.Dispatcher.Invoke(new Action(delegate { Thread.Sleep(1); }));

            //mediaPlayer.Open(new Uri(filePath, UriKind.Relative));
            //VideoDrawing videoDrawing = new VideoDrawing();
            //videoDrawing.Rect = new Rect(0, 0, 100, 100);
            //videoDrawing.Player = mediaPlayer;
            //Console.WriteLine("Video size: " + mediaPlayer.NaturalVideoWidth);
            //DrawingBrush brush = new DrawingBrush(videoDrawing);
            //this.BackColor = brush;

            //mediaPlayer.Play();
            //try
            //{
            //    Console.WriteLine("Video 1");
            //    axWindowsMediaPlayer1.URL = "..\\..\\Resources\\MediaPlayer.mp4";
            //    axWindowsMediaPlayer1.Ctlcontrols.play();
            //    Console.WriteLine("Video 2");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //string[] videoPaths;
            //string folderPath = @"C:\Users\Jeon\Desktop\test\";
            //videoPaths = System.IO.Directory.GetFiles(folderPath, "*.wmv");
            //video = new Video(videoPaths[0], false); // 아마도 쓰레드로 처리 해야할 거 같음
        }
    }
}
