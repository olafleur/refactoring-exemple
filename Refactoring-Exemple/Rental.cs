namespace Refactoring_Exemple
{
    class Rental
    {
        private readonly Movie _movie;
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        public double GetCharge()
        {
            return _movie.GetCharge(_daysRented);
        }

        public int GetFrequentRenterPoints()
        {
            if ((GetMovie().GetPriceCode() == Movie.NewRelease) && GetDaysRented() > 1)
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
