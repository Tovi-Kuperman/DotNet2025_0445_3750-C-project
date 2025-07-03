namespace UI
{
    partial class ShopkeeperMenu
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
            productsbtn = new Button();
            customersbtn = new Button();
            salesbtn = new Button();
            SuspendLayout();
            // 
            // productsbtn
            // 
            productsbtn.BackColor = SystemColors.ActiveCaption;
            productsbtn.Font = new Font("Bamberger Grunge FM", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 177);
            productsbtn.Location = new Point(672, 231);
            productsbtn.Name = "productsbtn";
            productsbtn.RightToLeft = RightToLeft.Yes;
            productsbtn.Size = new Size(209, 92);
            productsbtn.TabIndex = 1;
            productsbtn.Text = "מוצרים";
            productsbtn.UseVisualStyleBackColor = false;
            productsbtn.Click += productsbtn_Click;
            // 
            // customersbtn
            // 
            customersbtn.BackColor = SystemColors.ActiveCaption;
            customersbtn.Font = new Font("Bamberger Grunge FM", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 177);
            customersbtn.Location = new Point(431, 231);
            customersbtn.Name = "customersbtn";
            customersbtn.RightToLeft = RightToLeft.Yes;
            customersbtn.Size = new Size(209, 92);
            customersbtn.TabIndex = 2;
            customersbtn.Text = "לקוחות";
            customersbtn.UseVisualStyleBackColor = false;
            customersbtn.Click += customersbtn_Click;
            // 
            // salesbtn
            // 
            salesbtn.BackColor = SystemColors.ActiveCaption;
            salesbtn.Font = new Font("Bamberger Grunge FM", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 177);
            salesbtn.Location = new Point(189, 231);
            salesbtn.Name = "salesbtn";
            salesbtn.RightToLeft = RightToLeft.Yes;
            salesbtn.Size = new Size(209, 92);
            salesbtn.TabIndex = 3;
            salesbtn.Text = "מבצעים";
            salesbtn.UseVisualStyleBackColor = false;
            // 
            // ShopkeeperMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 573);
            Controls.Add(salesbtn);
            Controls.Add(customersbtn);
            Controls.Add(productsbtn);
            Name = "ShopkeeperMenu";
            Text = "ShopkeeperMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button productsbtn;
        private Button customersbtn;
        private Button salesbtn;
    }
}