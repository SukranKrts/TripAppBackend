namespace TripApplication.Data.Entities
{
    public class PaymentInformation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual User User { get; set; }
    }
}
