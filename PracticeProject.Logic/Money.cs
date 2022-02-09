using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Logic
{
    public sealed class Money
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

    }
}
