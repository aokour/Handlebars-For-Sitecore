﻿using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.Handlebars
{
    public interface IFormProcessor
    {
        void Process(Item processorItem, Item formConfiguration, HttpRequestBase request);
    }
}