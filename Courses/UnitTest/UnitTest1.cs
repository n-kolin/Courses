using Courses.Controllers;
using Courses.Entities;
using Courses.Servers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Phone_ReturnsTrue()
        {

            ErrorType errorType = 0;
            bool isValid = new IsValidPhone().IsValid("56565", out errorType);
            Assert.False(isValid);


        }
        [Fact]
        public void GetAll_ReturnsCount()
        {
            //var controller = new StudentsController();

            var controller = new StudentsController(new StudentServer(new FakeContext()));
            var res = controller.Get();
            Assert.Equal(1, res.Value.Count());

        }
        [Fact]
        public void Get_ReturnsBadRequest()
        {
            //var controller = new StudentsController();

            var controller = new StudentsController(new StudentServer(new FakeContext()));
            var res = controller.Get(-5);
            Assert.IsType<BadRequestResult>(res.Result);

        }
        [Fact]
        public void Post_ReturnsOk()
        {
            //var controller = new StudentsController();

            var controller = new StudentsController(new StudentServer(new FakeContext()));
            var res = controller.Post(new Student() { Phone = "45645" });
            Assert.IsType<OkObjectResult>(res);

        }
        [Fact]
        public void Put_ReturnsNotFount()
        {
            //var controller = new StudentsController();

            var controller = new StudentsController(new StudentServer(new FakeContext()));
            var res = controller.Put(2, new Student() { Phone = "052456456", Id = 5 });
            Assert.IsType<NotFoundResult>(res.Result);
        }
        [Fact]
        public void Delete_ReturnsNotOk()
        {
            //var controller = new StudentsController();

            var controller = new StudentsController(new StudentServer(new FakeContext()));
            var res = controller.Delete(2);
            Assert.IsNotType<OkObjectResult>(res);
        }

    }
}