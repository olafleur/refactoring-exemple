using System.Collections.Generic;

namespace Refactoring_Exemple
{
    class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string GetName()
        {
            return _name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            List<Rental> rentals = _rentals;
            string result = "Rental Record for " + GetName() + "\n";

            foreach (var each in rentals)
            {
                double thisAmount = 0;

                //determine amounts for each line
                thisAmount = AmountFor(each);

                //add frequent renters points
                frequentRenterPoints++;
                //add bonus for a tow day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NewRelease) &&
                    each.GetDaysRented() > 1)
                    frequentRenterPoints++;

                //show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" +
                          thisAmount + "\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints +
                      " frequent renter points";

            return result;
        }

        private double AmountFor(Rental aRental)
        {
            double thisAmount = 0;
            switch (aRental.GetMovie().GetPriceCode())
            {
                case Movie.Regular:
                    thisAmount += 2;
                    if (aRental.GetDaysRented() > 2)
                    {
                        thisAmount += (aRental.GetDaysRented() - 2)*1.5;
                    }
                    break;
                case Movie.NewRelease:
                    thisAmount += aRental.GetDaysRented()*3;
                    break;
                case Movie.Childrens:
                    thisAmount += 1.5;
                    if (aRental.GetDaysRented() > 3)
                        thisAmount += (aRental.GetDaysRented() - 3)*1.5;
                    break;
            }
            return thisAmount;
        }
    }
}
