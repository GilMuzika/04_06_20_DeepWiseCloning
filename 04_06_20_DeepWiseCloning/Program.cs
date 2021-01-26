using System;


namespace _04_06_20_DeepWiseCloning
{
    class Program
    {
        static void Main(string[] args)
        {


            //AirlineCompany airCompany = new AirlineCompany { ADORNING="AS324", AIRLINE_NAME="Momola Airlines", ID=1, COUNTRY_CODE=45, IDENTIFIER="g6356dfd6", IMAGE="here_must_be_64base_string_immage", USER_ID=333  };
            AirlineCompany airCompany = new AirlineCompany("Momola Airlines", 12555, "here_must_be_64base_string_immage", "fhf53dg5525", "aAS23", 12565);
            //Administrator admin = new Administrator { ID = 1, IDENTIFIER = "hk3g5g543dg546d", NAME = "John", USER_ID = 255, airlineCompany = airCompany };
            Administrator admin = new Administrator("John", "65df56dfd56f", 7254, airCompany);
            //Customer customer = new Customer { ADDRESS="not a house or a street, but the USSR", CREDIT_CARD_NUMBER="564546", FIRST_NAME="Yonatan", ID=56, IDENTIFIER="89gg5fgfg6", IMAGE="image_image_where_are_you", LAST_NAME="Momamimarurukla", PHONE_NO="1236564787", USER_ID=54322 };
            Customer customer = new Customer("Nadgad", "Konstantinski", "not a house nor a street", "22333222356", "355-353-530", "image_image_where_are_you", "sdf54sf54sdf",4587);
            Flight flight = new Flight { AIRLINECOMPANY_ID = 1, DEPARTURE_TIME = DateTime.Now, DESTINATION_COUNTRY_CODE = 123, ID=21, IDENTIFIER="sg546rfgv54fgv54", LANDING_TIME = DateTime.Now.AddDays(5).AddHours(8).AddMinutes(55), ORIGIN_COUNTRY_CODE=446, REMAINING_TICKETS=568};
            Country country = new Country {COUNTRY_NAME = "Bolivia", ID=658, IDENTIFIER="fgb52df54dg54dgv", admin = admin };


             
            CheckingObject checkingObj = new CheckingObject(customer, flight, country);            
            CompositeObject composite = new CompositeObject(admin, airCompany, checkingObj);

            checkingObj.composite = composite;
            composite.checking = checkingObj;


            CompositeObject clonedObject = composite.MemberWiseDeepClone();

            var obj1 = clonedObject;
            var obj2 = composite.SimpleMemberWiseClone();

            //Console.ReadKey();
        }
    }
}
