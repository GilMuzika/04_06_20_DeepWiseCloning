using System;
using System.Collections.Generic;
using System.Text;

namespace _04_06_20_DeepWiseCloning
{
    public class CompositeObject
    {
        private Administrator _administrator;
        public AirlineCompany AirCompany { get; set; }
        public CheckingObject CheckingObject { get; set; }

        public CheckingObject checking { get; set; }

        public CompositeObject(Administrator administrator, AirlineCompany airCompany, CheckingObject checkingObject)
        {
            _administrator = administrator;
            AirCompany = airCompany;
            CheckingObject = checkingObject;
        }

        public CompositeObject()
        {
        }
    }

    public class CheckingObject
    {
        private Customer _customer;
        private Flight _flight;
        public Country Country { get; set; }

        public CompositeObject composite { get; set; }


        public CheckingObject(Customer customer, Flight flight, Country country)
        {
            _customer = customer;
            _flight = flight;
            Country = country;            
        }

        public CheckingObject()
        {
        }
    }
}
