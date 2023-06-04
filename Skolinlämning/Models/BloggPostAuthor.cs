namespace Skolinlämning.Models
{
    public class BloggPostAuthor
    {

        public ICollection<BloggPost> BloggPost { get; set; }

        public ICollection<Author> Author { get; set; }
    }
}
