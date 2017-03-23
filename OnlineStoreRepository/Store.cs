using OnlineStoreDomain;
using System;
using System.Data.Entity;
using System.Linq;
namespace OnlineStoreRepository
{

    public class Store : DbContext
    {
        // Контекст настроен для использования строки подключения "Store" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "OnlineStoreRepository.Store" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Store" 
        // в файле конфигурации приложения.
        static Store()
        {
            Database.SetInitializer<Store>(new StoreDbInitializer());
        }

        public Store()
            : base("Store")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<TypeEntity> Types { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }

    }
    
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}