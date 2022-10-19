using API.DTOs;
using API.Extensions;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] string username)
        {
            var gender = (await this._userManager.FindByNameAsync(username)).Gender;

            gender = gender == "male" ? "female" : "male";

            var users = await this._userManager.Users.Where(u => u.Gender == gender).ToListAsync();

            return Ok(users);
        }

        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await this._userManager.FindByNameAsync(username);

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {

            var user = await this._userManager.FindByNameAsync(User.GetUsername());

            _mapper.Map(memberUpdateDto, user);

            if ((await this._userManager.UpdateAsync(user)).Succeeded) return NoContent();

            return BadRequest("Failed to update user");
        }

    }
}