namespace MyHealthChart3.Models
{
    public class NoteFolder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public int ParentFolderId { get; set; }
        public int UId { get; set; }
        public string Password { get; set; }
    }
}