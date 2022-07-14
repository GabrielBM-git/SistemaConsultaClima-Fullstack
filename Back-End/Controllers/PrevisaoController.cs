//-------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Back_End.Data;
using Back_End.Models;

//-------------------------------------------------------------------------------------------------

namespace Back_End.Controllers
{
    //---------------------------------------------------------------------------------------------

    [ApiController]
    [Route("api/[controller]")]
    public class SistemaController : ControllerBase
    {
        //-----------------------------------------------------------------------------------------

        private readonly IRepository _repository;

        public SistemaController(IRepository repository)
        {
            this._repository = repository;
        }

        //-----------------------------------------------------------------------------------------

        [HttpGet("PrevisaoClima_Minimas")]
        public async Task<IActionResult> Get_Minimas()
        {
            IList<PrevisaoClima> objeto = null;

            try
            {
                objeto = await _repository.Get_Minimas();
            }
            catch (Exception err)
            {
                return BadRequest("{ \"erro\": \"" + err.Message + "\" }"); // 400
            }

            return Ok(objeto); // 200
        }

        [HttpGet("PrevisaoClima_Maximas")]
        public async Task<IActionResult> Get_Maximas()
        {
            IList<PrevisaoClima> objeto = null;

            try
            {
                objeto = await _repository.Get_Maximas();
            }
            catch (Exception err)
            {
                return BadRequest("{ \"erro\": \"" + err.Message + "\" }"); // 400
            }
                    
            return Ok(objeto); // 200
        }

        //-----------------------------------------------------------------------------------------

        [HttpGet("PrevisaoClima_Cidades")]
        public async Task<IActionResult> Get_Cidades()
        {
            IList<Cidade> objeto = null;

            try
            {
                objeto = await _repository.Get_Cidades();
            }
            catch (Exception err)
            {
                return BadRequest("{ \"erro\": \"" + err.Message + "\" }"); // 400
            }
                    
            return Ok(objeto); // 200
        }

        [HttpGet("PrevisaoClima_7Dias/{cidade}")]
        public async Task<IActionResult> Get_7Dias(string cidade)
        {
            IList<PrevisaoClima> objeto = null;

            try
            {
                objeto = await _repository.Get_7Dias(cidade);
            }
            catch (Exception err)
            {
                return BadRequest("{ \"erro\": \"" + err.Message + "\" }"); // 400
            }
                    
            return Ok(objeto); // 200
        }

        //-----------------------------------------------------------------------------------------
    }

    //---------------------------------------------------------------------------------------------
}

//-------------------------------------------------------------------------------------------------