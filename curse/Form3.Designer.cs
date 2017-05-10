namespace curse
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.moneyBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.categoryBox = new System.Windows.Forms.TextBox();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // nameBox
            // 
            resources.ApplyResources(this.nameBox, "nameBox");
            this.nameBox.Name = "nameBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // surnameBox
            // 
            resources.ApplyResources(this.surnameBox, "surnameBox");
            this.surnameBox.Name = "surnameBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // moneyBox
            // 
            resources.ApplyResources(this.moneyBox, "moneyBox");
            this.moneyBox.Name = "moneyBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // categoryBox
            // 
            resources.ApplyResources(this.categoryBox, "categoryBox");
            this.categoryBox.Name = "categoryBox";
            // 
            // acceptBtn
            // 
            resources.ApplyResources(this.acceptBtn, "acceptBtn");
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // errorBox
            // 
            resources.ApplyResources(this.errorBox, "errorBox");
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            // 
            // Form3
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.moneyBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.surnameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox moneyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox categoryBox;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.TextBox errorBox;
    }
}