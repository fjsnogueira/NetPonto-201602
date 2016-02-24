namespace NetPontoSec.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks; 

    using Microsoft.AspNet.Authorization; 
    using Microsoft.AspNet.Mvc;

    using NetPontoSec.Authorization;
    using NetPontoSec.Models;
    using NetPontoSec.Repository;

    public class HomeController : Controller
    {
        private readonly IPostRepository postRepository;

        private readonly IAuthorizationService authorizationService;

        public HomeController(IPostRepository postRepository, IAuthorizationService authorizationService)
        {
            this.postRepository = postRepository;
            this.authorizationService = authorizationService;
        }
         
        public IActionResult Index()
        {
            var posts = this.postRepository.GetAll(); 
            return this.View(posts);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var post = this.postRepository.Find(x => x.Id == id);

            post.Visits++;

            return this.View(post);
        }

        [Authorize(Policy = "NoPhpees")]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Policy = "NoPhpees")]
        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var nameIdentifier = this.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier));
                if (nameIdentifier != null)
                {
                    model.AuthorId = int.Parse(nameIdentifier.Value);
                }

                model.AuthorName = this.User.Identity.Name;
            }
            else
            {
                model.AuthorId = -1;
                model.AuthorName = "Anonymous";
            }
            model.Id = 1 + this.postRepository.GetAll().Count();
            this.postRepository.Add(model);

            return this.RedirectToAction("index");
        }
         
        public async  Task<IActionResult> Edit(int id)
        {
            var model = this.postRepository.Find(x => x.Id == id);

            if (!await this.authorizationService.AuthorizeAsync(User, model, NetPontoOpps.Edit))
            {
                return new ChallengeResult();
            }

            if (model == null)
            {
                return this.HttpNotFound();
            }

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Post model)
        {
            var act = this.postRepository.Find(x => x.Id == model.Id);

            act.Abstract = model.Abstract;
            act.AuthorId = model.AuthorId == 0 ? act.AuthorId : model.AuthorId;
            act.AuthorName = string.IsNullOrEmpty(model.AuthorName) ? act.AuthorName : model.AuthorName;
            act.Body = model.Body;
            act.Title = model.Title;
            act.Visits = model.Visits == 0 ? act.Visits : model.Visits;

            return this.RedirectToAction("index");
        }

        public IActionResult Error()
        {
            return this.View();
        }
    }
}
