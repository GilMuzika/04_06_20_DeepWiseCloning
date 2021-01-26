using _04_06_20_DeepWiseCloning;
using NUnit.Framework;
using System;
using System.Reflection;

namespace _04_06_20_DeepWiseCloning_NUnitTests
{
    public class DeepCloner_Tests
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MemberWiseDeepClone_Test()
        {
            //Arrange
            CustomSerializableType customSerializable = new CustomSerializableType
            {
                DateTimeValueType =
                                   DateTime.Now.AddDays(1).AddMilliseconds(123).AddTicks(123),
                NumericValueType = 777,
                StringValueType = Guid.NewGuid().ToString(),
                ReferenceType =
                                   new CustomSerializableType
                                   {
                                       DateTimeValueType = DateTime.Now,
                                       StringValueType = Guid.NewGuid().ToString()
                                   }
            };

            //Act
            CustomSerializableType clonedCustomSerializable = customSerializable.MemberWiseDeepClone();

            //Assert            
            Assert.IsNotNull(clonedCustomSerializable);
            Assert.IsFalse(ReferenceEquals(customSerializable, clonedCustomSerializable));
            Assert.That(customSerializable.NumericValueType == clonedCustomSerializable.NumericValueType);
            Assert.That(customSerializable.DateTimeValueType == clonedCustomSerializable.DateTimeValueType);
            Assert.That(customSerializable.StringValueType == clonedCustomSerializable.StringValueType);
            Assert.IsNotNull(customSerializable.ReferenceType);
            Assert.IsFalse(ReferenceEquals(customSerializable.ReferenceType, clonedCustomSerializable.ReferenceType));
            Assert.That(customSerializable.ReferenceType.DateTimeValueType == clonedCustomSerializable.ReferenceType.DateTimeValueType);
            Assert.That(customSerializable.ReferenceType.StringValueType == clonedCustomSerializable.ReferenceType.StringValueType);



        }

        [Test]
        public void MemberWiseDeepClone_Test_2()
        {  
            //Arrange
            AirlineCompany airCompany = new AirlineCompany("Momola Airlines", 12555, "here_must_be_64base_string_immage", "fhf53dg5525", "aAS23", 12565);            
            Administrator admin = new Administrator("John", "65df56dfd56f", 7254, airCompany);            
            Customer customer = new Customer("Nadgad", "Konstantinski", "not a house nor a street", "22333222356", "355-353-530", "image_image_where_are_you", "sdf54sf54sdf", 4587);
            Flight flight = new Flight { AIRLINECOMPANY_ID = 1, DEPARTURE_TIME = DateTime.Now, DESTINATION_COUNTRY_CODE = 123, ID = 21, IDENTIFIER = "sg546rfgv54fgv54", LANDING_TIME = DateTime.Now.AddDays(5).AddHours(8).AddMinutes(55), ORIGIN_COUNTRY_CODE = 446, REMAINING_TICKETS = 568 };
            Country country = new Country { COUNTRY_NAME = "Bolivia", ID = 658, IDENTIFIER = "fgb52df54dg54dgv", admin = admin };

            CheckingObject checkingObj = new CheckingObject(customer, flight, country);
            CompositeObject original = new CompositeObject(admin, airCompany, checkingObj);

            checkingObj.composite = original;
            original.checking = checkingObj;

            //Act
            CompositeObject clonedObject = original.MemberWiseDeepClone();
            var deepCloned = clonedObject;
            var shallowCloned = original.SimpleMemberWiseClone();

            //Assert
            Assert.IsNotNull(deepCloned);
            Assert.IsFalse(ReferenceEquals(original, deepCloned));
            Assert.That(original.AirCompany == deepCloned.AirCompany);
            Assert.AreEqual(original.AirCompany, deepCloned.AirCompany);

            string str = string.Empty;
            var originalFields = original.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            var deepClonedFields = deepCloned.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            Assert.AreEqual(originalFields.Length, deepClonedFields.Length);
            for (int i = 0; i < originalFields.Length; i++)
            {
                str += $"{originalFields[i].Name}: {originalFields[i].GetValue(original)}";
                //Assert.AreEqual(originalFields[i].GetValue(original), deepClonedFields[i].GetValue(deepCloned));
            }
            var originalAdministrator = original.GetType().GetField("_administrator", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Instance).GetValue(original);
            var deepClonedAdministrator = deepCloned.GetType().GetField("_administrator", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Instance).GetValue(deepCloned);

            Assert.AreEqual(originalAdministrator, deepClonedAdministrator);
            Assert.AreEqual(original.CheckingObject.composite.AirCompany, deepCloned.CheckingObject.composite.AirCompany);
            
            //Failing the test
            //Assert.AreEqual(original.CheckingObject, deepCloned.CheckingObject);

        }

        [Test]
        public void DeepCloneWithBinaryFormatter_Test()
        {
            //Arrange
            CustomSerializableType customSerializable = new CustomSerializableType
            {
                DateTimeValueType =
                                   DateTime.Now.AddDays(1).AddMilliseconds(123).AddTicks(123),
                NumericValueType = 777,
                StringValueType = Guid.NewGuid().ToString(),
                ReferenceType =
                                   new CustomSerializableType
                                   {
                                       DateTimeValueType = DateTime.Now,
                                       StringValueType = Guid.NewGuid().ToString()
                                   }
            };

            //Act
            CustomSerializableType clonedCustomSerializable = customSerializable.DeepCloneWithBinaryFormatter();

            //Assert            
            Assert.IsNotNull(clonedCustomSerializable);
            Assert.IsFalse(ReferenceEquals(customSerializable, clonedCustomSerializable));
            Assert.That(customSerializable.NumericValueType == clonedCustomSerializable.NumericValueType);
            Assert.That(customSerializable.DateTimeValueType == clonedCustomSerializable.DateTimeValueType);
            Assert.That(customSerializable.StringValueType == clonedCustomSerializable.StringValueType);
            Assert.IsNotNull(customSerializable.ReferenceType);
            Assert.IsFalse(ReferenceEquals(customSerializable.ReferenceType, clonedCustomSerializable.ReferenceType));
            Assert.That(customSerializable.ReferenceType.DateTimeValueType == clonedCustomSerializable.ReferenceType.DateTimeValueType);
            Assert.That(customSerializable.ReferenceType.StringValueType == clonedCustomSerializable.ReferenceType.StringValueType);

            //this failing the test
            //Assert.That(customSerializable == clonedCustomSerializable);
            //failing the test
            //Assert.That(customSerializable.ReferenceType == clonedCustomSerializable.ReferenceType);

        }







        [Serializable]
        internal sealed class CustomSerializableType
        {
            public int NumericValueType { get; set; }
            public string StringValueType { get; set; }
            public DateTime DateTimeValueType { get; set; }

            public CustomSerializableType ReferenceType { get; set; }
        }

    }
    
}