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
    public class HandlebarTemplateController : StandardController
    {
        protected readonly IHandlebarTemplateRepository HandlebarTemplateRepository;

        public HandlebarTemplateController(IHandlebarTemplateRepository repository)
        {
            this.HandlebarTemplateRepository = repository;
        }

        protected override object GetModel()
        {
            return HandlebarTemplateRepository.GetModel();
        }

        public override ActionResult Index()
        {
            var model = this.GetModel() as HandlebarTemplateModel;
            
            return View(model);
        }
    }
}