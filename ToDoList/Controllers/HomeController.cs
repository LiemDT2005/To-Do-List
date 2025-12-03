using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Models;
using UseCases;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly TodoListManager _listManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(TodoListManager listManager, ILogger<HomeController> logger)
        {
            _listManager = listManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var todoItems = _listManager.GetTodoItems();
            return View(new TodoListViewModel()
            {
                Items = todoItems.Select(ti => new Item()
                {
                    Id = ti.Id,
                    IsCompleted = ti.IsCompleted,
                    Text = ti.Text
                })
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Item item)
        {

            _listManager.AddTodoItem(new TodoItem()
            {
                Text = item.Text,
                IsCompleted = false
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            _listManager.MarkComplete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var todo = _listManager.GetTodoItemById(id);
            if (todo == null)
            {
                return NotFound();
            }

            var item = new Item()
            {
                Id = todo.Id,
                IsCompleted = todo.IsCompleted,
                Text = todo.Text
            };

            return View(item);
        }

        public IActionResult Update(Item item)
        {
            _listManager.Update(new TodoItem()
            {
                Id = item.Id,
                Text = item.Text,
                IsCompleted = item.IsCompleted
            });
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            _listManager.Delete(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
