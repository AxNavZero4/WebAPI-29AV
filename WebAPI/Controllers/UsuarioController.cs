using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.IServices;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usuarioServices.GetAll(); 

            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _usuarioServices.GetbyId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioRequest request)
        {
            var respose = await _usuarioServices.Create(request);
            return Ok(respose);
        }
        
       
    }
}
