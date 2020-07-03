using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Extensions;

namespace AspNetCoreIdentity.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		//[Authorize]
		public IActionResult Privacy()
		{
			return View();
		}

		[Authorize(Roles = "Admin, Gestor")]
		public IActionResult Secret()
		{
			return View();
		}

		[Authorize(Policy = "PodeExcluir")]
		public IActionResult SecretClaim()
		{
			return View("Secret");
		}

		[Authorize(Policy = "PodeEscrever")]
		public IActionResult SecretClaimGravar()
		{
			return View("Secret");
		}


		[ClaimsAuthorize("Produtos", "Ler")]
		public IActionResult ClaimCustom()
		{
			return View("Secret");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
