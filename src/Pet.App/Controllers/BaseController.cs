using Microsoft.AspNetCore.Mvc;
using Pet.Business.Interface;

namespace Pet.App.Controllers
{
    public abstract class BaseController : Controller 
    {
        //TUDO que for em comum fazer aqui.. e as controllers herdarão de BaseController ao inves de apenas controller...

        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();//! se nao tem notificação.. deu bom!
        }
    }
}