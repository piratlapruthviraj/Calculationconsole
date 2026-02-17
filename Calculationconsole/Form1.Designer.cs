namespace Calculationconsole
{
    partial class Form1
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
            this.firstnumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.secondnumber = new System.Windows.Forms.TextBox();
            this.addition = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.resulttext = new System.Windows.Forms.TextBox();
            this.Subtraction = new System.Windows.Forms.Button();
            this.Multiplication = new System.Windows.Forms.Button();
            this.Division = new System.Windows.Forms.Button();
            this.statecomboBox = new System.Windows.Forms.ComboBox();
            this.CountrycomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstnumber
            // 
            this.firstnumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstnumber.Location = new System.Drawing.Point(230, 68);
            this.firstnumber.Multiline = true;
            this.firstnumber.Name = "firstnumber";
            this.firstnumber.Size = new System.Drawing.Size(232, 35);
            this.firstnumber.TabIndex = 0;
            this.firstnumber.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the first number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter the second number";
            // 
            // secondnumber
            // 
            this.secondnumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondnumber.Location = new System.Drawing.Point(230, 148);
            this.secondnumber.Multiline = true;
            this.secondnumber.Name = "secondnumber";
            this.secondnumber.Size = new System.Drawing.Size(232, 35);
            this.secondnumber.TabIndex = 3;
            // 
            // addition
            // 
            this.addition.BackColor = System.Drawing.SystemColors.Highlight;
            this.addition.Location = new System.Drawing.Point(557, 65);
            this.addition.Name = "addition";
            this.addition.Size = new System.Drawing.Size(90, 31);
            this.addition.TabIndex = 4;
            this.addition.Text = "Add";
            this.addition.UseVisualStyleBackColor = false;
            this.addition.Click += new System.EventHandler(this.addition_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result";
            // 
            // resulttext
            // 
            this.resulttext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resulttext.Location = new System.Drawing.Point(230, 221);
            this.resulttext.Multiline = true;
            this.resulttext.Name = "resulttext";
            this.resulttext.Size = new System.Drawing.Size(232, 35);
            this.resulttext.TabIndex = 6;
            this.resulttext.TextChanged += new System.EventHandler(this.result_TextChanged);
            // 
            // Subtraction
            // 
            this.Subtraction.BackColor = System.Drawing.SystemColors.Highlight;
            this.Subtraction.Location = new System.Drawing.Point(557, 122);
            this.Subtraction.Name = "Subtraction";
            this.Subtraction.Size = new System.Drawing.Size(90, 31);
            this.Subtraction.TabIndex = 7;
            this.Subtraction.Text = "Sub";
            this.Subtraction.UseVisualStyleBackColor = false;
            this.Subtraction.Click += new System.EventHandler(this.Subtraction_Click);
            // 
            // Multiplication
            // 
            this.Multiplication.BackColor = System.Drawing.SystemColors.Highlight;
            this.Multiplication.Location = new System.Drawing.Point(557, 178);
            this.Multiplication.Name = "Multiplication";
            this.Multiplication.Size = new System.Drawing.Size(90, 31);
            this.Multiplication.TabIndex = 8;
            this.Multiplication.Text = "Mul";
            this.Multiplication.UseVisualStyleBackColor = false;
            this.Multiplication.Click += new System.EventHandler(this.Multiplication_Click);
            // 
            // Division
            // 
            this.Division.BackColor = System.Drawing.SystemColors.Highlight;
            this.Division.Location = new System.Drawing.Point(557, 231);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(90, 31);
            this.Division.TabIndex = 9;
            this.Division.Text = "Div";
            this.Division.UseVisualStyleBackColor = false;
            this.Division.Click += new System.EventHandler(this.Division_Click);
            // 
            // statecomboBox
            // 
            this.statecomboBox.FormattingEnabled = true;
            this.statecomboBox.Location = new System.Drawing.Point(230, 342);
            this.statecomboBox.Name = "statecomboBox";
            this.statecomboBox.Size = new System.Drawing.Size(181, 28);
            this.statecomboBox.TabIndex = 13;
            this.statecomboBox.SelectedIndexChanged += new System.EventHandler(this.statecomboBox_SelectedIndexChanged);
            // 
            // CountrycomboBox
            // 
            this.CountrycomboBox.FormattingEnabled = true;
            this.CountrycomboBox.Items.AddRange(new object[] {
            "India",
            "USA",
            "Australia"});
            this.CountrycomboBox.Location = new System.Drawing.Point(230, 293);
            this.CountrycomboBox.Name = "CountrycomboBox";
            this.CountrycomboBox.Size = new System.Drawing.Size(181, 28);
            this.CountrycomboBox.TabIndex = 14;
            this.CountrycomboBox.SelectedIndexChanged += new System.EventHandler(this.CountrycomboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Country Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "State Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CountrycomboBox);
            this.Controls.Add(this.statecomboBox);
            this.Controls.Add(this.Division);
            this.Controls.Add(this.Multiplication);
            this.Controls.Add(this.Subtraction);
            this.Controls.Add(this.resulttext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addition);
            this.Controls.Add(this.secondnumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstnumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstnumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox secondnumber;
        private System.Windows.Forms.Button addition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resulttext;
        private System.Windows.Forms.Button Subtraction;
        private System.Windows.Forms.Button Multiplication;
        private System.Windows.Forms.Button Division;
        private System.Windows.Forms.ComboBox statecomboBox;
        private System.Windows.Forms.ComboBox CountrycomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

