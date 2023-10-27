using ShopApp.DataAccess;

namespace ShopApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            var dbContext = new ShopDbContext();
            category.Text = dbContext.Categories.Count().ToString();
            client.Text = dbContext.Clients.Count().ToString();
            product.Text = dbContext.Products.Count().ToString();   
        }

    
    }
}