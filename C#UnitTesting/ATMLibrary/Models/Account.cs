using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Models
{

    public class Account
    {
        public string id { get; private set; }
        public string name { get; private set; }

        public List<Deposit> deposits { get; private set; }

        public Account(string id, string accountMame, List<Deposit> deposits)
        {
            this.id = id;
            this.name = accountMame;
            this.deposits = deposits;
        }

        public Deposit GetDeposit(string id)
        {
            return deposits.Where(d => d.id.Equals(id)).FirstOrDefault();
        }

        public void UpdateDeposit(Deposit deposit) 
        {
            var foundDep = deposits.Where(d => d.id.Equals(deposit.id)).First();

            var index = deposits.IndexOf(foundDep);

            deposits.RemoveAt(index);
            deposits.Insert(index, deposit);
        }
    }
}
