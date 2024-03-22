using Microsoft.AspNetCore.Mvc;
using MissionEleven_Thatcher.Models;
using MissionEleven_Thatcher.Models.ViewModels;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MissionEleven_Thatcher.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;


        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;
            var bookData = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };


            return View(bookData);
        }


    }
}
