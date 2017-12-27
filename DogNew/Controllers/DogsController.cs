using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogRepo.Repository;
using DogNew.api;

namespace DogNew.Controllers
{
    [Route("api/[controller]")]
    public class DogsController : Controller
    {
        private readonly DogRepository Dogz;
        public DogsController()
        {
            Dogz = new DogRepository();
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<DogModel>> Get() => await Dogz.loadBothAsync();
        


      
      
    }
}
