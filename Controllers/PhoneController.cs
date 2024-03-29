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
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _PhoneService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private OperationResult operationResult = new OperationResult();
        public PhoneController(IPhoneService PhoneService, IUnitOfWorkAsync unitOfWork)
        {
            _PhoneService = PhoneService;
            _unitOfWork = unitOfWork;
          
        }
        [HttpPost, Route("AddPhone")]
        public async Task<IActionResult> AddPhone(Phone Phone)
        {
            try
            {
                _PhoneService.Add(Phone);
                int res =  await _unitOfWork.SaveChangesAsync();
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
        [HttpPost, Route("UpdatePhone")]
        public async Task<IActionResult> UpdatePhone(Phone Phone)
        {
            try
            {
                _PhoneService.Update(Phone);
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
        
        [HttpDelete, Route("DeletePhone")]
        public async Task<IActionResult> DeletePhone(int id)
        {
            try
            {
                _PhoneService.Delete(id);
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
        [HttpGet, Route("GetPhone")]
        public IActionResult GetPhone()
        {
            return Ok(_PhoneService.Queryable());
        }


    }
}