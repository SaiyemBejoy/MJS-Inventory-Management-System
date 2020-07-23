﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System.Controllers
{
    public class PurchaseInvoiceController : Controller
    {
        inventoryDBEntities obj = new inventoryDBEntities();
        // GET: PurchaseInvoice
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var data = (from x in obj.suppliers select new { x.sup_id, x.sup_name}).ToList();

            return View();
        }
    }
}