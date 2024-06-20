namespace Diplom.Models
{
    public class FileSystemItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemItem> Contents { get; set; }
    }
}
