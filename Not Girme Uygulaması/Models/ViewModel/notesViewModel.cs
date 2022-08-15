using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Not_Girme_Uygulaması.Models.ViewModel
{
    public class notesViewModel
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int studentNo { get; set; }
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int Not1 { get; set; }
        public int Not2 { get; set; }
        public int Per1 { get; set; }
        public int Per2 { get; set; }
        public int Average { get; set; }

    }
}
