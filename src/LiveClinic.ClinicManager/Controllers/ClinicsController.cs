using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Common;
using LiveClinic.ClinicManager.Core.Application.Services;
using LiveClinic.ClinicManager.Core.Domain.Facility;
using LiveClinic.ClinicManager.Core.Domain.Facility.Dto;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LiveClinic.ClinicManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicsController : ControllerBase
    {
        private readonly IClinicService _clinicService;

        public ClinicsController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var loadClinic =await  _clinicService.Load();
                return this.ServeResult(loadClinic,"Clinic has not been setup");
            }
            catch (Exception e)
            {
                return this.ServeError(e,"Load Clinic Error");
            }
        }
        
        [HttpPost("Setup")]
        public async Task<IActionResult> Setup(ClinicDto clinicDto)
        {
            try
            {
                var clinic = clinicDto.Create();
                var loadClinic =await  _clinicService.SetupClinic(clinic);
                return this.ServeResultStatus(loadClinic);
            }
            catch (Exception e)
            {
                return this.ServeError(e,"Load Clinic Error");
            }
        }
        
        [HttpPost("Change")]
        public async Task<IActionResult> ChangeDetails(ClinicDto clinicDto)
        {
            try
            {
                var loadClinic = await _clinicService.ChangeClinicDetails(
                    clinicDto.Id, 
                    clinicDto.Name,
                    clinicDto.Street, 
                    clinicDto.City
                    );
                return this.ServeResultStatus(loadClinic);
            }
            catch (Exception e)
            {
                return this.ServeError(e,"Load Clinic Error");
            }
        }
        
        [HttpPost("ChangeFee")]
        public async Task<IActionResult> FeeUpdate(ClinicDto clinicDto)
        {
            try
            {
                var loadClinic = await _clinicService.AdjustServiceFee(
                    clinicDto.Id, 
                    clinicDto.Amount,
                    clinicDto.Currency
                );
                return this.ServeResultStatus(loadClinic);
            }
            catch (Exception e)
            {
                return this.ServeError(e,"Load Clinic Error");
            }
        }
   }
}