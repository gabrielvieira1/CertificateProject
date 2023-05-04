using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CertificateProject.CertificateConfiguration
{
    public class Certificate
    {
        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected(HttpContext context)
        {
            if (context.Connection.ClientCertificate == null)
            {
                throw new InvalidOperationException("Certificado digital do cliente não encontrado.");
            }

            // Valide o certificado digital aqui...

            return new JsonResult(new
            {
                Message = "Este é um recurso protegido"
            });
        }
    }
}
