using BlApi;
using BO;
using BlApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DO;

namespace UI
{
    public partial class Products : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        public Products()
        {
            InitializeComponent();
            this.Load += Products_Load;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshProductList();
                // עדכון קטגוריות
                categoryUpdate.DataSource = Enum.GetValues(typeof(Categories));

                nameProduct.Enabled = false;
                categoryUpdate.Enabled = false;
                amount.Enabled = false;
                price.Enabled = false;
                updateBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void codeProductToDelete_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productNameInput.Text) ||
               string.IsNullOrWhiteSpace(categoryInput.Text) ||
               priceInput.Value == 0 ||
               amountInput.Value == 0)
                {
                    MessageBox.Show("אנא מלא את כל השדות.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BO.Product p = new BO.Product();
                p.ProductName = productNameInput.Text;
                p.Category = (Categories)Enum.Parse(typeof(Categories), categoryInput.SelectedItem.ToString());
                p.Price = (int)priceInput.Value;
                p.AmountInStock = (int)amountInput.Value;

                _bl.Product.Create(p);

                RefreshProductList();
                MessageBox.Show("המוצר נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // איפוס הטופס
                productNameInput.Text = "";
                categoryInput.SelectedIndex = -1;
                priceInput.Value = 0;
                amountInput.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת הוספת מוצר" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshProductList()
        {
            try
            {
                List<BO.Product?> products = _bl.Product.ReadAll();
                productsList.Items.Clear();

                foreach (var product in products)
                {
                    if (product != null)
                    {
                        var productDetails = product.ToString() + "\n----------------------------";

                        var productLines = productDetails.Split("\n");
                        foreach (var line in productLines)
                        {
                            productsList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת טעינת המוצרים: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codeProductInput.Text))
            {
                MessageBox.Show("אנא מלא את כל השדות.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int productId = int.Parse(codeProductInput.Text);
            try
            {
                BO.Product p = _bl.Product.Read(productId);
                if (p == null)
                {
                    MessageBox.Show("קוד מוצר שגוי.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                nameProduct.Text = p.ProductName;
                categoryUpdate.SelectedItem = p.Category;
                price.Value = (int)p.Price;
                amount.Value = (int)p.AmountInStock;

                codeProductInput.ReadOnly = true;

                nameProduct.Enabled = true;
                categoryUpdate.Enabled = true;
                amount.Enabled = true;
                price.Enabled = true;
                updateBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת חיפוש המוצר" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(codeProductInput.Text);

            if (productId == null)
            {
                MessageBox.Show("לא נמצא מוצר עם השם שהוזן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BO.Product updatedProduct = new BO.Product()
            {
                Code = productId,
                ProductName = string.IsNullOrEmpty(nameProduct.Text) ? "שם מוצר ברירת מחדל" : nameProduct.Text,
                Category = categoryUpdate.SelectedItem == null ? Categories.סידורים : (Categories)Enum.Parse(typeof(Categories), categoryUpdate.SelectedItem.ToString()),
                Price = price.Value == 0 ? 0 : (int)price.Value,
                AmountInStock = amount.Value == 0 ? 0 : (int)amount.Value
            };


            try
            {
                _bl.Product.Update(updatedProduct);
                RefreshProductList();
                MessageBox.Show("המוצר עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                codeProductInput.ReadOnly = false;

                // איפוס הטופס
                codeProductInput.Text = "";
                nameProduct.Text = "";
                categoryUpdate.SelectedIndex = -1;
                price.Value = 0;
                amount.Value = 0;


                nameProduct.Enabled = false;
                categoryUpdate.Enabled = false;
                amount.Enabled = false;
                price.Enabled = false;
                updateBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת עדכון המוצר" + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int codeProduct;
                if (int.TryParse(codeInputToDelete.Text, out codeProduct))
                {
                    // כאן תוכל להוסיף את הקוד למחיקת המוצר מה-BL
                    _bl.Product.Delete(codeProduct);

                    // הצגת הודעה שהמוצר נמחק בהצלחה
                    MessageBox.Show("המוצר נמחק בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshProductList();
                    codeInputToDelete.Text = "";
                }
                else
                {
                    // הצגת הודעה אם הקלט לא תקין
                    MessageBox.Show("אנא הכנס קוד מוצר תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת מחיקת המוצר" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int productId;
                if (!int.TryParse(idProductSearch.Text, out productId))
                {
                    MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // עצור את הפעולה אם ההמרה לא הצליחה
                }

                detailProductOne.Items.Clear(); // ניקוי פריטים קודמים

                var product = _bl.Product.Read(productId);

                if (product != null)
                {
                    var productDetails = product.ToString();
                    var productLines = productDetails.Split("\n");
                    foreach (var line in productLines)
                    {
                        detailProductOne.Items.Add(line);
                    }
                    idProductSearch.Text = "";
                }
                else
                {
                    MessageBox.Show("לא נמצא מוצר עם הקוד הזה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצר" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void categoryUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void productsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void displayProducts_Click(object sender, EventArgs e)
        {
            try
            {
                // שליפת כל המוצרים מהמלאי
                List<BO.Product> products = _bl.Product.ReadAll();

                // ניקוי הרשימה לפני שמכניסים את החדשים
                productsList.Items.Clear();

                // הוספת המוצרים לתצוגה (אפשר לעצב איך שרוצים)
                foreach (var product in products)
                {
                    if (product != null)
                    {
                        MessageBox.Show("displayProducts_Click!!!!!!!!!!!!");
                        productsList.Items.Add(
                            $"שם: {product.ProductName}, קטגוריה: {product.Category}, מחיר: {product.Price} ₪, כמות: {product.AmountInStock}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void priceInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void filterByName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nameInput = filterByName.Text; // הטקסט שהוזן בחיפוש שם

                // אם לא הוזן שם, טוענים את כל הלקוחות
                if (string.IsNullOrEmpty(nameInput))
                {
                    RefreshProductList(); // טוען את כל הלקוחות
                }
                else
                {
                    FilterProductsByName(nameInput); // מסנן את הלקוחות לפי שם
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סינון המוצרים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterProductsByName(string nameInput)
        {
            try
            {
                List<BO.Product?> filteredProducts = _bl.Product.ReadAll(c => c?.ProductName?.Contains(nameInput, StringComparison.OrdinalIgnoreCase) == true).ToList();
                productsList.Items.Clear();
                foreach (var customer in filteredProducts)
                {
                    if (customer != null)
                    {
                        var customerDetails = customer.ToString() + "\n----------------------------";
                        var customerLines = customerDetails.Split("\n");
                        foreach (var line in customerLines)
                        {
                            productsList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סינון המוצרים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterCategory.SelectedItem == null) return;
try
            {
            Categories selectedCategory = (Categories)Enum.Parse(typeof(Categories), filterCategory.SelectedItem.ToString());

            
                List<BO.Product?> filteredProducts = _bl.Product.ReadAll(p => p != null && p.Category == selectedCategory).ToList();

                productsList.Items.Clear();
                foreach (var product in filteredProducts)
                {
                    if (product != null)
                    {
                        var productDetails = product.ToString() + "\n----------------------------";
                        var productLines = productDetails.Split("\n");
                        foreach (var line in productLines)
                        {
                            productsList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בסינון לפי קטגוריה" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
