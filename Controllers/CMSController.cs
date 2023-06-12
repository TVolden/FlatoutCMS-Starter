using FlatoutCMS.Core;
using Microsoft.AspNetCore.Mvc;

namespace FlatoutCMS_Starter.Controllers
{
    public class CMSController : Controller
    {
        private readonly ModelRepository modelRepository;
        private readonly IConfiguration configuration;

        public CMSController(ModelRepository modelRepository, IConfiguration configuration)
        {
            this.modelRepository = modelRepository;
            this.configuration = configuration;
        }

        [Route("{*path}")]
        public IActionResult Index(string path)
        {
            IActionResult result = NotFound();

            var uri = string.IsNullOrWhiteSpace(path) ? configuration["DefaultPages"] : path;
            modelRepository.GetModel(uri).Apply(model =>
            {
                result = View(model.View, (dynamic)model);
            });

            return result;
        }
    }
}
