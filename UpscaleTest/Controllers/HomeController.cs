using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UpscaleTest.Models;
using UpscaleTest.Service;

namespace UpscaleTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceTodo _serviceTodo;

        public HomeController(ILogger<HomeController> logger, IServiceTodo serviceTodo)
        {
            _logger = logger;
            _serviceTodo = serviceTodo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            long longVer = (long)Id;
            return View(longVer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodo(SortingModel sorting)
        {
            List<TodoModel> result = await _serviceTodo.GetAllTodo(sorting);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetDataById(int Id)
        {
            TodoModel result = await _serviceTodo.GetDataById(Id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoModel data)
        {
            await _serviceTodo.CreateTodo(data);
            return Json("Data has been created");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTodo([FromBody] TodoModel data)
        {
            await _serviceTodo.UpdateTodoChecklistOnly(data);
            return Json("Data has been update");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTodoAll([FromBody] TodoModel data)
        {
            await _serviceTodo.UpdateTodo(data);
            return Json("Data has been update");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int Id)
        {
            await _serviceTodo.DeleteById(Id);
            return Json("Data has been Deleted");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}