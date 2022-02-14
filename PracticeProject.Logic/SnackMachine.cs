using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticeProject.Logic.Money;

namespace PracticeProject.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public SnackMachine()
        {
                
        }
        public SnackMachine(Money moneyInside, Money moneyInTransaction)
        {
            MoneyInside = moneyInside;
            MoneyInTransaction = moneyInTransaction;
        }

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = new Money[] { Cent, TenCent, Dollor, FiveDollor, TwentyDollor, Quarter };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
