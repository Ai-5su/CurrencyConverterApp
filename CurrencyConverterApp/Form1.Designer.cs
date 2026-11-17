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
            this.components = new System.ComponentModel.Container();
            this.fromCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.toCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.refreshRatesButton = new System.Windows.Forms.Button();
            this.ratesLabel = new System.Windows.Forms.Label();
            this.rateStatusLabel = new System.Windows.Forms.Label();
            this.ratesTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // fromCurrencyComboBox
            // 
            this.fromCurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromCurrencyComboBox.FormattingEnabled = true;
            this.fromCurrencyComboBox.Location = new System.Drawing.Point(40, 40);
            this.fromCurrencyComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.fromCurrencyComboBox.Name = "fromCurrencyComboBox";
            this.fromCurrencyComboBox.Size = new System.Drawing.Size(121, 38);
            this.fromCurrencyComboBox.TabIndex = 0;
            // 
            // toCurrencyComboBox
            // 
            this.toCurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toCurrencyComboBox.FormattingEnabled = true;
            this.toCurrencyComboBox.Location = new System.Drawing.Point(200, 40);
            this.toCurrencyComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.toCurrencyComboBox.Name = "toCurrencyComboBox";
            this.toCurrencyComboBox.Size = new System.Drawing.Size(121, 38);
            this.toCurrencyComboBox.TabIndex = 1;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(40, 90);
            this.amountTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(281, 37);
            this.amountTextBox.TabIndex = 2;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(40, 156);
            this.convertButton.Margin = new System.Windows.Forms.Padding(4);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(219, 40);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Конвертировать";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(40, 210);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(115, 30);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Результат:";
            // 
            // refreshRatesButton
            // 
            this.refreshRatesButton.Location = new System.Drawing.Point(281, 156);
            this.refreshRatesButton.Name = "refreshRatesButton";
            this.refreshRatesButton.Size = new System.Drawing.Size(198, 40);
            this.refreshRatesButton.TabIndex = 5;
            this.refreshRatesButton.Text = "Обновить курсы";
            this.refreshRatesButton.UseVisualStyleBackColor = true;
            this.refreshRatesButton.Click += new System.EventHandler(this.refreshRatesButton_Click);
            // 
            // ratesLabel
            // 
            this.ratesLabel.AutoSize = true;
            this.ratesLabel.Location = new System.Drawing.Point(40, 250);
            this.ratesLabel.Name = "ratesLabel";
            this.ratesLabel.Size = new System.Drawing.Size(187, 30);
            this.ratesLabel.TabIndex = 6;
            this.ratesLabel.Text = "Курсы: загрузка...";
            // 
            // rateStatusLabel
            // 
            this.rateStatusLabel.AutoSize = true;
            this.rateStatusLabel.Location = new System.Drawing.Point(40, 290);
            this.rateStatusLabel.Name = "rateStatusLabel";
            this.rateStatusLabel.Size = new System.Drawing.Size(191, 30);
            this.rateStatusLabel.TabIndex = 7;
            this.rateStatusLabel.Text = "Статус: ожидание";
            // 
            // ratesTimer
            // 
            this.ratesTimer.Interval = 600000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 394);
            this.Controls.Add(this.rateStatusLabel);
            this.Controls.Add(this.ratesLabel);
            this.Controls.Add(this.refreshRatesButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.toCurrencyComboBox);
            this.Controls.Add(this.fromCurrencyComboBox);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер валют v1.1.2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox fromCurrencyComboBox;
        public System.Windows.Forms.ComboBox toCurrencyComboBox;
        public System.Windows.Forms.TextBox amountTextBox;
        public System.Windows.Forms.Button convertButton;
        public System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button refreshRatesButton;
        private System.Windows.Forms.Label ratesLabel;
        private System.Windows.Forms.Label rateStatusLabel;
        private System.Windows.Forms.Timer ratesTimer;
    }
}