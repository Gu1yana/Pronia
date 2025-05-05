using MVClassromTask.Models.Common;

namespace MVClassromTask.Models;

public class Service:BaseEntity
{
    public  string ImagePath {  get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
