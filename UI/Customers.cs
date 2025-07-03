using BlApi;
using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace UI
{
    public partial class Customers : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        public Customers()
        {
            InitializeComponent();
            this.Load += Customers_Load;
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshCustomerList();
                customerNameToUpdate.Enabled = false;
                //.Enabled = false;
                customerAddressToUpdate.Enabled = false;
                customerPhoneNumberToUpdate.Enabled = false;
                updateBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוחות" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCustomerList()
        {
            try
            {
                List<BO.Customer?> customers = _bl.Customer.ReadAll();
                customersList.Items.Clear();

                foreach (var customer in customers)
                {
                    if (customer != null)
                    {
                        var customerDetails = customer.ToString() + "\n----------------------------";

                        var customerLines = customerDetails.Split("\n");
                        foreach (var line in customerLines)
                        {
                            customersList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת טעינת הלקוחות: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codeCustomerInput.Text))
            {
                MessageBox.Show("אנא מלא את כל השדות.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerId = int.Parse(codeCustomerInput.Text);
            try
            {

                BO.Customer? c = _bl.Customer.Read(customerId);
                if (c == null)
                {
                    MessageBox.Show("מזהה לקוח שגוי.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                customerNameToUpdate.Text = c.Name;
                customerPhoneNumberToUpdate.Text = c.PhoneNumber;
                customerAddressToUpdate.Text = c.Address;

                //codeCustomerInput.ReadOnly = true;

                customerNameToUpdate.Enabled = true;
                customerPhoneNumberToUpdate.Enabled = true;
                customerAddressToUpdate.Enabled = true;
                codeCustomerInput.Enabled = true;
                updateBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת חיפוש הלקוח" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customerNameToUpdate.Text) ||
                string.IsNullOrWhiteSpace(customerPhoneNumberToUpdate.Text) ||
                string.IsNullOrWhiteSpace(customerAddressToUpdate.Text))
            {
                MessageBox.Show("אנא מלא את כל השדות.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerId = int.Parse(codeCustomerInput.Text);

            BO.Customer updatedCustomer = new BO.Customer(customerId, customerNameToUpdate.Text, customerAddressToUpdate.Text, customerPhoneNumberToUpdate.Text);

            try
            {
                _bl.Customer.Update(updatedCustomer);
                RefreshCustomerList();
                MessageBox.Show("הלקוח עודכן בהצלחה.", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                codeCustomerInput.ReadOnly = false;

                // איפוס הטופס
                codeCustomerInput.Text = "";
                customerNameToUpdate.Text = "";
                customerPhoneNumberToUpdate.Text = "";
                customerAddressToUpdate.Text = "";


                //codeCustomerInput.Enabled = false;
                customerNameToUpdate.Enabled = false;
                customerPhoneNumberToUpdate.Enabled = false;
                customerAddressToUpdate.Enabled = false;
                updateBtn.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת עדכון הלקוח" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int codeCustomer;
                if (int.TryParse(codeInputToDelete.Text, out codeCustomer))
                {
                    _bl.Customer.Delete(codeCustomer);

                    MessageBox.Show("הלקוח נמחק בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCustomerList();
                    codeInputToDelete.Text = "";
                }
                else
                {
                    MessageBox.Show("אנא הכנס מזהה לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת מחיקת הלקוח" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId;
                if (!int.TryParse(idCustomerSearch.Text, out customerId))
                {
                    MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // עצור את הפעולה אם ההמרה לא הצליחה
                }

                detailCustomerOne.Items.Clear(); // ניקוי פריטים קודמים

                var customer = _bl.Customer.Read(customerId);

                if (customer != null)
                {
                    var customerDetails = customer.ToString();
                    var customerLines = customerDetails.Split("\n");
                    foreach (var line in customerLines)
                    {
                        detailCustomerOne.Items.Add(line);
                    }
                    idCustomerSearch.Text = "";
                }
                else
                {
                    MessageBox.Show("לא נמצא מוצר עם הקוד הזה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוח" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void displayCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                // שליפת כל המוצרים מהמלאי
                List<BO.Customer> customers = _bl.Customer.ReadAll();

                // ניקוי הרשימה לפני שמכניסים את החדשים
                customersList.Items.Clear();

                // הוספת המוצרים לתצוגה (אפשר לעצב איך שרוצים)
                foreach (var customer in customers)
                {
                    if (customer != null)
                    {

                        customersList.Items.Add(
                            $"שם: {customer.Name}, מזהה: {customer.Id}, כתובת: {customer.Address}, מס' טלפון: {customer.PhoneNumber}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוחות" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerNameInput.Text) ||
               string.IsNullOrWhiteSpace(customerId.Text) ||
               string.IsNullOrWhiteSpace(customerAddress.Text) ||
               string.IsNullOrWhiteSpace(customerPhoneNumber.Text)
               )
                {
                    MessageBox.Show("אנא מלא את כל השדות.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BO.Customer c = new BO.Customer(int.Parse(customerId.Text), customerNameInput.Text, customerAddress.Text, customerPhoneNumber.Text);
                // בדיקה אם הלקוח כבר קיים

                _bl.Customer.Create(c);

                RefreshCustomerList();
                MessageBox.Show("הלקוח נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // איפוס הטופס
                customerNameInput.Text = "";
                customerId.Text = "";
                customerAddress.Text = "";
                customerPhoneNumber.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת הוספת לקוח" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterByName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nameInput = filterByName.Text; // הטקסט שהוזן בחיפוש שם

                // אם לא הוזן שם, טוענים את כל הלקוחות
                if (string.IsNullOrEmpty(nameInput))
                {
                    RefreshCustomerList(); // טוען את כל הלקוחות
                }
                else
                {
                    FilterCustomersByName(nameInput); // מסנן את הלקוחות לפי שם
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סינון הלקוחות" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FilterCustomersByName(string nameInput)
        {
            try
            {
                List<BO.Customer?> filteredCustomers = _bl.Customer.ReadAll(c => c?.Name?.Contains(nameInput, StringComparison.OrdinalIgnoreCase) == true).ToList();
                customersList.Items.Clear();
                foreach (var customer in filteredCustomers)
                {
                    if (customer != null)
                    {
                        var customerDetails = customer.ToString() + "\n----------------------------";
                        var customerLines = customerDetails.Split("\n");
                        foreach (var line in customerLines)
                        {
                            customersList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סינון הלקוחות" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
