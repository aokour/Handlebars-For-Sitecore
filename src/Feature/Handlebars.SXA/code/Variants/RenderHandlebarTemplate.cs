﻿using Sitecore.XA.Foundation.RenderingVariants.Fields;
using Sitecore.XA.Foundation.RenderingVariants.Pipelines.RenderVariantField;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using SF.Foundation.Handlebars;

namespace SF.Feature.Handlebars.SXA.Variants
{
    public class RenderHandlebarTemplate : RenderRenderingVariantFieldProcessor
    {

        public override RendererMode RendererMode
        {
            get
            {
                return RendererMode.Html;
            }
        }

        public override Type SupportedType
        {
            get
            {
                return typeof(HandlebarVariantTemplate);
            }
        }

        public RenderHandlebarTemplate()
        {
        }

        public override void RenderField(RenderVariantFieldArgs args)
        {
            var variantField = args.VariantField as HandlebarVariantTemplate;
            if (variantField != null)
            {
                HtmlGenericControl htmlGenericControl = new HtmlGenericControl((string.IsNullOrWhiteSpace(variantField.Tag) ? "div" : variantField.Tag));
                this.AddClass(htmlGenericControl, variantField.CssClass);
                this.AddWrapperDataAttributes(variantField, args, htmlGenericControl);

                if (HttpContext.Current.Items["htmlHelper"] == null)
                {
                    HttpContext.Current.Items.Add("htmlHelper", args.HtmlHelper);
                }

                var content = HandlebarManager.GetTemplatedContent(variantField.TemplateItem, args.Item, args.Model);

                

                htmlGenericControl.InnerHtml = content.ToHtmlString();

                args.ResultControl = htmlGenericControl;
                args.Result = this.RenderControl(args.ResultControl);
            }
        }
    }
}