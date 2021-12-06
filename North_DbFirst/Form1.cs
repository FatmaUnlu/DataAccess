using Microsoft.EntityFrameworkCore;
using North_DbFirst.Models;
using North_DbFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace North_DbFirst
{
    public partial class Form1 : Form
    {
        private NorthwindYeniContext _dbContext = new NorthwindYeniContext();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //RaporuGoster();
            //var query1 = _dbContext.Categories.Select(x => x.CategoryName).ToList();

            //iki satır arasında bişeyleri çekerken kullanabilirsin. Bulunduğu scopta çalışır sadece
            //var query2 = _dbContext.Categories.Select(x => new 
            //{
            //    x.CategoryName,
            //    x.Description,
            //    x.Picture 
            //}).ToList();

            //dgvNorth.DataSource = query2;

            //bu şekilde join türlerini vs kendisine göre ayarlar. Kendimiz ayarlamak istiyorsak from lu sorgu yazılmalı.
            var query1 = _dbContext.Categories.Select(x => new CategoryViewModel()
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture,
                ProductCount = x.Products.Count
            }).ToList();

            dgvNorth.DataSource = query1;

            var query2 = from cat in _dbContext.Categories
                         join prod in _dbContext.Products on cat.CategoryId equals prod.CategoryId
                         where prod.UnitPrice > 20
                         select new
                         {
                             cat.CategoryName,
                             prod.ProductName,
                             prod.UnitPrice
                         };

            dgvNorth.DataSource = query2
                .OrderBy(x => x.CategoryName)
                .ThenByDescending(x => x.UnitPrice)
                .ToList();


            var query3 = _dbContext.Products.Select(x => new
            {
                x.Category.CategoryName,
                x.ProductName,
                x.UnitPrice
            }).OrderBy(x => x.CategoryName)
                .ThenByDescending(x => x.UnitPrice)
                .ToList();
            dgvNorth.DataSource = query3;

            ///
            var query4 = from order in _dbContext.Orders
                         join shipper in _dbContext.Shippers on order.ShipVia equals shipper.ShipperId
                         join employee in _dbContext.Employees on order.EmployeeId equals employee.EmployeeId
                         where shipper.CompanyName == "Federal Shipping " && employee.FirstName == "Nancy"
                         select new
                         {
                             order.OrderId,

                         };

            dgvNorth.DataSource = query4
                .OrderBy(x => x.OrderId)
                .ToList();


            var query5 = _dbContext.Products.Select(x => new
            {
                x.Category.CategoryName,
                x.ProductName,
                x.UnitPrice,
                x.Supplier.CompanyName
            }).OrderBy(x => x.CategoryName)
                .ToList();
            dgvNorth.DataSource = query5;


            var query6 = _dbContext.Products.Select(x => new ProductViewModel()
            {
                ProductName = x.ProductName,
                UnitPrice = (decimal)x.UnitPrice,
                UnitsInStock = (short)x.UnitsInStock,
                Maliyet = ((decimal)x.UnitPrice) * ((short)x.UnitsInStock)
            }).OrderByDescending(x => x.Maliyet)
            .ToList();

            dgvNorth.DataSource = query6;

            var query7 = from od in _dbContext.OrderDetails
                         join prod in _dbContext.Products on od.ProductId equals prod.ProductId
                         select new
                         {
                             prod.ProductName,
                             prod.UnitPrice,
                             OrderPrice = od.UnitPrice,
                             od.Quantity,
                             od.Discount

                         };

            dgvNorth.DataSource = query7
                .ToList();

            //hangi üründen ne kadarlık satış yapıldı
            var query8 = from prod in _dbContext.Products
                         join od in _dbContext.OrderDetails on prod.ProductId equals od.ProductId
                         group od by prod.ProductName into mygroup //grupladıktan sonra yeni bir eleman ortaya çıkıyor(mygroup)
                         select new
                         {
                             ProductName = mygroup.Key,
                             SumOrder = mygroup.Sum(x => x.UnitPrice * x.Quantity)
                         };

            dgvNorth.DataSource = query8
                .ToList();

            var query9 = from order in _dbContext.Orders
                         join employee in _dbContext.Employees on order.EmployeeId equals employee.EmployeeId
                         group order by employee.FirstName into mygroup
                         select new
                         {
                             FirstName = mygroup.Key,
                             TotalOrder = mygroup.Count()
                         };

            dgvNorth.DataSource = query9
                .ToList();


            //
            var query10 = from prod in _dbContext.Products
                          join cat in _dbContext.Categories on prod.CategoryId equals cat.CategoryId
                          join supp in _dbContext.Suppliers on prod.SupplierId equals supp.SupplierId
                          group new { prod, cat } by new { cat.CategoryName, supp.CompanyName } into mygroup
                          where mygroup.Sum(x => x.prod.UnitPrice * x.prod.UnitsInStock) > 3000
                          select new
                          {
                              CategoryName = mygroup.Key.CategoryName,
                              CompanyName = mygroup.Key.CompanyName,
                              Maliyet = mygroup.Sum(x => x.prod.UnitPrice * x.prod.UnitsInStock)
                          };

            dgvNorth.DataSource = query10
                .OrderBy(x => x.CategoryName).ToList();

            //Siparişleri sipariş numarası ve sipariş toplam tutarı olarak listeleyiniz.
            var query11 = from order in _dbContext.Orders
                          join od in _dbContext.OrderDetails on order.OrderId equals od.OrderId
                          group new { order, od } by order.OrderId into mygroup
                          select new
                          {
                              OrderId = mygroup.Key,
                              ToplamTutar = mygroup.Sum(x => Convert.ToInt32(1 - x.od.Discount) * (x.od.Quantity * x.od.UnitPrice))
                          };

            dgvNorth.DataSource = query11
                .ToList();


            //HANGİ TEDARİKÇİDEN NE KADARLIK SİPARİŞ EDİLMİŞ
            var query12 = from supp in _dbContext.Suppliers
                          join prod in _dbContext.Products on supp.SupplierId equals prod.SupplierId
                          group prod by supp.CompanyName into mygroup
                          select new
                          {
                              CompanyName = mygroup.Key,
                              Adet = mygroup.Count()
                          };

            dgvNorth.DataSource = query12
                .ToList();

            //01.01.1998 tarihinden sonra sipariş veren müşterilerin isimlerini ve sipariş tarih
            var query13 = from order in _dbContext.Orders
                          join cust in _dbContext.Customers on order.CustomerId equals cust.CustomerId
                          where order.OrderDate > new DateTime(1998, 01, 01)
                          select new
                          {
                              ContactName = cust.ContactName,
                              OrderDate = order.OrderDate
                          };

            dgvNorth.DataSource = query13
                .ToList();

            var query14 = from cust in _dbContext.Customers
                          join order in _dbContext.Orders on cust.CustomerId equals order.CustomerId
                          join od in _dbContext.OrderDetails on order.OrderId equals od.OrderId
                          join prod in _dbContext.Products on od.ProductId equals prod.ProductId
                          join employee in _dbContext.Employees on order.EmployeeId equals employee.EmployeeId
                          group employee by cust.CustomerId into mygroup
                          select new
                          {
                              CalısanSayisi = mygroup.Count(),
                              MusteriId = mygroup.Key
                          };

            dgvNorth.DataSource = query14
                .ToList();


            //lazyloading taktiği. ne zaman ihtiyaç varsa o zaman getirilir veri.(x.Supplier.CompanyName, gibi)
            var query15 = _dbContext.Products
                //.Include(x=> x.Supplier)
                //.Include(x => x.Category)
                .Select(x => new
                {
                    x.ProductName,
                    x.UnitPrice,
                    x.Supplier.CompanyName,
                    x.Category.CategoryName
                });
            dgvNorth.DataSource = query15
            .ToList();

            //eagerloading taktiği. Gerekli olan bütün veriyi çeker. Navigation property ile tablolar arası gezinme sağlanır.
            var query16 = _dbContext.Products
                .Include(x => x.Supplier)
                .Include(x => x.Category)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Order)
                .ThenInclude(x => x.ShipViaNavigation)
                .Select(x => new
                {
                    x.ProductName,
                    x.UnitPrice,
                    x.Supplier.CompanyName,
                    x.Category.CategoryName,
                    x.OrderDetails.Count
                });
            dgvNorth.DataSource = query16
                .ToList();

            //sqle nasıl sorgu atacağını gösterir.

            var queryString = query16.ToQueryString();
            var qq = query16.ToList();

            RaporuGoster();

            var query17 = from cat in _dbContext.Categories
                          join prod in _dbContext.Products on cat.CategoryId equals prod.CategoryId
                          join sup in _dbContext.Suppliers on prod.SupplierId equals sup.SupplierId
                          group new { cat, prod, sup } by new { cat.CategoryName, sup.CompanyName } into cats
                          select new
                          {
                              CategoryName = cats.Key.CategoryName,
                              CompanyName = cats.Key.CompanyName,
                              Count = cats.Count()
                          };

            dgvNorth.DataSource = query17
                .OrderBy(x => x.CategoryName)
                .ThenByDescending(x => x.Count)
                .ToList();


            var query18 = from cat in _dbContext.Categories
                          join prod in _dbContext.Products on cat.CategoryId equals prod.CategoryId
                          join sup in _dbContext.Suppliers on prod.SupplierId equals sup.SupplierId
                          group new { cat, prod, sup } by new { cat.CategoryName, sup.CompanyName } into cats
                          select new
                          {
                              CategoryName = cats.Key.CategoryName,
                              CompanyName = cats.Key.CompanyName,
                              Cost = cats.Sum(x => x.prod.UnitPrice * x.prod.UnitsInStock)
                          };

            dgvNorth.DataSource = query18
                .OrderBy(x => x.CategoryName)
                .ThenByDescending(x => x.Cost)
                .ToList();

            var query19 = _dbContext.Products
                .Include(x => x.Category) //joinler
                .Include(x => x.Supplier)
                .GroupBy(x => new { x.Category.CategoryName, x.Supplier.CompanyName })
                .Select(x => new
                {
                    x.Key.CategoryName,
                    x.Key.CompanyName,
                    Cost = x.Sum(p => p.UnitsInStock * p.UnitPrice)
                });
            dgvNorth.DataSource = query19
                .OrderBy(x => x.CategoryName)
                .ThenByDescending(x => x.Cost)
                .ToList();

            var query20 = from prod in _dbContext.Products
                          join od in _dbContext.OrderDetails on prod.ProductId equals od.ProductId
                          group new { od, prod } by prod.ProductName into mygroup
                          select new ProductNameTotalViewModel
                          {
                              ProductName = mygroup.Key,
                              Total = Math.Round(mygroup.Sum(x => (Decimal)(1 - x.od.Discount) * x.od.Quantity * x.od.UnitPrice), 2)
                          };
            dgvNorth.DataSource = query20
                .ToList();


            var query21 = _dbContext.OrderDetails
                .Include(x => x.Product) //joinler
                .GroupBy(x => new { x.Product.ProductName })
                .Select(x => new ProductNameTotalViewModel
                {
                    ProductName = x.Key.ProductName,
                    Total = x.Sum(od => (decimal)(1 - od.Discount) * od.Quantity * od.UnitPrice)
                });
            dgvNorth.DataSource = query21
                .OrderByDescending(x => x.Total)
                .ToList();

            var query22 = _dbContext.Products
          .Include(x => x.Supplier)
          .Include(x => x.Category)
          .Include(x => x.OrderDetails)
          .ThenInclude(x => x.Order)
          .ThenInclude(x => x.ShipViaNavigation)
          .Select(x => new
          {
              x.ProductName,
              x.UnitPrice,
              x.Supplier.CompanyName,
              x.Category.CategoryName,
              x.OrderDetails.Count
          });
            dgvNorth.DataSource = query22
                .ToList();



            //Console.WriteLine();
        }
        private int _offset = 0, _pagesize = 10, _maxpage; //kacıncı sayfada oldugunu ve sayfada kaç kayıt oldugunu göstermek için

        private void butbtnIleriton2_Click(object sender, EventArgs e)
        {
            if (_offset + 1 == _maxpage) return;
            _offset++;
            RaporuGoster();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (_offset == 0) return;
            _offset--;
            RaporuGoster();
        }


        private void RaporuGoster()
        {
            lblSayfa.Text = $"{_offset + 1 }";
            var query = _dbContext.Products
               .Include(x => x.Category)
               .Include(x => x.Supplier)
               .Select(x => new
               {
                   x.Category.CategoryName,
                   x.ProductName,
                   x.UnitPrice,
                   x.Supplier.CompanyName
               });


            //sqle nasıl sorgu atacağını gösterir.

            var queryString = query.ToQueryString();
            var qq = query.ToList();

            if (_maxpage == 0)
            {
                _maxpage = (int)Math.Ceiling(query.Count() / Convert.ToDouble(_pagesize));
            }

            query.Count(x => x.UnitPrice < 20);
            query.Sum(x => x.UnitPrice);
            query.Average(x => x.UnitPrice);
            query.Max(x => x.UnitPrice);
            query.Min(x => x.UnitPrice);

            query.Any(); //bütün kayıtlarda istenen kayıt aranır
                         // query.All(); //kayıdın varlığı değil yokluğu lazımsa all kullanılır.Any ile tam ters işlevde
            if (query.All(x => x.CategoryName != "Beverages"))
            {

                // }

                var result = query
               .OrderBy(x => x.CategoryName)
               .Skip(_offset * _pagesize)
               .Take(_pagesize)
               .ToList();

                dgvNorth.DataSource = result;
                dgvNorth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }


    }
}