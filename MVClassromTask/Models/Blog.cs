using MVClassromTask.Models.Common;

namespace MVClassromTask.Models
{
    public class Blog:BaseEntity
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }  
        public string Description { get; set; }
        public DateTime createdDate {  get; set; }  
    }
}
