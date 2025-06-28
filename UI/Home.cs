namespace UI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
       
        }

        private void shopkeeperbtn_Click(object sender, EventArgs e)
        {
            ShopkeeperMenu shopkeeperMenu = new ShopkeeperMenu();
            shopkeeperMenu.Show();
        }

        private void customerbtn_Click(object sender, EventArgs e)
        {
            StartOrder startOrder = new StartOrder();
            startOrder.Show();
        }
    }
}
