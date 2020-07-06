using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class NoteFolder
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public DateTime CreationDate
        {
            get;
            set;
        }

        public int ParentFolderId
        {
            get;
            set;
        }
        public int uId
        {
            get;
            set;
        }
    }
}