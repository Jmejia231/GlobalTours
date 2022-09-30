using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly IRepositorio<Lugar> _lugarRepo;
        private readonly IRepositorio<Pais> _paisRepo;
        private readonly IRepositorio<Categoria> _categoriaRepo;
        private readonly IMapper _mapper;
        
        public LugaresController(IRepositorio<Lugar> lugarRepo, IRepositorio<Pais> paisRepo, IRepositorio<Categoria> categoriaRepo, IMapper mapper)
        {
            _mapper = mapper;
            _categoriaRepo = categoriaRepo;
            _paisRepo = paisRepo;
            _lugarRepo = lugarRepo;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Lugar>>> GetLugares()
        {
            var espec = new LugaresConPaisCategoriaSpecification();
            var lugares = await _lugarRepo.ObtenerTodosEspec(espec);

            return Ok(_mapper.Map<IReadOnlyList<Lugar>, IReadOnlyList<LugarDto>>(lugares));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LugarDto>> GetLugar(int id)
        {
            var espec = new LugaresConPaisCategoriaSpecification(id);
            var lugar = await _lugarRepo.ObtenerEspec(espec);
            return _mapper.Map<Lugar, LugarDto>(lugar);
        }

        [HttpGet("paises")]
        public async Task<ActionResult<List<Pais>>> GetPaises()
        {
            return Ok(await _paisRepo.ObtenerTodosAsync());
        }
        
        [HttpGet("categorias")]
        public async Task<ActionResult<List<Pais>>> GetCategorias()
        {
            return Ok(await _categoriaRepo.ObtenerTodosAsync());
        }
    }
}