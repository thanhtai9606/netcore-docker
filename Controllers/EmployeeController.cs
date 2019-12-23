using acb_app.Models;
using acb_app.Repositories.Services;
using BecamexIDC.Common;
using BecamexIDC.Pattern.EF.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace acbapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = "Bearer")] // waring have to use this
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IPersonService personService;
        private readonly IBusinessEntityAddressService businessEntityAddressService;
        private readonly IBusinessEntityContactService businessEntityContactService;
        private readonly IPhoneService phoneService;
        private readonly IAddressService addressService;
        private readonly IAddressTypeService addressTypeService;
        private readonly IPhoneTypeService phoneTypeService;
        private readonly IUnitOfWorkAsync unitOfWork;
        private OperationResult operationResult = new OperationResult();
        public EmployeeController(IEmployeeService employeeService, 
                                 IPersonService personService,
                                 IBusinessEntityAddressService businessEntityAddressService,
                                 IBusinessEntityContactService businessEntityContactService,
                                 IPhoneService phoneService,
                                 IAddressService addressService,
                                 IAddressTypeService addressTypeService,
                                 IPhoneTypeService phoneTypeService,
                                 IUnitOfWorkAsync unitOfWork)
        {
            this.employeeService = employeeService;
            this.unitOfWork = unitOfWork;
            this.addressService = addressService;
            this.personService = personService;
            this.businessEntityContactService = businessEntityContactService;
            this.businessEntityAddressService = businessEntityAddressService;
            this.personService = personService;
            this.phoneService = phoneService;
            this.addressTypeService= addressTypeService;
            this.phoneTypeService = phoneTypeService;
          
        }
        [HttpPost, Route("AddEmployee")]
        public IActionResult AddEmployee(BusinessEntity businessEntity)
        {
            try
            {
                employeeService.Add(businessEntity.Employee);
                personService.Add(businessEntity.Person);
                
                // businessEntityAddressService.AddRange(businessEntity.BusinessEntityAddresses);
                // businessEntityContactService.AddRange(businessEntity.BusinessEntityContacts);

                int res = unitOfWork.SaveChanges();
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
                employeeService.Update(Employee);
                int res = unitOfWork.SaveChanges();
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
                employeeService.Delete(id);
                int res = unitOfWork.SaveChanges();
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
            return Ok(employeeService.Queryable());
        }


    }
}