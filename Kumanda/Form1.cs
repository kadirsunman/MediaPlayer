using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

using WMPLib;

namespace Kumanda
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        int screenWidth, screenHeight;
        int time = 0;
        string menuState = null;
        string menu2State = null;
        string CurrentVideoPath = null;
        string videoState = null;
        int cursorPositionXPrevious = 0, cursorPositionYPrevious = 0;
        string sizeState = "normal";
        int screenWidthPrevious = 0, screenHeightPrevious = 0, screenLocationXPrevious = 0, screenLocationYPrevious = 0;
        bool volumeShowState = false;

        int mediaTime = 0;

        int value, volumeValue;
        Rectangle durationTimeBox;
        Rectangle currentTimeBox;
        bool drawState = false;
        bool volumeDrawState = false;
        int volumeDeger = 0;
        int deger = 0;


        private void Form1_Load(object sender, EventArgs e)
        {

            volumeContainer.Visible = false;
            volumeContainer.BackColor = Color.FromArgb(31,31,31);
            maximumSizeButton.BackgroundImage = Image.FromFile("img/maximizeButton2.png");
            playpause.BackgroundImage = Image.FromFile("img/play.png");
            forward.BackgroundImage = Image.FromFile("img/forward.png");
            reverse.BackgroundImage = Image.FromFile("img/backForward.png");

            axWindowsMediaPlayer1.Width = this.Width;
            axWindowsMediaPlayer1.Height = this.Height;
            axWindowsMediaPlayer1.Location = new Point(0, 0);
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.enableContextMenu = false;
            axWindowsMediaPlayer1.settings.volume = 50;

            screenWidth = this.Width;
            screenHeight = this.Height;
            

            // Menü boyutları ayarları ve açılımı
            menu.Width = screenWidth;
            menu.Height = 80;
            menu.Location = new Point(0, screenHeight);

            menu2.Width = screenWidth;
            menu2.Height = 30;
            menu2.Location = new Point(0, 0);

            currentTimeBar.Width = menu.Width;
            currentTimeBar.Height = 15;
            currentTimeBar.Location = new Point(0, 0);
            mediaTime = currentTimeBar.Width;

            volumeBar.Width = volumeContainer.Width - 4;
            volumeBar.Height = 15;
            volumeBar.Location = new Point(2, volumeContainer.Height / 2 - 15 / 2);

            Color darkGray =Color.FromArgb(100, 80, 80, 80);
            volumeButton.FlatAppearance.MouseDownBackColor = darkGray;
            reverse.FlatAppearance.MouseDownBackColor = darkGray;
            forward.FlatAppearance.MouseDownBackColor = darkGray;
            playpause.FlatAppearance.MouseDownBackColor = darkGray;
            simgeDurumundaKucult.FlatAppearance.MouseDownBackColor = darkGray;
            maximumSizeButton.FlatAppearance.MouseDownBackColor = darkGray;
            quitButton.FlatAppearance.MouseDownBackColor = darkGray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            menuOpenOrClose();
            currentTime();
            buttonsLocation();

            if (menu.Location.Y > this.Height - menu.Height + 30 && menuState == "menuOpen")
            {
                menu.Location = new Point(0, menu.Location.Y - 3);
            }
            if (time % 1 == 0 && menu.Location.Y < this.Height && menuState == "menuClose")
            {
                menu.Location = new Point(0, menu.Location.Y + 3);
                volumeContainer.Visible = false;
                volumeShowState = false;
            }
            if (menu2.Location.Y < 0 && menu2State == "menuOpen")
            {
                menu2.Location = new Point(0, menu2.Location.Y + 1);
            }
            if (time % 1 == 0 && menu2.Location.Y > - menu2.Height && menu2State == "menuClose")
            {
                menu2.Location = new Point(0, menu2.Location.Y - 1);
            }
            if (time % 200 == 0)
            {
                cursorPositionXPrevious = Cursor.Position.X;
                cursorPositionYPrevious = Cursor.Position.Y;
            }
            if (time % 10 == 0) 
            {
                currentTimeBarFunction(deger, currentTimeBar, drawState,true);
                currentTimeBarFunction(axWindowsMediaPlayer1.settings.volume, volumeBar, true, false);
            }
            
        }

        private void playpause_Click(object sender, EventArgs e)
        {
            if (videoState == "Undefined" || videoState == null) 
            {
                OpenFileDialog file = new OpenFileDialog();
                file.ShowDialog();
                CurrentVideoPath = file.FileName;
                axWindowsMediaPlayer1.URL = CurrentVideoPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playpause.BackgroundImage = Image.FromFile("img/pause.png");

            }
            else if (videoState == "Paused" || videoState == "Stopped")
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playpause.BackgroundImage = Image.FromFile("img/pause.png");
            }
            else if (videoState == "Playing")
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                playpause.BackgroundImage = Image.FromFile("img/play.png");
            }
            

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 0)
            {
                videoState = "Undefined";
            }
            if (e.newState == 1)
            {
                videoState = "Stopped";
            }
            if (e.newState == 2)
            {
                videoState = "Paused";
            }
            if (e.newState == 3)
            {
                videoState = "Playing";
                mediaTime = Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration);
            }
            if (e.newState == 8)
            {
                videoState = "MediaEnded";
            }
            
        }
    
        private void stop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void forward_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition + 10;
            if(videoState == "Paused")
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            
        }

        private void reverse_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition - 10;
            if (videoState == "Paused")
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }

        private void simgeDurumundaKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void volumeButton_Click(object sender, EventArgs e)
        {
            

            if(volumeShowState == false)
            {
                volumeContainer.Visible = true;
                volumeShowState = true;
                
            }
            else if  (volumeShowState == true)
            {
                volumeContainer.Visible = false;
                volumeShowState = false;
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_SHOW);
        }

        public void menuOpenOrClose()
        {
            //Menünün Olduğu Alan Sorgulaması
            if ((Cursor.Position.X > this.Location.X - 10 && Cursor.Position.X < this.Location.X + menu.Width + 10) && (Cursor.Position.Y > this.Location.Y + this.Height - menu.Height + 10 && Cursor.Position.Y <  this.Location.Y + this.Height + 10))
            {
                menuState = "menuOpen";
            }
            else
            {
                menuState = "menuClose";
            }
            if(Cursor.Position.X == cursorPositionXPrevious && Cursor.Position.Y == cursorPositionYPrevious)
            {
                menu2State = "menuClose";
            }
            else
            {
                menu2State = "menuOpen";
            }

        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Left Button Click");
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximumSizeButton_Click(object sender, EventArgs e)
        {
            if(sizeState == "normal")
            {
                screenWidthPrevious = this.Width;
                screenHeightPrevious = this.Height;

                screenLocationXPrevious = this.Location.X;
                screenLocationYPrevious = this.Location.Y;


                this.Location = new Point(0, 0);
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;

                menu.Width = this.Width;
                menu2.Width = this.Width;
                menu.Location = new Point(0, this.Height);
                currentTimeBar.Width = menu.Width;

                axWindowsMediaPlayer1.Width = this.Width;
                axWindowsMediaPlayer1.Height = this.Height;

                sizeState = "maximum";
                maximumSizeButton.BackgroundImage = Image.FromFile("img/minimizeButton.png");


                int hwnd = FindWindow("Shell_TrayWnd", "");
                ShowWindow(hwnd, SW_HIDE);
                this.TopMost = true;

            }
            else if(sizeState == "maximum")
            {
                this.Location = new Point(screenLocationXPrevious, screenLocationYPrevious);
                this.Width = screenWidthPrevious;
                this.Height = screenHeightPrevious;

                menu.Width = this.Width;
                menu2.Width = this.Width;
                menu.Location = new Point(0, this.Height);
                currentTimeBar.Width = menu.Width;

                axWindowsMediaPlayer1.Width = this.Width;
                axWindowsMediaPlayer1.Height = this.Height;
                sizeState = "normal";
                maximumSizeButton.BackgroundImage = Image.FromFile("img/maximizeButton2.png");

                int hwnd = FindWindow("Shell_TrayWnd", "");
                ShowWindow(hwnd, SW_SHOW);
                this.TopMost = false;
            }
            
        }

       
        public double MapValue(double a0, double a1, double b0, double b1, double a)
        {
            return b0 + (b1 - b0) * ((a - a0) / (a1 - a0));
        }

        private void volumeBar_MouseDown(object sender, MouseEventArgs e)
        {
            volumeDrawState = true;
        }

        private void volumeBar_MouseUp(object sender, MouseEventArgs e)
        {
            volumeDrawState = false;
        }

        private void volumeBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (volumeDrawState == true && (e.X < volumeBar.Width+5  && e.X > 9))
            {
                volumeValue = e.X - 10;
                axWindowsMediaPlayer1.settings.volume = volumeValue;

            }
        }

        

        private void currentTimeBar_MouseDown(object sender, MouseEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            drawState = true;

        }

        private void currentTimeBar_MouseUp(object sender, MouseEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            drawState = false;
        }

        private void currentTimeBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawState == true && (e.X < currentTimeBar.Width - 15 && e.X > 10))
            {
                value = e.X - 10;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = Convert.ToInt32(MapValue(0, currentTimeBar.Width, 0, mediaTime, value));
                
            }
            
        }
        public void currentTime()
        {

            if (Convert.ToInt32(axWindowsMediaPlayer1.Ctlcontrols.currentPosition) > 0)
            {
                deger = Convert.ToInt32(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
            }
        }
        public void buttonsLocation()
        {
            quitButton.Location = new Point(this.Width - quitButton.Width, 0);
            maximumSizeButton.Location = new Point(this.Width - maximumSizeButton.Width - quitButton.Width - 2, 0);
            simgeDurumundaKucult.Location = new Point(this.Width - simgeDurumundaKucult.Width - maximumSizeButton.Width - quitButton.Width - 4, 0);
            volumeContainer.Location = new Point(5, menu.Location.Y - volumeContainer.Height / 2);

            if (axWindowsMediaPlayer1.settings.volume > 70)
            {
                volumeButton.BackgroundImage = Image.FromFile("img/highVolume.png");
            }
            else if (axWindowsMediaPlayer1.settings.volume <= 70 && axWindowsMediaPlayer1.settings.volume > 35)
            {
                volumeButton.BackgroundImage = Image.FromFile("img/middleVolume.png");
            }
            else if (axWindowsMediaPlayer1.settings.volume <= 35 && axWindowsMediaPlayer1.settings.volume > 0)
            {
                volumeButton.BackgroundImage = Image.FromFile("img/lowVolume.png");
            }
            else if (axWindowsMediaPlayer1.settings.volume == 0)
            {
                volumeButton.BackgroundImage = Image.FromFile("img/muteVolume.png");
            }
        }

        public void currentTimeBarFunction(int hamValue, PictureBox cizimAlani, bool drawState, bool drawVolumeState)
        {
            SolidBrush blue = new SolidBrush(Color.FromArgb(64, 151, 219));
            SolidBrush darkgrey = new SolidBrush(Color.FromArgb(31, 31, 31));
            SolidBrush dark = new SolidBrush(Color.FromArgb(40, 40, 40));
            Pen bluePen = new Pen(Color.FromArgb(64, 151, 219), 2);

            if (drawState == false && videoState != "Undefined" && drawVolumeState == true)
            {
                value = Convert.ToInt32(MapValue(0, mediaTime, 0, currentTimeBar.Width, hamValue));
            }
            else if (drawVolumeState == false)
            {
                value = hamValue;
            }

            int radius = cizimAlani.Height / 2;
            int centerX = value + radius / 4;
            int centerY = radius;

            Graphics g = cizimAlani.CreateGraphics();
            g.Clear(Color.FromArgb(40, 40, 40));
            currentTimeBox = new Rectangle(5, cizimAlani.Height / 2 - cizimAlani.Height / 4, value, cizimAlani.Height / 2);
            g.FillRectangle(darkgrey, durationTimeBox);
            g.FillRectangle(blue, currentTimeBox);
            g.FillEllipse(blue, centerX, centerY - radius, radius + radius, radius + radius);
            g.DrawRectangle(bluePen, 0, 0, cizimAlani.Width, cizimAlani.Height);

        }
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int menuState)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)menuState, IntPtr.Zero);
        }
    }
    
}
