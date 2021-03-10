using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.App.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-claim-name")] //1º parametro? div, a, href? TODO MUNDO. * //2º attributes: atributos usados na cshtml.. 
    [HtmlTargetElement("*", Attributes = "suppress-by-claim-value")]

    public class ApagaElementoByClaimTagHelper : TagHelper
    {
        //private readonly IHttpContextAccessor _contextAccessor;

        //public ApagaElementoByClaimTagHelper(IHttpContextAccessor contextAccessor)
        //{
        //    _contextAccessor = contextAccessor;
        //}

        //[HtmlAttributeName("suppress-by-claim-name")]
        //public string IdentityClaimName { get; set; }

        //[HtmlAttributeName("suppress-by-claim-value")]
        //public string IdentityClaimValue { get; set; }

        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    if (context == null)
        //        throw new ArgumentNullException(nameof(context));
        //    if (output == null)
        //        throw new ArgumentNullException(nameof(output));

        //    var temAcesso = CustomAuthorization.ValidarClaimsUsuario(_contextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

        //    if (temAcesso) return; //if true, return, nao faz nada

        //    output.SuppressOutput(); // nao vai ter output, nao vai gerar o elemento... 
        //}


    }
}
