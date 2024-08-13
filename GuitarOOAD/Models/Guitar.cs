namespace GuitarOOAD.Models
{
    internal class Guitar
    {
        public string SerialNumber { get; set; }
        public double Price { get; set; }

        public GuitarSpec Spec { get; set; }


        public Guitar(string serialNumber, double price, GuitarSpec spec)
        {
            SerialNumber = serialNumber;
            Price = price;
            Spec = spec;

        }

        public string GetSerialNumber() { return SerialNumber; }

        public double GetPrice() { return Price; }

        public void SetPrice(float newprice) { this.Price = newprice; }

        public GuitarSpec GetSpec() { return Spec; }



    }
}
