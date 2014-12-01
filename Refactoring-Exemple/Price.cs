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

        public double GetCharge(int daysRented)
        {
            double result = 0;
            switch (GetPriceCode())
            {
                case Movie.Regular:
                    result += 2;
                    if (daysRented > 2)
                    {
                        result += (daysRented - 2) * 1.5;
                    }
                    break;
                case Movie.NewRelease:
                    result += daysRented * 3;
                    break;
                case Movie.Childrens:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }

            return result;
        }
    }

    class ChildrensPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Childrens;
        }
    }

    class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }
    }

    class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }
    }
}
