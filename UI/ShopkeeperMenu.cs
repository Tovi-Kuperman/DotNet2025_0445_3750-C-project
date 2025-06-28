using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ShopkeeperMenu : Form
    {
        public ShopkeeperMenu()
        {
            InitializeComponent();
        }

        private void productsbtn_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }
    }
}
