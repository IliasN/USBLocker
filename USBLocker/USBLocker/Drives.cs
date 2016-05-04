﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace USBLocker
{
    class Drives
    {
        #region Fields

        private List<string> _drivesPath;
        private const string FILE = "usblock.txt";

        #endregion

        #region Properties

        public List<string> DrivesPath
        {
            get
            {
                return _drivesPath;
            }

            set
            {
                _drivesPath = value;
            }
        }

        #endregion

        #region Methodes

        #region Constructor

        public Drives()
        {
            //Init vars
            this.DrivesPath = new List<string>();
            //Get drives
            DriveInfo[] driveList = DriveInfo.GetDrives();

            foreach (DriveInfo drive in driveList)
            {
                this.DrivesPath.Add(drive.Name.ToString());
            }

        }

        #endregion

        public string CheckFile()
        {
            foreach (var drive in this.DrivesPath)
            {
                if (File.Exists(drive + FILE))
                    return drive;
            }
            return null;
        }

        #endregion
    }
}
