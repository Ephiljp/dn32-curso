using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.WPF
{
    public static class Utilitarios
    {
        public static void EnviarEmail(string destinatario, string titulo, string messagem)
        {

            var emailDeOrigem = "felipehideo@hotmail.com";
            var servidorSMTP = "in-v3.mailjet.com";
            var portaSMTP = 587;
            var usuarioSMTP = "2d60cd70ddf3035bba09ed23c3bdfcad";
            var senhaSMTP = "c9a58aefda30a79dec88ad2cf270e542";

            var smtp = new SmtpClient();
            smtp.Host = servidorSMTP;
            smtp.Port = portaSMTP;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(usuarioSMTP, senhaSMTP);

            var msg = new MailMessage();
            msg.To.Add(destinatario);
            msg.Subject = titulo;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(emailDeOrigem);
            msg.ReplyToList.Add(emailDeOrigem);
            msg.Body = messagem;

            smtp.Send(msg);

        }

    }
}
