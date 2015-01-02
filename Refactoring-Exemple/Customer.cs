using System.Collections.Generic;
using System.Linq;

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
            var result = "Rental Record for " + GetName() + "\n";

            foreach (var each in _rentals)
            {
                result += "\t" + each.GetMovie().GetTitle() + "\t" +
                          each.GetCharge() + "\n";
            }

            result += "Amount owed is " + GetTotalCharge() + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints() +
                      " frequent renter points";

            return result;
        }

        private double GetTotalCharge()
        {
            return _rentals.Sum(each => each.GetCharge());
        }

        private int GetTotalFrequentRenterPoints()
        {
            return _rentals.Sum(each => each.GetFrequentRenterPoints());
        }
    }
}
