using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClassLibrary
{
    public class ProduceClass
    {
        public long Id { get; set; }
        public int ProduceCategory { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Status { get; set; }
        public long CreatedBy { get; set; }
    }

    public class ResultClass
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

   
}
