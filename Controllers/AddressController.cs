using System.Threading.Tasks;
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
    [Authorize(AuthenticationSchemes = "Bearer")] // waring have to use this
    //[Authorize] This is not working
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private OperationResult operationResult = new OperationResult();
        public AddressController(IAddressService AddressService, IUnitOfWorkAsync unitOfWork)
        {
            _addressService = AddressService;
            _unitOfWork = unitOfWork;
          
        }
        [HttpPost, Route("AddAddress")]
        public async Task<IActionResult> AddAddress(Address Address)
        {
            try
            {
                _addressService.Add(Address);
                int res = await _unitOfWork.SaveChangesAsync();
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
        [HttpPost, Route("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(Address Address)
        {
            try
            {
                _addressService.Update(Address);
                int res =  await _unitOfWork.SaveChangesAsync();
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
        
        [HttpDelete, Route("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                _addressService.Delete(id);
               int res =  await _unitOfWork.SaveChangesAsync();
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
        [HttpGet, Route("GetAddress")]
        public IActionResult GetAddress()
        {
            return Ok(_addressService.Queryable());
        }


    }
}