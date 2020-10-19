using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbFirstProj.Entities;
using DbFirstProj.Services.BusinessLogic;
using DbFirstProj.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly RelationService _relationService;
        private readonly IMapper _mapper;

        public HomeController(RelationService relationService, IMapper mapper)
        {
            this._relationService = relationService;
            this._mapper = mapper;
        }

        [HttpGet("relations")]
        public ActionResult<IEnumerable<RelationViewModel>> GetAllData()
        {
            try
            {
                var all = _relationService.GetAllRelations();

                return Ok(_mapper.Map<IEnumerable<RelationViewModel>>(all));
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost("add")]
        public ActionResult Add(/*RelationViewModel relationViewModel*/)
        {
            var newRel = new RelationViewModel
            {
                City = "Odessa",
                CountryName = "Ukraine",
                EMailAddress = "artur@gmail.com",
                FullName = "ARTUR G",
                Name = "ARTUR",
                Number = 168,
                PostalCode = "111244",
                Street = "Luzanovka",
                TelephoneNumber = "063311455994"
            };

            var relation = _mapper.Map<Relation>(newRel);
            var address = _mapper.Map<RelationAddress>(newRel);

            _relationService.CreateRelation(relation);
            _relationService.CreateAddress(address);

            return Ok(new List<object> { relation, address});
        }

        [HttpGet("countries")]
        public ActionResult GetCountries()
        {
            try
            {
                var countries = _relationService.GetAllCountries();

                return Ok(countries);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("types")]
        public ActionResult GetAddressTypes()
        {
            try
            {
                var types = _relationService.GetAllAdressTypes();

                return Ok(types);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRelation(string id)
        {
            try
            {
                var guidId = Guid.Parse(id);
                _relationService.DeleteRelation(guidId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRelation(string id)
        {
            try
            {
                var guidId = Guid.Parse(id);
                var relation = _relationService.GetRelation(guidId);

                return Ok(_mapper.Map<RelationViewModel>(relation));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
