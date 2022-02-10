using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money  MoneyInside { get; private set; }
        public Money MoneyInTransaction { get; private set;}

        public SnackMachine(Money moneyInside, Money moneyInTransaction)
        {
            MoneyInside = moneyInside;
            MoneyInTransaction = moneyInTransaction;
        }

        public void InsertMoney(Money money)
        {
            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            //MoneyInTransaction = 0;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            //MoneyInTransaction = 0;
        }
    }
}
