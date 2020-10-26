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
    [Route("api/")]
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
        public ActionResult<IEnumerable<RelationReadViewModel>> GetAllData()
        {
            try
            {
                var all = _relationService.GetAllRelations();
                var result = _mapper.Map<IEnumerable<RelationReadViewModel>>(all);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("add")]
        public ActionResult Add(RelationPostViewModel relationViewModel)
        {
            var relation = _mapper.Map<Relation>(relationViewModel);

            _relationService.CreateRelation(relation);

            return CreatedAtAction("CreatedRelation", new { id = relation.Id }, relation);
        }

        [HttpPut]
        public ActionResult EditRelation(RelationReadViewModel editRelation)
        {
            try
            {
                var relation = _mapper.Map<Relation>(editRelation);
                var relationAddress = _mapper.Map<RelationAddress>(editRelation);

                _relationService.UpdateRelation(relation);
                _relationService.UpdateAddress(relationAddress);
                

                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("countries")]
        public ActionResult GetCountries()
        {
            try
            {
                var countries = _relationService.GetAllCountries();
                var result = _mapper.Map<IEnumerable<CountryReadViewModel>>(countries);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
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

                return Ok(_mapper.Map<RelationReadViewModel>(relation));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
