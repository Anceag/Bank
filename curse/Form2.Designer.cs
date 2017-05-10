namespace curse
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addMoney = new System.Windows.Forms.Button();
            this.moneyBox = new System.Windows.Forms.TextBox();
            this.takeMoney = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // addMoney
            // 
            resources.ApplyResources(this.addMoney, "addMoney");
            this.addMoney.Name = "addMoney";
            this.addMoney.UseVisualStyleBackColor = true;
            this.addMoney.Click += new System.EventHandler(this.addMoney_Click);
            // 
            // moneyBox
            // 
            resources.ApplyResources(this.moneyBox, "moneyBox");
            this.moneyBox.Name = "moneyBox";
            // 
            // takeMoney
            // 
            resources.ApplyResources(this.takeMoney, "takeMoney");
            this.takeMoney.Name = "takeMoney";
            this.takeMoney.UseVisualStyleBackColor = true;
            this.takeMoney.Click += new System.EventHandler(this.takeMoney_Click);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.takeMoney);
            this.Controls.Add(this.moneyBox);
            this.Controls.Add(this.addMoney);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addMoney;
        private System.Windows.Forms.TextBox moneyBox;
        private System.Windows.Forms.Button takeMoney;
    }
}