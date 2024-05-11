using Library.PublicControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    [Route("Api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase {
        [HttpPost] //api/main/uploadfile
        public IActionResult UploadFile(IFormFile file) {

            return Ok(new UploadHandler().Upload(file));
        }




    }
}
