using Microsoft.Extensions.Configuration;

namespace UlukunShopAPI.Persistence;

static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            //connection stringi appsettings içinden alabilmek icin 2 eklenti yüklendi. burada hangi json dosyasina gidecegini gösteriyoruz.
            ConfigurationManager configurationManager = new();

            try
            {
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                    "../../Presentation/UlukunShopAPI.API"));
                configurationManager.AddJsonFile("appsettings.json");


            }
            catch
            {
                //bu kisim uygulama deploy oldugu zaman connectionstringi publishte okuyabilmesi icin eklendi.
                configurationManager.AddJsonFile("appsettings.Production.json");
            }
            
            // return configurationManager.GetConnectionString("SqliteConnection");
            return configurationManager.GetConnectionString("PostgreSQL");

        }
    }
}