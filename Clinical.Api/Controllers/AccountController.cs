using Clinical.Api.Services.Interfaces;
using Clinical.Application.Extensions;
using Clinical.Application.Services.Interfaces;
using Clinical.Domain.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinical.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        #region Constructor
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        #endregion

        #region Login
        public async Task<IActionResult> PostLogin(LoginDTO model)
        {
            var result = await _userService.LoginAsync(model);

            switch (result)
            {
                case LoginResult.Success:
                    var user = await _userService.GetUserByPhoneNumberAsync(model.PhoneNumber);
                    return new JsonResult(new UserDTO()
                    {
                        //Avatar = null,
                        DisplayName = user.DisplayName,
                        Token = _tokenService.CreateToken(user),
                        UserName = user.UserName
                    });
                case LoginResult.Failure:
                    return Unauthorized();
                case LoginResult.UserNotFound:
                    return NotFound();
            }
            return Ok();
        }
        #endregion

        #region Register
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostRegister([FromBody]RegisterDto model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var result = await _userService.RegisterAsync(model);
            switch (result)
            {
                case RegisterResult.Success:
                    var user = await _userService.GetUserByPhoneNumberAsync(model.PhoneNumber);
                    return new JsonResult(new UserDTO()
                    {
                        //Avatar = null,
                        DisplayName = user.DisplayName,
                        Token = _tokenService.CreateToken(user),
                        UserName = user.UserName
                    });
                case RegisterResult.DuplicatedPhoneNumber:
                    return BadRequest("phone number exists");
                case RegisterResult.Error:
                    return BadRequest("Operation failed");
            }
            return BadRequest();
        }
        #endregion
        #region Get Current User
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userService.GetUserByIdAsync(User.GetUserId());
            return new JsonResult(new UserDTO()
            {
                //Avatar = ,
                DisplayName = user.DisplayName,
                UserName = user.UserName
            });
        }
        #endregion
    }
}
