

namespace ShopApp.Services;

public class DatabaseRutaService : IDatabaseRutaService
{
    public string Get(string nombreArchivo)
    {
        Console.WriteLine("archivo: "+nombreArchivo);
        var rutaDirectorio = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(rutaDirectorio, nombreArchivo);
    }
}
