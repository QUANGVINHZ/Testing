using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        //khởi tạo list tên là todoList chứa các đối tượng(object) là ModelTodo dựa trên class cùng tên trong project
        //đồng thời khởi tạo 2 đối tượng 
        private static List<ModelTodo> todoList = new List<ModelTodo>
        {
            new ModelTodo
            {
                Id = 1,
                Name = "Test",
                 Description = "Description",
            },
            new ModelTodo
            {
                Id = 2,
                Name = "Test1",
                 Description = "Description23",
            }
        };
        


        [HttpGet]

        public IActionResult getTodo()
        {
            //THEM VAO LIST HIEN CO
            //tao cai list moi cho get va post
           


            return Ok(todoList);
        }
        [HttpPost]

        public IActionResult addTodo(ModelTodo todo)
        {

            todoList.Add(todo);
            return Ok(todoList);
        }

        [HttpPut]

        public IActionResult getTodoId(int id, ModelTodo updateTodo)   
        {
            var existingTodo = todoList.FirstOrDefault(todo => todo.Id == id);
            //gán phần tử exsitingtodo có cùng Id tron danh sách todolist
            //dựa theo parameter 
            if (existingTodo == null) {
                return NotFound();
            }
            existingTodo.Id = updateTodo.Id;
            existingTodo.Name = updateTodo.Name;
            existingTodo.Description = updateTodo.Description;
           
            //sau đó ta nhập vào giá trị ta muốn có vào từng phần tử
            //
            return Ok(updateTodo);
        }

        [HttpDelete]
        public IActionResult deleteTodo(int id)
        {
            var todo = todoList.FirstOrDefault(todo => todo.Id == id);
            // todo là đc gắn giá trị đầu tiên có cùng id trong todoList
            //(todo => todo.Id == id): Đây là biểu thức lambda, nó định nghĩa điều kiện để tìm kiếm 
            //phần tử trong danh sách. Biểu thức này kiểm tra xem thuộc tính Id của mỗi đối tượng 
            //trong danh sách có bằng giá trị id mà bạn cung cấp hay không. Nếu bằng, thì đối tượng đó sẽ được trả về.

            todoList.Remove(todo);
            //xóa phần tử tương đương với biến todo trong danh sách, sau khi xóa phần tử sẽ ko tồn tại nữa
            //nếu ko có phần tử todo thì danh sách sẽ ko thay đổi

            return Ok(todoList);
            //trả về http 200"Ok" chưa danh sách todoList
        }
    }
}
