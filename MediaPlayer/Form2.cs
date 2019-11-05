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
            Console.WriteLine("Hello");

            video = new Video(@"C:\Users\Jeon\Desktop\test\test.wmv", false);
            video.Owner = this;
            video.Play();
        }
    }
}
