using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Lucky.Data;
using Lucky.Data.Common.Application;
using Lucky.Entity.Common.Application;
using Lucky.Entity.Common.Application.Interfaces;
using System.Xml.Linq;

namespace Facade_Planning
{

    /// <summary>
    /// Descripción breve de Facade_Proceso_Supervisor
    /// Permite a los usuarios del módulo supervisor realizar consultas sencillas para las actividades de supervisión en SIGE
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    public class Facade_Proceso_Supervisor : System.Web.Services.WebService
    {


        [WebMethod(Description = "Método para verificar duplicidad de información en asignación de productos a operativo")]
        public DataTable Get_ProductoDuplicado(int iid_ProductsPlanning, int iPerson_id, int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_SUPERVISOR_DUPLICADOASIGNARPRODUCTOSAOPERATIVO", iid_ProductsPlanning, iPerson_id, iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método para consultar información en asignación de puntos de venta a operativo")]
        public DataTable Get_ConsultarAsignacionPDV(int iid_Planning, int iPerson_id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_SUPERVISOR_CONSULTAASIGNACIONPDVAOPERATIVO", iid_Planning, iPerson_id);
            return dt;
        }

        [WebMethod(Description = "Método para consultar información en asignación de productos a operativo")]
        public DataTable Get_ConsultarAsignacionPRODUCTO(int iid_Planning, int iPerson_id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_SUPERVISOR_CONSULTAASIGNACIONPRODUCTOSAOPERATIVO", iid_Planning, iPerson_id);
            return dt;
        }

        [WebMethod(Description = "Método Consultar registro de asignación de productos a personal operativo que tengan resultado en punto de venta para ventas")]
        public DataTable Get_ConsultarAsignacionPRODUCTOPDV_XINFORME(int iid_Report, int iid_Planning, int iPerson_id, int iid_MPOSPlanning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_SUPERVISOR_CONSULTAPRODUCTOSOPERATIVORESULTADOENPDV_XINFORME", iid_Report, iid_Planning, iPerson_id, iid_MPOSPlanning);
            return dt;
        }

        [WebMethod(Description = "Método Consultar la información de la actividad de comercio de un planning")]
        public DataTable Get_ConsultarInfoActividadComercio(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_SUPERVISOR_SEARCHINFOACTIVIDADCOMERCIOXPLANNING", iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método Consultar la fotos propias de un planning")]
        public DataTable Get_ConsultarInfoActividadPropia(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_SUPERVISOR_SEARCHINFOACTIVIDADPROPIAXPLANNING", iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método para verificar si un punto de venta esta asignado al menos una vez en un planning")]
        public DataTable Get_PuntoVentaAsignado(int iid_MPOSPlanning, int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_SUPERVISOR_PDVASIGNADO", iid_MPOSPlanning, iid_Planning);
            return dt;
        }
    }
}

