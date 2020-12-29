using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteBook.PL.Models
{
    public class NoteVM
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Заметка")]
        public string Text { get; set; }
        public int ID { get; set; }

    }
}