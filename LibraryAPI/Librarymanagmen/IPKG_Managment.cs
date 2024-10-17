using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Librarymanagmen
{
    public interface IPKG_Managment
    {
        IActionResult addbooks(addbookDTO books);
        IActionResult GetAllBooks();

    }
}
