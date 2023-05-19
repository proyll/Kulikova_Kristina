namespace WebApiTesst.Contracts.CartItem
{
    public class CreateCartItemRequest
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Cart { get; set; }
        public int Product { get; set; }
    }
}
