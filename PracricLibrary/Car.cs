using System;

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

        public override bool Equals(object obj)
        {
            if (!(obj is Car))
                return false;

            var other = obj as Car;

            if (stateNumber != other.stateNumber || color != other.color ||
                ownerSurname != other.ownerSurname || inParkingLot != other.inParkingLot) return false;

            return true;
        }

        public static bool operator == (Car x, Car y)
        {
            return x.Equals(y);
        }

        public static bool operator != (Car x, Car y)
        {
            return !(x == y);
        }
    }
}