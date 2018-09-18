using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SIGE.Pages.Modulos.Planning
{
    /// <summary>
    /// Descripción breve de PageLoader
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
     //Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class PageLoader : System.Web.Services.WebService
    {

        [WebMethod] 

    public string LoadPage(string pageName) 

    { 

        return @"<iframe frameborder='0' 

                         scrolling='no' 

                         marginheight='0' 

                         marginwidth='0' 

                         height='200px' 

                         width='200px' id='frame' src='" + pageName + "' runat='server'></iframe>"; 

    } 


    }
}
