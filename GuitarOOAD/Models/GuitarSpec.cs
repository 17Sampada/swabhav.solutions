namespace GuitarOOAD.Models
{
    internal class GuitarSpec
    {
        public Builder Builder { get; set; }
        public string Model { get; set; }

        public Type Type { get; set; }

        public Wood BackWood { get; set; }
        public Wood TopWood { get; set; }

        private int numStrings { get; set; }

        public GuitarSpec(Builder builder, string model, Type type, int numstrings, Wood backwood, Wood topwood)
        {

            Builder = builder;
            Model = model;
            Type = type;
            numStrings = numstrings;
            BackWood = backwood;
            TopWood = topwood;

        }

        public Builder GetBuilder() { return Builder; }
        public string GetModel() { return Model; }

        public Type GetType() { return Type; }

        public Wood GetBackWood() { return BackWood; }
        public Wood GetTopWood() { return TopWood; }

        public int GetNumStrings() { return numStrings; }


        public bool Matches(GuitarSpec otherSpec)
        {
            if (Builder != otherSpec.Builder)
                return false;
            if (!string.IsNullOrEmpty(Model) && !Model.Equals(otherSpec.Model))
                return false;
            if (Type != otherSpec.Type)
                return false;
            if (numStrings != otherSpec.numStrings)
                return false;
            if (BackWood != otherSpec.BackWood)
                return false;
            if (TopWood != otherSpec.TopWood)
                return false;
            return true;
        }
    }
}
