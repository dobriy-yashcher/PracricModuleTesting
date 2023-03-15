using PracricLibrary;

namespace PracticTests
{
    [TestClass]
    public class ParkingTests
    {
        [TestMethod]
        public void CreationParkingLot_IdenticalCars_ExceptionReturned()
        {
            try
            {
                Dictionary<int, Car> cars = new()
                {
                    { 1, new Car("wef782", "red", "Vasilev")},
                    { 1, new Car("sij249", "red", "Vasilev")},
                };

                var parking = new Parking(cars);
            }
            catch
            {
                return;
            }

            Assert.Fail();
        }
    }
}