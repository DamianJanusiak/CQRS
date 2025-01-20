namespace Domain
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int BookPages { get; set; }
        public string Content { get; set; }

        public string Author { get; set; }

    }
}
