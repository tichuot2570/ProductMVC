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
    public class CurrenciesController : Controller
    {
        // GET: Currencies
        ExchangeRESTService crservice = new ExchangeRESTService();

        public ActionResult Index()
        {
            //return View();
            return View(crservice.GetCurrencies());
        }


        // GET: Currencies/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Category, Rate")]Currency c)
        {
            crservice.PostCurrency(c);

            return RedirectToAction("Index");
        }



        //EDIT
        // GET: Forecasts/Edit/5
        public ActionResult Edit(int id)
        {
            return View(crservice.GetCurrencyById(id));
        }
        // GET: /Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(Currency currency)
        {
            crservice.PutCurrency(currency);
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            return View(crservice.GetCurrencyById(id));
        }

        //DELETE
        public ActionResult Delete(int id)
        {
            crservice.DeleteCurrency(id);
            return RedirectToAction("Index");

        }
    }
}
