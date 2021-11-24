using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DagnysBageri.Interfaces;
using DagnysBageri.Models;
using DagnysBageri.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DagnysBageri.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost()]
        public async Task<IActionResult> AddUser(PostViewModel post)
        {
            User model = new User {
                FirstName = post.FirstName,
                LastName = post.LastName,
                Email = post.Email,
                Password = post.Password,
                Role = post.Role,
                CreatedDate = DateTime.UtcNow
            };

            if (await _unitOfWork.UserRepository.AddUserAsync(model))
                if (await _unitOfWork.Complete())
                return StatusCode(201, new ViewModel {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = model.Role,
                    CreatedDate = model.CreatedDate
                });

            return StatusCode(500, "Someting went wrong when trying to add a new user.");
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            IList<User> models = await _unitOfWork.UserRepository.ListAllUsersAsync();

            if (models == null) 
            {
                return NotFound("Could not find any users in the system.");
            }

            List<ViewModel> viewModels = new();

            foreach (var m in models)
            {
                viewModels.Add( new ViewModel() {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    Password = m.Password,
                    Role = m.Role,
                    CreatedDate = m.CreatedDate
                });
            }

            return Ok(viewModels);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] PutViewModel put)
        {
            User model =  await _unitOfWork.UserRepository.FindUserById(id);

            model.FirstName = put.FirstName;
            model.LastName = put.LastName;
            model.Email = put.Email;
            model.Password = put.Password;
            model.Role = put.Role;

            if (await _unitOfWork.UserRepository.UpdateUserAsync(model))
                if (await _unitOfWork.Complete()) 
                return NoContent();

            return StatusCode(500, $"Something went wrong when trying to update the details of user by id ({model.Id}).");

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] PatchViewModel patch)
        {
            User model =  await _unitOfWork.UserRepository.FindUserById(id);

            model.LastLogin = patch.LastLogin;

            if (await _unitOfWork.UserRepository.UpdateUserAsync(model))
                if (await _unitOfWork.Complete()) 
                return NoContent();

            return StatusCode(500, $"Something went wrong when trying to update the LastLogin of user by id ({model.Id}).");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            User model = await _unitOfWork.UserRepository.FindUserById(id);

            if (model == null)
            {
                return NotFound($"Could not find a user with an id of: {id}");
            }
            if (await _unitOfWork.UserRepository.RemoveUserAsync(model))
                if (await _unitOfWork.Complete())
                return NoContent();

            return StatusCode(500, "An error occured when trying to remove a user.");
        }
    }

    
}