namespace StudentsFetcher
{
    internal class AMMFormAttributes : System.Attribute
    {
        public string ButtonText { get; set; }

        private double order = double.PositiveInfinity;

        public double Order
        {
            get { return order; }
            set { order = value; }
        }

        public AMMFormAttributes()
        {
            
        }
    }
}
