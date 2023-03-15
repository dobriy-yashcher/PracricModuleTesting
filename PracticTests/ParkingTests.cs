using PracricLibrary;
using System.Reflection;

namespace PracticTests
{
    [TestClass]
    public class ParkingTests
    {
        [TestMethod]
        public void AddCar_AddToOccupiedPlace_ExceptionReturned()
        {
            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Vasilev")}
            };
                
            var parking = new Parking(cars);

            try {
                parking.AddCar(1, new Car("sij249", "red", "Vasilev"));
            }
            catch {
                return;
            }

            Assert.Fail();
        }          

        [TestMethod]
        public void AddCar_AddToNotOccupiedPlace_2CarReturned()
        {
            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Vasilev")}
            };
                
            var parking = new Parking(cars);

            try {
                parking.AddCar(2, new Car("sij249", "red", "Vasilev"));
            }
            catch {
                Assert.Fail();
            }                 
        }  

        [TestMethod]
        public void AddCar_AddExistCar_ExceptionReturned()
        {
            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Vasilev")}
            };
                
            var parking = new Parking(cars);

            try {
                parking.AddCar(2, new Car("wef782", "red", "Vasilev"));
            }
            catch {
                return;
            }

            Assert.Fail();
        }       

        [TestMethod]
        public void AddCar_AddNotExistCar_2CarReturned()
        {
            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Vasilev")}
            };
                
            var parking = new Parking(cars);

            try {
                parking.AddCar(2, new Car("ged466", "pink", "Sharipof"));
            }
            catch {
                Assert.Fail();
            }        
        }  
            
        [TestMethod]
        public void GetCarsFromColor_ManyRedCars_3CarReturned()
        {
            var expected = new Dictionary<int, Car>()
            {
                { 1, new Car("wef782", "red", "Vasilev")},
                { 4, new Car("mjz768", "red", "Safiullin")},
                { 5, new Car("ghj533", "red", "Sharipof")}
            };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Vasilev")},
                { 2, new Car("sdg673", "blue", "Petrov")},
                { 3, new Car("fgv253", "green", "Zaripov")},
                { 4, new Car("mjz768", "red", "Safiullin")},
                { 5, new Car("ghj533", "red", "Sharipof")}
            };
                
            var parking = new Parking(cars);
            var actual = parking.GetCarsFromColor("red");

            CheckResult(actual, expected);
        }           
            
        [TestMethod]
        public void GetCarsFromColor_OneRedCar_1CarReturned()
        {
            var expected = new Dictionary<int, Car>()
            {
                { 1, new Car("wef782", "red", "Vasilev")}
            };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Vasilev")},
                { 2, new Car("sdg673", "blue", "Petrov")},
                { 3, new Car("fgv253", "green", "Zaripov")},
            };
                
            var parking = new Parking(cars);
            var actual = parking.GetCarsFromColor("red");

            CheckResult(actual, expected);
        }         
            
        [TestMethod]
        public void GetCarsFromColor_NoRedCar_0CarReturned()
        {
            var expected = new Dictionary<int, Car>() { };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "white", "Vasilev")},
                { 2, new Car("sdg673", "blue", "Petrov")},
                { 3, new Car("fgv253", "green", "Zaripov")},
            };
                
            var parking = new Parking(cars);
            var actual = parking.GetCarsFromColor("red");

            CheckResult(actual, expected);
        }                           
            
        [TestMethod]
        public void GetCarFromStateNumber_ExistCar_1CarReturned()
        {
            var expectedCar = new Car("fgv253", "green", "Zaripov");
            var expectedPlace = 3;

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "white", "Vasilev")},
                { 2, new Car("sdg673", "blue", "Petrov")},
                { 3, new Car("fgv253", "green", "Zaripov")},
            };
                
            var parking = new Parking(cars);
            var actual = parking.GetCarFromStateNumber("fgv253").Value;

            Assert.IsTrue(expectedCar.Equals(actual.Value));
            Assert.AreEqual(expectedPlace, actual.Key);
        }           

        [TestMethod]
        public void GetCarFromStateNumber_NotExistCar_0CarReturned()
        {
            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "white", "Vasilev")},
                { 2, new Car("sdg673", "blue", "Petrov")},
                { 3, new Car("fgv253", "green", "Zaripov")},
            };
                
            var parking = new Parking(cars);
            var actual = parking.GetCarFromStateNumber("fgv254");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetCarsFromOwnerSurname_ManySafiullinCars_3CarReturned()
        {
            var expected = new Dictionary<int, Car>()
            {
                { 2, new Car("sdg673", "black", "Safiullin")},
                { 4, new Car("mjz768", "red", "Safiullin")},
                { 5, new Car("ghj533", "blue", "Safiullin")}
            };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Vasilev")},
                { 2, new Car("sdg673", "black", "Safiullin")},
                { 3, new Car("fgv253", "green", "Zaripov")},
                { 4, new Car("mjz768", "red", "Safiullin")},
                { 5, new Car("ghj533", "blue", "Safiullin")}
            };

            var parking = new Parking(cars);
            var actual = parking.GetCarsFromOwnerSurname("Safiullin");

            CheckResult(actual, expected);
        }

        [TestMethod]
        public void GetCarsFromOwnerSurname_OneSafiullinCar_1CarReturned()
        {
            var expected = new Dictionary<int, Car>()
            {
                { 1, new Car("wef782", "red", "Safiullin")}
            };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Safiullin")},
                { 2, new Car("sdg673", "blue", "Petrov")},
                { 3, new Car("fgv253", "green", "Zaripov")},
            };

            var parking = new Parking(cars);
            var actual = parking.GetCarsFromOwnerSurname("Safiullin");

            CheckResult(actual, expected);
        }

        [TestMethod]
        public void GetCarsFromOwnerSurname_NoSafiullinCar_0CarReturned()
        {
            var expected = new Dictionary<int, Car>() { };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "white", "Vasilev")},
                { 2, new Car("sdg673", "blue", "Petrov")},
                { 3, new Car("fgv253", "green", "Zaripov")},
            };

            var parking = new Parking(cars);
            var actual = parking.GetCarsFromOwnerSurname("Safiullin");

            CheckResult(actual, expected);
        }                       

        [TestMethod]
        public void GetInParkingCars_ManyParkingCars_3CarReturned()
        {
            var expected = new Dictionary<int, Car>()
            {
                { 1, new Car("wef782", "red", "Vasilev")},
                { 3, new Car("fgv253", "green", "Zaripov")},
                { 4, new Car("mjz768", "red", "Safiullin")},
            };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Vasilev")},
                { 2, new Car("sdg673", "black", "Safiullin", false)},
                { 3, new Car("fgv253", "green", "Zaripov")},
                { 4, new Car("mjz768", "red", "Safiullin")},
                { 5, new Car("ghj533", "blue", "Safiullin", false)}
            };

            var parking = new Parking(cars);
            var actual = parking.GetInParkingCars();

            CheckResult(actual, expected);
        }

        [TestMethod]
        public void GetInParkingCars_OneParkingCar_1CarReturned()
        {
            var expected = new Dictionary<int, Car>()
            {
                { 1, new Car("wef782", "red", "Safiullin")}
            };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "red", "Safiullin")},
                { 2, new Car("sdg673", "blue", "Petrov", false)},
                { 3, new Car("fgv253", "green", "Zaripov", false)},
            };

            var parking = new Parking(cars);
            var actual = parking.GetInParkingCars();

            CheckResult(actual, expected);
        }

        [TestMethod]
        public void GetInParkingCars_NoParkingCars_0CarReturned()
        {
            var expected = new Dictionary<int, Car>() { };

            Dictionary<int, Car> cars = new() {
                { 1, new Car("wef782", "white", "Vasilev", false)},
                { 2, new Car("sdg673", "blue", "Petrov", false)},
                { 3, new Car("fgv253", "green", "Zaripov", false)},
            };

            var parking = new Parking(cars);
            var actual = parking.GetInParkingCars();

            CheckResult(actual, expected);
        }

        private void CheckResult(Dictionary<int, Car> actual, Dictionary<int, Car> expected)
        {
            foreach (var car in actual)
            {
                Assert.IsTrue(car.Value.Equals(expected[car.Key]));
            }
        }
    }          
}