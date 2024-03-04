using Hospital_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;

namespace Hospital_MVC.Controllers
{
    public class PacientController : Controller
    {
        private readonly IPacientService _pacientService;
        public PacientController(IPacientService pacientService)
        {
            this._pacientService = pacientService;
        }
        public IActionResult Index()
        {
            ViewBag.greeting = "hello";
            return View();
        }
        public IActionResult AddPacient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPacient(PacientDto pacientDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {

                QRCodeGenerator generator = new QRCodeGenerator();

                var data = generator.CreateQrCode(pacientDto.Passport.ToString(), QRCodeGenerator.ECCLevel.M);

                QRCoder.BitmapByteQRCode qrcode = new BitmapByteQRCode(data);

                var bytes = qrcode.GetGraphic(20);


                return File(bytes, "image/png", pacientDto.Firstname+".png");
                return RedirectToAction("AddPacient");
                await _pacientService.Create(pacientDto);
            }
            catch (Exception ex)
            {
                TempData["msg"]=ex.ToString();
                return View();
            }

        }
    }
}
