using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using OnlineStoreDomain;

namespace OnlineStoreRepository
{
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<Store>
    {
        protected override void Seed(Store context)
        {
            context.Types.Add(new TypeEntity { Id = 1, Name = "Чаи" });
            context.Types.Add(new TypeEntity { Id = 2, Name = "Газировки" });
            context.Types.Add(new TypeEntity { Id = 3, Name = "Соки" });
            context.Types.Add(new TypeEntity { Id = 4, Name = "Энергетики" });


            context.Products.Add(new ProductEntity { Id = 1, Name = "Coca-Cola", Price = 98, Volume = 2 , TypeEntityId = 2});
            context.Products.Add(new ProductEntity { Id = 2, Name = "Pepsi", Price = 102, Volume = 2.25, TypeEntityId = 2 });
            context.Products.Add(new ProductEntity { Id = 3, Name = "Red Bull", Price = 150, Volume = 0.5, TypeEntityId = 4 });
            context.Products.Add(new ProductEntity { Id = 4, Name = "Burn", Price = 90, Volume = 0.33, TypeEntityId = 4 });
            context.Products.Add(new ProductEntity { Id = 5, Name = "Arizona Green Tea", Price = 100, Volume = 0.5, TypeEntityId = 1 });
            context.Products.Add(new ProductEntity { Id = 6, Name = "Nestea Lemon", Price = 80, Volume = 1.5, TypeEntityId = 1 });
            context.Products.Add(new ProductEntity { Id = 7, Name = "Rich Pomegranate", Price = 120, Volume = 1, TypeEntityId = 3 });
            context.Products.Add(new ProductEntity { Id = 8, Name = "Я Апельсин", Price = 135, Volume = 1, TypeEntityId = 3 });


            base.Seed(context);
            context.SaveChanges();

        }
    }
}