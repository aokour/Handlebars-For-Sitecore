﻿using SF.Feature.Handlebars.SXA.Models;
using SF.Feature.Handlebars.SXA.Repositories;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SF.Feature.Handlebars.SXA.Controllers
{
    public class AddNewItemController : StandardController
    {
        protected readonly IAddNewItemRepository AddNewItemRepository;

        public AddNewItemController(IAddNewItemRepository repository)
        {
            this.AddNewItemRepository = repository;
        }

        protected override object GetModel()
        {
            return AddNewItemRepository.GetModel();
        }

        public override ActionResult Index()
        {
            var model = this.GetModel() as AddNewItemModel;
            return View(model);
        }
    }
}