﻿using SF.Feature.Handlebars.SXA.Models;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Feature.Handlebars.SXA.Repositories
{
    public class HandlebarFacetContainerRepository : ModelRepository, IHandlebarFacetContainerRepository
    {
        public override IRenderingModelBase GetModel()
        {
            var model = new HandlebarFacetContainerModel();
            FillBaseProperties(model);
            
            return model;
        }
    }
}