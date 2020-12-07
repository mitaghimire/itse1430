/*
 * ITSE 1430
 */
using System;
using System.Configuration;
using System.Windows.Forms;

using Nile.Stores.Sql;

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

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = false;

            _database = LoadDatabase();

            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (TryAction("Add Failed", () => _database.Add(child.Product)))
                    break;

            } while (true);

            UpdateList();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
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

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
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

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (TryAction("Delete Failed", () => _database.Remove(product.Id)))
                UpdateList();
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");

            do
            {
                child.Product = product;
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (TryAction("Update Failed", () => _database.Update(child.Product)))
                    break;
            } while (true);

            UpdateList();
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private IProductDatabase LoadDatabase ()
        {
            var connString = ConfigurationManager.ConnectionStrings["ProductDatabase"];
            if (connString == null)
                throw new InvalidOperationException("Database connection string not found.");

            return new SqlProductDatabase(connString.ConnectionString);
        }

        private bool TryAction ( string title, Action action )
        {
            try
            {
                action();
                return true;
            } catch (Exception e)
            {
                MessageBox.Show(this, e.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            return false;
        }

        private void UpdateList ()
        {
            TryAction("Load Failed", () => _bsProducts.DataSource = _database.GetAll());
        }

        private IProductDatabase _database;
        #endregion
    }
}
