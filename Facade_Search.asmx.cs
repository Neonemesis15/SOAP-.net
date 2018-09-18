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
    /// Descripción breve de Facade_Search
    /// Creada Por: Ing.Carlos Alberto Hernandez
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Facade_Search : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable Search_User(string sPersonnd,int iPerosnid)
        {
            Conexion oConn = new Conexion();
            DataTable dt = null;
             dt = oConn.ejecutarDataTable("UP_WEB_SEARCH_USER", sPersonnd, iPerosnid);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    EUsuario osUsuario = new EUsuario();
                    osUsuario.Personnd = sPersonnd;
                    osUsuario.Personid = iPerosnid;
                    osUsuario.Personid = Convert.ToInt32(dt.Rows[i]["Person_id"].ToString().Trim());
                    osUsuario.idtypeDocument = dt.Rows[i]["id_typeDocument"].ToString().Trim();
                    osUsuario.Personnd = dt.Rows[i]["Person_nd"].ToString().Trim();
                    osUsuario.PersonFirtsname = dt.Rows[i]["Person_Firtsname"].ToString().Trim();
                    osUsuario.PersonLastName = dt.Rows[i]["Person_LastName"].ToString().Trim();
                    osUsuario.PersonSurname = dt.Rows[i]["Person_Surname"].ToString().Trim();
                    osUsuario.PersonSeconName = dt.Rows[i]["Person_SeconName"].ToString().Trim();
                    osUsuario.PersonEmail = dt.Rows[i]["Person_Email"].ToString().Trim();
                    osUsuario.PersonPhone = dt.Rows[i]["Person_Phone"].ToString().Trim();
                    osUsuario.PersonAddres = dt.Rows[i]["Person_Addres"].ToString().Trim();
                    osUsuario.codCountry = dt.Rows[i]["cod_Country"].ToString().Trim();
                    osUsuario.nameuser = dt.Rows[i]["name_user"].ToString().Trim();
                    osUsuario.UserPassword = dt.Rows[i]["User_Password"].ToString().Trim();
                    osUsuario.Perfilid = dt.Rows[i]["Perfil_id"].ToString().Trim();
                    osUsuario.Moduloid = dt.Rows[i]["Modulo_id"].ToString().Trim();
                    osUsuario.UserRecall = dt.Rows[i]["User_Recall"].ToString().Trim();
                    osUsuario.companyid = dt.Rows[i]["Company_id"].ToString().Trim();
                    osUsuario.PersonStatus = Convert.ToBoolean(dt.Rows[i]["Person_Status"].ToString().Trim());



                }
                return dt;




            }
            else
            {
                return null;
            }




        }
        [WebMethod(Description = "esto es prueba")]

        public DataSet Get_Obtener_User(string spersonnd, int ipersonid) {
            Conexion oCoon = new Conexion();
            DataSet ds = oCoon.ejecutarDataSet("UP_WEB_SEARCH_USER", spersonnd, ipersonid);
            return ds;
        
        
        }


        [WebMethod(Description = "Llena  Combo de busqueda de presupuesto en Planning")]

        public DataSet Get_ObtenerPresupuestoSearch(string scodcountry) { 
         Conexion oCoon= new Conexion();

         DataSet ds = oCoon.ejecutarDataSet("UP_WEBSIGE_LLENAPRESUPUESTOSEARCH", scodcountry);
         return ds;
        
        
        
        }
    }
}
