using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentNewDatabaseSample.Models
{
  public   class StudentClass
    {
        public int StudentClassId { get; set; }
        public string StudentClassName { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
