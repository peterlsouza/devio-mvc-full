using Pet.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Business.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
