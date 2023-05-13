namespace StudentsFetcher
{
    internal class AmmFormAttributes : System.Attribute
    {
        public string ButtonText { get; set; }

        private double order;

        public double Order
        {
            get { return order; }
            set { order = value; }
        }

        public AmmFormAttributes(string buttonText, double order = double.PositiveInfinity)
        {
            ButtonText = buttonText;
            Order = order;
        }
    }
}
