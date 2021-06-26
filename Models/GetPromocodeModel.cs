namespace Models
{
    public class GetPromocodeModel
    {
        public string Code { get; set; }
        public int Discount { get; set; }
        public bool IsAvailable { get; set; }
    }
}