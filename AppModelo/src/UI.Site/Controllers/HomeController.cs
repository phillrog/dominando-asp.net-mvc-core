using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UI.Site.Data;

namespace UI.Site.Controllers
{
    public class HomeController : Controller
    {
		//private readonly IPedidoRespository _pedidoRespository;

		//public HomeController(IPedidoRespository pedidoRepository)
		//{
		//	_pedidoRepository = pedidoRepository;
		//}
		public IActionResult Index([FromServices] IPedidoRespository _pedidoRespository )
        {
			var pedido = _pedidoRespository.ObeterPedido();

			return View(pedido);
        }
    }
}