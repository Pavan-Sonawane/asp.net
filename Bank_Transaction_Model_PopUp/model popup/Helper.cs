using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace model_popup
{
    public class Helper
    {
        public static string RenderRazorViewToString(Controller controller, string viewName,object model = null)
        {
            controller.ViewData.Model=model;
            using (var sw=new StringWriter())
            {
                IViewEngine viewEngine=controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewresult = viewEngine.FindView(controller.ControllerContext, viewName, false);
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewresult.View, controller.ViewData, controller.TempData, sw, new Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelperOptions());
                viewresult.View.RenderAsync(viewContext);   
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
