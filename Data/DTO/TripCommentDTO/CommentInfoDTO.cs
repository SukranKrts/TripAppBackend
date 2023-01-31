namespace TripApplication.Data.DTO.TripCommentDTO
{
    public class CommentInfoDTO
    {
        public int TripId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Point { get; set; }
    }
}
