using DevSore.Domain;
using DevStore.Infra.Mappings;
using System.Data.Entity;

namespace DevStore.Infra.DataContext
{
    public class DevStoreDataContext : DbContext
    {
        public DevStoreDataContext() : base("Conexao")
        {
            //Database.SetInitializer<DevStoreDataContext>(new DevStoreDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            base.OnModelCreating(modelBuilder); 
        }

    }

    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {
        protected override void Seed(DevStoreDataContext context)
        {

            //context.Categories.Add(new Category { Id = 1, Title = "Informatica" });
            //context.Categories.Add(new Category { Id = 2, Title = "Games" });
            //context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            //context.SaveChanges();


            //context.Product.Add(new Product { Id = 1, CateogoryId = 1, Title = "GTX 770 4GB", Price = 1200, IsActive = true, });
            //context.Product.Add(new Product { Id = 2, CateogoryId = 1, Title = "HD 1TB SSD", Price = 120, IsActive = true, });
            //context.Product.Add(new Product { Id = 3, CateogoryId = 2, Title = "Battlefield 1", Price = 400, IsActive = true, });
            //context.Product.Add(new Product { Id = 4, CateogoryId = 3, Title = "Folha Sulfite", Price = 15, IsActive = true, });
            //context.SaveChanges();

            //base.Seed(context);
            context.Categories.Add(new Category { Id = 1, Title = "Informática" });
            context.Categories.Add(new Category { Id = 2, Title = "Games" });
            context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            context.SaveChanges();

            context.Product.Add(new Product { Id = 1, CateogoryId = 1, IsActive = true, Title = "Mouse Microsoft Confort 5000", Price = 99 });
            context.Product.Add(new Product { Id = 2, CateogoryId = 1, IsActive = true, Title = "Teclado Microsoft Confort 5000", Price = 199 });
            context.Product.Add(new Product { Id = 3, CateogoryId = 1, IsActive = true, Title = "Mouse Pad Razor", Price = 59 });

            context.Product.Add(new Product { Id = 4, CateogoryId = 2, IsActive = true, Title = "Gears of War", Price = 59 });
            context.Product.Add(new Product { Id = 5, CateogoryId = 2, IsActive = true, Title = "Gears of War 2", Price = 79 });
            context.Product.Add(new Product { Id = 6, CateogoryId = 2, IsActive = true, Title = "Gears of War 3", Price = 99 });

            context.Product.Add(new Product { Id = 7, CateogoryId = 3, IsActive = true, Title = "Papel Sulfite 1000 folhas", Price = 9.89M });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
