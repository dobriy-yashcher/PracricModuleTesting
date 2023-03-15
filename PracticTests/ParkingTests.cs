using PracricLibrary;

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
        public void SearchCarFromColor_ManyRedCars_3CarReturned()
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

        private void CheckResult(Dictionary<int, Car> actual, Dictionary<int, Car> expected)
        {
            for (int i = 0; i < actual.Count; i++)
            {
                if (actual.Count != expected.Count) Assert.Fail();
                if (actual.Keys.Except(expected.Keys).Any()) Assert.Fail();
                if (expected.Keys.Except(actual.Keys).Any()) Assert.Fail();
                foreach (var pair in actual)
                    Assert.Equals(pair.Value, expected[pair.Key]);
            }
        }
    }
}