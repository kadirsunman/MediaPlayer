namespace Kumanda
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.Panel();
            this.forward = new System.Windows.Forms.Button();
            this.playpause = new System.Windows.Forms.Button();
            this.reverse = new System.Windows.Forms.Button();
            this.volumeButton = new System.Windows.Forms.Button();
            this.currentTimeBar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menu2 = new System.Windows.Forms.Panel();
            this.quitButton = new System.Windows.Forms.Button();
            this.maximumSizeButton = new System.Windows.Forms.Button();
            this.simgeDurumundaKucult = new System.Windows.Forms.Button();
            this.volumeContainer = new System.Windows.Forms.Panel();
            this.volumeBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentTimeBar)).BeginInit();
            this.menu2.SuspendLayout();
            this.volumeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 1);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(802, 447);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.menu.Controls.Add(this.forward);
            this.menu.Controls.Add(this.playpause);
            this.menu.Controls.Add(this.reverse);
            this.menu.Controls.Add(this.volumeButton);
            this.menu.Controls.Add(this.currentTimeBar);
            this.menu.Controls.Add(this.label1);
            this.menu.Location = new System.Drawing.Point(0, 405);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(802, 45);
            this.menu.TabIndex = 1;
            // 
            // forward
            // 
            this.forward.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.forward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.forward.FlatAppearance.BorderSize = 0;
            this.forward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forward.Location = new System.Drawing.Point(415, 17);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(30, 30);
            this.forward.TabIndex = 11;
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // playpause
            // 
            this.playpause.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.playpause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playpause.FlatAppearance.BorderSize = 0;
            this.playpause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playpause.Location = new System.Drawing.Point(379, 17);
            this.playpause.Name = "playpause";
            this.playpause.Size = new System.Drawing.Size(30, 30);
            this.playpause.TabIndex = 10;
            this.playpause.UseVisualStyleBackColor = true;
            this.playpause.Click += new System.EventHandler(this.playpause_Click);
            // 
            // reverse
            // 
            this.reverse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.reverse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reverse.FlatAppearance.BorderSize = 0;
            this.reverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reverse.Location = new System.Drawing.Point(343, 17);
            this.reverse.Name = "reverse";
            this.reverse.Size = new System.Drawing.Size(30, 30);
            this.reverse.TabIndex = 9;
            this.reverse.UseVisualStyleBackColor = true;
            this.reverse.Click += new System.EventHandler(this.reverse_Click);
            // 
            // volumeButton
            // 
            this.volumeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("volumeButton.BackgroundImage")));
            this.volumeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.volumeButton.FlatAppearance.BorderSize = 0;
            this.volumeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volumeButton.Location = new System.Drawing.Point(5, 17);
            this.volumeButton.Name = "volumeButton";
            this.volumeButton.Size = new System.Drawing.Size(30, 30);
            this.volumeButton.TabIndex = 8;
            this.volumeButton.UseVisualStyleBackColor = true;
            this.volumeButton.Click += new System.EventHandler(this.volumeButton_Click);
            // 
            // currentTimeBar
            // 
            this.currentTimeBar.Location = new System.Drawing.Point(2, 0);
            this.currentTimeBar.Name = "currentTimeBar";
            this.currentTimeBar.Size = new System.Drawing.Size(797, 15);
            this.currentTimeBar.TabIndex = 7;
            this.currentTimeBar.TabStop = false;
            this.currentTimeBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.currentTimeBar_MouseDown);
            this.currentTimeBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.currentTimeBar_MouseMove);
            this.currentTimeBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentTimeBar_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // menu2
            // 
            this.menu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.menu2.Controls.Add(this.quitButton);
            this.menu2.Controls.Add(this.maximumSizeButton);
            this.menu2.Controls.Add(this.simgeDurumundaKucult);
            this.menu2.Location = new System.Drawing.Point(0, 0);
            this.menu2.Name = "menu2";
            this.menu2.Size = new System.Drawing.Size(802, 30);
            this.menu2.TabIndex = 4;
            // 
            // quitButton
            // 
            this.quitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitButton.BackgroundImage")));
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitButton.FlatAppearance.BorderSize = 0;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Location = new System.Drawing.Point(770, 0);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(30, 30);
            this.quitButton.TabIndex = 14;
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // maximumSizeButton
            // 
            this.maximumSizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.maximumSizeButton.FlatAppearance.BorderSize = 0;
            this.maximumSizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximumSizeButton.Location = new System.Drawing.Point(734, 0);
            this.maximumSizeButton.Name = "maximumSizeButton";
            this.maximumSizeButton.Size = new System.Drawing.Size(30, 30);
            this.maximumSizeButton.TabIndex = 13;
            this.maximumSizeButton.UseVisualStyleBackColor = true;
            this.maximumSizeButton.Click += new System.EventHandler(this.maximumSizeButton_Click);
            // 
            // simgeDurumundaKucult
            // 
            this.simgeDurumundaKucult.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simgeDurumundaKucult.BackgroundImage")));
            this.simgeDurumundaKucult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.simgeDurumundaKucult.FlatAppearance.BorderSize = 0;
            this.simgeDurumundaKucult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simgeDurumundaKucult.Location = new System.Drawing.Point(698, 0);
            this.simgeDurumundaKucult.Name = "simgeDurumundaKucult";
            this.simgeDurumundaKucult.Size = new System.Drawing.Size(30, 30);
            this.simgeDurumundaKucult.TabIndex = 12;
            this.simgeDurumundaKucult.UseVisualStyleBackColor = true;
            this.simgeDurumundaKucult.Click += new System.EventHandler(this.simgeDurumundaKucult_Click);
            // 
            // volumeContainer
            // 
            this.volumeContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.volumeContainer.Controls.Add(this.volumeBar);
            this.volumeContainer.Location = new System.Drawing.Point(5, 389);
            this.volumeContainer.Name = "volumeContainer";
            this.volumeContainer.Size = new System.Drawing.Size(118, 33);
            this.volumeContainer.TabIndex = 6;
            // 
            // volumeBar
            // 
            this.volumeBar.Location = new System.Drawing.Point(4, 9);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(110, 15);
            this.volumeBar.TabIndex = 0;
            this.volumeBar.TabStop = false;
            this.volumeBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.volumeBar_MouseDown);
            this.volumeBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.volumeBar_MouseMove);
            this.volumeBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.volumeBar_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.volumeContainer);
            this.Controls.Add(this.menu2);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentTimeBar)).EndInit();
            this.menu2.ResumeLayout(false);
            this.volumeContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Panel menu2;
        private System.Windows.Forms.Panel volumeContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox currentTimeBar;
        private System.Windows.Forms.Button volumeButton;
        private System.Windows.Forms.Button reverse;
        private System.Windows.Forms.Button playpause;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button simgeDurumundaKucult;
        private System.Windows.Forms.Button maximumSizeButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.PictureBox volumeBar;
    }
}

