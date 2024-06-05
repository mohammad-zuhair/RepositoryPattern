using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.core;
using RepositoryPatternWithUOW.core.Interfaces;
using RepositoryPatternWithUOW.core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork ;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetById()
        {

            var result = _unitOfWork.Books.GetById(1);
            return Ok(result);
        }


        [HttpGet("GetAll")]
        public IActionResult GetGetAll()
        {

            var result = _unitOfWork.Books.GetAll();
            return Ok(result);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            var result = _unitOfWork.Books.Find(n=>n.Title == "New", new[] {"Author"} );
            return Ok(result);
        }


        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            var result = _unitOfWork.Books.FindAll(n => n.Title.Contains("book"), new[] { "Author" });
            return Ok(result);
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            var result = _unitOfWork.Books.FindAll(n => n.Title.Contains("book"), null ,null ,b=>b.Id);
            return Ok(result);
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var result = _unitOfWork.Books.Add(new Book { Title ="new book 4" , AuthorId =1});
            _unitOfWork.Complete();
            return Ok(result);
        }
    }
}
