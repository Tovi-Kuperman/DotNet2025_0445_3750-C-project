
namespace UI
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            shopkeeperbtn = new Button();
            customerbtn = new Button();
            SuspendLayout();
            // 
            // shopkeeperbtn
            // 
            shopkeeperbtn.BackColor = SystemColors.ActiveCaption;
            shopkeeperbtn.Font = new Font("Bamberger Grunge FM", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 177);
            shopkeeperbtn.Location = new Point(521, 274);
            shopkeeperbtn.Name = "shopkeeperbtn";
            shopkeeperbtn.RightToLeft = RightToLeft.Yes;
            shopkeeperbtn.Size = new Size(209, 92);
            shopkeeperbtn.TabIndex = 0;
            shopkeeperbtn.Text = "מוכר? הכניסה מכאן>";
            shopkeeperbtn.UseVisualStyleBackColor = false;
            shopkeeperbtn.Click += shopkeeperbtn_Click;
            // 
            // customerbtn
            // 
            customerbtn.BackColor = SystemColors.ActiveCaption;
            customerbtn.Font = new Font("Bamberger Grunge FM", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 177);
            customerbtn.Location = new Point(277, 274);
            customerbtn.Name = "customerbtn";
            customerbtn.RightToLeft = RightToLeft.Yes;
            customerbtn.Size = new Size(209, 92);
            customerbtn.TabIndex = 1;
            customerbtn.Text = "לקוח? הכניסה מכאן>";
            customerbtn.UseVisualStyleBackColor = false;
            customerbtn.Click += customerbtn_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 641);
            Controls.Add(customerbtn);
            Controls.Add(shopkeeperbtn);
            Name = "Home";
            Text = "Home";
            Load += this.Home_Load;
            ResumeLayout(false);
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        #endregion

        private Button shopkeeperbtn;
        private Button customerbtn;
    }
}
