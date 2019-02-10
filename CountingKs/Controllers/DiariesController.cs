using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CountingKs.Data;
using System.Threading;
using CountingKs.Services;

namespace CountingKs.Controllers
{
    public class DiariesController : BaseApiController
    {
        private ICountingKsIdentityService _identityService;

        public DiariesController(ICountingKsRepository repo,ICountingKsIdentityService IdentityService) : base(repo)
        {
            _identityService = IdentityService;
        }

        public object Get()
        {
            //var userName = Thread.CurrentPrincipal.Identity.Name;
            var userName = _identityService.CurrentUser;
            var results = TheRepository.GetDiaries(userName)
                .OrderByDescending(d => d.CurrentDate)
                .Take(10)
                .ToList()
                .Select(d => TheModelFactory.Create(d));

            return new object();
        }
    }
}
