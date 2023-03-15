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
            foreach (var car in actual)
            {
                Assert.IsTrue(car.Value.Equals(expected[car.Key]));
            }
        }
    }

    static class extentions
    {
        public static List<Variance> DetailedCompare<T>(this T val1, T val2)
        {
            List<Variance> variances = new List<Variance>();
            var temp = val1.GetType();
            var temp1 = temp.GetFields();
            FieldInfo[] fi = temp1;
            foreach (FieldInfo f in fi)
            {
                Variance v = new Variance();

                v.Prop = f.Name;
                v.valA = f.GetValue(val1);
                v.valB = f.GetValue(val2);

                if (!Equals(v.valA, v.valB))
                    variances.Add(v);        
            }
            return variances;
        }       
    }

    class Variance
    {
        public string Prop { get; set; }
        public object valA { get; set; }
        public object valB { get; set; }
    }                    
}