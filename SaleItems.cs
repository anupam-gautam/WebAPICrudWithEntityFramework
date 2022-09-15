namespace APICrudWithEntityFramework
{
    public class SaleItems
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string Image { get; set; } = string.Empty ;

        //Image pani halnu parney => Ask Chhetra dai
    }
}
