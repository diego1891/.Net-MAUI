using ShopApp;
using ShopApp.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage, IQueryAttributable
{
	public HelpSupportDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Title = $"Cliente : {query["id"]}";
		var clientId = int.Parse(query["id"].ToString()) ;
		(BindingContext as HelpSupportDetailData).ClienteId = clientId;
    }

}

public class HelpSupportDetailData : BindingUtilObjects
{
	private ObservableCollection<Product> _products;

    public HelpSupportDetailData()
    {
		var database = new ShopDbContext();
		Products= new ObservableCollection<Product>(database.Products);
		AddCommand = new Command(	() =>
		{
			var compra = new Compra(ClienteId, ProductoSeleccionado.Id, Cantidad);
			Compras.Add(compra);
		},
		() => true
		);
    }

	public ICommand AddCommand { get; set; }

	private ObservableCollection<Compra> _compras = new ObservableCollection<Compra>();

	public ObservableCollection<Compra> Compras
	{
		get { return _compras ; }
		set {
            if (Compras != value)
            {
				_compras = value;
				RaisePropertyChanged();
            }
        }
	}


	private int _clienteId;

	public int ClienteId
	{
		get { return _clienteId; }
		set { _clienteId = value; }
	}


	public  ObservableCollection<Product> Products
	{
		get { return _products; }
		set
		{
			if (_products != value)
			{
				_products = value;
				RaisePropertyChanged();
			}

		}

	}

	private Product _productoSeleccionado;

	public Product ProductoSeleccionado
	{
        get { return _productoSeleccionado; }
        set
        {
            if (_productoSeleccionado != value)
            {
                _productoSeleccionado = value;
                RaisePropertyChanged();
            }

        }
    }

	private int _cantidad;

	public int Cantidad
	{
		get { return _cantidad; }
		set
		{
			if (_cantidad != value)
			{
				_cantidad = value;
				RaisePropertyChanged();
			}
		}
	}

}