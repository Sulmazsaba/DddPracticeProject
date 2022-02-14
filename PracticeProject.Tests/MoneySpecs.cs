using FluentAssertions;
using PracticeProject.Logic;
using Xunit;

namespace PracticeProject.Tests
{
    public class MoneySpecs
    {

        [Fact]
        public void Sum_of_two_moneys_produces_correct_result()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            Money sum = money1 + money2;

            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollorCount.Should().Be(8);
            sum.FiveDollorCount.Should().Be(10);
            sum.TwentyDollorCount.Should().Be(12);
        }

        [Fact]
        public void Two_money_instances_equal_if_contain_the_same_money_amount()
        {
            var money = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            money.Should().Be(money2);
            money.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void Two_money_instances_do_not_equal_if_contain_different_money_amounts()
        {
            var hundredCent = new Money(100, 0, 0, 0, 0, 0);
            var oneDollor = new Money(0, 0, 0, 1, 0, 0);

            oneDollor.Should().NotBe(hundredCent);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, -1)]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, -1, 0, 0, 0, 0)]
        [InlineData(0, 0, -1, 0, 0, 0)]
        [InlineData(0, 0, 0, -1, 0, 0)]
        [InlineData(0, 0, 0, 0, -1, 0)]
        public void Cannot_create_money_with_negative_value(int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollorCount,
            int fiveDollorCount,
            int twentyDollorCount)
        {
            Action action = () => new Money(oneCentCount,
                tenCentCount, quarterCount, oneDollorCount,
                fiveDollorCount, twentyDollorCount);

            action.Should().Throw<InvalidOperationException>();
        }


        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0, 0, 0, 0.01)]
        [InlineData(1, 2, 0, 0, 0, 0, 0.21)]
        [InlineData(1, 2, 3, 0, 0, 0, 0.96)]
        [InlineData(1, 2, 3, 4, 0, 0, 4.96)]
        [InlineData(1, 2, 3, 4, 5, 0, 29.96)]
        [InlineData(1, 2, 3, 4, 5, 6, 149.96)]
        [InlineData(110, 0, 0, 0, 100, 0, 501.1)]
        public void Amount_is_calculated_correctly(int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollorCount,
            int fiveDollorCount,
            int twentyDollorCount,
            decimal expectedAmount
            )
        {

            var money = new Money(oneCentCount, tenCentCount, quarterCount, oneDollorCount, fiveDollorCount, twentyDollorCount);
            money.Amount.Should().Be(expectedAmount);

        }

        [Fact]
        public void Substraction_of_two_moneys_produces_correct_result()
        {

            Money money1 = new Money(10, 10, 10, 10, 10, 10);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Money result = money1 - money2;

            result.OneCentCount.Should().Be(9);
            result.TenCentCount.Should().Be(8);
            result.QuarterCount.Should().Be(7);
            result.OneDollorCount.Should().Be(6);
            result.FiveDollorCount.Should().Be(5);
            result.TwentyDollorCount.Should().Be(4);
        }

        [Fact]
        public void Cannot_substract_more_than_exist()
        {
            Money money1 = new Money(0, 1, 0, 0, 0, 0);
            Money money2 = new Money(1, 0, 0, 0, 0, 0);

            var action = () =>
            {
                Money result = money1 - money2;
            };

            action.Should().Throw<InvalidOperationException>();
        }
    }
}