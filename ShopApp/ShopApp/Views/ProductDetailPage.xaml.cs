using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
	public ProductDetailPage()
	{
		InitializeComponent();


	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse (query["id"].ToString());
        var producto = dbContext.Products.First(x => x.Id == id);
        container.Children.Add(new Label { Text = producto.Nombre });
        container.Children.Add(new Label { Text = producto.Descripcion });
        container.Children.Add(new Label { Text = producto.Precio.ToString() });
    }
}