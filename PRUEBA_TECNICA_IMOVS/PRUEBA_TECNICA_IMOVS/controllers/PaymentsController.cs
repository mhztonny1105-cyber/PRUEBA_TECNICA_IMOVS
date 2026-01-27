using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Responses;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/payments")]
    public class PaymentsController : ApiController
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        // GET api/payments/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IHttpActionResult GetById(Guid id)
        {
            try
            {
                var payment = _service.GetById(id);
                return Ok(ApiResponse<object>.Ok(payment));
            }
            catch (KeyNotFoundException ex)
            {
                return Content(HttpStatusCode.NotFound,
                    ApiResponse<string>.Fail(ex.Message));
            }
        }

        // GET api/payments/ticket/{ticketId}
        [HttpGet]
        [Route("ticket/{ticketId:guid}")]
        public IHttpActionResult GetByTicket(Guid ticketId)
        {
            var payments = _service.GetByTicket(ticketId);
            return Ok(ApiResponse<object>.Ok(payments));
        }

        // POST api/payments
        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] PaymentCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _service.Create(dto);

                return Content(HttpStatusCode.Created,
                    ApiResponse<string>.Ok(null, "Payment created"));
            }
            catch (KeyNotFoundException ex)
            {
                return Content(HttpStatusCode.NotFound,
                    ApiResponse<string>.Fail(ex.Message));
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError,
                    ApiResponse<string>.Fail("Unexpected error"));
            }
        }
    }
}
