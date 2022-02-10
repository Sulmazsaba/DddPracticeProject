using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCount { get; private set; }
        public int OneDollorCount { get; private set; }
        public int FiveDollorCount { get; private set; }
        public int TwentyDollorCount { get; private set; }

        public Money(int oneCentCount, int tenCentCount, int quarterCount, int oneDollorCount, int fiveDollorCount, int twentyDollorCount)
        {
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
                hashCode = (hashCode *397) ^ TenCentCount;
                hashCode = (hashCode *397) ^ QuarterCount;
                hashCode = (hashCode *397) ^ OneDollorCount;
                hashCode = (hashCode *397) ^ FiveDollorCount;
                hashCode = (hashCode *397) ^ TwentyDollorCount;
                return hashCode;
            }
        }
    }
}
