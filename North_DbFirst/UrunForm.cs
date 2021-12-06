using Microsoft.EntityFrameworkCore;
using North_DbFirst.Models;
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
    public partial class UrunForm : Form
    {
        NorthwindYeniContext _dbContext = new NorthwindYeniContext();
        public UrunForm()
        {
            InitializeComponent();
        }

        private void UrunForm_Load(object sender, EventArgs e)
        {
            ListeyiDoldur();
        }

        private void ListeyiDoldur()
        {
            lstProducts.DataSource = _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .ToList(); //null gelmemesi için Incluede yapılır
            //lstProducts.DisplayMember = "ProductName"; //listboxta verileri göstermek için kullanılır.Bunun yaptığı işi partials klasöründe
            //yeni bir Product isimli (modelsteki aynı isimli) clas oluşturup tostringi override ederek yapabiliriz.

            cmbCategory.DataSource = _dbContext.Categories.ToList();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId"; //ıd ile işlem yapmak için(listboxta Categoryname bulunacak fakat arkada id ile işlemler yapılacak)


            cmbSupplier.DataSource = _dbContext.Suppliers.ToList();
            cmbSupplier.DisplayMember = "CompanyName";
        }
        private Product _selectedProduct;
        private Category _selectedCategory;
        private Supplier _selectedSupplier;

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex == null) return;
            _selectedProduct = (Product)lstProducts.SelectedItem;

            txtProductName.Text = _selectedProduct.ProductName;
            nUnitPrice.Value = _selectedProduct.UnitPrice.GetValueOrDefault();
            cbDiscontinued.Checked = _selectedProduct.Discontinued;

            cmbCategory.SelectedItem = _selectedProduct.Category;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem != null)
            {
                _selectedCategory = (Category)cmbCategory.SelectedItem;
            }
            else
            {
                _selectedCategory = null;
            }
            if (cmbSupplier.SelectedItem != null)
            {
                _selectedSupplier = (Supplier)cmbSupplier.SelectedItem;
            }
            else
            {
                _selectedSupplier = null;
            }
            var yeni = new Product()
            {
                UnitPrice = nUnitPrice.Value,
                ProductName = txtProductName.Text,
                Discontinued = cbDiscontinued.Checked,
                CategoryId = _selectedCategory == null ? null : _selectedCategory.CategoryId,
                SupplierId = _selectedSupplier?.SupplierId //üsttekinin kısaltması

            };

            try
            {
                _dbContext.Products.Add(yeni);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _dbContext = new NorthwindYeniContext();
            }
            finally
            {
                ListeyiDoldur();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null) return;

            //combobox kontrolleri
            if (cmbCategory.SelectedItem != null)
            {
                _selectedCategory = (Category)cmbCategory.SelectedItem;
            }
            else
            {
                _selectedCategory = null;
            }
            if (cmbSupplier.SelectedItem != null)
            {
                _selectedSupplier = (Supplier)cmbSupplier.SelectedItem;
            }
            else
            {
                _selectedSupplier = null;
            }
            try
            {
                var product = _dbContext.Products.First(x=> x.ProductId == _selectedProduct.ProductId); //First Find aynı iş için kullanılabilir. Find sadece primay keylerle çalışır,first expressionslarla
                product.ProductName = txtProductName.Text;
                product.UnitPrice = nUnitPrice.Value;
                product.Discontinued = cbDiscontinued.Checked;
                product.SupplierId = _selectedSupplier?.SupplierId;
                product.CategoryId = _selectedCategory == null ? null : _selectedCategory.CategoryId;//üsttekinin aynısı

            //2.yol
            // _dbContext.Categories.Update(category);
            // var updateEntry = _dbContext.Categories.Update(category);

            _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _dbContext = new NorthwindYeniContext();
            }
            finally
            {
                ListeyiDoldur();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var product = _dbContext.Products
                .Include(x => x.OrderDetails)
                .FirstOrDefault(x=> x.ProductId == _selectedProduct.ProductId); 

            //kontroller
            if (product == null) return;
            if (product.OrderDetails.Any())
            {
                MessageBox.Show($"{product.ProductName} isimli ürün siparişlerde kullaıldığından silemezsiniz");
                return;
            }

            var dialogResult = MessageBox.Show($"{product.ProductName} isimli ürünü silmek istiyor musunuz?", "Ürün Silme",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                try
                {                   
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _dbContext = new NorthwindYeniContext();
                }
                finally
                {
                    ListeyiDoldur();
                }
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAra.Text))
            {
                lstProducts.DataSource = _dbContext.Products.ToList();
            }
            else
            {
                var result = _dbContext.Products.Where(x => x.ProductName.Contains(txtAra.Text.ToUpper())).ToList();
                lstProducts.DataSource = result;
                this.Text = $"{result.Count} Adet ürün Listelenmektedir.";
            }
        }
    }
}
