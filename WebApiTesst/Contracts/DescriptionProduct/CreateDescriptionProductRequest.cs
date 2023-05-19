namespace WebApiTesst.Contracts.DescriptionProduct
{
    public class CreateDescriptionProductRequest
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string? TextD { get; set; }
        public int Rating { get; set; }
        public int Customer { get; set; }
        public int Product { get; set; }
    }
}
