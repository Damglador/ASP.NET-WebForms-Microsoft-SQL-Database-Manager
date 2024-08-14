using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace dotNET_V8.Models
{
    public partial class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public int? ManufactureCode { get; set; }
        public int? AuthorCode { get; set; }
        public int? ReleaseYear { get; set; }
        public int? StorageCode { get; set; }
    }
}
