﻿using System;
using System.Web.Mvc;
using MOBYNew.Models;
using System.Collections.Generic;
using MOBYNew.ViewModels;

namespace MOBYNew.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item/Random
        public ActionResult Random()
        {
            var item = new Item() { Name = "Watchmen", Id =1};

            var contacts = new List<Contact>
            {
                new Contact() {Name = "Contact 1"},
                new Contact() {Name = "Contact 2"}
            };

            var viewModel = new RandomItemViewModel
            {
                Item = item,
                Contacts = contacts
            };

            return View(viewModel);
        }

        //attribute route with constraints
        [Route("item/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}/{day:regex(\\d{2}):range(1,31)}")]
        public ActionResult ByReleaseDate(int year, int month, int? day)
        {
            return Content(year + "/" + month + "/" + day);
        }

        // item
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

            return Content(String.Format("pageIndex = {0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}