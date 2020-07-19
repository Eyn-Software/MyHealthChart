using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class NoteListModel
    {
        public NoteListModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
