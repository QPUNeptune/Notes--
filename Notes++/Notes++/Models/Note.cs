using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Notes__
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}
