using Chempions.Common.DAO;

namespace Chempions.Data.Sql.Migrations;

public class DatabaseSeed
{
    private readonly ChempionsDbContext _context;
        
    //wstrzyknięcie instancji klasy FoodlyDbContext poprzez konstruktor
    public DatabaseSeed(ChempionsDbContext context)
    {
        _context = context;
    }
    public void Seed()
    {
        #region CreateProducts
        var productList = BuildProdList();
        _context.Product.AddRange(productList);
        _context.SaveChanges();
        #endregion
        
        #region CreateWarehouse
        var warehousetList = BuildWareList();
        _context.Warehouse.AddRange(warehousetList);
        _context.SaveChanges();
        #endregion
        
        #region CreateClient
        var clientList = BuildClieList();
        _context.Client.AddRange(clientList);
        _context.SaveChanges();
        #endregion
        
        #region CreateInvoice
        var invoiceList = BuildInvoList();
        _context.Invoice.AddRange(invoiceList);
        _context.SaveChanges();
        #endregion
        
        #region CreateOrder
        var orderList = BuildOrdList();
        _context.Order.AddRange(orderList);
        _context.SaveChanges();
        #endregion
        
        #region CreateBasket
        var basketList = BuildBaskList();
        _context.Basket.AddRange(basketList);
        _context.SaveChanges();
        #endregion
        
    }

    private IEnumerable<Product> BuildProdList()
    {
        var productList = new List<Product>();
        var Product = new Product()
        {
            Nazwa = "WPC 80 250g",
            Producent = "Xtitan",
            Kategoria = "Bialko",
            CenaNetto = 25,
            CenaBrutto = 30.75
        };
        productList.Add(Product);
        var Product2 = new Product()
        {
            Nazwa = "Creatine Monohydrate 500g",
            Producent = "Xtitan",
            Kategoria = "Kreatyna",
            CenaNetto = 30,
            CenaBrutto = 36.90
        };
        productList.Add(Product2);
        var Product3 = new Product()
        {
            Nazwa = "Napalm 200ml",
            Producent = "SFD",
            Kategoria = "Przedtreningówka",
            CenaNetto = 5,
            CenaBrutto = 5.90
        };
        productList.Add(Product3);
        var Product4 = new Product()
        {
            Nazwa = "ClenBurexin 60caps",
            Producent = "Trec",
            Kategoria = "Spalacz",
            CenaNetto = 50,
            CenaBrutto = 55.90
        };
        productList.Add(Product4);
        var Product5 = new Product()
        {
            Nazwa = "Protein Bar",
            Producent = "Trec",
            Kategoria = "białko",
            CenaNetto = 2,
            CenaBrutto = 2.5
        };
        productList.Add(Product5);
        return productList;
    }

    private IEnumerable<Warehouse> BuildWareList()
    {
        var warehouseList = new List<Warehouse>();
        var Warehouse = new Warehouse()
        {
            DataWaznosci = new DateTime(2024,05,05),
            Ilosc=100,
            Partia="AAB01",
            Idprod=1
        };
        warehouseList.Add(Warehouse);
        var Warehouse2 = new Warehouse()
        {
            DataWaznosci = new DateTime(2023,06,05),
            Ilosc=80,
            Partia="ABK01",
            Idprod=2
        };
        warehouseList.Add(Warehouse2);
        return warehouseList;
    }
    
    private IEnumerable<Client> BuildClieList()
    {
        var clientList = new List<Client>();
        var Client = new Client()
        {
            NazwaFirmy="TrecTeam",
            NIP=11111111,
            Imie="Krzystof",
            Nazwisko="Puchacki"
        };
        clientList.Add(Client);
        var Client2 = new Client()
        {
            NazwaFirmy="SFD",
            NIP=22222222,
            Imie="Cieslak",
            Nazwisko="JedenDwaTrzy"
        };
        clientList.Add(Client2);
        return clientList;
    }
    
    private IEnumerable<Invoice> BuildInvoList()
    {
        var invoiceList = new List<Invoice>();
        var Invoice = new Invoice()
        {
            DataWyst=new DateTime(2022,11,23),
            CenaBrutto=12654,
            CenaNetto=10800,
            StautsOplacenia=true,
            IdKlient=1
        };
        invoiceList.Add(Invoice);
        var Invoice2 = new Invoice()
        {
            DataWyst=new DateTime(2023,01,09),
            CenaBrutto=8654,
            CenaNetto=6800,
            StautsOplacenia=true,
            IdKlient=2
        };
        invoiceList.Add(Invoice2);
        return invoiceList;
    }
    
    private IEnumerable<Order> BuildOrdList()
    {
        var orderList = new List<Order>();
        var Order = new Order()
        {
            DeadLine=new DateTime(2023,01,25),
            StatusRealizacji=true,
            IdKlient=1,
            IdFakt=1
        };
        orderList.Add(Order);
        var Order2 = new Order()
        {
            DeadLine=new DateTime(2023,01,19),
            StatusRealizacji=true,
            IdKlient=2,
            IdFakt=2
        };
        orderList.Add(Order2);
        return orderList;
    }
    
    private IEnumerable<Basket> BuildBaskList()
    {
        var basketList = new List<Basket>();
        var basket = new Basket()
        {
            Ilosc=90,
            IdZam=1,
            IdProd=1
        };
        basketList.Add(basket);
        var Basket2 = new Basket()
        {
            Ilosc=200,
            IdZam=2,
            IdProd=2
        };
        basketList.Add(Basket2);
        return basketList;
    }
    
}
