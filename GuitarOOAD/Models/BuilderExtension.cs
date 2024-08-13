namespace GuitarOOAD.Models
{
    internal class BuilderExtension
    {
        public static string ToString(Builder builder)
        {
            switch (builder)
            {
                case Builder.Fender:
                    return "Fender";
                case Builder.Martin:
                    return "Martin";
                case Builder.Gibson:
                    return "Gibson";
                case Builder.Collings:
                    return "Collings";
                case Builder.Olson:
                    return "Olson";
                case Builder.Ryan:
                    return "Ryan";
                case Builder.Prs:
                    return "PRS";
                case Builder.Any:
                    return "Any";
                default:
                    return builder.ToString();
            }
        }
    }
}
