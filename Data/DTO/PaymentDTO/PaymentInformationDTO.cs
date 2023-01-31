namespace TripApplication.Data.DTO.PaymentDTO
{
    public class PaymentInformationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
