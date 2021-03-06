﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBLocker
{
    public partial class Form1 : Form
    {
        #region Fields

        private bool _locked;
        private Image _img;

        #endregion

        #region Properties

        public bool Locked
        {
            get
            {
                return _locked;
            }

            set
            {
                _locked = value;
            }
        }

        #endregion

        #region Methodes

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Hide the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            _img = Image.FromFile("wallpaper.png");
            pibWallpaper.Image = _img;
            Data data = new Data(this);
            data.Start();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        /// <summary>
        /// Lock the window and show it
        /// </summary>
        public void Lock()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Locked = true;
            Show();
            this.TopMost = true;
        }

        /// <summary>
        /// Unlock and hide the window
        /// </summary>
        public void Unlock()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Locked = false;
            Hide();
            this.TopMost = false;
        }

        #endregion

        /// <summary>
        /// Show the window to block the PC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrLock_Tick(object sender, EventArgs e)
        {
            if (this.Locked)
            {
                Cursor.Position = new Point(0, 0);
                this.Activate();
                try
                {
                    SendKeys.Send("{ESC}");
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Locked)
                e.Cancel = true;
        }
    }
}
