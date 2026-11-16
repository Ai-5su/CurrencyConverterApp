namespace CurrencyConverterApp
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
            this.fromCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.toCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fromCurrencyComboBox
            // 
            this.fromCurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromCurrencyComboBox.FormattingEnabled = true;
            this.fromCurrencyComboBox.Location = new System.Drawing.Point(140, 154);
            this.fromCurrencyComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fromCurrencyComboBox.Name = "fromCurrencyComboBox";
            this.fromCurrencyComboBox.Size = new System.Drawing.Size(160, 38);
            this.fromCurrencyComboBox.TabIndex = 0;
            // 
            // toCurrencyComboBox
            // 
            this.toCurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toCurrencyComboBox.FormattingEnabled = true;
            this.toCurrencyComboBox.Location = new System.Drawing.Point(488, 153);
            this.toCurrencyComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toCurrencyComboBox.Name = "toCurrencyComboBox";
            this.toCurrencyComboBox.Size = new System.Drawing.Size(160, 38);
            this.toCurrencyComboBox.TabIndex = 1;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(516, 370);
            this.amountTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(132, 37);
            this.amountTextBox.TabIndex = 2;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(281, 241);
            this.convertButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(219, 73);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Конвертировать";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(329, 378);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(115, 30);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Результат:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 675);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.toCurrencyComboBox);
            this.Controls.Add(this.fromCurrencyComboBox);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер валют v1.0.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fromCurrencyComboBox;
        private System.Windows.Forms.ComboBox toCurrencyComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label resultLabel;
    }
}