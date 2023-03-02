using AutoMapper;
using Nectia.Application.DTO;
using Nectia.Application.Interface;
using Nectia.Domain.Entity;
using Nectia.Domain.Interface;
using Nectia.Transversal.Common;
using System;
using System.Collections.Generic;

namespace Nectia.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UsersApplication> _logger;

        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper, IAppLogger<UsersApplication> logger)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
            _logger = logger;
        }
        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parámetros no pueden ser vacios.";
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Insert(UsersDto userdto)
        {
            var response = new Response<bool>();
            try
            {
                var user = _mapper.Map<Users>(userdto);
                response.Data = _usersDomain.Insert(user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se registró Usuario de forma exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<IEnumerable<UsersDto>> GetAll()
        {
            var response = new Response<IEnumerable<UsersDto>>();
            try
            {
                var users = _usersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<UsersDto>>(users);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.LogInformation("Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
    }
}
