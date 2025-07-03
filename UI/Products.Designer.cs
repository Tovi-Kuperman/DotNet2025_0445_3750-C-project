namespace UI
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            productsTabControl = new TabControl();
            addProduct = new TabPage();
            amountInput = new NumericUpDown();
            amountLable = new Label();
            categoryInput = new ComboBox();
            category = new Label();
            addProductBtn = new Button();
            priceInput = new NumericUpDown();
            productNameInput = new TextBox();
            priceLable = new Label();
            nameProductLable = new Label();
            updateProduct = new TabPage();
            searchBtn = new Button();
            codeProductInput = new TextBox();
            label5 = new Label();
            amount = new NumericUpDown();
            label1 = new Label();
            categoryUpdate = new ComboBox();
            label2 = new Label();
            updateBtn = new Button();
            price = new NumericUpDown();
            nameProduct = new TextBox();
            label3 = new Label();
            label4 = new Label();
            deleteProduct = new TabPage();
            deleteBtn = new Button();
            codeInputToDelete = new TextBox();
            codeProductToDelete = new Label();
            productDetails = new TabPage();
            detailProductOne = new ListBox();
            showDetailsProduct = new Button();
            idProductSearch = new TextBox();
            label10 = new Label();
            productsList = new ListBox();
            label6 = new Label();
            filterByName = new TextBox();
            label7 = new Label();
            filterCategory = new ComboBox();
            label11 = new Label();
            productsTabControl.SuspendLayout();
            addProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            updateProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)price).BeginInit();
            deleteProduct.SuspendLayout();
            productDetails.SuspendLayout();
            SuspendLayout();
            // 
            // productsTabControl
            // 
            productsTabControl.Controls.Add(addProduct);
            productsTabControl.Controls.Add(updateProduct);
            productsTabControl.Controls.Add(deleteProduct);
            productsTabControl.Controls.Add(productDetails);
            productsTabControl.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            productsTabControl.Location = new Point(133, 71);
            productsTabControl.Name = "productsTabControl";
            productsTabControl.RightToLeft = RightToLeft.Yes;
            productsTabControl.RightToLeftLayout = true;
            productsTabControl.SelectedIndex = 0;
            productsTabControl.Size = new Size(411, 455);
            productsTabControl.TabIndex = 0;
            // 
            // addProduct
            // 
            addProduct.Controls.Add(amountInput);
            addProduct.Controls.Add(amountLable);
            addProduct.Controls.Add(categoryInput);
            addProduct.Controls.Add(category);
            addProduct.Controls.Add(addProductBtn);
            addProduct.Controls.Add(priceInput);
            addProduct.Controls.Add(productNameInput);
            addProduct.Controls.Add(priceLable);
            addProduct.Controls.Add(nameProductLable);
            addProduct.Location = new Point(4, 42);
            addProduct.Name = "addProduct";
            addProduct.Padding = new Padding(3);
            addProduct.Size = new Size(403, 409);
            addProduct.TabIndex = 0;
            addProduct.Text = "הוספה";
            addProduct.UseVisualStyleBackColor = true;
            // 
            // amountInput
            // 
            amountInput.Location = new Point(69, 243);
            amountInput.Name = "amountInput";
            amountInput.Size = new Size(150, 41);
            amountInput.TabIndex = 17;
            // 
            // amountLable
            // 
            amountLable.AutoSize = true;
            amountLable.Location = new Point(299, 243);
            amountLable.Name = "amountLable";
            amountLable.Size = new Size(54, 33);
            amountLable.TabIndex = 16;
            amountLable.Text = "כמות";
            // 
            // categoryInput
            // 
            categoryInput.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryInput.FormattingEnabled = true;
            categoryInput.Items.AddRange(new object[] { "מחזורים", "סידורים", "כיפות", "נרתיקי תפילין", "הטבעות" });
            categoryInput.Location = new Point(68, 97);
            categoryInput.Name = "categoryInput";
            categoryInput.Size = new Size(189, 41);
            categoryInput.TabIndex = 15;
            // 
            // category
            // 
            category.AutoSize = true;
            category.Location = new Point(277, 100);
            category.Name = "category";
            category.Size = new Size(76, 33);
            category.TabIndex = 14;
            category.Text = "קטגוריה";
            category.TextAlign = ContentAlignment.TopRight;
            // 
            // addProductBtn
            // 
            addProductBtn.BackColor = SystemColors.ActiveCaption;
            addProductBtn.Cursor = Cursors.Hand;
            addProductBtn.Location = new Point(68, 313);
            addProductBtn.Name = "addProductBtn";
            addProductBtn.Size = new Size(277, 61);
            addProductBtn.TabIndex = 13;
            addProductBtn.Text = "שמור";
            addProductBtn.UseVisualStyleBackColor = false;
            addProductBtn.Click += addProductBtn_Click;
            // 
            // priceInput
            // 
            priceInput.Location = new Point(69, 167);
            priceInput.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(150, 41);
            priceInput.TabIndex = 12;
            priceInput.ValueChanged += priceInput_ValueChanged;
            // 
            // productNameInput
            // 
            productNameInput.Location = new Point(69, 34);
            productNameInput.Name = "productNameInput";
            productNameInput.Size = new Size(188, 41);
            productNameInput.TabIndex = 11;
            // 
            // priceLable
            // 
            priceLable.AutoSize = true;
            priceLable.Location = new Point(300, 172);
            priceLable.Name = "priceLable";
            priceLable.Size = new Size(53, 33);
            priceLable.TabIndex = 10;
            priceLable.Text = "מחיר";
            // 
            // nameProductLable
            // 
            nameProductLable.AutoSize = true;
            nameProductLable.Location = new Point(269, 37);
            nameProductLable.Name = "nameProductLable";
            nameProductLable.Size = new Size(84, 33);
            nameProductLable.TabIndex = 9;
            nameProductLable.Text = "שם מוצר";
            // 
            // updateProduct
            // 
            updateProduct.Controls.Add(searchBtn);
            updateProduct.Controls.Add(codeProductInput);
            updateProduct.Controls.Add(label5);
            updateProduct.Controls.Add(amount);
            updateProduct.Controls.Add(label1);
            updateProduct.Controls.Add(categoryUpdate);
            updateProduct.Controls.Add(label2);
            updateProduct.Controls.Add(updateBtn);
            updateProduct.Controls.Add(price);
            updateProduct.Controls.Add(nameProduct);
            updateProduct.Controls.Add(label3);
            updateProduct.Controls.Add(label4);
            updateProduct.Location = new Point(4, 42);
            updateProduct.Name = "updateProduct";
            updateProduct.Padding = new Padding(3);
            updateProduct.Size = new Size(403, 409);
            updateProduct.TabIndex = 1;
            updateProduct.Text = "עדכון";
            updateProduct.UseVisualStyleBackColor = true;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = SystemColors.ActiveCaption;
            searchBtn.Cursor = Cursors.Hand;
            searchBtn.Location = new Point(99, 67);
            searchBtn.Margin = new Padding(2, 3, 2, 3);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(91, 44);
            searchBtn.TabIndex = 32;
            searchBtn.Text = "חפש";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // codeProductInput
            // 
            codeProductInput.Location = new Point(19, 20);
            codeProductInput.Name = "codeProductInput";
            codeProductInput.Size = new Size(171, 41);
            codeProductInput.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(198, 23);
            label5.Name = "label5";
            label5.Size = new Size(187, 33);
            label5.TabIndex = 30;
            label5.Text = "הכנס קוד מוצר לעידכון";
            // 
            // amount
            // 
            amount.Location = new Point(41, 259);
            amount.Name = "amount";
            amount.Size = new Size(97, 41);
            amount.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 267);
            label1.Name = "label1";
            label1.Size = new Size(54, 33);
            label1.TabIndex = 28;
            label1.Text = "כמות";
            // 
            // categoryUpdate
            // 
            categoryUpdate.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryUpdate.FormattingEnabled = true;
            categoryUpdate.Items.AddRange(new object[] { "מחזורים", "סידורים", "כיפות", "נרתיקי תפילין", "הטבעות" });
            categoryUpdate.Location = new Point(41, 204);
            categoryUpdate.Name = "categoryUpdate";
            categoryUpdate.Size = new Size(224, 41);
            categoryUpdate.TabIndex = 27;
            categoryUpdate.SelectedIndexChanged += categoryUpdate_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(294, 207);
            label2.Name = "label2";
            label2.Size = new Size(76, 33);
            label2.TabIndex = 26;
            label2.Text = "קטגוריה";
            // 
            // updateBtn
            // 
            updateBtn.BackColor = SystemColors.ActiveCaption;
            updateBtn.Cursor = Cursors.Hand;
            updateBtn.Location = new Point(99, 323);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(211, 60);
            updateBtn.TabIndex = 25;
            updateBtn.Text = "עדכן";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // price
            // 
            price.Location = new Point(205, 259);
            price.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            price.Name = "price";
            price.Size = new Size(96, 41);
            price.TabIndex = 24;
            // 
            // nameProduct
            // 
            nameProduct.Location = new Point(41, 142);
            nameProduct.Name = "nameProduct";
            nameProduct.Size = new Size(211, 41);
            nameProduct.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(311, 267);
            label3.Name = "label3";
            label3.Size = new Size(53, 33);
            label3.TabIndex = 22;
            label3.Text = "מחיר";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(287, 142);
            label4.Name = "label4";
            label4.Size = new Size(84, 33);
            label4.TabIndex = 21;
            label4.Text = "שם מוצר";
            // 
            // deleteProduct
            // 
            deleteProduct.Controls.Add(deleteBtn);
            deleteProduct.Controls.Add(codeInputToDelete);
            deleteProduct.Controls.Add(codeProductToDelete);
            deleteProduct.Location = new Point(4, 42);
            deleteProduct.Name = "deleteProduct";
            deleteProduct.Size = new Size(403, 409);
            deleteProduct.TabIndex = 2;
            deleteProduct.Text = "מחיקה";
            deleteProduct.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = SystemColors.ActiveCaption;
            deleteBtn.Cursor = Cursors.Hand;
            deleteBtn.Location = new Point(106, 254);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(195, 45);
            deleteBtn.TabIndex = 5;
            deleteBtn.Text = " מחיקה";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // codeInputToDelete
            // 
            codeInputToDelete.Location = new Point(107, 185);
            codeInputToDelete.Name = "codeInputToDelete";
            codeInputToDelete.Size = new Size(194, 41);
            codeInputToDelete.TabIndex = 4;
            // 
            // codeProductToDelete
            // 
            codeProductToDelete.AutoSize = true;
            codeProductToDelete.Location = new Point(106, 123);
            codeProductToDelete.Name = "codeProductToDelete";
            codeProductToDelete.Size = new Size(194, 33);
            codeProductToDelete.TabIndex = 3;
            codeProductToDelete.Text = "הקש קוד מוצר למחיקה";
            codeProductToDelete.Click += codeProductToDelete_Click;
            // 
            // productDetails
            // 
            productDetails.Controls.Add(detailProductOne);
            productDetails.Controls.Add(showDetailsProduct);
            productDetails.Controls.Add(idProductSearch);
            productDetails.Controls.Add(label10);
            productDetails.Location = new Point(4, 42);
            productDetails.Name = "productDetails";
            productDetails.Size = new Size(403, 409);
            productDetails.TabIndex = 3;
            productDetails.Text = "פרטי מוצר";
            productDetails.UseVisualStyleBackColor = true;
            // 
            // detailProductOne
            // 
            detailProductOne.FormattingEnabled = true;
            detailProductOne.ItemHeight = 33;
            detailProductOne.Location = new Point(25, 126);
            detailProductOne.Margin = new Padding(3, 4, 3, 4);
            detailProductOne.Name = "detailProductOne";
            detailProductOne.RightToLeft = RightToLeft.No;
            detailProductOne.Size = new Size(356, 268);
            detailProductOne.TabIndex = 13;
            // 
            // showDetailsProduct
            // 
            showDetailsProduct.BackColor = SystemColors.ActiveCaption;
            showDetailsProduct.Cursor = Cursors.Hand;
            showDetailsProduct.Location = new Point(25, 65);
            showDetailsProduct.Name = "showDetailsProduct";
            showDetailsProduct.Size = new Size(356, 45);
            showDetailsProduct.TabIndex = 12;
            showDetailsProduct.Text = "הצג פרטי מוצר";
            showDetailsProduct.UseVisualStyleBackColor = false;
            showDetailsProduct.Click += showDetailsProduct_Click;
            // 
            // idProductSearch
            // 
            idProductSearch.Location = new Point(25, 18);
            idProductSearch.Name = "idProductSearch";
            idProductSearch.Size = new Size(223, 41);
            idProductSearch.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(254, 26);
            label10.Name = "label10";
            label10.Size = new Size(127, 33);
            label10.TabIndex = 10;
            label10.Text = "הכנס קוד מוצר";
            // 
            // productsList
            // 
            productsList.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            productsList.FormattingEnabled = true;
            productsList.ItemHeight = 33;
            productsList.Location = new Point(609, 155);
            productsList.Margin = new Padding(2, 3, 2, 3);
            productsList.Name = "productsList";
            productsList.Size = new Size(344, 367);
            productsList.TabIndex = 2;
            productsList.SelectedIndexChanged += productsList_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bamberger Grunge FM Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 177);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(844, 9);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(109, 44);
            label6.TabIndex = 9;
            label6.Text = "מוצרים:";
            label6.Click += label6_Click;
            // 
            // filterByName
            // 
            filterByName.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            filterByName.Location = new Point(609, 71);
            filterByName.Name = "filterByName";
            filterByName.Size = new Size(238, 41);
            filterByName.TabIndex = 16;
            filterByName.TextChanged += filterByName_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            label7.Location = new Point(853, 79);
            label7.Name = "label7";
            label7.Size = new Size(100, 33);
            label7.TabIndex = 15;
            label7.Text = "סנן לפי שם";
            // 
            // filterCategory
            // 
            filterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            filterCategory.Font = new Font("Arial Narrow", 16.2F);
            filterCategory.FormattingEnabled = true;
            filterCategory.Items.AddRange(new object[] { "מחזורים", "סידורים", "כיפות", "נרתיקי תפילין", "הטבעות" });
            filterCategory.Location = new Point(609, 113);
            filterCategory.Name = "filterCategory";
            filterCategory.Size = new Size(212, 39);
            filterCategory.TabIndex = 18;
            filterCategory.SelectedIndexChanged += filterCategory_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            label11.Location = new Point(819, 119);
            label11.Name = "label11";
            label11.Size = new Size(134, 33);
            label11.TabIndex = 17;
            label11.Text = "סנן לפי קטגוריה";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 571);
            Controls.Add(filterCategory);
            Controls.Add(label11);
            Controls.Add(filterByName);
            Controls.Add(label7);
            Controls.Add(productsList);
            Controls.Add(productsTabControl);
            Controls.Add(label6);
            Name = "Products";
            Text = "Products";
            productsTabControl.ResumeLayout(false);
            addProduct.ResumeLayout(false);
            addProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amountInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            updateProduct.ResumeLayout(false);
            updateProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amount).EndInit();
            ((System.ComponentModel.ISupportInitialize)price).EndInit();
            deleteProduct.ResumeLayout(false);
            deleteProduct.PerformLayout();
            productDetails.ResumeLayout(false);
            productDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl productsTabControl;
        private TabPage addProduct;
        private TabPage updateProduct;
        private TabPage deleteProduct;
        private TabPage productDetails;
        private NumericUpDown amountInput;
        private Label amountLable;
        private ComboBox categoryInput;
        private Label category;
        private Button addProductBtn;
        private NumericUpDown priceInput;
        private TextBox productNameInput;
        private Label priceLable;
        private Label nameProductLable;
        private Button searchBtn;
        private TextBox codeProductInput;
        private Label label5;
        private NumericUpDown amount;
        private Label label1;
        private ComboBox categoryUpdate;
        private Label label2;
        private Button updateBtn;
        private NumericUpDown price;
        private TextBox nameProduct;
        private Label label3;
        private Label label4;
        private Button deleteBtn;
        private TextBox codeInputToDelete;
        private Label codeProductToDelete;
        private ListBox detailProductOne;
        private Button showDetailsProduct;
        private TextBox idProductSearch;
        private Label label10;
        private ListBox productsList;
        private Label label6;
        private TextBox filterByName;
        private Label label7;
        private ComboBox filterCategory;
        private Label label11;
    }
}