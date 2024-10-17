using LibraryAPI.Librarymanagmen;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

        private readonly IPKG_Managment _pkgService;

        public LibraryController(IPKG_Managment pkgService)
        {
            _pkgService = pkgService;
        }
        [HttpPost("add-books")]
        public IActionResult AddBooks([FromBody] addbookDTO books)
        {
            if (books == null)
            {
                return BadRequest("Book data is required.");
            }

            var result = _pkgService.addbooks(books);
            return Ok(result);
        }


        [HttpGet("get-books")]
        public IActionResult GetBooks()
        {
            var result = _pkgService.GetAllBooks();
            return result;


        }
    }
}
