using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Logic
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if(ReferenceEquals(null, valueObject))
                return false;


            return EqualScore(valueObject);
        }

        protected abstract bool EqualScore(T other);


        public override int GetHashCode()
        {
            return GetHashCodeScore();
        }

        protected abstract int GetHashCodeScore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;


            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
