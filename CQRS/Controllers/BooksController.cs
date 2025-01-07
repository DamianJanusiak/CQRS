using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CQRS.Data;
using Domain;
using MediatR;
using Aplication.Queries.GetBooks;
using Azure.Core;

namespace CQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<GetBooksQueryResponse> GetBooks([FromQuery]GetBooksQueryRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("[action]")]
        public async Task<GetBookByIdQueryResponse> GetById([FromQuery]GetBookByIdQueryRequest request)
        {
            return await _mediator.Send(request);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(AddBookCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("[action]")]
        public async Task<UpdateBookDetailsCommandResponse> Edit(UpdateBookDetailsCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromQuery]DeleteBookCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
