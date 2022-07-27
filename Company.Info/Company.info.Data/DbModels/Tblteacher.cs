using System;
using System.Collections.Generic;

#nullable disable

namespace Company.info.Data.DbModels
{
    public partial class Tblteacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Address { get; set; }
    }
}
