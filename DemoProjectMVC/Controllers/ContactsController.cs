using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DTO;
using DemoProjectMVC.Models;
using BLL;

namespace DemoProjectMVC.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Currencies
        ContactRESTService crservice = new ContactRESTService();

        public ActionResult Index()
        {
            //return View();
            return View(crservice.GetContacts());
        }


        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Email")]Contact c)
        {
            crservice.PostContact(c);

            return RedirectToAction("Index");
        }



        //EDIT
        // GET: Forecasts/Edit/5
        public ActionResult Edit(int id)
        {
            return View(crservice.GetContactById(id));
        }
        // GET: /Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            crservice.PutContact(contact);
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            return View(crservice.GetContactById(id));
        }

        //DELETE
        public ActionResult Delete(int id)
        {
            crservice.DeleteContact(id);
            return RedirectToAction("Index");

        }
    }
}
