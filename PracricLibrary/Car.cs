namespace PracricLibrary
{
    public class Car
    {
        public string stateNumber { get; set; }

        public string color { get; set; }
        public string ownerSurname { get; set; }

        public bool inParkingLot { get; set; }

        public Car() { }

        public Car(string stateNumber, string color, string ownerSurname, bool inParkingLot = true)
        {
            this.stateNumber = stateNumber;
            this.color = color;
            this.ownerSurname = ownerSurname;
            this.inParkingLot = inParkingLot;
        }
    }
}