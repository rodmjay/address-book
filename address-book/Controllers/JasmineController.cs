using System;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
