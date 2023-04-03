using Microsoft.AspNetCore.Mvc;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class AppointmentController : Controller
{
    public IActionResult BookAppointment()
    {
        return View();
    }
}
