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
        public ActionResult<IEnumerable<RelationReadViewModel>> GetRelations()
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
            try
            {
                var relation = _mapper.Map<Relation>(relationViewModel);
                var address = _mapper.Map<RelationAddress>(relationViewModel);

                relation.RelationAddresses.Add(address);

                _relationService.CreateRelation(relation);

                return Ok(relation);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public ActionResult EditRelation(RelationReadViewModel editRelation)
        {
            try
            {
                var relation = _mapper.Map<Relation>(editRelation);
                var relationAddress = _mapper.Map<RelationAddress>(editRelation);

                relation.RelationAddresses.Add(relationAddress);

                _relationService.UpdateRelation(relation);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("countries")]
        public ActionResult<IEnumerable<CountryReadViewModel>> GetCountries()
        {
            try
            {
                var countries = _relationService.GetAllCountries();
                var result = _mapper.Map<IEnumerable<CountryReadViewModel>>(countries);

                return Ok(result);
            }
            catch (Exception ex)
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            
        [HttpPut("{id}")]
        public ActionResult DeleteRelation(string id)
        {
            try
            {
                var guidId = Guid.Parse(id);
                _relationService.DeleteRelation(guidId);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("deleteCollection")]
        public ActionResult DeleteCollection(string[] relations)
        {
            try
            {
                _relationService.DeleteCollection(relations);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("relations/{category}/{isDesc}")]
        public ActionResult GetSortedRellations(string category, bool isDesc)
        {
            try
            {
                var all = _relationService.GetSortedRelations(category, isDesc);
                var result = _mapper.Map<IEnumerable<RelationReadViewModel>>(all);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("categories")]
        public ActionResult<IEnumerable<CategoryReadViewModel>> GetCategories()
        {
            try
            {
                var all = _relationService.GetAllCategories();
                var result = _mapper.Map<IEnumerable<CategoryReadViewModel>>(all);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("relations/{filterId}")]
        public ActionResult<IEnumerable<RelationReadViewModel>> GetFiltredRelations(string filterId)
        {
            try
            {
                if (filterId == "0")
                {
                    return RedirectToAction("GetRelations");
                }

                var guid = Guid.Parse(filterId);
                var all =_relationService.GetFiltredRelations(guid);
                var result = _mapper.Map<IEnumerable<RelationReadViewModel>>(all);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
