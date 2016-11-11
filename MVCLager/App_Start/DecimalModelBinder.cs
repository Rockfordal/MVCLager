using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLager
{
    public class DecimalModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult == null)
            {
                return base.BindModel(controllerContext, bindingContext);
            }
            else
            {
                decimal result;
                var value = valueProviderResult.AttemptedValue;
                bool d = Decimal.TryParse(value.Replace('.', ','), out result);

                if (d)
                    return result;
                else
                    return value;
            }

        }
    }
}

