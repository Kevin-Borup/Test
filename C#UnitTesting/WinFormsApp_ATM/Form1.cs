using ATMLibrary.Models;

namespace WinFormsApp_ATM
{
    public partial class Form1 : Form
    {
        ATM atm = new ATM(new ATMLibrary.Data.LocalDataAccess());
        decimal cashInHand = 10000;

        bool inserted
        {
            get
            {
                return atm.Inserted;
            }
        }

        bool unlocked
        {
            get
            {
                return atm.Unlocked;
            }
        }

        public Form1()
        {
            InitializeComponent();

            cbCards.DataSource = atm.GetAllCards();
            cbValuta.DataSource = atm.valutas;

            UpdateUI();
        }

        private void tbNumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || tbPinCode.Text.Length > 4)
            {
                e.Handled = true;
            }
        }

        private void btnInsertCard_Click(object sender, EventArgs e)
        {
            var item = cbCards.SelectedItem;

            if (item != null && item is Card)
            {
                Card card = (Card)item;
                atm.InsertCard(card);
                gpbPinCode.Visible = inserted;
            }
            UpdateUI();
        }
        private void btnRemoveCard_Click(object sender, EventArgs e)
        {
            atm.RemoveCard();
            UpdateUI();
        }

        private void btnEnterPinCode_Click(object sender, EventArgs e)
        {
            string pin = tbPinCode.Text;

            if (!string.IsNullOrWhiteSpace(pin) && pin.Length.Equals(4))
            {
                atm.UnlockCard(pin);
                gpbTransfer.Visible = unlocked;
            }

            UpdateUI();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            decimal amount = Decimal.Parse(tbAmount.Text);
            string value = cbValuta.SelectedValue as string;

            if (amount.ToString().Length > 0)
            {
                atm.DepositToCard(amount, value);
                cashInHand -= amount;
            }

            UpdateUI();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            decimal amount = Decimal.Parse(tbAmount.Text);
            string value = cbValuta.SelectedValue as string;

            if (amount.ToString().Length > 0)
            {
                cashInHand += atm.WithdrawFromCard(amount, value);
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            var details = atm.GetCardDetails();
            lblAccountName.Text = details.accountName;
            lblDepositName.Text = details.depositName;
            lblDepositBalance.Text = details.depositBalance;
            lblCashInHand.Text = cashInHand.ToString();
        }


    }
}