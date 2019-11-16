using System.Windows.Forms;

namespace MediaPlayerApp
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.arrow_btn_right = new System.Windows.Forms.Panel();
            this.arrow_btn_left = new System.Windows.Forms.Panel();
            this.page1_panel = new System.Windows.Forms.Panel();
            this.base_panel = new System.Windows.Forms.Panel();
            this.right_animator = new System.Windows.Forms.Timer(this.components);
            this.left_animator = new System.Windows.Forms.Timer(this.components);
            this.page3_panel = new System.Windows.Forms.Panel();
            this.page2_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // arrow_btn_right
            // 
            this.arrow_btn_right.Location = new System.Drawing.Point(708, 190);
            this.arrow_btn_right.Name = "arrow_btn_right";
            this.arrow_btn_right.Size = new System.Drawing.Size(80, 70);
            this.arrow_btn_right.TabIndex = 0;
            this.arrow_btn_right.Paint += new System.Windows.Forms.PaintEventHandler(this.arrow_right_Paint);
            // 
            // arrow_btn_left
            // 
            this.arrow_btn_left.BackColor = System.Drawing.SystemColors.Control;
            this.arrow_btn_left.Location = new System.Drawing.Point(12, 190);
            this.arrow_btn_left.Name = "arrow_btn_left";
            this.arrow_btn_left.Size = new System.Drawing.Size(80, 70);
            this.arrow_btn_left.TabIndex = 0;
            this.arrow_btn_left.Paint += new System.Windows.Forms.PaintEventHandler(this.arrow_left_Paint);
            // 
            // page1_panel
            // 
            this.page1_panel.Location = new System.Drawing.Point(209, 108);  // Panel 위치 좌표
            this.page1_panel.Name = "page1_panel";
            this.page1_panel.Size = new System.Drawing.Size(382, 234);  // Panel 크기
            this.page1_panel.TabIndex = 0;
            this.page1_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.page1_panel_Paint);
            // 
            // base_panel
            // 
            this.base_panel.Location = new System.Drawing.Point(209, 108);
            this.base_panel.Name = "base_panel";
            this.base_panel.Size = new System.Drawing.Size(50, 50);
            this.base_panel.TabIndex = 0;
            // 
            // right_animator
            // 
            this.right_animator.Interval = 1;
            this.right_animator.Tick += new System.EventHandler(this.right_animator_Tick);
            // 
            // left_animator
            // 
            this.left_animator.Interval = 1;
            this.left_animator.Tick += new System.EventHandler(this.left_animator_Tick);
            // 
            // page3_panel
            // 
            this.page3_panel.Location = new System.Drawing.Point(-280, 155);
            this.page3_panel.Name = "page3_panel";
            this.page3_panel.Size = new System.Drawing.Size(382, 140);
            this.page3_panel.TabIndex = 0;
            this.page3_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.page3_panel_Paint);
            // 
            // page2_panel
            // 
            this.page2_panel.Location = new System.Drawing.Point(698, 155);
            this.page2_panel.Name = "page2_panel";
            this.page2_panel.Size = new System.Drawing.Size(382, 140);
            this.page2_panel.TabIndex = 5;
            this.page2_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.page2_panel_Paint);
            // 
            // Form1
            // 
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;  // 창 테두리 없애기
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;  // 전체화면

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.arrow_btn_right);
            this.Controls.Add(this.arrow_btn_left);
            this.Controls.Add(this.page1_panel);
            this.Controls.Add(this.page2_panel);
            this.Controls.Add(this.page3_panel);
            this.Controls.Add(this.base_panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel arrow_btn_right;
        private System.Windows.Forms.Panel arrow_btn_left;
        private System.Windows.Forms.Panel page1_panel;
        private System.Windows.Forms.Timer right_animator;
        private System.Windows.Forms.Timer left_animator;
        private System.Windows.Forms.Panel page3_panel;
        private System.Windows.Forms.Panel page2_panel;
        private System.Windows.Forms.Panel base_panel;
    }
}

