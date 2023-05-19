namespace WebApiTesst.Contracts.Filter
{
    public class GetFilterResponse
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? SubcategoryName { get; set; }
        public int ProductId { get; set; }
        public string? NameP { get; set; }
        public string? Color { get; set; }
        public int? Popular { get; set; }
        public string? Material { get; set; }
        public string? Size { get; set; }
        public int Price { get; set; }
        public int Sale { get; set; }
    }
}
