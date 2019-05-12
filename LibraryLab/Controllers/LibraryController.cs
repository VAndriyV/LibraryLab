using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookService _bookService;
        public LibraryController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetBooks(int limit,int offset)
        {
            var books = await _bookService.GetBooksRangeAsync(limit, offset);
            throw new NotImplementedException();
        }
    }
}