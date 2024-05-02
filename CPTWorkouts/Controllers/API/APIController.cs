using CPTWorkouts.Controllers;
using CPTWorkouts.Data;
using CPTWorkouts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPTWorkouts.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        public CPTWorkoutsContext _context;

        public UserManager<IdentityUser> _userManager;

        public SignInManager<IdentityUser> _signInManager;

        public AulasController(CPTWorkoutsContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var listaDb = _context.Users.ToList();
            var listaRes = new List<UsersDTO>();

            foreach (var user in listaDb)
            {
                UsersDTO coldto = new UsersDTO();
                coldto.Nome = user.Nome;

                listaRes.Add(coldto);
            }

            return Ok(listaRes);
        }

        [HttpPost]
        [Route("insereUser")]
        public ActionResult InsereColecao([FromBody] UsersDTO dto)
        {
            Users colecao = new Users();
            colecao.Nome = dto.Nome;
            colecao.Password = dto.Password;

            _context.Users.Add(colecao);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("editUser")]
        public ActionResult EditColecao([FromBody] UsersDTO dto, [FromQuery] int id)
        {
            Users colecao = _context.Users.Where(c => c.ID == id).FirstOrDefault();

            colecao.Nome = dto.Nome;
            colecao.Password = dto.Password;

            _context.Users.Update(colecao);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("signInUser")]
        public async Task<ActionResult> CreateUserAsync(string email, string pass)
        {

            try
            {
                IdentityUser user = _userManager.FindByEmailAsync(email).Result;
                if (user != null)
                {
                    PasswordVerificationResult result = new PasswordHasher<IdentityUser>().VerifyHashedPassword(null, user.PasswordHash, pass);
                    if(result.Equals(PasswordVerificationResult.Success)){
                        await _signInManager.SignInAsync(user, false);

                    }
                }
            }
            catch
            {

            }

            return Ok();

        }

        [HttpGet]
        [Route("createUser")]
        public ActionResult CreateUser()
        {
            try
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "alcobiadias@gmail.com";
                identityUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "qsc23FTP%/");
                identityUser.Email = "alcobiadias@gmail.com";
                identityUser.NormalizedEmail = identityUser.UserName.ToUpper();
                identityUser.NormalizedUserName = identityUser.UserName.ToUpper();
                identityUser.Id = Guid.NewGuid().ToString();
                identityUser.NormalizedEmail = "alcobiadias@gmail.com";

                _userManager.CreateAsync(identityUser);
                //_context.SaveChanges();

            }
            catch (Exception e)
            {

            }
            return Ok("ola");
        }

        [Authorize]
        [Route("ola")]
        public ActionResult Ola([FromQuery] string nome, [FromQuery] string turma)
        {
            //User.Identity.Name
            if (turma != "A" && turma != "B" && turma != "C")
                return BadRequest();

            return Ok("Olá " + nome + " da turma " + turma + "!");
        }

        [HttpPost]
        [Route("sendFile")]
        public ActionResult SendFile([FromForm] EquipasController test)
        {
            if (test == null) { return BadRequest(); }
            return Ok();

        }
    }
}