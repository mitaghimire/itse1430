/*Mita Ghimire
 * ITSE 1430
 * Lab 4
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = false;

            UpdateList();
        }

        #region Event Handlers

        private void OnFileExit(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsProductDuplicate(Product product)
        {
            IEnumerable<Product> lstProduct = _database.GetAll();
            foreach(Product p in lstProduct)
            {
                if (p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase) && p.Id!=product.Id)
                {
                    MessageBox.Show($"The {product.Name} has already been on Products", "Duplicate Name", MessageBoxButtons.OK);
                    return true;
                }
                    
            }

            return false;
        }

        private void OnProductAdd(object sender, EventArgs e)
        {
            var child = new ProductDetailForm("Product Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;


            if (IsProductDuplicate(child.Product))
                return;
                
            //Handle errors
            try
            {
                //Save product
                _database.Add(child.Product);
                UpdateList();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Bad Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Equivalent to catch
            {
                //Handle errors
                MessageBox.Show(this, ex.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void OnProductEdit(object sender, EventArgs e)
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };
           
            EditProduct(product);
        }

        private void OnProductDelete(object sender, EventArgs e)
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }

        private void OnEditRow(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);

            //Don't continue with key
            e.SuppressKeyPress = true;
        }

        #endregion

        #region Private Members

        private void DeleteProduct(Product product)
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Handle errors
            try
            {
                //Delete product
                _database.Remove(product.Id);
                UpdateList();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Bad Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Equivalent to catch
            {
                //Handle errors
                MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            };
        }

        private void EditProduct(Product product)
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            if (IsProductDuplicate(child.Product))
                return;

            // Handle errors
            try
            {
                //Save product
                _database.Update(child.Product);
                UpdateList();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Bad Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Equivalent to catch
            {
                //Handle errors
                MessageBox.Show(this, ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            };
        }

        private Product GetSelectedProduct()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList()
        {
            // Handle errors

            try
            {
                _bsProducts.DataSource = _database.GetAll()?.OrderBy(r => r.Name);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Bad Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Equivalent to catch
            {
                //Handle errors
                MessageBox.Show(this, ex.Message, "Get Products Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            };
        }

        private readonly IProductDatabase _database = new Nile.Stores.SqlProductDatabase(ConfigurationManager.ConnectionStrings["ProductDatabase"].ToString());
        #endregion

        private void _gridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
