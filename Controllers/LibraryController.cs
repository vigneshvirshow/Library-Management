using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Library_Management.Interfaces;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Controllers
{

    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService ?? throw new ArgumentNullException(nameof(libraryService));
        }

        [HttpGet]
        [Route("viewbooks")]
        public List<BookDetails> GetBookDetails()
        {
            var bookDetails = _libraryService.GetBookDetails().Result;
            return bookDetails;
        }

        [HttpPost]
        [Route("insertbook")]
        [HttpPost]
        public IActionResult InsertBook(InsertBookDetails bookDetails)
        {
            _libraryService.InsertBook(bookDetails);
            return Ok();
        }

        [HttpPost]
        [Route("updatebook")]
        [HttpPost]
        public IActionResult UpdateBook(string bookName, int bookId)
        {
            _libraryService.UpdateBook(bookName, bookId);
            return Ok();
        }

        [HttpDelete]
        [Route("deletebook")]
        public IActionResult DeleteBook(int bookId)
        {
            _libraryService.DeleteBook(bookId);
            return Ok();
        }
    }
}
