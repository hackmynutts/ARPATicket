using ARPATicket.API.DTO;
using ARPATicket.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ARPATicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userServices.GetAllUsers();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userServices.GetUserById(id);
            return user is not null ? Ok(user) : NotFound();
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserAddDTO newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _userServices.AddUser(newUser);
            return CreatedAtAction(nameof(GetById),
                new { id = createdUser.userID }, createdUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDTO updatedUser)
        {
            if (id != updatedUser.userID)
                return BadRequest("ID no coincide");

            var result = await _userServices.UpdateUser(updatedUser);
            return result is not null ? Ok(result) : NotFound();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userServices.DeleteUser(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}