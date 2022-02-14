using FluentAssertions;
using PracticeProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static PracticeProject.Logic.Money;

namespace PracticeProject.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_empties_money_in_transaction()
        {
            SnackMachine snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollor);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Amount.Should().Be(0);
        }

        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            SnackMachine snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollor);
            snackMachine.InsertMoney(Cent);

            snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
        }

        [Fact]
        public void Cannot_accept_more_than_one_coin_or_note_at_the_time()
        {
            SnackMachine snackMachine = new SnackMachine();
            var twoCoins = Cent + Cent;

            Action action = () =>   snackMachine.InsertMoney(twoCoins);
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Money_in_transaction_goes_to_mone_inside_after_purchase()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollor);
            snackMachine.InsertMoney(Dollor);

            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Should().Be(None);
            snackMachine.MoneyInside.Amount.Should().Be(2m);
        }

    }
}
