namespace MyHealthChart3.Models
{
    public class Note : NoteFolder
    {
        public Note()
        {

        }
        public Note(Folder f)
        {
            ParentFolderId = f.Id;
            UId = f.UId;
            Password = f.Password;
        }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
