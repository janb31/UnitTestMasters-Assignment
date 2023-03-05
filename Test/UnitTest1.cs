using EmployeeService.Model;

namespace Test
{
    public class UnitTest1
    {

        EmployeeService.Services.EmployeeService service = new();

        [Fact]
        public void CreateEmployee_Test()
        {
            //Arrange
            Employee employee = new();
            //Act
            int result = service.CreateEmployee(employee);
            //Assert
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void GetEmployeeById_FirstElement_Test()
        {
            //Arrange
            int id = 1;
            //Act
            Employee employee = service.GetEmployeeById(id);
            //Assert
            Assert.NotNull(employee);
            Assert.NotNull(employee.FirstName);
            Assert.NotNull(employee.MiddleName);
            Assert.NotNull(employee.LastName);
        }

        [Fact]
        public void GetEmployees_Test()
        {
            //Arrange & Act
            IEnumerable<Employee> employees = service.GetEmployees();
            bool count = employees.Count() > 0;
            //Assert
            Assert.True(count);
            Assert.NotNull(employees.First().FirstName);
            Assert.NotNull(employees.First().MiddleName);
            Assert.NotNull(employees.First().LastName);
        }

    }
}