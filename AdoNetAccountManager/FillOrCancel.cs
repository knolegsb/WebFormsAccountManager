using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetAccountManager
{
    public partial class FillOrCancel : Form
    {
        private int parsedOrderID;
        string connStr = AdoNetAccountManager.Utility.GetConnectionString();
        public FillOrCancel()
        {
            InitializeComponent();
        }


    }
}
