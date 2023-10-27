using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess;

    internal class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopComputer");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category(1, "Electronicos"),
            new Category(2, "Computadoras"),
            new Category(3, "Telefonos Moviles"),
            new Category(4, "Dispositivos de Escritorio"),
            new Category(5, "Microfonos y Audio"),
            new Category(6, "Artefactos del Hogar"),
            new Category(7, "Juguetes y Juegos")
            );

        modelBuilder.Entity<Product>().HasData(
            new Product(1, "Radio Digital", "Es una radio de banda ancha", 100, 1),
            new Product(2, "Reloj electronico honda", "Reloj de muy buena sincronización", 50, 1),
            new Product(3, "Laptop HP", "Laptop para escritorio y manejo de office", 900, 2),
            new Product(4, "Laptop Acer", "Laptop para juegos avanzados de memoria", 1200, 2),
            new Product(5, "Mackbook Apple", "Mackbook para trasnporte de gran capacidad", 1500,2),
            new Product(6, "Samsung Galaxy 2", "TElefono con 5G y media", 1800, 3),
            new Product(7, "IPhone 4", "Apple dispositivo de gran capacidad", 1500, 3)
            );

        modelBuilder.Entity<Client>().HasData(
            new Client(1, "Martin Perez", "Av. 18 de Julio 1869"),
            new Client(2, "Francisco Rodriguez", "Av. Rivera 1502")
            );
    }
}

public record Category(int Id, string Nombre);
public record Product(int Id, string Nombre, string Descripcion, decimal Precio, int CategoryId)
{ 
    public Category Category {  get; set; }
}
public record Client(int Id, string Nombre, string Direccion);