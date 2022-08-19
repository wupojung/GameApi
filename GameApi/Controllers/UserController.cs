using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApi.Models;
using GameApi.Services;
using Microsoft.Extensions.Logging;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly UserService _userService;
        public UserController(ILogger<UserController> logger, MyContext dbContext)
        {
            _logger = logger;
            _userService = new UserService(dbContext);
        }

        [HttpPost]
        [Route("")]
        public async Task<bool> Insert(Account account)
        {
            return await _userService.InsertAsync(account);
        }


        [HttpGet]
        [Route("")]
        public async Task<IList<Account>> Index()
        {
            return await _userService.ListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Account> Get(int id)
        {
            return await _userService.GetByIdAsync(id);
        }


        [HttpPut]
        [Route("{id?}")]
        public async Task<bool> Update(Account account, int id = 0)
        {
            if (id != 0)   //表示系統主動告知要修改的id 
            {
                account.id = id; 
            }

            //TODO:需要檢查商業邏輯,此DEMO 略過


            return await _userService.UpdateAsync(account);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _userService.DeleteAsync(id);
        }
    }
}
