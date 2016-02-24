namespace NetPontoSec.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Body { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public int Visits { get; set; }
    }
}
