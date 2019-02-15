﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Controllers;
using SF.Foundation.Handlebars;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace SF.Feature.Handlebars
{
    public class HandlebarsController : SitecoreController
    {

        public ActionResult HandlebarForm()
        {
            var modelItem = this.GetItem();

            if (Request.RequestType.ToUpper() == "POST")
            {
                var contentItem = Sitecore.Context.Database.GetItem(modelItem.Fields["Post Processing Data Source"].Value);

                if (contentItem != null)
                {
                    HandlebarManager.SetupContainer(contentItem);
                }

                var proccessors = (MultilistField)modelItem.Fields["Processors"];
             
                foreach(var processor in proccessors.Items)
                {
                    var processorItem = Sitecore.Context.Database.GetItem(processor);
                    var processorTypeValue = processorItem.Fields["Type"].Value;

                    try
                    {
                        
                        Type processorType = Type.GetType(processorTypeValue);
                        var formProcessor = Activator.CreateInstance(processorType) as IFormProcessor;
                        formProcessor.Process(processorItem, modelItem, Request);                        
                    }
                    catch(Exception ex)
                    {
                        Sitecore.Diagnostics.Log.Error("Could not instatiate and invoke type: " + processorTypeValue, ex, this);
                    }
                }

                var redirectField = (LinkField) modelItem.Fields["Redirection Url"];
                if (!string.IsNullOrEmpty(redirectField.Value))
                {
                    return Redirect(redirectField.GetFriendlyUrl());
                }
            }
            else
            {
                var contentItem = Sitecore.Context.Database.GetItem(modelItem.Fields["Content Data Source"].Value);
                if (contentItem != null)
                {
                    HandlebarManager.SetupContainer(contentItem);
                }
            }

            return View();
        }


        public Item GetItem()
        {
            var rc = RenderingContext.CurrentOrNull;
            if (rc != null && rc.Rendering != null)
            {
                if (!string.IsNullOrEmpty(rc.Rendering.DataSource))
                {
                    return Sitecore.Context.Database.GetItem(rc.Rendering.DataSource);
                }
            }
            return Sitecore.Context.Item;
        }
    }
}