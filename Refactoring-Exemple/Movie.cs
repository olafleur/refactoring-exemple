using System;

namespace Refactoring_Exemple
{
    class Movie
    {
        public const int Childrens = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;

        private readonly string _title;
        private Price _price;

        public Movie(string title, int priceCode)
        {
            _title = title;
            SetPriceCode(priceCode);
        }

        public int GetPriceCode()
        {
            return _price.GetPriceCode();
        }

        public void SetPriceCode(int arg)
        {
            switch (arg)
            {
                case Regular:
                    _price = new RegularPrice();
                    break;
                case Childrens:
                    _price = new ChildrensPrice();
                    break;
                case NewRelease:
                    _price = new NewReleasePrice();
                    break;
                default:
                    throw new ArgumentException("Incorrect Price Code");
            }
        }

        public string GetTitle()
        {
            return _title;
        }

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

        public int GetFrequentRenterPoints(int daysRented)
        {
            if ((GetPriceCode() == Movie.NewRelease) && daysRented > 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
