namespace UI
{
    partial class Customers
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
            customersList = new ListBox();
            productsTabControl = new TabControl();
            addCustomer = new TabPage();
            customerPhoneNumber = new TextBox();
            label9 = new Label();
            customerAddress = new TextBox();
            label8 = new Label();
            customerId = new TextBox();
            label7 = new Label();
            addCustomerBtn = new Button();
            customerNameInput = new TextBox();
            nameProductLable = new Label();
            updateCustomer = new TabPage();
            customerPhoneNumberToUpdate = new TextBox();
            label2 = new Label();
            customerAddressToUpdate = new TextBox();
            label3 = new Label();
            customerNameToUpdate = new TextBox();
            label11 = new Label();
            searchBtn = new Button();
            codeCustomerInput = new TextBox();
            label5 = new Label();
            updateBtn = new Button();
            deleteCustomer = new TabPage();
            label1 = new Label();
            deleteBtn = new Button();
            codeInputToDelete = new TextBox();
            codeProductToDelete = new Label();
            customerDetails = new TabPage();
            detailCustomerOne = new ListBox();
            showDetailsCustomer = new Button();
            idCustomerSearch = new TextBox();
            label10 = new Label();
            label6 = new Label();
            filterByName = new TextBox();
            label4 = new Label();
            button1 = new Button();
            productsTabControl.SuspendLayout();
            addCustomer.SuspendLayout();
            updateCustomer.SuspendLayout();
            deleteCustomer.SuspendLayout();
            customerDetails.SuspendLayout();
            SuspendLayout();
            // 
            // customersList
            // 
            customersList.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            customersList.FormattingEnabled = true;
            customersList.ItemHeight = 33;
            customersList.Location = new Point(546, 139);
            customersList.Margin = new Padding(2, 3, 2, 3);
            customersList.Name = "customersList";
            customersList.Size = new Size(344, 367);
            customersList.TabIndex = 11;
            // 
            // productsTabControl
            // 
            productsTabControl.Controls.Add(addCustomer);
            productsTabControl.Controls.Add(updateCustomer);
            productsTabControl.Controls.Add(deleteCustomer);
            productsTabControl.Controls.Add(customerDetails);
            productsTabControl.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            productsTabControl.Location = new Point(70, 62);
            productsTabControl.Name = "productsTabControl";
            productsTabControl.RightToLeft = RightToLeft.Yes;
            productsTabControl.RightToLeftLayout = true;
            productsTabControl.SelectedIndex = 0;
            productsTabControl.Size = new Size(411, 455);
            productsTabControl.TabIndex = 10;
            // 
            // addCustomer
            // 
            addCustomer.Controls.Add(customerPhoneNumber);
            addCustomer.Controls.Add(label9);
            addCustomer.Controls.Add(customerAddress);
            addCustomer.Controls.Add(label8);
            addCustomer.Controls.Add(customerId);
            addCustomer.Controls.Add(label7);
            addCustomer.Controls.Add(addCustomerBtn);
            addCustomer.Controls.Add(customerNameInput);
            addCustomer.Controls.Add(nameProductLable);
            addCustomer.Location = new Point(4, 42);
            addCustomer.Name = "addCustomer";
            addCustomer.Padding = new Padding(3);
            addCustomer.Size = new Size(403, 409);
            addCustomer.TabIndex = 0;
            addCustomer.Text = "הוספה";
            addCustomer.UseVisualStyleBackColor = true;
            // 
            // customerPhoneNumber
            // 
            customerPhoneNumber.Location = new Point(69, 238);
            customerPhoneNumber.Name = "customerPhoneNumber";
            customerPhoneNumber.Size = new Size(188, 41);
            customerPhoneNumber.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(272, 244);
            label9.Name = "label9";
            label9.Size = new Size(95, 33);
            label9.TabIndex = 18;
            label9.Text = "מס' טלפון:";
            // 
            // customerAddress
            // 
            customerAddress.Location = new Point(69, 173);
            customerAddress.Name = "customerAddress";
            customerAddress.Size = new Size(222, 41);
            customerAddress.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(297, 181);
            label8.Name = "label8";
            label8.Size = new Size(70, 33);
            label8.TabIndex = 16;
            label8.Text = "כתובת:";
            // 
            // customerId
            // 
            customerId.Location = new Point(69, 105);
            customerId.Name = "customerId";
            customerId.Size = new Size(160, 41);
            customerId.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(235, 108);
            label7.Name = "label7";
            label7.Size = new Size(139, 33);
            label7.TabIndex = 14;
            label7.Text = "מס' זהות/ דרכון:";
            // 
            // addCustomerBtn
            // 
            addCustomerBtn.BackColor = SystemColors.ActiveCaption;
            addCustomerBtn.Cursor = Cursors.Hand;
            addCustomerBtn.Location = new Point(68, 313);
            addCustomerBtn.Name = "addCustomerBtn";
            addCustomerBtn.Size = new Size(277, 61);
            addCustomerBtn.TabIndex = 13;
            addCustomerBtn.Text = "שמור";
            addCustomerBtn.UseVisualStyleBackColor = false;
            addCustomerBtn.Click += addCustomerBtn_Click;
            // 
            // customerNameInput
            // 
            customerNameInput.Location = new Point(69, 34);
            customerNameInput.Name = "customerNameInput";
            customerNameInput.Size = new Size(188, 41);
            customerNameInput.TabIndex = 11;
            // 
            // nameProductLable
            // 
            nameProductLable.AutoSize = true;
            nameProductLable.Location = new Point(272, 40);
            nameProductLable.Name = "nameProductLable";
            nameProductLable.Size = new Size(102, 33);
            nameProductLable.TabIndex = 9;
            nameProductLable.Text = "שם הלקוח:";
            // 
            // updateCustomer
            // 
            updateCustomer.Controls.Add(customerPhoneNumberToUpdate);
            updateCustomer.Controls.Add(label2);
            updateCustomer.Controls.Add(customerAddressToUpdate);
            updateCustomer.Controls.Add(label3);
            updateCustomer.Controls.Add(customerNameToUpdate);
            updateCustomer.Controls.Add(label11);
            updateCustomer.Controls.Add(searchBtn);
            updateCustomer.Controls.Add(codeCustomerInput);
            updateCustomer.Controls.Add(label5);
            updateCustomer.Controls.Add(updateBtn);
            updateCustomer.Location = new Point(4, 42);
            updateCustomer.Name = "updateCustomer";
            updateCustomer.Padding = new Padding(3);
            updateCustomer.Size = new Size(403, 409);
            updateCustomer.TabIndex = 1;
            updateCustomer.Text = "עדכון";
            updateCustomer.UseVisualStyleBackColor = true;
            // 
            // customerPhoneNumberToUpdate
            // 
            customerPhoneNumberToUpdate.Location = new Point(51, 276);
            customerPhoneNumberToUpdate.Name = "customerPhoneNumberToUpdate";
            customerPhoneNumberToUpdate.Size = new Size(188, 41);
            customerPhoneNumberToUpdate.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 282);
            label2.Name = "label2";
            label2.Size = new Size(95, 33);
            label2.TabIndex = 39;
            label2.Text = "מס' טלפון:";
            // 
            // customerAddressToUpdate
            // 
            customerAddressToUpdate.Location = new Point(51, 229);
            customerAddressToUpdate.Name = "customerAddressToUpdate";
            customerAddressToUpdate.Size = new Size(222, 41);
            customerAddressToUpdate.TabIndex = 38;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(279, 237);
            label3.Name = "label3";
            label3.Size = new Size(70, 33);
            label3.TabIndex = 37;
            label3.Text = "כתובת:";
            // 
            // customerNameToUpdate
            // 
            customerNameToUpdate.Location = new Point(51, 182);
            customerNameToUpdate.Name = "customerNameToUpdate";
            customerNameToUpdate.Size = new Size(188, 41);
            customerNameToUpdate.TabIndex = 34;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(254, 188);
            label11.Name = "label11";
            label11.Size = new Size(102, 33);
            label11.TabIndex = 33;
            label11.Text = "שם הלקוח:";
            // 
            // searchBtn
            // 
            searchBtn.BackColor = SystemColors.ActiveCaption;
            searchBtn.Cursor = Cursors.Hand;
            searchBtn.Location = new Point(164, 109);
            searchBtn.Margin = new Padding(2, 3, 2, 3);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(91, 44);
            searchBtn.TabIndex = 32;
            searchBtn.Text = "חפש";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // codeCustomerInput
            // 
            codeCustomerInput.Location = new Point(69, 62);
            codeCustomerInput.Name = "codeCustomerInput";
            codeCustomerInput.Size = new Size(262, 41);
            codeCustomerInput.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 26);
            label5.Name = "label5";
            label5.Size = new Size(271, 33);
            label5.TabIndex = 30;
            label5.Text = "הכנס מס' זהות של הלקוח לעידכון";
            // 
            // updateBtn
            // 
            updateBtn.BackColor = SystemColors.ActiveCaption;
            updateBtn.Cursor = Cursors.Hand;
            updateBtn.Location = new Point(100, 342);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(211, 60);
            updateBtn.TabIndex = 25;
            updateBtn.Text = "עדכן";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // deleteCustomer
            // 
            deleteCustomer.Controls.Add(label1);
            deleteCustomer.Controls.Add(deleteBtn);
            deleteCustomer.Controls.Add(codeInputToDelete);
            deleteCustomer.Controls.Add(codeProductToDelete);
            deleteCustomer.Location = new Point(4, 42);
            deleteCustomer.Name = "deleteCustomer";
            deleteCustomer.Size = new Size(403, 409);
            deleteCustomer.TabIndex = 2;
            deleteCustomer.Text = "מחיקה";
            deleteCustomer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bamberger Grunge FM", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 177);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(81, 376);
            label1.Name = "label1";
            label1.Size = new Size(253, 26);
            label1.TabIndex = 6;
            label1.Text = "לתשומת לב: מחיקת לקוח איננה מומלצת";
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = SystemColors.ActiveCaption;
            deleteBtn.Cursor = Cursors.Hand;
            deleteBtn.Location = new Point(106, 245);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(211, 45);
            deleteBtn.TabIndex = 5;
            deleteBtn.Text = " מחיקה";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // codeInputToDelete
            // 
            codeInputToDelete.Location = new Point(106, 169);
            codeInputToDelete.Name = "codeInputToDelete";
            codeInputToDelete.Size = new Size(211, 41);
            codeInputToDelete.TabIndex = 4;
            // 
            // codeProductToDelete
            // 
            codeProductToDelete.AutoSize = true;
            codeProductToDelete.Location = new Point(106, 123);
            codeProductToDelete.Name = "codeProductToDelete";
            codeProductToDelete.Size = new Size(211, 33);
            codeProductToDelete.TabIndex = 3;
            codeProductToDelete.Text = "הכנס מס' זהות של הלקוח";
            // 
            // customerDetails
            // 
            customerDetails.Controls.Add(detailCustomerOne);
            customerDetails.Controls.Add(showDetailsCustomer);
            customerDetails.Controls.Add(idCustomerSearch);
            customerDetails.Controls.Add(label10);
            customerDetails.Location = new Point(4, 42);
            customerDetails.Name = "customerDetails";
            customerDetails.Size = new Size(403, 409);
            customerDetails.TabIndex = 3;
            customerDetails.Text = "פרטי לקוח";
            customerDetails.UseVisualStyleBackColor = true;
            // 
            // detailCustomerOne
            // 
            detailCustomerOne.FormattingEnabled = true;
            detailCustomerOne.ItemHeight = 33;
            detailCustomerOne.Location = new Point(25, 192);
            detailCustomerOne.Margin = new Padding(3, 4, 3, 4);
            detailCustomerOne.Name = "detailCustomerOne";
            detailCustomerOne.RightToLeft = RightToLeft.No;
            detailCustomerOne.Size = new Size(356, 202);
            detailCustomerOne.TabIndex = 13;
            // 
            // showDetailsCustomer
            // 
            showDetailsCustomer.BackColor = SystemColors.ActiveCaption;
            showDetailsCustomer.Cursor = Cursors.Hand;
            showDetailsCustomer.Location = new Point(25, 126);
            showDetailsCustomer.Name = "showDetailsCustomer";
            showDetailsCustomer.Size = new Size(356, 45);
            showDetailsCustomer.TabIndex = 12;
            showDetailsCustomer.Text = "הצג פרטי לקוח";
            showDetailsCustomer.UseVisualStyleBackColor = false;
            showDetailsCustomer.Click += showDetailsCustomer_Click;
            // 
            // idCustomerSearch
            // 
            idCustomerSearch.Location = new Point(25, 79);
            idCustomerSearch.Name = "idCustomerSearch";
            idCustomerSearch.Size = new Size(356, 41);
            idCustomerSearch.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(109, 34);
            label10.Name = "label10";
            label10.Size = new Size(211, 33);
            label10.TabIndex = 10;
            label10.Text = "הכנס מס' זהות של הלקוח";
            label10.Click += label10_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bamberger Grunge FM Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 177);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(777, 20);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(113, 44);
            label6.TabIndex = 12;
            label6.Text = "לקוחות:";
            label6.Click += label6_Click;
            // 
            // filterByName
            // 
            filterByName.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            filterByName.Location = new Point(546, 85);
            filterByName.Name = "filterByName";
            filterByName.Size = new Size(238, 41);
            filterByName.TabIndex = 14;
            filterByName.TextChanged += filterByName_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Bamberger Grunge FM", 17.9999981F);
            label4.Location = new Point(790, 85);
            label4.Name = "label4";
            label4.Size = new Size(100, 33);
            label4.TabIndex = 13;
            label4.Text = "סנן לפי שם";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(693, 512);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(91, 44);
            button1.TabIndex = 41;
            button1.Text = "חפש";
            button1.UseVisualStyleBackColor = false;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 560);
            Controls.Add(button1);
            Controls.Add(filterByName);
            Controls.Add(label4);
            Controls.Add(customersList);
            Controls.Add(productsTabControl);
            Controls.Add(label6);
            Name = "Customers";
            Text = "Customers";
            productsTabControl.ResumeLayout(false);
            addCustomer.ResumeLayout(false);
            addCustomer.PerformLayout();
            updateCustomer.ResumeLayout(false);
            updateCustomer.PerformLayout();
            deleteCustomer.ResumeLayout(false);
            deleteCustomer.PerformLayout();
            customerDetails.ResumeLayout(false);
            customerDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox customersList;
        private TabControl productsTabControl;
        private TabPage addCustomer;
        private NumericUpDown amountInput;
        private Label amountLable;
        private ComboBox categoryInput;
        private Label category;
        private Button addCustomerBtn;
        private NumericUpDown priceInput;
        private TextBox customerNameInput;
        private Label priceLable;
        private Label nameProductLable;
        private TabPage updateCustomer;
        private Button searchBtn;
        private TextBox codeCustomerInput;
        private Label label5;
        private Button updateBtn;
        private TabPage deleteCustomer;
        private Button deleteBtn;
        private TextBox codeInputToDelete;
        private Label codeProductToDelete;
        private TabPage customerDetails;
        private ListBox detailCustomerOne;
        private Button showDetailsCustomer;
        private TextBox idCustomerSearch;
        private Label label10;
        private Label label6;
        private TextBox customerAddress;
        private Label label8;
        private TextBox customerId;
        private Label label7;
        private TextBox customerPhoneNumber;
        private Label label9;
        private Label label1;
        private TextBox customerPhoneNumberToUpdate;
        private Label label2;
        private TextBox customerAddressToUpdate;
        private Label label3;
        private TextBox customerNameToUpdate;
        private Label label11;
        private TextBox filterByName;
        private Label label4;
        private Button button1;
    }
}