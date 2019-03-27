namespace LINQ_Lambda
{
    public class Auto
    {
        public bool Elektroantrieb { get; private set; }
        /// <summary>
        /// Hubraub in m³
        /// </summary>
        public int Hubraum { get; private set; }
        public string Name { get; private set; }

        public Auto(string name, int hubraum, bool elektroantrieb = false)
        {
            Elektroantrieb = elektroantrieb;
            Hubraum = hubraum;
            Name = name;
        }

        public override string ToString()
        {
            string hatElektroantrieb = Elektroantrieb ? ",mit Elektoantrieb" : "";
            return $"{Name}, ({Hubraum} m³) {hatElektroantrieb}";
        }
    }
}
