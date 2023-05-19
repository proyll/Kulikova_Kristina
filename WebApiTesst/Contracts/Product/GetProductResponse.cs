namespace WebApiTesst.Contracts.Product
{
    public class GetProductResponse
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? NameP { get; set; }
        public int Price { get; set; }
        public int ProductAvailability { get; set; }
    }
}
