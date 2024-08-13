namespace GuitarOOAD.Models
{
    internal class TypeExtension
    {
        public static string ToString(Type type)
        {
            switch (type)
            {
                case Type.Acoustic:
                    return "acoustic";
                case Type.Electric:
                    return "electric";
                default:
                    return type.ToString();
            }
        }
    }
}
