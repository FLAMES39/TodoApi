namespace TodoApi.dto
{
    public class ProductsDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public int price { get; set; }

        public Boolean status { get; set; }
    }
}
