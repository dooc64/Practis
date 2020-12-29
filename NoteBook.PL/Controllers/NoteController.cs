using Entities;
using NoteBook.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NoteBook.PL.Models;
using System.Web.Security;

namespace NoteBook.PL.Controllers
{
    public class NoteController : Controller
    {
        private readonly INotesBL notesBL;
        private readonly IUserBL userBL;

        public NoteController(INotesBL notesBL, IUserBL userBL)
        {
            this.notesBL = notesBL;
            this.userBL = userBL;
        }

        static MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Note, NoteVM>());
        static Mapper mapper = new Mapper(config);
        static MapperConfiguration config2 = new MapperConfiguration(cfg => cfg.CreateMap<NoteVM, Note>());
        static Mapper mapper2 = new Mapper(config2);

        [HttpPost]
        public ActionResult Create(NoteVM noteVM)
        {
            var note = mapper2.Map<Note>(noteVM);
            notesBL.Create(note);
            return Redirect("~/Note/GetAll");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Note/LogIn");
        }
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string login, string password)
        {
            var result = userBL.LogIn(login, password);
            if (result != 0)
            {
                if (!User.Identity.IsAuthenticated)
                    FormsAuthentication.SetAuthCookie(login, true);
                return Redirect("~/Note/GetAll");
            }
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string login, string password)
        {
            var result = userBL.Create(login, password);
            return Redirect("~/Note/GetAll");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Update(NoteVM noteVM)
         {
            var note = mapper2.Map<Note>(noteVM);
            notesBL.Update(note);
            return Redirect("~/Note/GetAll");
         }

        public ActionResult Update(int id)
        {
            var note = notesBL.GetByID(id);
            var noteVM = mapper.Map<NoteVM>(note);
            return View(noteVM);
        }
        public ActionResult Delete(int id)
        {
            notesBL.DeleteByID(id);
            return Redirect("~/Note/GetAll");
        }

        public ActionResult GetByID(int id)
        {
            var note = notesBL.GetByID(id);
            var noteVM = mapper.Map<NoteVM>(note);
            return View(noteVM);
        }

        public ActionResult GetAll(string name)
        {
            if (name == null || name == "")
            {
                var notes = notesBL.GetAll();
                var notesVM = mapper.Map<IEnumerable<NoteVM>>(notes);
                return View(notesVM);
            }
            else
            {
                var notes = notesBL.SearchByName(name);
                var notesVM = mapper.Map<IEnumerable<NoteVM>>(notes);
                return View(notesVM);
            }
        }
    }
}