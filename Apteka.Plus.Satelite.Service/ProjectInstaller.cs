﻿using System.ComponentModel;
using System.Configuration.Install;

namespace Satelite.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
