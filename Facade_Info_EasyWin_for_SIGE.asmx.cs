using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Lucky.Data;
using Lucky.Data.Common.Application;
using Lucky.Business;
using Lucky.Business.Common.Application;
using Lucky.Entity.Common.Application;
using Lucky.Entity.Common.Application.Interfaces;
using System.Web;
using System.Web.Services;
using Lucky.Entity;

namespace Facade_Planning
{
    /// <summary>
    /// Descripción breve de Facade_Info_EasyWin_for_SIGE
    /// Creado Por:Ing.Carlos Alberto Hernandez
    /// Fecha:05/03/2009
    /// Descripcion:Obtines Datos Generados a partir de la Interface Easywin-SIGE
    /// Reqerimiento<>
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Facade_Info_EasyWin_for_SIGE : System.Web.Services.WebService
    {
        Conexion oConn = new Conexion();

        /// <summary>
        /// Descripción  : Método para obtener los presupuestos sin asignación
        /// Módificación : 30/07/2010 Se cambia nombre al SP UP_WEB_INTERFACE_SEARCH_PRESUPUESTO por
        ///                UP_WEBXPLORA_INTERFACE_PRESUPUESTOSNOASIGNADOS de acuerdo a metricas establecidas.
        ///                Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="scountry"></param>
        /// <returns dt></returns>
        [WebMethod(Description = "Metodo Para Obtener los Presupuesto sin Asignar")]
        public DataTable Presupuesto(string scountry, int iCompany_id)
        {            
            DataTable dt = null;
            EPresupuesto oeiEasywin = new EPresupuesto();
            dt = oConn.ejecutarDataTable("UP_WEBXPLORA_INTERFACE_PRESUPUESTOSNOASIGNADOS", scountry, iCompany_id);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    oeiEasywin.Numberbudget = oeiEasywin.Numberbudget;
                    oeiEasywin.Numberbudget = dt.Rows[0]["Numero_Presupuesto"].ToString().Trim();
                    oeiEasywin.Namebudget = dt.Rows[0]["Nombre"].ToString().Trim();
                    oeiEasywin.Namebudget = dt.Rows[0]["name"].ToString().Trim();
                    oeiEasywin.Name_Country = dt.Rows[0]["Name_Country"].ToString().Trim();
                }
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creado por   : Carlos Hernández
        /// Descripción  : Método para Obtener los Presupustos Asignados
        /// Modificación : 05/08/2010 se cambia nombre al Store de acuerdo a nuevas metricas
        ///                establecidas [UP_WEB_INTERFACE_SEARCH_PRESUPUESTO_ASIGNADO] por
        ///                [UP_WEBXPLORA_PLA_SEARCHPRESUPUESTOSASIGNADOS]
        ///                y se quita parametro @TIPOBUSQUEDA ya que el budget_Lucky_History ya que no aplica
        ///                Ing. Mauricio Ortiz
        /// </summary>
        /// <returns dt></returns>
        [WebMethod(Description = "Metodo para Obtener los Presupustos Asignados")]
        public DataTable Presupuesto_Search(int iCompany_id)
        {            
            DataTable dt = null;
            EPresupuesto oeiEasywin = new EPresupuesto();
            dt = oConn.ejecutarDataTable("UP_WEBXPLORA_PLA_SEARCHPRESUPUESTOSASIGNADOS", iCompany_id);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    oeiEasywin.Numberbudget = oeiEasywin.Numberbudget;
                    oeiEasywin.Numberbudget = dt.Rows[0]["Numero_Presupuesto"].ToString().Trim();
                    oeiEasywin.Namebudget = dt.Rows[0]["Nombre"].ToString().Trim();
                    oeiEasywin.Namebudget = dt.Rows[0]["name"].ToString().Trim();
                }
                return dt;
            }
            else
            {
                return null;
            }
        }
        [WebMethod(Description = "Metodo para obtener Presupuestos para Actualizar")]
        public DataTable Get_Obtener_Presupuestos_Update(string snamepresu)
        {            
            DataTable dtpup = null;
            dtpup = oConn.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENER_PRESUPUESTOSNEW", snamepresu);
            return dtpup;



        }

        [WebMethod(Description = "Obtine el Nombre del Planning")]

        public DataTable Get_NamePlanning(string snumbrerpresupuesto)
        {
            
            DataTable dt = null;
            dt = oConn.ejecutarDataTable("UP_WEBSIGE_INTERFACE_EASYWINSIGE_LLENANAMEPRESUPUESTO", snumbrerpresupuesto);
            return dt;


        }
        [WebMethod(Description = "Metodo para Obtener Fechas Planning")]
        public DataTable Get_OtenerFechasPlanning(string snumberpresupuesto, int ivalor)
        {
            
            DataTable dt = null;

            dt = oConn.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERFECHASPLANNING", snumberpresupuesto, ivalor);
            return dt;





        }




        [WebMethod]
        public DataTable Get_ObtenerClientes(string snumberpresupuesto, int ivalor)
        {
            
            DataTable dt = null;
            EPresupuesto oeiEasywin = new EPresupuesto();

            dt = oConn.ejecutarDataTable("UP_WEB_INTERFACE_EASYWIN_SIGE_LLENARCOMBOS", snumberpresupuesto, ivalor);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {

                    oeiEasywin.Companyid = Convert.ToInt32(dt.Rows[i]["Company_id"].ToString().Trim());
                    oeiEasywin.namecompany = dt.Rows[i]["Company_Name"].ToString().Trim();



                }
                return dt;
            }
            else
            {

                return null;


            }
        }

        [WebMethod(Description = "Metodo para generar listado de Personal de calle asignado a una campaña")]
        public DataTable Get_ObtenerPersonalcalle(string snumberpresupuesto, int ivalor)
        {
            
            DataTable dt = null;
            EPresupuesto oeiEasywin = new EPresupuesto();

            dt = oConn.ejecutarDataTable("UP_WEB_INTERFACE_EASYWIN_SIGE_LLENARCOMBOS", snumberpresupuesto, ivalor);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {

                    oeiEasywin.Personid = Convert.ToInt32(dt.Rows[i]["Person_id"].ToString().Trim());
                    oeiEasywin.name = dt.Rows[i]["Nombres"].ToString().Trim();



                }
                return dt;
            }
            else
            {

                return null;


            }


        }

        [WebMethod]
        public DataTable Get_ObtenerSupervisores(string snumberpresupuesto, int ivalor)
        {
            
            DataTable dt = null;
            EPresupuesto oeiEasywin = new EPresupuesto();

            dt = oConn.ejecutarDataTable("UP_WEB_INTERFACE_EASYWIN_SIGE_LLENARCOMBOS", snumberpresupuesto, ivalor);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {

                    oeiEasywin.Personid = Convert.ToInt32(dt.Rows[i]["Person_id"].ToString().Trim());
                    oeiEasywin.name = dt.Rows[i]["Nombres"].ToString().Trim();



                }
                return dt;
            }
            else
            {

                return null;


            }
        }
    }
}

