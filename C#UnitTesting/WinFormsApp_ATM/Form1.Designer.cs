namespace WinFormsApp_ATM
{
    partial class Form1
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
            label1 = new Label();
            cbCards = new ComboBox();
            btnInsertCard = new Button();
            label2 = new Label();
            label3 = new Label();
            lblAccountName = new Label();
            lblDepositName = new Label();
            label6 = new Label();
            lblDepositBalance = new Label();
            label5 = new Label();
            label4 = new Label();
            label7 = new Label();
            lblCashInHand = new Label();
            gpbPinCode = new GroupBox();
            btnEnterPinCode = new Button();
            tbPinCode = new TextBox();
            gpbTransfer = new GroupBox();
            btnWithdraw = new Button();
            tbAmount = new TextBox();
            btnDeposit = new Button();
            cbValuta = new ComboBox();
            gpbPinCode.SuspendLayout();
            gpbTransfer.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 23);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = " Cards";
            // 
            // cbCards
            // 
            cbCards.FormattingEnabled = true;
            cbCards.Location = new Point(25, 43);
            cbCards.Name = "cbCards";
            cbCards.Size = new Size(121, 23);
            cbCards.TabIndex = 1;
            // 
            // btnInsertCard
            // 
            btnInsertCard.Location = new Point(27, 76);
            btnInsertCard.Name = "btnInsertCard";
            btnInsertCard.Size = new Size(75, 23);
            btnInsertCard.TabIndex = 2;
            btnInsertCard.Text = "Insert card";
            btnInsertCard.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(600, 23);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Account";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(600, 43);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Name";
            // 
            // lblAccountName
            // 
            lblAccountName.AutoSize = true;
            lblAccountName.Location = new Point(654, 43);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(82, 15);
            lblAccountName.TabIndex = 5;
            lblAccountName.Text = "accountName";
            // 
            // lblDepositName
            // 
            lblDepositName.AutoSize = true;
            lblDepositName.Location = new Point(654, 73);
            lblDepositName.Name = "lblDepositName";
            lblDepositName.Size = new Size(78, 15);
            lblDepositName.TabIndex = 7;
            lblDepositName.Text = "depositName";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(600, 73);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 6;
            label6.Text = "Deposit";
            // 
            // lblDepositBalance
            // 
            lblDepositBalance.AutoSize = true;
            lblDepositBalance.Location = new Point(654, 104);
            lblDepositBalance.Name = "lblDepositBalance";
            lblDepositBalance.Size = new Size(87, 15);
            lblDepositBalance.TabIndex = 9;
            lblDepositBalance.Text = "depositBalance";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(600, 104);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 8;
            label5.Text = "Balance";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 194);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 11;
            label4.Text = "Cash";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 174);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 10;
            label7.Text = "In hand";
            // 
            // lblCashInHand
            // 
            lblCashInHand.AutoSize = true;
            lblCashInHand.Location = new Point(76, 194);
            lblCashInHand.Name = "lblCashInHand";
            lblCashInHand.Size = new Size(70, 15);
            lblCashInHand.TabIndex = 12;
            lblCashInHand.Text = "cashInHand";
            // 
            // gpbPinCode
            // 
            gpbPinCode.Controls.Add(btnEnterPinCode);
            gpbPinCode.Controls.Add(tbPinCode);
            gpbPinCode.Location = new Point(244, 23);
            gpbPinCode.Name = "gpbPinCode";
            gpbPinCode.Size = new Size(257, 96);
            gpbPinCode.TabIndex = 13;
            gpbPinCode.TabStop = false;
            gpbPinCode.Text = "PinCode";
            gpbPinCode.Visible = false;
            // 
            // btnEnterPinCode
            // 
            btnEnterPinCode.Location = new Point(116, 25);
            btnEnterPinCode.Name = "btnEnterPinCode";
            btnEnterPinCode.Size = new Size(75, 23);
            btnEnterPinCode.TabIndex = 1;
            btnEnterPinCode.Text = "Enter";
            btnEnterPinCode.UseVisualStyleBackColor = true;
            // 
            // tbPinCode
            // 
            tbPinCode.Location = new Point(10, 25);
            tbPinCode.Name = "tbPinCode";
            tbPinCode.PasswordChar = '*';
            tbPinCode.Size = new Size(100, 23);
            tbPinCode.TabIndex = 0;
            tbPinCode.KeyPress += tbPinCode_KeyPress;
            // 
            // gpbTransfer
            // 
            gpbTransfer.Controls.Add(cbValuta);
            gpbTransfer.Controls.Add(btnDeposit);
            gpbTransfer.Controls.Add(btnWithdraw);
            gpbTransfer.Controls.Add(tbAmount);
            gpbTransfer.Location = new Point(244, 125);
            gpbTransfer.Name = "gpbTransfer";
            gpbTransfer.Size = new Size(257, 118);
            gpbTransfer.TabIndex = 14;
            gpbTransfer.TabStop = false;
            gpbTransfer.Text = "Transfer";
            gpbTransfer.Visible = false;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Location = new Point(10, 54);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(75, 23);
            btnWithdraw.TabIndex = 1;
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.UseVisualStyleBackColor = true;
            // 
            // tbAmount
            // 
            tbAmount.Location = new Point(10, 25);
            tbAmount.Name = "tbAmount";
            tbAmount.PasswordChar = '*';
            tbAmount.Size = new Size(181, 23);
            tbAmount.TabIndex = 0;
            // 
            // btnDeposit
            // 
            btnDeposit.Location = new Point(176, 54);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(75, 23);
            btnDeposit.TabIndex = 2;
            btnDeposit.Text = "Deposit";
            btnDeposit.UseVisualStyleBackColor = true;
            // 
            // cbValuta
            // 
            cbValuta.FormattingEnabled = true;
            cbValuta.Location = new Point(197, 25);
            cbValuta.Name = "cbValuta";
            cbValuta.Size = new Size(54, 23);
            cbValuta.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gpbTransfer);
            Controls.Add(gpbPinCode);
            Controls.Add(lblCashInHand);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(lblDepositBalance);
            Controls.Add(label5);
            Controls.Add(lblDepositName);
            Controls.Add(label6);
            Controls.Add(lblAccountName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnInsertCard);
            Controls.Add(cbCards);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            gpbPinCode.ResumeLayout(false);
            gpbPinCode.PerformLayout();
            gpbTransfer.ResumeLayout(false);
            gpbTransfer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbCards;
        private Button btnInsertCard;
        private Label label2;
        private Label label3;
        private Label lblAccountName;
        private Label lblDepositName;
        private Label label6;
        private Label lblDepositBalance;
        private Label label5;
        private Label label4;
        private Label label7;
        private Label lblCashInHand;
        private GroupBox gpbPinCode;
        private Button btnEnterPinCode;
        private TextBox tbPinCode;
        private GroupBox gpbTransfer;
        private ComboBox cbValuta;
        private Button btnDeposit;
        private Button btnWithdraw;
        private TextBox tbAmount;
    }
}