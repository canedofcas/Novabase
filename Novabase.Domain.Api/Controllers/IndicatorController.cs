using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Novabase.Domain.Entities;
using Novabase.Domain.Repositories;
using Novabase.Domain.Commands;
using Novabase.Domain.Commands.Indicator;
using Domain.Handlers;

namespace Novabase.Domain.Api.Controllers
{
    [Route("indicator")]
    [ApiController]
    public class IndicatorController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Indicator> GetAll([FromServices] IIndicatorRepository repository)
        {
            return repository.GetAll();
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateIndicatorCommand command, [FromServices] IndicatorHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }


    }
}
