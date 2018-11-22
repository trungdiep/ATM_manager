﻿using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validate
{
    public partial class Feature : Form
    {
        private ResourceManager rm;
        private CardDTO card;

        public Feature(ResourceManager rm, CardDTO card = null)
        {
            this.rm = rm;
            this.card = card;
            InitializeComponent();
        }

        private void Feature_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new DoiPin(this.rm, this.card)).Show();
        }
    }
}
