using EmployeeService.Interface;
using EmployeeService.Model;
using EmployeeService.Repository.Interface;
using EmployeeService.Services;
using Moq;

namespace Test
{
    public class EmployeeAttendance
    {
        [Fact]
        public void SaveAttendance_succesful_for_existing_employee_Test()
        {
            //Arrange
            var employeeAttendanceRepoMock = new Mock<IEmployeeAttendanceRepo>();
            employeeAttendanceRepoMock.Setup(x => x.SaveInOut(It.IsAny<int>())).Returns(true);
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(x => x.EmployeeExist(It.IsAny<int>())).Returns(true);
            var employeeAttendanceServiceMock = new Mock<EmployeeAttendanceService>(employeeAttendanceRepoMock.Object, employeeServiceMock.Object);
            employeeAttendanceServiceMock.CallBase = true;

            //Act
            employeeAttendanceServiceMock.Setup(x => x.SaveInOut(It.IsAny<int>())).Returns(true);
            var response = employeeAttendanceServiceMock.Object.SaveAttendance(It.IsAny<int>());

            //Assert
            Assert.True(response);
            employeeAttendanceServiceMock.Verify(x => x.SaveInOut(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void SaveAttendance_fails_for_nonexisting_employee_Test()
        {
            //Arrange
            var employeeAttendanceRepoMock = new Mock<IEmployeeAttendanceRepo>();
            employeeAttendanceRepoMock.Setup(x => x.SaveInOut(It.IsAny<int>())).Returns(true);
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(x => x.EmployeeExist(It.IsAny<int>())).Returns(true);
            var employeeAttendanceServiceMock = new Mock<EmployeeAttendanceService>(employeeAttendanceRepoMock.Object, employeeServiceMock.Object);
            employeeAttendanceServiceMock.CallBase = true;

            //Act
            employeeAttendanceServiceMock.Setup(x => x.SaveAttendance(It.IsAny<int>())).Returns(false);
            var response = employeeAttendanceServiceMock.Object.SaveAttendance(It.IsAny<int>());

            //Assert
            Assert.False(response);
            employeeAttendanceServiceMock.Verify(x => x.SaveInOut(It.IsAny<int>()), Times.Never);
        }
    }
}