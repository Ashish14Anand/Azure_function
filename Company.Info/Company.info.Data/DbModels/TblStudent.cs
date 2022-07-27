using System;
using System.Collections.Generic;

#nullable disable

namespace Company.info.Data.DbModels
{
    public partial class TblStudent
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string Phoneno { get; set; }
    }
}
