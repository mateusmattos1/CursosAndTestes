using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Post]")]
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Write(false)]
        public Category Category { get; set; }

        [Write(false)]
        public List<Tag> Tags { get; set; }
    }
}