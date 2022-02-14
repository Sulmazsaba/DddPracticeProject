using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCount { get; }
        public int OneDollorCount { get; }
        public int FiveDollorCount { get; }
        public int TwentyDollorCount { get; }
        public decimal Amount => OneCentCount * 0.01m +
                      TenCentCount * 0.10m +
                      QuarterCount * 0.25m +
                      OneDollorCount +
                      FiveDollorCount * 5 +
                      TwentyDollorCount * 20;


        public Money(int oneCentCount, int tenCentCount, int quarterCount, int oneDollorCount, int fiveDollorCount, int twentyDollorCount)
        {
            if (oneCentCount < 0)
                throw new InvalidOperationException();
            if (tenCentCount < 0)
                throw new InvalidOperationException();
            if (quarterCount < 0)
                throw new InvalidOperationException();
            if (fiveDollorCount < 0)
                throw new InvalidOperationException();
            if (twentyDollorCount < 0)
                throw new InvalidOperationException();
            if (oneDollorCount < 0)
                throw new InvalidOperationException();


            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollorCount = oneDollorCount;
            FiveDollorCount = fiveDollorCount;
            TwentyDollorCount = twentyDollorCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            var sum = new Money
            (
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCount + money2.QuarterCount,
                money1.OneDollorCount + money2.OneDollorCount,
                money1.FiveDollorCount + money2.FiveDollorCount,
                money1.TwentyDollorCount + money2.TwentyDollorCount
            );

            return sum;

        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCount - money2.QuarterCount,
                money1.OneDollorCount - money2.OneDollorCount,
                money1.FiveDollorCount - money2.FiveDollorCount, money1.TwentyDollorCount - money2.TwentyDollorCount
                );
        }

        protected override bool EqualScore(Money other)
        {
            return other.OneCentCount == OneCentCount &&
                other.TenCentCount == TenCentCount &&
                other.TwentyDollorCount == TwentyDollorCount &&
                other.QuarterCount == QuarterCount &&
                other.OneDollorCount == OneDollorCount &&
                other.FiveDollorCount == FiveDollorCount;
        }

        protected override int GetHashCodeScore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCount;
                hashCode = (hashCode * 397) ^ OneDollorCount;
                hashCode = (hashCode * 397) ^ FiveDollorCount;
                hashCode = (hashCode * 397) ^ TwentyDollorCount;
                return hashCode;
            }
        }
    }
}
