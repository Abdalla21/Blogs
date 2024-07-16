using System.ComponentModel.DataAnnotations;

namespace BlogsCore.Domain
{
    public class Blog
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
