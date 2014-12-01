﻿using System.Collections.Generic;

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
            List<Rental> rentals = _rentals;
            string result = "Rental Record for " + GetName() + "\n";

            foreach (var each in rentals)
            {
                //show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" +
                          each.GetCharge() + "\n";
            }

            //add footer lines
            result += "Amount owed is " + GetTotalCharge() + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints() +
                      " frequent renter points";

            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            List<Rental> rentals = _rentals;

            foreach (var each in rentals)
            {
                result += each.GetCharge();
            }

            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;

            foreach (var each in _rentals)
            {
                result += each.GetFrequentRenterPoints();
            }

            return result;
        }
    }
}
