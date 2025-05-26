﻿using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Context;
using WebAPI.Services.IServices;

namespace WebAPI.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> GetAll() //Trae la lista de usuarios
        {
            try
            {

                List<Usuario> response = await _context.Usuarios.Include(x=> x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response, "Lista de usuarios");

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<Usuario>> GetbyId(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                return new Response<Usuario>(usuario);
            }

            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<Usuario>> Create (UsuarioRequest request)
        {
            try
            {
                Usuario usuario1 = new Usuario()
                {
                    Nombre = request.Nombre,
                    Password = request.Password,
                    UserName = request.UserName,
                    FkRol = request.FkRol,
                };

                _context.Usuarios.Add(usuario1);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario1);
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
