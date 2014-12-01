using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_Exemple
{
    abstract class Price
    {
        public abstract int GetPriceCode();

        public abstract double GetCharge(int daysRented);
    }

    class ChildrensPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Childrens;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 1.5;

            if (daysRented > 3)
            {
                result += (daysRented - 3)*1.5;
            }

            return result;
        }
    }

    class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }

        public override double GetCharge(int daysRented)
        {
            return daysRented*3;
        }
    }

    class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 2;

            if (daysRented > 2)
            {
                result += (daysRented - 2)*1.5;
            }

            return result;
        }
    }
}
