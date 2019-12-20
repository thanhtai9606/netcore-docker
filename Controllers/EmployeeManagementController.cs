using acb_app.Models;
using acb_app.Repositories.Services;
using BecamexIDC.Common;
using BecamexIDC.Pattern.EF.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace acb_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = "Bearer")] // waring have to use this
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private OperationResult operationResult = new OperationResult();
        public EmployeeManagementController(IEmployeeService employeeService, IUnitOfWorkAsync unitOfWork)
        {
            _employeeService = employeeService;
            _unitOfWork = unitOfWork;
          
        }
        [HttpPost, Route("AddEmployee")]
        public IActionResult AddEmployee(Employee Employee)
        {
            try
            {
                _employeeService.Add(Employee);
                int res = _unitOfWork.SaveChanges();
                if (res > 0)
                {
                    operationResult.Success = true;
                    operationResult.Message = "Added new record";
                    operationResult.Caption = "Add complete";
                }

            }
            catch (System.Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = ex.ToString();
                operationResult.Caption = "Add failed!";
            }
            return Ok(operationResult);
        }
        [HttpPost, Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee Employee)
        {
            try
            {
                _employeeService.Update(Employee);
                int res = _unitOfWork.SaveChanges();
                if (res > 0)
                {
                    operationResult.Success = true;
                    operationResult.Message = "Update success";
                    operationResult.Caption = "Update complete";
                }

            }
            catch (System.Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = ex.ToString();
                operationResult.Caption = "Update failed!";
            }
            return Ok(operationResult);
        }
        
        [HttpDelete, Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeService.Delete(id);
                int res = _unitOfWork.SaveChanges();
                if (res > 0)
                {
                    operationResult.Success = true;
                    operationResult.Message = "Delete success";
                    operationResult.Caption = "Delete complete";
                }

            }
            catch (System.Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = ex.ToString();
                operationResult.Caption = "Delete failed!";
            }
            return Ok(operationResult);
        }
        [HttpGet, Route("GetEmployee")]
        public IActionResult GetEmployee()
        {
            return Ok(_employeeService.Queryable());
        }


    }
}