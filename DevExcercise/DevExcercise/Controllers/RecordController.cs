using System;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevExcercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        protected IGlobalRepository Repository { get; }

        public RecordController(
            IGlobalRepository repository)
        {
            this.Repository = repository;
        }

        // GET: api/Record
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetRecords()
        {
            try
            {
                return this.Ok(this.Repository.GetRecords());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        // GET: api/Record
        [AllowAnonymous]
        [HttpGet("{recordId}")]
        public IActionResult GetRecord(int recordId)
        {
            try
            {
                return this.Ok(this.Repository.GetRecord(recordId));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        // POST: api/Record
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddRecord([FromBody] RecordData recordData)
        {
            try
            {
                this.Repository.InsertData(recordData);

                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
