namespace GuitarOOAD.Models
{
    internal class Inventory
    {
        public List<Guitar> Guitars { get; set; } = new List<Guitar>();

        public void AddGuitar(Guitar guitar)
        {
            Guitars.Add(guitar);

        }

        public Guitar GetGuitar(string serialNumber)
        {
            return Guitars.Find(x => x.SerialNumber == serialNumber);

        }

        public List<Guitar> Search(GuitarSpec searchSpec)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();

            foreach (Guitar guitar in Guitars)
            {
                if (guitar.Spec.Matches(searchSpec))
                {
                    matchingGuitars.Add(guitar);
                }
            }
            return matchingGuitars;
        }



    }
}
