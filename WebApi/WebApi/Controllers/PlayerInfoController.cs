using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Context;
using WebApi.Interfaces.Manager;
using WebApi.Manager;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")] 
    [ApiController]
    public class PlayerInfoController :BaseController
    {
        IPlayerManager _postPlayerManager;
      /*  ApplicationDbContext _dbContext;
        PostManager _postManager;*/
/*
        public PlayerInfoController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
            _postManager = new PostManager(dbContext);
        
        }
*/
        public PlayerInfoController(IPlayerManager postManager)
        {
            /*_dbContext = dbContext;
            _postManager = new PostManager(dbContext);*/
            _postPlayerManager = postManager;

        }
        //[Route("GetPlayerName")]
        [HttpGet]
        public IActionResult  GetPlayerName() 
        {
            try
            {
                //var players = _dbContext.playerDb.ToList();
                var players = _postPlayerManager.GetAll().ToList();
                return CustomResult("Data Loaded Successfully",players);
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
           
            
        }

        [HttpGet("Id")]
        public IActionResult GetPlayerById(int id) 
        {
            try
            {
                var players = _postPlayerManager.GetPlayerById(id);
                if (players == null)
                {
                    return CustomResult("Player Id not found", HttpStatusCode.NotFound);
                }

                return CustomResult("Data Found",players);

            }

            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        
        }
        [HttpPost]
        public IActionResult PostPlayerInfo(Player _Player) 
        {
           

            try
            {
                /* _dbContext.playerDb.Add(_Player);
                bool isSaved = _dbContext.SaveChanges() > 0;*/
                bool isSaved = _postPlayerManager.Add(_Player);

                if (isSaved)
                {
                    return CustomResult("player created",_Player);
                }
                return CustomResult("Saved Failed",HttpStatusCode.BadRequest);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

               
          
        }

        [HttpPut]
        public IActionResult UpdatePlayerInfo(Player _player) 
        {
            try 
            {
                if (_player.Id == 0)
                {
                    return CustomResult("Id not found", HttpStatusCode.BadRequest) ;
                }
                bool isUpdate = _postPlayerManager.Update(_player);
                if (isUpdate)
                {
                    return CustomResult("update successful", _player);
                }
                return CustomResult("player update failed", HttpStatusCode.BadRequest);

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpDelete("id")]
        public IActionResult DeletePlayerInfo(int id) 
        {
            try 
            {
                var player = _postPlayerManager.GetPlayerById(id);
                if (player == null)
                {
                    return CustomResult("Player Id not found", HttpStatusCode.NotFound);
                }
                bool isDelete = _postPlayerManager.Delete(player);

                if (isDelete)
                {
                    return CustomResult("player delete successfull");
                }
                return CustomResult("player delete failed", HttpStatusCode.BadRequest);

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            
            }
           
        }

        [HttpGet]
        public IActionResult GetAllPlayerInfoDesendingOrder() 
        {
            try
            {
                var player = _postPlayerManager.GetAll().OrderByDescending(x=>x.Id).ThenByDescending(c=>c.Name).ToList();
                return CustomResult("Data founnd successfully", player);

            }

            catch(Exception ex) 
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult GetPlayerByAbility(string ability) 
        {
            try
            {
                var abilityPlayer = _postPlayerManager.GetPlayerByAbility(ability);
                return CustomResult("Player data found", abilityPlayer.ToList());
            }

            catch (Exception ex) 
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult GetplayerByStringMatch(string text) 
        {
            try
            {
                var player=_postPlayerManager.GetPlayerByStringMatch(text);
                return CustomResult("Player match string found", player);
            }

            catch (Exception ex) 
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        
        }

        [HttpGet]
        public IActionResult GetPlayerDataInPage(int page=1) 
        {
            try
            {
                var player = _postPlayerManager.GetPlayerDataInPage(page, 2);
                return CustomResult("Player data found", player.ToList());

            }
            catch (Exception ex) 
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
