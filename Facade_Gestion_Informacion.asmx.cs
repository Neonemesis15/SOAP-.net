using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Lucky.Data;
using Lucky.Data.Common.Application;
using Lucky.Business;
using Lucky.Business.Common.Application;
using Lucky.Entity.Common.Application;
using System.Web;
using System.Web.Services;
using Lucky.Entity;

namespace Facade_Planning
{
    /// <summary>
    /// Creado Por: Ing. Carlos Alberto Hernández Rincón
    /// Fecha: 11/11/2009
    /// Descripcion: Contiene los metodos necesarios para gestionar las consultas de infromacion gestionada en los Modulos Planning, Operativo, Supervisión
    /// Requerimientos<>
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Facade_Gestion_Informacion : System.Web.Services.WebService
    {
        //Instanciamos un objeto conexion
        Conexion oCoon = new Conexion();

        [WebMethod(Description = "Metodo para obtener Nivelss de Cliente Lucky")]
        public DataSet Get_Obtener_Niveles_Cliente(string snameuser, int icompany_id, string sperfilname) {
            DataSet dsnivel = null;
            dsnivel = oCoon.ejecutarDataSet("UP_WEBSIGE_GESTION_OBTENER_NIVELCLIENTE", snameuser, icompany_id, sperfilname);
            return dsnivel;
        
        
        
        
        }

        [WebMethod(Description = "Metodo  para Obtener lo tipos de informes")]
        public DataSet Get_Obtener_Tipo_Informes() {
            DataSet dsinfor = null;
            dsinfor = oCoon.ejecutarDataSet("UP_WEBSIGE_GESTION_OBTENERTYPEREPORT");
            return dsinfor;
        
        
        
        
        }
        [WebMethod(Description = "Metodo para Obtener loa Informes Asociados a los Tipos de Informes")]
        public DataSet Get_obtener_Informes(int itypeinforme, int icompanyid) {
            DataSet dsinfo = null;
            dsinfo = oCoon.ejecutarDataSet("UP_WEBSIGE_GESTION_OBTENER_INFORMES", itypeinforme, icompanyid);
            return dsinfo;
        
        
        
        
        
        }
     
       
    }
}
