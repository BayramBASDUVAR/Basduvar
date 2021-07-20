using AutoMapper;
using Basduvar.API.DTOs;
using Basduvar.API.Filters;
using Basduvar.Core.Models;
using Basduvar.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basduvar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;
        public PersonsController(IService<Person> service,IMapper mapper)
        {
            _personService = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var newPerson = await _personService.AddAsync(_mapper.Map<Person>(personDto));
            return Created(string.Empty,_mapper.Map<PersonDto>(newPerson));
        }
        [HttpPut]
        public IActionResult Update(PersonDto personDto)
        {
            var person = _personService.Update(_mapper.Map<Person>(personDto));
            return NoContent();//Gereksiz veri trafiği olmasın.Best practice açısından bu şekilde olması gerekir
        }
    }
}
