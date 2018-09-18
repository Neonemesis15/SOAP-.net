using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Lucky.Data;
using Lucky.Data.Common.Application;
using Lucky.Entity.Common.Application;
using Lucky.Entity.Common.Application.Interfaces;
using System.Web.Services;using Lucky.Business;
using Lucky.Business.Common.Application;

namespace Facade_Planning
{
    /// <summary>f
    /// Descfripción : Este WS permite interactuar de manera directa con todas las
    /// operaciones que se involucran en el proceso de creación , edición, consulta y actualización
    /// en el módulo planning
    /// </summary>    

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    public class Facade_Proceso_Planning : System.Web.Services.WebService
    {
        Conexion oCoon = new Conexion();

        /// <summary>
        /// Obtener Planning creados
        /// Ing. Mauricio Ortiz 14 de julio de 2010
        /// Modificación : Se cambia parametro int por string . 05/08/2010 Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <returns ds></returns>
        [WebMethod(Description = "Método para obtener los planning creados")]
        public DataSet Get_PlanningCreados(string sid_planning)
        {
            DataSet ds = oCoon.ejecutarDataSet("UP_WEBSIGE_PLANNIG_CREADOS", sid_planning);
            return ds;
        }

        /// <summary>
        /// Obtine los Clientes de Lucky
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para Obtener Clientes Lucky")]
        public DataTable Get_ObtenerClientes()
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEB_SIGE_OBTENER_CLIENTES");
            return dt;
        }

        [WebMethod(Description = "Metodo para obtener Canales")]
        public DataTable Get_ObtenerCanales()
        {
            DataTable dt = null;
            dt = oCoon.ejecutarDataTable("UP_WEB_LLENACOMBOS", 9);
            return dt;
        }
        //@PACHO

        [WebMethod(Description = "Metodo para llenar Marcas")]
        public DataTable Get_ObtenerMarcas(int iidcategory, int company_id)
        {

            DataTable dtmarca = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERMARCASXCATEGORIAS", iidcategory, company_id);
            return dtmarca;
        }

        /// <summary>
        /// Método para obtener marca y sbmarca de un producto seleccionado
        /// Modificación : 31/08/2010 se cambia tipo de dato del parametro de int a long. Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="lid_product"></param>
        /// <returns>dtProduct</returns>
        [WebMethod(Description = "Método para obtener marca y sbmarca de un producto seleccionado")]
        public DataTable Get_Obtener_BrandySubbrandxProducto(long lid_product)
        {
            DataTable dtProduct = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_SEARCH_BRAND_Y_SUBBRAND_PRODUCT", lid_product);
            return dtProduct;
        }

        /// <summary>
        /// Método para obtener productos a partir de una categoria y un cliente        /// 
        /// </summary>
        /// <param name="scategory"></param>
        /// <param name="icompany_id"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para obtener productos a partir de una categoria y un cliente")]
        public DataTable Get_Obtener_ProductosxCategoria(string scategory, int icompany_id)
        {
            DataTable dtProd = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_PRODUCTOS_CATEGORIAS", scategory, icompany_id);
            return dtProd;
        }

        //@PACHO Se agrega la variable COMPANY_ID
        [WebMethod(Description = "Metodo para Obtener Productos con Marcas NEW")]
        public DataTable Get_Obtener_ProductosxMarcas(int imarca, int compañia_id)
        {

            DataTable dtpmar = null;
            dtpmar = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_PRODUCTOS_MARCAS", imarca, compañia_id);
            return dtpmar;
        }

        /// <summary>
        /// Metodo para LLenar Subnmarcas de una Marca
        /// Módificacion :  30/08/2010 Adición de parametros de acuerdo a cambio realizado al store 
        ///                 se modifica consulta debido a cambio estructural de
        ///                 productos (ya no aplica Product_Tipo) todos la estructura se encuentra 
        ///                 en la tabla products para mejorar performance en las consultas 
        ///                 Ing. Mauricio Ortiz         
        /// </summary>
        /// <param name="sid_ProductCategory"></param>
        /// <param name="idmarca"></param>
        /// <param name="iCompany_id"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para LLenar Subnmarcas de una Marca")]
        public DataTable Get_ObtenerSubMarcas(string sid_ProductCategory, int idmarca, int iCompany_id)
        {
            DataTable dtmsmarca = oCoon.ejecutarDataTable("UP_WEBSIGE_OBTENERSUBMARCA", sid_ProductCategory, idmarca, iCompany_id);
            return dtmsmarca;
        }


        /// <summary>
        /// Metodo para obtener las submarcas de una marca seleccionada, para las familias del planning
        /// Ing. Mauricio Ortiz
        /// 22/03/2011
        /// </summary>
        /// <param name="sid_ProductCategory"></param>
        /// <param name="idmarca"></param>
        /// <param name="iCompany_id"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para LLenar Submarcas de una Marca para las familias del planning ")]
        public DataTable Get_ObtenerSubMarcas_Family(string sid_ProductCategory, int idmarca, int iCompany_id)
        {
            DataTable dtmsmarca = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_OBTENERSUBMARCASFAMILY", sid_ProductCategory, idmarca, iCompany_id);
            return dtmsmarca;
        }

        [WebMethod(Description = "Metodo para Obtener Productos de una Marca")]
        public DataTable Get_ObtenerProductos(int idmarca, string idsmarca, string ivalor)
        {

            DataTable dt = null;
            EProductos oeproducto = new EProductos();

            dt = oCoon.ejecutarDataTable("UP_WEBSIGE_LLENACOMBOPRODUCTOS", idmarca, idsmarca, ivalor);
            if (dt != null)
            {

                if (dt.Rows.Count > 0)
                {
                    oeproducto.id_Product = Convert.ToInt32(dt.Rows[0]["id_Product"].ToString().Trim());
                    oeproducto.Product_Name = dt.Rows[0]["name_product"].ToString().Trim();



                }
                return dt;
            }
            else
            {

                return null;

            }
        }

        [WebMethod(Description = "Metodo para obtener Presentaciones Planning")]
        public DataTable Get_ObtenerPresentaPlanning(int iidplanning)
        {

            DataTable dtprepla = null;
            dtprepla = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERPRESENTACIONESPLANNING", iidplanning);
            return dtprepla;



        }

        [WebMethod(Description = "Metodo para obtener Presentaciones de la Competencia")]
        public DataTable Get_ObtenerPresentaCompetencia(string sproduct, int iidplanning)
        {

            DataTable dtprocompe = null;
            dtprocompe = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTERCOMPETIDORESPLANNING", sproduct, iidplanning);
            return dtprocompe;



        }

        //@PACHO
        [WebMethod(Description = "Metodo para obtener Productos por Submarca NEW")]
        public DataTable Get_ObtenerProductosxSubmarca(string isubmarca, int Company_id)
        {

            DataTable dtprosubmarca = oCoon.ejecutarDataTable("UP_WEBSIGE-PLANNING_OBTENERPRODUCTOSSUBMARCA", isubmarca, Company_id);
            return dtprosubmarca;




        }

        [WebMethod(Description = "Metodo para Obtener los Tipos de Agrupacion Comercial")]
        public DataTable Get_Obtener_Tipos_Agrupacion()
        {

            DataTable dtagru = oCoon.ejecutarDataTable("UP_WEB_LLENACOMBOS", 28);
            return dtagru;



        }

        [WebMethod(Description = "Metodo para Obtener los Nombre de Agrupacion Comercial")]
        public DataTable Get_Obtener_Nombres_Agrupacion(int idtypecome)
        {

            DataTable dtnamecome = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERNOMBREAGRUCOMERCIAL", idtypecome);
            return dtnamecome;


        }

        [WebMethod(Description = "Metodo para Obtener PDV")]
        public DataTable Get_Obtener_PDV(string scountry, int inamecomercial)
        {

            DataTable dtpdv = null;
            dtpdv = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_PDV", scountry, inamecomercial);
            return dtpdv;



        }

        [WebMethod(Description = "Metodo Para Obtener Planning para Presupuestos actualizados por Intreface")]
        public DataTable Get_ObtnerPlanningxPrespuestos()
        {

            DataTable dtpla = null;
            dtpla = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERPRESUPUESTOSSINPLANNING");
            return dtpla;




        }

        [WebMethod(Description = "Metodo para Determinar si el Supervisor se le han asignado operativos en la Construcción de Planning")]
        public DataTable Get_Count_OperaxSupervi(string snameuser, int ipersonidsupe)
        {

            DataTable dtopxsupe = null;
            dtopxsupe = oCoon.ejecutarDataTable("UP_WEBSIGE_PALNNING_VALIDARCANTIDADOPERAXSUPE", snameuser, ipersonidsupe);
            return dtopxsupe;




        }

        [WebMethod(Description = "Metodo para Obtener Ciudades de PDV en planning")]
        public DataSet Get_Obtener_Ciudades(string scoountry)
        {

            DataSet ds = null;
            ds = oCoon.ejecutarDataSet("UP_WEBSIGE_LLENARCOMBOCITYPLA", scoountry);
            return ds;



        }

        [WebMethod(Description = "Metodo para Obtener Ciudad Principal")]
        public DataTable Get_Obtener_Ciudad_Principal(int idplanning)
        {

            DataTable dtcity = null;
            dtcity = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERCITYPRINCIPAL", idplanning);
            return dtcity;
        }

        [WebMethod(Description = "Metodo para Obtener las Cadenas usadas en Planning")]
        public DataSet Get_CadenasPlannig()
        {

            DataSet ds = null;
            ds = oCoon.ejecutarDataSet("UP_LLENARCADENASPLANNING");
            return ds;


        }

        [WebMethod(Description = "Metodo para obtener los PDV elistados en Planning")]
        public DataSet Get_ObtenerPDVPla(string scoountry, string scadena, string scanal)
        {

            DataSet ds = null;
            ds = oCoon.ejecutarDataSet("UP_WEBSIGE_OBTENERPDVPLANNING", scoountry, scadena, scanal);
            return ds;


        }

        [WebMethod(Description = "Metodo Para obtener Material POP")]
        public DataTable Get_ObtenerPOP()
        {

            DataTable dtpop = null;
            dtpop = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERMPOP");
            return dtpop;




        }

        [WebMethod(Description = "Metodo para realizar el Conteo de PDV_TMP")]
        public DataTable Get_ObtenerCuentaPdvtmp()
        {

            DataTable dtcuenta = null;
            dtcuenta = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNNING_CUENTAPDVTEMPORAL");
            return dtcuenta;





        }

        [WebMethod(Description = "Metodo para actualizar Cliente en asociacion clientes PDV")]
        public DataTable Get_UpdatePDVxCliente(int icompanyid)
        {

            DataTable dtuppdvcli = null;
            dtuppdvcli = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_UPDATECOMAPNYPDV", icompanyid);
            return dtuppdvcli;




        }

        [WebMethod(Description = "Metodo Para Limpiar Tablas de Planning y eliminar Planning invalidos")]
        public DataTable Get_DeleteTablesPlanning(int idplanning, string snameuser)
        {

            DataTable dtlitabl = null;
            dtlitabl = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_DELETETABLESPLA", idplanning, snameuser);
            return dtlitabl;





        }

        [WebMethod(Description = "Metodo Para Eliminar Planning no generados")]
        public DataTable Get_Delete_Planning(string snameuser)
        {

            DataTable dtdel = null;
            dtdel = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_DELEPLANNING", snameuser);
            return dtdel;




        }

        [WebMethod(Description = "Metodo para Eliminar pdv_tmp")]
        public DataTable Get_Deletepdvtmp(string snameuser)
        {

            DataTable dtdepdv = null;
            dtdepdv = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_DELETEPDVTMP", snameuser);
            return dtdepdv;




        }

        /// <summary>
        ///Se crea este Metodo para suplir rerquerimiento de Multimarcas, Multicattegorias y registros de n presentaciones de la competencia por Presentacion Propia 
        /// </summary>

        [WebMethod(Description = "Metodo para Obtener Presentaciones Propias")]
        public DataTable Get_Obtener_PresentacionesPropias(int iidporudctplanning)
        {

            DataTable dtprepro = null;
            dtprepro = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERPRODUCTPLANNING", iidporudctplanning);
            return dtprepro;




        }

        [WebMethod(Description = "Metodo para Actualizar el Numero de Planning en Presentaciones Planning")]
        public DataTable Get_Update_PlanningPresentaciones(int iidplanning, string snameuser)
        {

            DataTable dtuppla = null;
            dtuppla = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_UPDATEPLAXPRESENTACIONPROPIA", iidplanning, snameuser);
            return dtuppla;


        }

        [WebMethod(Description = "Metodo para Actualizar el Numero de Planning en Asignación de Operativos a Supervisores")]
        public DataTable Get_Update_PlanningAsignarOperativoxSuperv(int iidplanning, string snameuser)
        {

            DataTable dtupopsu = null;
            dtupopsu = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_UPDATEPLANNINGOPEXSUPE", iidplanning, snameuser);
            return dtupopsu;


        }

        [WebMethod(Description = "Metodo para obtener Items Adicionales de Gestión")]
        public DataTable Get_Ontener_Itetms_Adicionales_Gestión(int icostrategy, int icompanyid)
        {

            DataTable dtitem = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENER_ITETMSADICIONALES", icostrategy, icompanyid);
            return dtitem;

        }

        [WebMethod(Description = "Metodo Para Obtener el item de formato")]
        public DataSet Get_ObtenerItemFormato(int icodstrategy, int icoditem, int icompanyid, int iubicacion)
        {

            DataSet ds = null;
            ds = oCoon.ejecutarDataSet("UP_WEBSIGE_OBTENERITEMFORMATO", icodstrategy, icoditem, icompanyid, iubicacion);
            return ds;



        }
        /// <summary>
        /// Metodo para obtener lo items de encabezado de un formato de Levantamiento de Informacion
        /// </summary>
        /// <param name="icoditem"></param>
        /// <returns></returns>

        [WebMethod(Description = "Metodo Para Obtener Detalles de items de Encabezado de Formato")]
        public DataTable Get_ObtenerDetalleitemsformato(int icoditem)
        {

            DataTable dtidetalle = null;
            dtidetalle = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERITEMPOINTDETALLE_ENCABEZADO", icoditem);
            return dtidetalle;





        }

        /// <summary>
        /// Metodo para obtener los detalles del Pie de un Formato de Levantamiento de Información
        /// </summary>
        /// <param name="icoditem"></param>
        /// <returns></returns>

        [WebMethod(Description = "Metodo Para Obtener Detalless de items de Pie de Formato")]
        public DataTable Get_ObtenerDetalleitemsformato_Pie(int icoditem)
        {

            DataTable dtidetalle = null;
            dtidetalle = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERITEMPOINTDETALLE_PIE", icoditem);
            return dtidetalle;





        }

        /// <summary>
        /// Obtine Ciudades donde se elabora el planning
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para obtner Ciudades donde se elabora el Planning")]
        public DataSet Get_Otener_CiudadesPlanning(string sCountry)
        {

            DataSet ds = oCoon.ejecutarDataSet("UP_WEB_SIGE_OBTENER_CIUDADESPLANNING", sCountry);
            return ds;
        }

        /// <summary>
        /// Obtine Ciudades no asignadas al Planning Seleccionado
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para obtner  Ciudades no asignadas al Planning Seleccionado")]
        public DataSet Get_Otener_CiudadesPlanningAdd(string sCountry, int iidplanning)
        {

            DataSet ds = oCoon.ejecutarDataSet("UP_WEB_SIGE_OBTENER_CIUDADESPLANNINGADD", sCountry, iidplanning);
            return ds;
        }

        [WebMethod(Description = "Metodo para Obtener los Formatos de Levantamiento de Información")]
        public DataTable Get_Obtener_Formatos_Levantamiento(int icostratetgy, int icompanyid, string scodchannel)
        {


            DataTable dtforma = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERITEMSFORMATO", icostratetgy, icompanyid, scodchannel);
            return dtforma;




        }

        [WebMethod(Description = "Metodo para Obtener la estructura del formato de levantamiento de acuerdo al informe")]
        public DataTable Get_Obtener_Estructuraxformato(int iiditestrategy, int icompanyid)
        {

            DataTable dtinfo = null;
            dtinfo = oCoon.ejecutarDataTable("UP_WEBSIGE_OBTENERESTRUCTURA_FORMATO", iiditestrategy, icompanyid);
            return dtinfo;




        }

        [WebMethod(Description = "Metodo para Obtener Diseños de Formatos")]
        public DataTable Get_Obtener_Diseños_Formatos()
        {

            DataTable dtdise = null;
            dtdise = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_DESIGNFORMA");
            return dtdise;




        }

        [WebMethod(Description = "Metodo para obtener Formatos de Levantamiento de Information  x Planning")]
        public DataTable Get_Obtener_Formatos_LevantamientoxPlanning(int iplaningid)
        {


            DataTable dtforma = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERFOMATOSLEVAPLA", iplaningid);
            return dtforma;


        }

        [WebMethod(Description = "Metodo Para obtener Items de Formatos de Levantamiento de Información")]
        public DataTable Get_Obtener_ItemPointFormato(int icodItem, int icodstrategy)
        {

            DataTable dtitemformato = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OTENERITEMPOINT", icodItem, icodstrategy);
            return dtitemformato;


        }

        [WebMethod(Description = "Metodo para Activa Ingreso de Supervisor a SIGE")]
        public EPresupuesto Get_Update_Acces_Supervisor(int ipersonid, string snumberpresupuesto, string iperfilid)
        {
            DPlanning odplannings = new DPlanning();
            EPresupuesto oeplannings = odplannings.Activar_Acces_Supervisor(ipersonid, snumberpresupuesto, iperfilid);


            oeplannings.Personid = ipersonid;
            oeplannings.Perfilid = iperfilid;
            oeplannings.Namebudget = snumberpresupuesto;
            odplannings = null;
            return oeplannings;




        }

        [WebMethod(Description = "Metodo para Consultar Usuarios Supervisores a Ingresar a SIGE")]
        public DataTable Get_ObtenerUserSupervisores(int ipersonid)
        {

            DataTable dtsup = null;
            dtsup = oCoon.ejecutarDataTable("UP_WEBSIGEPLA_OBTENERUSERSUPERVI", ipersonid);
            return dtsup;




        }

        [WebMethod(Description = "Metodo para Obtener los Planes de Ventas actuales")]
        public DataTable Get_ObtenerPlanVentas(string schanel, int icompanyid)
        {


            DataTable dtplan = null;
            dtplan = oCoon.ejecutarDataTable("UP_WEB_ASIGNACIONECANAL_SEARCH_PLANCUENTAS", schanel, icompanyid);
            return dtplan;



        }

        [WebMethod(Description = "Metodo para Obtener Informes por Servicio")]
        public DataTable Get_ObtenerFormatosxServicio(int icodstrategy)
        {

            DataTable dtinforme = null;
            dtinforme = oCoon.ejecutarDataTable("UP_WEBSEIGE_PLANNING_OBTENERINFORMESXSERVICIO", icodstrategy);
            return dtinforme;


        }

        [WebMethod(Description = "Metodo para Obtener Indicadores x Informe")]
        public DataTable Get_ObtenerIndicadoresxInforme(int ireportid, int icodstrategy)
        {

            DataTable dtindica = null;
            dtindica = oCoon.ejecutarDataTable("UP_WEBSEIGE_PLANNING_OBTENERINDICADORES", ireportid, icodstrategy);
            return dtindica;





        }

        [WebMethod(Description = "Metodo para Obtener Columnas de Sales_Planning")]
        public DataTable Get_obtener_Columns_Sales_Planning(int ivalor)
        {

            DataTable dtcolumnsales = null;
            dtcolumnsales = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENER_COLUMNS_TABLES_INFORMES", ivalor);
            return dtcolumnsales;


        }

        [WebMethod(Description = "Metodo para obtener Actividades en el Comercio")]
        public DataTable Get_Obtener_Actividades_Comercio(int iCompany_id, string scodchannel)
        {

            DataTable dtacti = oCoon.ejecutarDataTable("UP_PLANNING_ASIGNACIONOBTNER_ACTIVIDADES", iCompany_id, scodchannel);
            return dtacti;

        }

        /// Descripción     : Metodo para actualizar la informacion relacionada a la primera pestaña de planning . asignacion de presupuesto
        /// Creado          : Ing. Mauricio Ortiz
        /// Fecha modificado: 10/09/2010
        /// <param name="sid_planning"></param>
        /// <param name="sPlanning_CodChannel"></param>
        /// <param name="tPlanning_StartActivity"></param>
        /// <param name="tPlanning_EndActivity"></param>
        /// <param name="tPlanning_DateRepSoli"></param>
        /// <param name="tPlanning_PreproduDateini"></param>
        /// <param name="tPlanning_PreproduDateEnd"></param>
        /// <param name="sPlanning_ProjectDuration"></param>
        /// <param name="tPlanning_DateFinreport"></param>
        /// <param name="sPlanning_Vigen"></param>
        /// <param name="bPlanning_Status"></param>
        /// <param name="iStatus_id"></param>
        /// <param name="sPlanning_ModiBy"></param>
        /// <param name="tPlanning_DateModiBy"></param>
        /// <returns>oeplanning</returns>
        [WebMethod(Description = "Metodo para Actualizar Planning")]
        public EPlaning Get_Update_Planning(string sid_planning, string sPlanning_CodChannel, DateTime tPlanning_StartActivity,
            DateTime tPlanning_EndActivity, DateTime tPlanning_DateRepSoli, DateTime tPlanning_PreproduDateini, DateTime tPlanning_PreproduDateEnd,
            string sPlanning_ProjectDuration, DateTime tPlanning_DateFinreport, string sPlanning_Vigen, bool bPlanning_Status, int iStatus_id,
            string sPlanning_ModiBy, DateTime tPlanning_DateModiBy)
        {
            DPlanning odplanning = new DPlanning();
            EPlaning oeplanning = odplanning.Actualiza_DatosAsignarPresupuesto(sid_planning, sPlanning_CodChannel, tPlanning_StartActivity,
             tPlanning_EndActivity, tPlanning_DateRepSoli, tPlanning_PreproduDateini, tPlanning_PreproduDateEnd,
             sPlanning_ProjectDuration, tPlanning_DateFinreport, sPlanning_Vigen, bPlanning_Status, iStatus_id,
             sPlanning_ModiBy, tPlanning_DateModiBy);

            odplanning = null;
            return oeplanning;
        }


        /// <summary>
        /// Metodo para actualizar estado en TBL_EQUIPO
        /// Ing. Mauricio Ortiz
        /// 14/02/2011
        /// Modificación : se adiciona el campo Canal . Ing. Mauricio Ortiz 24/05/2011
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para Actualizar Estado y canal en DB_LUCKY_TMP en la tabla TBL_EQUIPO ")]
        public DataTable Get_Update_PlanningTBL_EQUIPO(string sid_planning, string scanal, string sEstado)
        {
            DPlanning odplanning = new DPlanning();
            DataTable dtActualizaTBL_Equipo = odplanning.ActualizarEstadoTBL_EQUIPO(sid_planning, scanal, sEstado);
            return dtActualizaTBL_Equipo;
        }


        [WebMethod(Description = "Metodo para Actualizar numero de Planning en Presupuesto cuando se actualizan por Interface")]
        public DataTable Get_Update_PlanningPreIterface(string snumpresu)
        {

            DataTable dtup = null;
            dtup = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_ASIGNARNUMEROPLANNING", snumpresu);
            return dtup;





        }

        [WebMethod(Description = "Metodo para obtener fotos de Actividades en el Comercio")]
        public DataTable Get_Obtener_PhotoActividades_Comercio(int iCompany_id, string scodchannel)
        {

            DataTable dtacti = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERFOTOSACTIVIDAD", iCompany_id, scodchannel);
            return dtacti;
        }

        [WebMethod(Description = "Metodo para Obtener los PDV del Planning")]
        public DataTable Get_Obtener_PDV_Planning(int iplanning)
        {


            DataTable dtpdv = oCoon.ejecutarDataTable("UP_PLANNING_ASIGNACIONOBTNER_ACTIVIDADES", iplanning);
            return dtpdv;


        }

        [WebMethod(Description = "Metodo para actualizar numero de planning en PDV")]
        public DataTable Get_Update_PDV_NumPlanning(int idplanning)
        {


            DataTable dtpdv = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_UPDATEPLANNINGPDV", idplanning);
            return dtpdv;




        }

        [WebMethod(Description = "Metodo para Actualizar Numero de Planning En Tablas Metadata")]
        public DataTable Get_Update_IdPlanning_Metadatas(string snumpresupuesto)
        {

            DataTable dtiplameta = null;
            dtiplameta = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_UPDATEPLANNING_METADATAS", snumpresupuesto);
            return dtiplameta;





        }

        [WebMethod(Description = "Metodo para Actualizar Plan de Ventas x Cliente y Servicios")]
        public ESales_Plan Get_UpdateSalesPlan(int iSalesPlanid, int icod_strategy, int icmpanyid, int iidCityPri, decimal fValuePlanCityPri, string scodcountry, decimal fValuePlanCountry, string sSalesPlanUnit, string sSalesPlanModiBy, DateTime tSalesPlanDateModiBy)
        {
            DPlanning odplauppla = new DPlanning();
            ESales_Plan oeupsalesplan = odplauppla.Actualizar_PlanVentas(iSalesPlanid, icod_strategy, icmpanyid, iidCityPri, fValuePlanCityPri, scodcountry, fValuePlanCountry, sSalesPlanUnit, sSalesPlanModiBy, tSalesPlanDateModiBy);
            oeupsalesplan.SalesPlanid = iSalesPlanid;
            oeupsalesplan.codstrategy = icod_strategy;
            oeupsalesplan.companyid = icmpanyid;
            oeupsalesplan.idCityPri = iidCityPri;
            oeupsalesplan.ValuePlanCityPri = fValuePlanCityPri;
            oeupsalesplan.codcountry = scodcountry;
            oeupsalesplan.ValuePlanCountry = fValuePlanCountry;
            oeupsalesplan.SalesPlanUnit = sSalesPlanUnit;
            oeupsalesplan.SalesPlanModiBy = sSalesPlanModiBy;
            oeupsalesplan.SalesPlanDateModiBy = tSalesPlanDateModiBy;
            odplauppla = null;
            return oeupsalesplan;






        }

        [WebMethod(Description = "Metodo para Actualizar Estado de Intems en Formatos Planning")]
        public EContenedoraFormatos Get_Update_Formatos_Planning(int iicodItem, bool bcontenstatus, string scontenedorModiBy, DateTime tcontenedorDateModiBy)
        {
            DPlanning odconte = new DPlanning();
            EContenedoraFormatos oeconte = odconte.Actualizar_Items_Formatos(iicodItem, bcontenstatus, scontenedorModiBy, tcontenedorDateModiBy);
            oeconte.codItem = iicodItem;
            oeconte.contenstatus = bcontenstatus;
            oeconte.contenedorModiBy = scontenedorModiBy;
            oeconte.contenedorDateModiBy = tcontenedorDateModiBy;
            odconte = null;
            return oeconte;





        }

        [WebMethod(Description = "Metodo para Obtener los indicadores asignados en el Planning por Informe")]
        public DataTable Get_Obtener_Indicator_Informe(int idreport, int iidplanning, int ivalor)
        {

            DataTable dtsindfor = null;
            dtsindfor = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_SEARCHASIGNAINDICATORS", idreport, iidplanning, ivalor);
            return dtsindfor;






        }

        [WebMethod(Description = "Metodo para Obtener Planning Elaborados")]
        public DataTable Get_Obtener_Planning_Elaborados(string snumpresupuesto, string snameclient, string snameplanning, DateTime tfecini, DateTime tFecfin, bool btipobusqueda)
        {

            DataTable dtsarpla = null;
            dtsarpla = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_SEARCH", snumpresupuesto, snameclient, snameplanning, tfecini, tFecfin, btipobusqueda);

            return dtsarpla;





        }

        [WebMethod(Description = "Metodo para Obtener los PDV Cargados")]
        public DataTable Get_ObtenerPDVLoad(int idplanning)
        {

            DataTable dtpdv = null;
            dtpdv = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERPDVLOAD", idplanning);
            return dtpdv;




        }

        //Metodos Usados en el llenado de objetos para Busquedas en Planning Ing.Carlos Hernandez
        [WebMethod(Description = "Metodo para Obtener los Planning Elaborados de cuardo a el numero de Presupuesto")]
        public DataTable Get_ObtenerPlanningxPresupuesto(string snumberPresupuesto, int ivalor)
        {

            DataTable dtplapresu = null;
            dtplapresu = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_SEARCH_CAMPAÑAS", snumberPresupuesto, ivalor);
            return dtplapresu;





        }

        [WebMethod(Description = "Metodo para Obtener Datos Contruccion Planning")]
        public DataTable Get_ObtenerDatosPlanning(int iiplanning, int ivalor)
        {

            DataTable dtdataplan = null;
            dtdataplan = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERDATOSPLANNING", iiplanning, ivalor);
            return dtdataplan;




        }

        [WebMethod(Description = "Metodo para Obtener contruccion de Formatos")]
        public DataTable Get_Obtener_Estructra_formatos(int idiplanning, int idcopoint)
        {

            DataTable dtformatos = null;
            dtformatos = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_SEARCH_lEVAN_FORMATOS", idiplanning, idcopoint);
            return dtformatos;






        }

        [WebMethod(Description = "Metodo para Obtener formatos Usados en Planning")]
        public DataTable Get_Obtener_FormatosLeva_Planning(int idplanning)
        {


            DataTable dtleva = null;
            dtleva = oCoon.ejecutarDataTable("UP_WEBSIGE_OBTENERFORMATOSLEVA_PLANNING", idplanning);
            return dtleva;




        }

        [WebMethod(Description = "Metodo para Obtener formatos Planning")]
        public DataTable Get_ObtenerFormatosPlanning(int iidplanning)
        {

            DataTable dtformapla = null;
            dtformapla = oCoon.ejecutarDataTable("UP_WEBSIGE_OBTENERFORMATOSPLANNING", iidplanning);
            return dtformapla;




        }

        [WebMethod(Description = "Metodo Para obtener estructuracion de Formatos")]
        public DataTable Get_ObtenerEstructuraFormaPlanning(int iplanning, int iidcodpoit, int ivalor)
        {


            DataTable dtestrforma = null;
            dtestrforma = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERFORMATOS", iplanning, iidcodpoit, ivalor);
            return dtestrforma;




        }

        /// <summary>
        /// Método para obtener los puntos de venta asignados a un planning seleccionado
        /// Ing. Mauricio Ortiz
        /// Fecha : 20/10/2010
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="imalla"></param>
        /// <param name="isector"></param>
        /// <returns>dtpdvpla</returns>
        [WebMethod(Description = "Metodo para Obtener PDV del Planning")]
        public DataTable Get_ObtenerPDVPlanning(string sidplanning, int imalla, int isector)
        {
            DataTable dtpdvpla = null;
            dtpdvpla = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERPDVPLA", sidplanning, imalla, isector);
            return dtpdvpla;
        }

        [WebMethod(Description = "Metodo para Obtener Campañas Clientes")]

        public DataTable Get_ObtenerCampañasCliente(int icompanyid, int icodchannel)
        {

            DataTable dtcampaña = null;
            dtcampaña = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERPLANNINGCLIENTE", icompanyid, icodchannel);
            return dtcampaña;




        }

        [WebMethod(Description = "Metodo para llenado de Combos en Consultas Planning")]
        public DataTable Get_Obtener_LlenadoCombos()
        {

            DataTable dtcombos = null;
            dtcombos = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_LLENACOMBOS");
            return dtcombos;



        }

        /// <summary>
        /// Descripción  : Metodos para Realizar Save de Planning
        /// Modificación : 23/07/2010	Se adecuada inserción unicamente con los campos
        ///                que de acuerdo al nuevo planteamiento se debe cubrir para
        ///                la creacion del planning. se excluyen @Planning_ReportAditional,
        ///                @Planning_DevelopmentActivityReport, @Planning_Person_Eje,
        ///                @Planning_ActivityFormats, @Planning_AreaInvolved, @id_designFor,
        ///                @Name_Contact, @Email_Contac y @Planning_FormaCompe. Ing. Mauricio Ortiz
        ///                30/07/2010 se adiciona parametro id_planning ya que este no seguirá
        ///                siendo autogenerado por sql sino por la aplicación concatenando número de
        ///                presupuesto y fecha actual.                
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="sPlanning_Name"></param>
        /// <param name="icod_Strategy"></param>
        /// <param name="sPlanning_CodChannel"></param>
        /// <param name="tPlanning_StartActivity"></param>
        /// <param name="tPlanning_EndActivity"></param>
        /// <param name="tPlanning_DateRepSoli"></param>
        /// <param name="tPlanning_PreproduDateini"></param>
        /// <param name="tPlanning_PreproduDateEnd"></param>
        /// <param name="sPlanning_ProjectDuration"></param>
        /// <param name="tPlanning_DateFinreport"></param>
        /// <param name="sPlanning_Vigen"></param>
        /// <param name="sPlanning_Budget"></param>
        /// <param name="bPlanning_Status"></param>
        /// <param name="iStatus_id"></param>
        /// <param name="sPlanning_CreateBy"></param>
        /// <param name="tPlanning_DateBy"></param>
        /// <param name="sPlanning_ModiBy"></param>
        /// <param name="tPlanning_DateModiBy"></param>
        /// <returns oeplanning></returns>
        [WebMethod(Description = "Metodo para realizar el save de Planning")]
        public EPlaning Save_Planning(string sid_planning, string sPlanning_Name, int icod_Strategy, string sPlanning_CodChannel,
            DateTime tPlanning_StartActivity, DateTime tPlanning_EndActivity, DateTime tPlanning_DateRepSoli,
            DateTime tPlanning_PreproduDateini, DateTime tPlanning_PreproduDateEnd, string sPlanning_ProjectDuration,
            DateTime tPlanning_DateFinreport, string sPlanning_Vigen, string sPlanning_Budget, bool bPlanning_Status,
            int iStatus_id, string sPlanning_CreateBy, DateTime tPlanning_DateBy, string sPlanning_ModiBy,
            DateTime tPlanning_DateModiBy)
        {
            DPlanning odplanning = new DPlanning();
            EPlaning oeplanning = odplanning.CrearPlanning(sid_planning, sPlanning_Name, icod_Strategy, sPlanning_CodChannel,
             tPlanning_StartActivity, tPlanning_EndActivity, tPlanning_DateRepSoli,
             tPlanning_PreproduDateini, tPlanning_PreproduDateEnd, sPlanning_ProjectDuration,
             tPlanning_DateFinreport, sPlanning_Vigen, sPlanning_Budget, bPlanning_Status,
             iStatus_id, sPlanning_CreateBy, tPlanning_DateBy, sPlanning_ModiBy,
             tPlanning_DateModiBy);
            odplanning = null;
            return oeplanning;
        }


        /// <summary>
        /// Metodo para crear registro en la base de datos DB_LUCKY_TMP en la tabla TBL_EQUIPO
        /// Ing. Mauricio Ortiz
        /// 14/02/2011
        /// Modificación : 24/05/2011 se adiciona el parametro canal no existía al momento de crear el metodo  . Ing. Mauricio Ortiz. 
        /// <param name="sid_planning"></param>
        /// <param name="sPlanning_Name"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Metodo para realizar el save de Planning en DB_LUCKY_TMP")]
        public DataTable Save_PlanningDB_LUCKY_TMP(string sid_planning, string sPlanning_Name, string SCanal)
        {
            DPlanning odplanning = new DPlanning();
            DataTable dt = odplanning.CrearPlanningTBL_EQUIPO(sid_planning, sPlanning_Name,  SCanal);
            return dt;
        }


        /// <summary>
        /// Descripción : Método para realizar actualización de contacto y area involucrada del planning
        /// Fecha       : 06/08/2010
        /// Creado por  : Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="sPlanning_AreaInvolved"></param>
        /// <param name="sName_Contact"></param>
        /// <param name="sPlanning_ModiBy"></param>
        /// <param name="tPlanning_DateModiBy"></param>
        /// <returns oeplanning></returns>
        [WebMethod(Description = "Método para realizar actualización de contacto y area involucrada del planning")]
        public EPlaning ActualizaContactoyarea(string sid_planning, string sPlanning_AreaInvolved, string sName_Contact,
             string sPlanning_ModiBy, DateTime tPlanning_DateModiBy)
        {
            DPlanning odplanning = new DPlanning();
            EPlaning oeplanning = odplanning.ActualizaContactoyarea(sid_planning, sPlanning_AreaInvolved, sName_Contact,
              sPlanning_ModiBy, tPlanning_DateModiBy);

            odplanning = null;
            return oeplanning;
        }

        /// <summary>
        /// Descripción  : Método para realizar el Save de las Ciudades del Planning
        /// Modificación : 29/07/2010 se cambia tipo de dato en id_planning de int a string        ///                
        ///                Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="sidPlannig"></param>
        /// <param name="sCodCity"></param>
        /// <param name="icompanyid"></param>
        /// <param name="sCityPrincipal"></param>
        /// <param name="bCityPlanningStatus"></param>
        /// <param name="sCityPlanningCreateBy"></param>
        /// <param name="tCityPlanningDateBy"></param>
        /// <param name="sCityPlanningModiBy"></param>
        /// <param name="tCityPlanningDateModiBy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para realizar el Save de las Ciudades del Plannig")]
        public ECityPlanning CrearCityPlanning(string sidPlannig, string sCodCity, int icompanyid, string sCityPrincipal, bool bCityPlanningStatus, string sCityPlanningCreateBy,
            DateTime tCityPlanningDateBy, string sCityPlanningModiBy, DateTime tCityPlanningDateModiBy)
        {
            DPlanning odcityPlanning = new DPlanning();
            ECityPlanning oecityplanning = odcityPlanning.CrearCityPlanning(sidPlannig, sCodCity, icompanyid, sCityPrincipal, bCityPlanningStatus, sCityPlanningCreateBy, tCityPlanningDateBy, sCityPlanningModiBy, tCityPlanningDateModiBy);
            oecityplanning.idplanning = sidPlannig;
            oecityplanning.CodCity = sCodCity;
            oecityplanning.CityPrincipal = sCityPrincipal;
            oecityplanning.companyid = icompanyid;
            oecityplanning.CityPlanningStatus = bCityPlanningStatus;
            oecityplanning.CityPlanningCreateBy = sCityPlanningCreateBy;
            oecityplanning.CityPlanningDateBy = tCityPlanningDateBy;
            oecityplanning.CityPlanningModiBy = sCityPlanningModiBy;
            oecityplanning.CityPlanningDateModiBy = tCityPlanningDateModiBy;
            odcityPlanning = null;
            return oecityplanning;
        }

        /// <summary>
        /// Descripción  : Metodo para realizar Save de Obseraviones de la Actividad
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string         ///                
        ///                Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="sobsDescription"></param>
        /// <param name="sobsCrerateBy"></param>
        /// <param name="tobsDateBy"></param>
        /// <param name="sobsModiBy"></param>
        /// <param name="tobsDateModiBy"></param>
        /// <returns oeobs></returns>
        [WebMethod(Description = "Metodo para realizar Save de Obseraviones de la Actividad")]
        public EObservationPlanning Save_Observaciones(string sidplanning, string sobsDescription, string sobsCrerateBy, DateTime tobsDateBy, string sobsModiBy, DateTime tobsDateModiBy)
        {
            DPlanning odobs = new DPlanning();
            EObservationPlanning oeobs = odobs.Crear_Observa(sidplanning, sobsDescription, sobsCrerateBy, tobsDateBy, sobsModiBy, tobsDateModiBy);

            oeobs.id_planning = sidplanning;
            oeobs.obsDescription = sobsDescription;
            oeobs.obsCrerateBy = sobsCrerateBy;
            oeobs.obsDateBy = tobsDateBy;
            oeobs.obsModiBy = sobsModiBy;
            oeobs.obsDateModiBy = tobsDateModiBy;
            odobs = null;
            return oeobs;
        }

        /// <summary>
        /// Descripción  : Metodo para Registrar Datos Calculados de Ventas
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz       
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="iidmetasales"></param>
        /// <param name="iobjectid"></param>
        /// <param name="icolumnid"></param>
        /// <param name="bDateCalStatus"></param>
        /// <param name="sDateCalCreateBy"></param>
        /// <param name="tDateCalDateBy"></param>
        /// <param name="sDateCalModyBy"></param>
        /// <param name="tDateCalDateModiBy"></param>
        /// <returns oemetacal></returns>
        [WebMethod(Description = "Metodo para Registrar Datos Calculados de Ventas")]
        public EMetaDataCaculation Get_Register_DateCalSales(string sidplanning, int iidmetasales, int iobjectid, int icolumnid, bool bDateCalStatus, string sDateCalCreateBy, DateTime tDateCalDateBy, string sDateCalModyBy, DateTime tDateCalDateModiBy)
        {
            DPlanning odPladcal = new DPlanning();
            EMetaDataCaculation oemetacal = odPladcal.Crear_DateCalSales(sidplanning, iidmetasales, iobjectid, icolumnid, bDateCalStatus, sDateCalCreateBy, tDateCalDateBy, sDateCalModyBy, tDateCalDateModiBy);
            oemetacal.idplanning = sidplanning;
            oemetacal.idmetatabla = iidmetasales;
            oemetacal.objectid = iobjectid;
            oemetacal.columnid = icolumnid;
            oemetacal.DateCalStatus = bDateCalStatus;
            oemetacal.DateCalCreateBy = sDateCalCreateBy;
            oemetacal.DateCalDateBy = tDateCalDateBy;
            oemetacal.DateCalModyBy = sDateCalModyBy;
            oemetacal.DateCalDateModiBy = tDateCalDateModiBy;
            odPladcal = null;
            return oemetacal;
        }

        /// <summary>
        /// Descripción  : Metodo para realizar el Save de Aprendizajes de la Actividad
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz       
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="slearngDescription"></param>
        /// <param name="slearngCreateBy"></param>
        /// <param name="tlearngDateBy"></param>
        /// <param name="slearngModiBy"></param>
        /// <param name="tlearngDateModiBy"></param>
        /// <returns oelear></returns>
        [WebMethod(Description = "Metodo para realizar el Save de Aprendizajes de la Actividad")]
        public ELearnningPlanning Save_Aprendizajes(string sidplanning, string slearngDescription, string slearngCreateBy, DateTime tlearngDateBy, string slearngModiBy, DateTime tlearngDateModiBy)
        {
            DPlanning odlear = new DPlanning();
            ELearnningPlanning oelear = odlear.Crear_Leanning(sidplanning, slearngDescription, slearngCreateBy, tlearngDateBy, slearngModiBy, tlearngDateModiBy);
            oelear.idplanning = sidplanning;
            oelear.learngDescription = slearngDescription;
            oelear.learngCreateBy = slearngCreateBy;
            oelear.learngDateBy = tlearngDateBy;
            oelear.learngModiBy = slearngModiBy;
            oelear.learngDateModiBy = tlearngDateModiBy;
            odlear = null;
            return oelear;
        }

        /// <summary>
        /// Descripción  : Metodo para Registrar Datos Calculados de Precios
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="iidmetaprices"></param>
        /// <param name="iobjectid"></param>
        /// <param name="icolumnid"></param>
        /// <param name="bDateCalStatus"></param>
        /// <param name="sDateCalCreateBy"></param>
        /// <param name="tDateCalDateBy"></param>
        /// <param name="sDateCalModyBy"></param>
        /// <param name="tDateCalDateModiBy"></param>
        /// <returns oemetacal></returns>
        [WebMethod(Description = "Metodo para Registrar Datos Calculados de Precios")]
        public EMetaDataCaculation Get_Register_DateCalPrices(string sidplanning, int iidmetaprices, int iobjectid, int icolumnid, bool bDateCalStatus, string sDateCalCreateBy, DateTime tDateCalDateBy, string sDateCalModyBy, DateTime tDateCalDateModiBy)
        {
            DPlanning odPladcal = new DPlanning();
            EMetaDataCaculation oemetacal = odPladcal.Crear_DateCalPrices(sidplanning, iidmetaprices, iobjectid, icolumnid, bDateCalStatus, sDateCalCreateBy, tDateCalDateBy, sDateCalModyBy, tDateCalDateModiBy);
            oemetacal.idplanning = sidplanning;
            oemetacal.idmetatabla = iidmetaprices;
            oemetacal.objectid = iobjectid;
            oemetacal.columnid = icolumnid;
            oemetacal.DateCalStatus = bDateCalStatus;
            oemetacal.DateCalCreateBy = sDateCalCreateBy;
            oemetacal.DateCalDateBy = tDateCalDateBy;
            oemetacal.DateCalModyBy = sDateCalModyBy;
            oemetacal.DateCalDateModiBy = tDateCalDateModiBy;
            odPladcal = null;
            return oemetacal;
        }

        /// <summary>
        /// Descripción  : Método para Registrar Datos Calculados de Covertura
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="iidmetacoverage"></param>
        /// <param name="iobjectid"></param>
        /// <param name="icolumnid"></param>
        /// <param name="bDateCalStatus"></param>
        /// <param name="sDateCalCreateBy"></param>
        /// <param name="tDateCalDateBy"></param>
        /// <param name="sDateCalModyBy"></param>
        /// <param name="tDateCalDateModiBy"></param>
        /// <returns oemetacal></returns>
        [WebMethod(Description = "Metodo para Registrar Datos Calculados de Covertura")]
        public EMetaDataCaculation Get_Register_DateCoverage(string sidplanning, int iidmetacoverage, int iobjectid, int icolumnid, bool bDateCalStatus, string sDateCalCreateBy, DateTime tDateCalDateBy, string sDateCalModyBy, DateTime tDateCalDateModiBy)
        {
            DPlanning odPladcal = new DPlanning();
            EMetaDataCaculation oemetacal = odPladcal.Crear_DateCalCoverange(sidplanning, iidmetacoverage, iobjectid, icolumnid, bDateCalStatus, sDateCalCreateBy, tDateCalDateBy, sDateCalModyBy, tDateCalDateModiBy);
            oemetacal.idplanning = sidplanning;
            oemetacal.idmetatabla = iidmetacoverage;
            oemetacal.objectid = iobjectid;
            oemetacal.columnid = icolumnid;
            oemetacal.DateCalStatus = bDateCalStatus;
            oemetacal.DateCalCreateBy = sDateCalCreateBy;
            oemetacal.DateCalDateBy = tDateCalDateBy;
            oemetacal.DateCalModyBy = sDateCalModyBy;
            oemetacal.DateCalDateModiBy = tDateCalDateModiBy;
            odPladcal = null;
            return oemetacal;
        }

        /// <summary>
        /// Descripción  : Método para Registrar Datos Calculados de Medición de Espacios
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="iidmetaspace"></param>
        /// <param name="iobjectid"></param>
        /// <param name="icolumnid"></param>
        /// <param name="bDateCalStatus"></param>
        /// <param name="sDateCalCreateBy"></param>
        /// <param name="tDateCalDateBy"></param>
        /// <param name="sDateCalModyBy"></param>
        /// <param name="tDateCalDateModiBy"></param>
        /// <returns oemetacal></returns>
        [WebMethod(Description = "Metodo para Registrar Datos Calculados de Medición de Espacios")]
        public EMetaDataCaculation Get_Register_DateCalSapace(string sidplanning, int iidmetaspace, int iobjectid, int icolumnid, bool bDateCalStatus, string sDateCalCreateBy, DateTime tDateCalDateBy, string sDateCalModyBy, DateTime tDateCalDateModiBy)
        {
            DPlanning odPladcal = new DPlanning();
            EMetaDataCaculation oemetacal = odPladcal.Crear_DateCalSpace(sidplanning, iidmetaspace, iobjectid, icolumnid, bDateCalStatus, sDateCalCreateBy, tDateCalDateBy, sDateCalModyBy, tDateCalDateModiBy);
            oemetacal.idplanning = sidplanning;
            oemetacal.idmetatabla = iidmetaspace;
            oemetacal.objectid = iobjectid;
            oemetacal.columnid = icolumnid;
            oemetacal.DateCalStatus = bDateCalStatus;
            oemetacal.DateCalCreateBy = sDateCalCreateBy;
            oemetacal.DateCalDateBy = tDateCalDateBy;
            oemetacal.DateCalModyBy = sDateCalModyBy;
            oemetacal.DateCalDateModiBy = tDateCalDateModiBy;
            odPladcal = null;
            return oemetacal;
        }

        /// <summary>
        /// Descripción  : Método para realizar el Save de Suguerencias de la Actividad
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="iidplanning"></param>
        /// <param name="ssuggDescription"></param>
        /// <param name="ssuggCreateBy"></param>
        /// <param name="tsuggDateBy"></param>
        /// <param name="ssuggModiBy"></param>
        /// <param name="tsuggDateModiBy"></param>
        /// <returns oesugg></returns>

        [WebMethod(Description = "Metodo para realizar el Save de Suguerencias de la Actividad")]
        public ESuggetionPlanning Save_Suguerencias(string sidplanning, string ssuggDescription, string ssuggCreateBy, DateTime tsuggDateBy, string ssuggModiBy, DateTime tsuggDateModiBy)
        {
            DPlanning odsugg = new DPlanning();
            ESuggetionPlanning oesugg = odsugg.Crear_Suggetion(sidplanning, ssuggDescription, ssuggCreateBy, tsuggDateBy, ssuggModiBy, tsuggDateModiBy);
            oesugg.idplanning = sidplanning;
            oesugg.suggDescription = ssuggDescription;
            oesugg.suggCreateBy = ssuggCreateBy;
            oesugg.suggDateBy = tsuggDateBy;
            oesugg.suggModiBy = ssuggModiBy;
            oesugg.suggDateModiBy = tsuggDateModiBy;
            odsugg = null;
            return oesugg;
        }

        /// <summary>
        /// Descripción  : Método para Realizar el Save de Formatos del Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        ///                26/10/2010 Se quita la linea oereport.ReportSt_id = iReportSt_id ya que el 
        ///                atributo ya no existe en la clase entity EReports_Planning. Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="iReportSt_id"></param>
        /// <param name="bReportsPlanning_Status"></param>
        /// <param name="sReportsPlanning_CreateBy"></param>
        /// <param name="tReportsPlanning_DateBy"></param>
        /// <param name="sReportsPlanning_ModiBy"></param>
        /// <param name="tReportsPlanning_DateModiBy"></param>
        /// <returns oereport></returns>

        [WebMethod(Description = "Metodo para Realizar el Save de Formatos del Planning")]
        public EReports_Planning Save_FormatosxServicio(string sid_planning, int iReportSt_id, bool bReportsPlanning_Status, string sReportsPlanning_CreateBy, DateTime tReportsPlanning_DateBy, string sReportsPlanning_ModiBy, DateTime tReportsPlanning_DateModiBy)
        {
            DPlanning odreport = new DPlanning();
            EReports_Planning oereport = odreport.Crear_Formatos_Planning(sid_planning, iReportSt_id, bReportsPlanning_Status, sReportsPlanning_CreateBy, tReportsPlanning_DateBy, sReportsPlanning_ModiBy, tReportsPlanning_DateModiBy);
            oereport.id_planning = sid_planning;
            //oereport.ReportSt_id = iReportSt_id;
            oereport.ReportsPlanning_Status = bReportsPlanning_Status;
            oereport.ReportsPlanning_CreateBy = sReportsPlanning_CreateBy;
            oereport.ReportsPlanning_DateBy = tReportsPlanning_DateBy;
            oereport.ReportsPlanning_ModiBy = sReportsPlanning_ModiBy;
            oereport.ReportsPlanning_DateModiBy = tReportsPlanning_DateModiBy;
            odreport = null;
            return oereport;
        }

        /// <summary>
        /// Descripción  : Método para Realizar el Save de PDV por Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                se cambia id_pointofsale por id_ClientPDV de acuerdo al cambio realizado 
        ///                en la base de datos Ing. Mauricio Ortiz  
        /// </summary>
        /// <param name="iid_ClientPDV"></param>
        /// <param name="sid_Planning"></param>
        /// <param name="bPointOfSalePlanning_Status"></param>
        /// <param name="sPointOfSalePlanning_CreateBy"></param>
        /// <param name="tPointOfSalePlanning_DateBy"></param>
        /// <param name="sPointOfSalePlanning_ModiBy"></param>
        /// <param name="tPointOfSalePlanning_DateModiBy"></param>
        /// <returns oepdvpla></returns>

        [WebMethod(Description = "Metodo para Realizar el Save de PDV por Planning")]
        public EPointOfSale_Planning Save_PDVXPlanning(int iid_ClientPDV, string sid_Planning, bool bPointOfSalePlanning_Status, string sPointOfSalePlanning_CreateBy, DateTime tPointOfSalePlanning_DateBy, string sPointOfSalePlanning_ModiBy, DateTime tPointOfSalePlanning_DateModiBy)
        {
            DPlanning odpdvpla = new DPlanning();
            EPointOfSale_Planning oepdvpla = odpdvpla.Crear_PDV_Planning(iid_ClientPDV, sid_Planning, bPointOfSalePlanning_Status, sPointOfSalePlanning_CreateBy, tPointOfSalePlanning_DateBy, sPointOfSalePlanning_ModiBy, tPointOfSalePlanning_DateModiBy);
            oepdvpla.id_ClientPDV = iid_ClientPDV;
            oepdvpla.id_Planning = sid_Planning;
            oepdvpla.PointOfSalePlanning_Status = bPointOfSalePlanning_Status;
            oepdvpla.PointOfSalePlanning_CreateBy = sPointOfSalePlanning_CreateBy;
            oepdvpla.PointOfSalePlanning_DateBy = tPointOfSalePlanning_DateBy;
            oepdvpla.PointOfSalePlanning_ModiBy = sPointOfSalePlanning_ModiBy;
            oepdvpla.PointOfSalePlanning_DateModiBy = tPointOfSalePlanning_DateModiBy;
            odpdvpla = null;
            return oepdvpla;
        }

        /// <summary>
        /// Descripción  : Método para Realizar el Save de Productos por Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        ///                31/08/2010 se cambia tipo de dato en id_Product de int a long
        ///                02/03/2011 se adiciona el parametro Report_Id . Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="lid_Product"></param>
        /// <param name="sidProductCategory"></param>
        /// <param name="iid_Brand"></param>
        /// <param name="sidSubBrand"></param>
        /// <param name="sProducCarac"></param>
        /// <param name="sProducBeni"></param>
        /// <param name="iProductsPlanningInitialStock"></param>
        /// <param name="iReport_Id"></param>
        /// <param name="bStatus"></param>
        /// <param name="sProductPlanCreateBy"></param>
        /// <param name="tProductPlanDateBy"></param>
        /// <param name="sProductPlanModiBy"></param>
        /// <param name="tProductPlanDateModiBy"></param>
        /// <returns oeprosave></returns>
        [WebMethod(Description = "Metodo para Realizar el Save de Productos por Planning")]
        public EProducts_Planning Get_Regitration_ProductosPlanning(string sid_planning, long lid_Product, string sidProductCategory, int iid_Brand, string sidSubBrand, string sProducCarac, string sProducBeni, int iProductsPlanningInitialStock, int iReport_Id, bool bStatus, string sProductPlanCreateBy, DateTime tProductPlanDateBy, string sProductPlanModiBy, DateTime tProductPlanDateModiBy)
        {
            DPlanning odsaveprod = new DPlanning();
            EProducts_Planning oeprosave = odsaveprod.Crear_Products_Planning(sid_planning, lid_Product, sidProductCategory, iid_Brand, sidSubBrand, sProducCarac, sProducBeni, iProductsPlanningInitialStock, iReport_Id, bStatus, sProductPlanCreateBy, tProductPlanDateBy, sProductPlanModiBy, tProductPlanDateModiBy);
            oeprosave.id_planning = sid_planning;
            oeprosave.id_Product = lid_Product;
            oeprosave.idProductCategory = sidProductCategory;
            oeprosave.id_Brand = iid_Brand;
            oeprosave.idSubBrand = sidSubBrand;
            oeprosave.ProductCaracte = sProducCarac;
            oeprosave.ProductBenefi = sProducBeni;
            oeprosave.ProductsPlanning_InitialStock = iProductsPlanningInitialStock;
            oeprosave.Report_Id = iReport_Id;
            oeprosave.Status = bStatus;
            oeprosave.ProductPlaCreateBy = sProductPlanCreateBy;
            oeprosave.ProductPlaDateBy = tProductPlanDateBy;
            oeprosave.ProductPlanModiBy = sProductPlanModiBy;
            oeprosave.ProductPlanDateModiBy = tProductPlanDateModiBy;
            odsaveprod = null;
            return oeprosave;
        }


        /// <summary>
        /// Método para insertar registro en la tabla PLA_Brand_Planning
        /// Ing. Mauricio Ortiz
        /// 26/02/2011
        /// Modificación:  02/03/2011 se adiciona el parametro Report_Id . Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="sid_ProductCategory"></param>
        /// <param name="iid_Brand"></param>
        /// <param name="iReport_Id"></param>
        /// <param name="bStatus"></param>
        /// <param name="sBrandPlan_CreateBy"></param>
        /// <param name="tBrandPlan_DateBy"></param>
        /// <param name="sBrandPlan_ModiBy"></param>
        /// <param name="tBrandPlan_DateModiBy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para Realizar el Save de Marcas por Planning")]
        public DataTable Get_Registrar_MarcasPlanning(string sid_planning, string sid_ProductCategory, int iid_Brand, int iReport_Id, bool bStatus, string sBrandPlan_CreateBy, DateTime tBrandPlan_DateBy, string sBrandPlan_ModiBy, DateTime tBrandPlan_DateModiBy)
        {
            DPlanning odsavebrand = new DPlanning();
            DataTable oebrandSave = odsavebrand.Crear_Marcas_Planning(sid_planning, sid_ProductCategory, iid_Brand, iReport_Id, bStatus, sBrandPlan_CreateBy, tBrandPlan_DateBy, sBrandPlan_ModiBy, tBrandPlan_DateModiBy);
            return oebrandSave;
        }

        /// <summary>
        /// Método para registrar en la tabla PLA_Family_Planning
        /// Ing. Mauricio Ortiz
        /// 23/03/2011
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="sid_ProductCategory"></param>
        /// <param name="iid_Brand"></param>
        /// <param name="sid_ProductFamily"></param>
        /// <param name="iReport_Id"></param>
        /// <param name="bStatus"></param>
        /// <param name="sFamilyPlan_CreateBy"></param>
        /// <param name="tFamilyPlan_DateBy"></param>
        /// <param name="sFamilyPlan_ModiBy"></param>
        /// <param name="tFamilyPlan_DateModiBy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para Realizar el Save de Familias por Planning")]
        public DataTable Get_Registrar_FamiliasPlanning(string sid_planning, string sid_ProductCategory, int iid_Brand, string sid_ProductFamily, int iReport_Id, bool bStatus, string sFamilyPlan_CreateBy, DateTime tFamilyPlan_DateBy, string sFamilyPlan_ModiBy, DateTime tFamilyPlan_DateModiBy)
        {
            DPlanning odsaveFamily = new DPlanning();
            DataTable oeFamilySave = odsaveFamily.Crear_FamiliasPlanning(sid_planning, sid_ProductCategory, iid_Brand, sid_ProductFamily, iReport_Id, bStatus, sFamilyPlan_CreateBy, tFamilyPlan_DateBy, sFamilyPlan_ModiBy, tFamilyPlan_DateModiBy);            
            return oeFamilySave;
        }

        /// <summary>
        /// Descripción  : Método Para registrar las Presentaciones de la Competencia en la Construcción de un Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="iidProductsPlanning"></param>
        /// <param name="snameproducCompe"></param>
        /// <param name="sBrandCompe"></param>
        /// <param name="sproductmanufac"></param>
        /// <param name="bproducCompeStatus"></param>
        /// <param name="sproducCompeCreateBy"></param>
        /// <param name="tproducCompeDateBy"></param>
        /// <param name="sproducCompeModiBy"></param>
        /// <param name="tproducCompeDateModiBy"></param>
        /// <returns oeproduccompe></returns>
        [WebMethod(Description = "Metodo Para registrar las Presentaciones de la Competencia en la Construcción de un Planning")]
        public EProduct_Compe Get_Register_Product_Compe(string sidplanning, int iidProductsPlanning, string snameproducCompe, string sBrandCompe, string sproductmanufac, bool bproducCompeStatus, string sproducCompeCreateBy, DateTime tproducCompeDateBy, string sproducCompeModiBy, DateTime tproducCompeDateModiBy)
        {
            DPlanning odsavprcom = new DPlanning();
            EProduct_Compe oeproduccompe = odsavprcom.Crear_ProductCompe(sidplanning, iidProductsPlanning, snameproducCompe, sBrandCompe, sproductmanufac, bproducCompeStatus, sproducCompeCreateBy, tproducCompeDateBy, sproducCompeModiBy, tproducCompeDateModiBy);
            oeproduccompe.idplanning = sidplanning;
            oeproduccompe.idProductsPlanning = iidProductsPlanning;
            oeproduccompe.nameproducCompe = snameproducCompe;
            oeproduccompe.BrandCompe = sBrandCompe;
            oeproduccompe.ProductCompemanufacturer = sproductmanufac;
            oeproduccompe.producCompeStatus = bproducCompeStatus;
            oeproduccompe.producCompeCreateBy = sproducCompeCreateBy;
            oeproduccompe.producCompeDateBy = tproducCompeDateBy;
            oeproduccompe.producCompeModiBy = sproducCompeModiBy;
            oeproduccompe.producCompeDateModiBy = tproducCompeDateModiBy;
            odsavprcom = null;
            return oeproduccompe;
        }

        /// <summary>
        /// Descripción  : Metodo para Asignar Operativos a Supervisores en la Construcción de un Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="iPersonidSupe"></param>
        /// <param name="iPersonidOpera"></param>
        /// <param name="bAsigmenPerstatus"></param>
        /// <param name="sAsigmenPerCreateBy"></param>
        /// <param name="tAsigmenPerDateBy"></param>
        /// <param name="sAsigmenPerModiBy"></param>
        /// <param name="tAsigmenPerDateModiBy"></param>
        /// <returns oeasiop></returns>
        [WebMethod(Description = "Metodo para Asignar Operativos a Supervisores en la Construcción de un Planning")]
        public EOperating__Supervisor__Assignment Get_Register_OperativosxSupervisor(string sidplanning, int iPersonidSupe, int iPersonidOpera, bool bAsigmenPerstatus, string sAsigmenPerCreateBy, DateTime tAsigmenPerDateBy, string sAsigmenPerModiBy, DateTime tAsigmenPerDateModiBy)
        {
            DPlanning odasigopesu = new DPlanning();
            EOperating__Supervisor__Assignment oeasiop = odasigopesu.Crear_Asignaciones_Operativos_Supervi(sidplanning, iPersonidSupe, iPersonidOpera, bAsigmenPerstatus, sAsigmenPerCreateBy, tAsigmenPerDateBy, sAsigmenPerModiBy, tAsigmenPerDateModiBy);
            oeasiop.idplanning = sidplanning;
            oeasiop.PersonidSupe = iPersonidSupe;
            oeasiop.PersonidOpera = iPersonidOpera;
            oeasiop.AsigmenPerstatus = bAsigmenPerstatus;
            oeasiop.AsigmenPerCreateBy = sAsigmenPerCreateBy;
            oeasiop.AsigmenPerDateBy = tAsigmenPerDateBy;
            oeasiop.AsigmenPerModiBy = sAsigmenPerModiBy;
            oeasiop.AsigmenPerDateModiBy = tAsigmenPerDateModiBy;
            odasigopesu = null;
            return oeasiop;
        }

        /// <summary>
        /// Descripción: Método para eliminar asignación de Operativos a Supervisores
        /// Creado por : Ing. Mauricio Ortiz
        /// Fecha      : 28/09/2010
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="iPersonidOpera"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para eliminar asignación de Operativos a Supervisores")]
        public DataTable Get_EliminarOperativosxSupervisor(string sidplanning, int iPersonidOpera)
        {
            DPlanning oDDelete = new DPlanning();
            DataTable dt = oDDelete.Delete_Asignaciones_Operativos_Supervi(sidplanning, iPersonidOpera);
            return dt;
        }


        /// <summary>
        /// Descripción  : Método para eliminar registros de la tabla PointOfSale_Planning
        /// Creado por   : Ing Mauricio Ortiz 
        /// Fecha        : 21/10/2010 
        /// </summary>
        /// <param name="iid_MPOSPlanning"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para eliminar puntos de venta planning")]
        public DataTable Get_EliminarPDVPlanning(int iid_MPOSPlanning)
        {
            DPlanning oDDelete = new DPlanning();
            DataTable dt = oDDelete.DeletePDV_Planning(iid_MPOSPlanning);
            return dt;
        }

        /// <summary>
        /// Descripción  : Metodo para realizar el Save de Material POP
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="sidplanning"></param>
        /// <param name="iidMPointOfPurchase"></param>
        /// <param name="bMPOPPlanningStatus"></param>
        /// <param name="sMPOPPlanningCreateBy"></param>
        /// <param name="tMPOPPlanningDateBy"></param>
        /// <param name="sMPOPPlanningModiBy"></param>
        /// <param name="tMPOPPlanningDateModiBy"></param>
        /// <returns oesavempop></returns>
        [WebMethod(Description = "Metodo para realizar el Save de Material POP")]
        public EMPointOfPurchase_Planning Get_Registration_MPO(string sidplanning, int iidMPointOfPurchase, bool bMPOPPlanningStatus, string sMPOPPlanningCreateBy, DateTime tMPOPPlanningDateBy, string sMPOPPlanningModiBy, DateTime tMPOPPlanningDateModiBy)
        {
            DPlanning odmpop = new DPlanning();
            {
                EMPointOfPurchase_Planning oesavempop = odmpop.Crear_MPOP_PLanning(sidplanning, iidMPointOfPurchase, bMPOPPlanningStatus, sMPOPPlanningCreateBy, tMPOPPlanningDateBy, sMPOPPlanningModiBy, tMPOPPlanningDateModiBy);
                oesavempop.id_Planning = sidplanning;
                oesavempop.id_MPOPPlanning = iidMPointOfPurchase;
                oesavempop.MPOPPlanning_Status = bMPOPPlanningStatus;
                oesavempop.MPOPPlanning_CreateBy = sMPOPPlanningCreateBy;
                oesavempop.MPOPPlanning_DateBy = tMPOPPlanningDateBy;
                oesavempop.MPOPPlanning_ModiBy = sMPOPPlanningModiBy;
                oesavempop.MPOPPlanning_DateModiBy = tMPOPPlanningDateModiBy;
                odmpop = null;
                return oesavempop;
            }
        }
        
        /// <summary>
        /// Metodo para Cargar PDV de archivo en Planning
        /// Modificación : 25/08/2010 Se quita parametro spdvCode , este campo ya no existe en la tabla. Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="iid_PointOfsale"></param>        
        /// <param name="sid_typeDocument"></param>
        /// <param name="spdvRegTax"></param>
        /// <param name="spdvcontact1"></param>
        /// <param name="spdvposition1"></param>
        /// <param name="spdvcontact2"></param>
        /// <param name="spdvposition2"></param>
        /// <param name="spdvRazónSocial"></param>
        /// <param name="spdvName"></param>
        /// <param name="spdvPhone"></param>
        /// <param name="spdvAnexo"></param>
        /// <param name="spdvFax"></param>
        /// <param name="spdvcodCountry"></param>
        /// <param name="snameCountry"></param>
        /// <param name="spdvcodDepartment"></param>
        /// <param name="snameDepartament"></param>
        /// <param name="spdvcodProvince"></param>
        /// <param name="snameprovince"></param>
        /// <param name="spdvcodDistrict"></param>
        /// <param name="snameDistrict"></param>
        /// <param name="spdvcodCommunity"></param>
        /// <param name="snameComunity"></param>
        /// <param name="spdvAddress"></param>
        /// <param name="spdvemail"></param>
        /// <param name="spdvcodChannel"></param>
        /// <param name="snameChannel"></param>
        /// <param name="iidNodeComType"></param>
        /// <param name="snamecomtype"></param>
        /// <param name="sNodeCommercial"></param>
        /// <param name="snamenodecomercial"></param>
        /// <param name="iid_Segment"></param>
        /// <param name="snameSegment"></param>
        /// <param name="bpdvstatus"></param>
        /// <param name="sPdvCreateBy"></param>
        /// <param name="tPdvDateBy"></param>
        /// <param name="sPdvModiBy"></param>
        /// <param name="tPdvDateModiBy"></param>
        /// <returns>oerPDV</returns>
        [WebMethod(Description = "Metodo para Cargar PDV de archivo en Planning")]
        public EPuntosDV Get_Load_PDV_Planning(int iid_PointOfsale, string sid_typeDocument, string spdvRegTax,
        string spdvcontact1, string spdvposition1, string spdvcontact2, string spdvposition2, string spdvRazónSocial,
        string spdvName, string spdvPhone, string spdvAnexo, string spdvFax, string spdvcodCountry, string snameCountry, string spdvcodDepartment, string snameDepartament,
        string spdvcodProvince, string snameprovince, string spdvcodDistrict, string snameDistrict, string spdvcodCommunity, string snameComunity, string spdvAddress, string spdvemail,
        string spdvcodChannel, string snameChannel, int iidNodeComType, string snamecomtype, string sNodeCommercial, string snamenodecomercial, int iid_Segment, string snameSegment, bool bpdvstatus, string sPdvCreateBy, DateTime tPdvDateBy,
        string sPdvModiBy, DateTime tPdvDateModiBy)
        {
            DPlanning odpdv = new DPlanning();
            EPuntosDV oerPDV = odpdv.Cargar_PDV_Planning(iid_PointOfsale, sid_typeDocument, spdvRegTax,
     spdvcontact1, spdvposition1, spdvcontact2, spdvposition2, spdvRazónSocial,
     spdvName, spdvPhone, spdvAnexo, spdvFax, spdvcodCountry, snameCountry, spdvcodDepartment, snameDepartament,
     spdvcodProvince, snameprovince, spdvcodDistrict, snameDistrict, spdvcodCommunity, snameComunity, spdvAddress, spdvemail,
     spdvcodChannel, snameChannel, iidNodeComType, snamecomtype, sNodeCommercial, snamenodecomercial, iid_Segment, snameSegment, bpdvstatus, sPdvCreateBy, tPdvDateBy,
     sPdvModiBy, tPdvDateModiBy);

            odpdv = null;
            return oerPDV;
        }

        /// <summary>
        /// Descripción  : Metodo para Registrar los indicadores de ventas  seleccionados en un Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="iobjectid"></param>
        /// <param name="sidplanning"></param>
        /// <param name="iidindicador"></param>
        /// <param name="icolumn"></param>
        /// <param name="sSymbolName"></param>
        /// <param name="sOperating"></param>
        /// <param name="sFormula"></param>
        /// <param name="sReformulation"></param>
        /// <param name="sorigendatos"></param>
        /// <param name="smetasalesCreateBy"></param>
        /// <param name="tmetasalesDateBy"></param>
        /// <param name="smetasalesModiBy"></param>
        /// <param name="tmetasalesDateModiBy"></param>
        /// <returns oesavepidicator></returns>
        [WebMethod(Description = "Metodo para Registrar los indicadores de ventas  seleccionados en un Planning")]
        public EMetadataSales_Planning Get_Register_Indicator_Sales_Planning(int iobjectid, string sidplanning, int iidindicador, int icolumn, string sSymbolName, string sOperating, string sFormula, string sReformulation, string sorigendatos, string smetasalesCreateBy, DateTime tmetasalesDateBy, string smetasalesModiBy, DateTime tmetasalesDateModiBy)
        {
            DPlanning odpindicator = new DPlanning();
            EMetadataSales_Planning oesavepidicator = odpindicator.Crear_Indicarores_Sales_Planning(iobjectid, sidplanning, iidindicador, icolumn, sSymbolName, sOperating, sFormula, sReformulation, sorigendatos, smetasalesCreateBy, tmetasalesDateBy, smetasalesModiBy, tmetasalesDateModiBy);
            oesavepidicator.objectid = iobjectid;
            oesavepidicator.idplanning = sidplanning;
            oesavepidicator.idindicador = iidindicador;
            oesavepidicator.columnid = icolumn;
            oesavepidicator.SymbolName = sSymbolName;
            oesavepidicator.Operating = sOperating;
            oesavepidicator.Formula = sFormula;
            oesavepidicator.Reformulation = sReformulation;
            oesavepidicator.OrigenDatos = sorigendatos;
            oesavepidicator.metasalesCreateBy = smetasalesCreateBy;
            oesavepidicator.metasalesDateBy = tmetasalesDateBy;
            oesavepidicator.metasalesModiBy = smetasalesModiBy;
            oesavepidicator.metasalesDateModiBy = tmetasalesDateModiBy;
            odpindicator = null;
            return oesavepidicator;
        }

        /// <summary>
        /// Descripción  : Método para Registrar los indicadores de Precios  seleccionados en un Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="iobjectid"></param>
        /// <param name="sidplanning"></param>
        /// <param name="iidindicador"></param>
        /// <param name="icolumn"></param>
        /// <param name="sSymbolName"></param>
        /// <param name="sOperating"></param>
        /// <param name="sFormula"></param>
        /// <param name="sReformulation"></param>
        /// <param name="sorigendatos"></param>
        /// <param name="smetapricesCreateBy"></param>
        /// <param name="tmetapricesDateBy"></param>
        /// <param name="smetapricesModiBy"></param>
        /// <param name="tmetapricesDateModiBy"></param>
        /// <returns oesavepidicator></returns>
        [WebMethod(Description = "Método para Registrar los indicadores de Precios  seleccionados en un Planning")]
        public EMetadataPrices_Planning Get_Register_Indicator_Prices_Planning(int iobjectid, string sidplanning, int iidindicador, int icolumn, string sSymbolName, string sOperating, string sFormula, string sReformulation, string sorigendatos, string smetapricesCreateBy, DateTime tmetapricesDateBy, string smetapricesModiBy, DateTime tmetapricesDateModiBy)
        {
            DPlanning odpindicator = new DPlanning();
            EMetadataPrices_Planning oesavepidicator = odpindicator.Crear_Indicarores_Prices_Planning(iobjectid, sidplanning, iidindicador, icolumn, sSymbolName, sOperating, sFormula, sReformulation, sorigendatos, smetapricesCreateBy, tmetapricesDateBy, smetapricesModiBy, tmetapricesDateModiBy);
            oesavepidicator.objectid = iobjectid;
            oesavepidicator.idplanning = sidplanning;
            oesavepidicator.idindicador = iidindicador;
            oesavepidicator.columnid = icolumn;
            oesavepidicator.SymbolName = sSymbolName;
            oesavepidicator.Operating = sOperating;
            oesavepidicator.Formula = sFormula;
            oesavepidicator.Reformulation = sReformulation;
            oesavepidicator.OrigenDatos = sorigendatos;
            oesavepidicator.metapricesCreateBy = smetapricesCreateBy;
            oesavepidicator.metapricesDateBy = tmetapricesDateBy;
            oesavepidicator.metapricesModiBy = smetapricesModiBy;
            oesavepidicator.metapricesDateModiBy = tmetapricesDateModiBy;
            odpindicator = null;
            return oesavepidicator;
        }

        /// <summary>
        /// Descripción : Método para Registrar los indicadores de Cobertura  seleccionados en un Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="iobjectid"></param>
        /// <param name="sidplanning"></param>
        /// <param name="iidindicador"></param>
        /// <param name="icolumn"></param>
        /// <param name="sSymbolName"></param>
        /// <param name="sOperating"></param>
        /// <param name="sFormula"></param>
        /// <param name="sReformulation"></param>
        /// <param name="sorigendatos"></param>
        /// <param name="smetacoverageCreateBy"></param>
        /// <param name="tmetacoverageDateBy"></param>
        /// <param name="smetacoverageModiBy"></param>
        /// <param name="tmetacoverageDateModiBy"></param>
        /// <returns oesavepidicator></returns>
        [WebMethod(Description = "Metodo para Registrar los indicadores de Cobertura  seleccionados en un Planning")]
        public EMetadataCoverage_Planning Get_Register_Indicator_Coverage_Planning(int iobjectid, string sidplanning, int iidindicador, int icolumn, string sSymbolName, string sOperating, string sFormula, string sReformulation, string sorigendatos, string smetacoverageCreateBy, DateTime tmetacoverageDateBy, string smetacoverageModiBy, DateTime tmetacoverageDateModiBy)
        {
            DPlanning odpindicator = new DPlanning();
            EMetadataCoverage_Planning oesavepidicator = odpindicator.Crear_Indicarores_coverage_Planning(iobjectid, sidplanning, iidindicador, icolumn, sSymbolName, sOperating, sFormula, sReformulation, sorigendatos, smetacoverageCreateBy, tmetacoverageDateBy, smetacoverageModiBy, tmetacoverageDateModiBy);
            oesavepidicator.objectid = iobjectid;
            oesavepidicator.idplanning = sidplanning;
            oesavepidicator.idindicador = iidindicador;
            oesavepidicator.columnid = icolumn;
            oesavepidicator.SymbolName = sSymbolName;
            oesavepidicator.Operating = sOperating;
            oesavepidicator.Formula = sFormula;
            oesavepidicator.Reformulation = sReformulation;
            oesavepidicator.OrigenDatos = sorigendatos;
            oesavepidicator.metacoverageCreateBy = smetacoverageCreateBy;
            oesavepidicator.metacoverageDateBy = tmetacoverageDateBy;
            oesavepidicator.metacoverageModiBy = smetacoverageModiBy;
            oesavepidicator.metacoverageDateModiBy = tmetacoverageDateModiBy;
            odpindicator = null;
            return oesavepidicator;
        }

        /// <summary>
        /// Descripción  : Metodo para Registrar los indicadores de Medicion de Espacios  seleccionados en un Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz 
        /// </summary>
        /// <param name="iobjectid"></param>
        /// <param name="sidplanning"></param>
        /// <param name="iidindicador"></param>
        /// <param name="icolumn"></param>
        /// <param name="sSymbolName"></param>
        /// <param name="sOperating"></param>
        /// <param name="sFormula"></param>
        /// <param name="sReformulation"></param>
        /// <param name="sorigendatos"></param>
        /// <param name="smetaspaceCreateBy"></param>
        /// <param name="tmetaspaceDateBy"></param>
        /// <param name="smetaspaceModiBy"></param>
        /// <param name="tmetaspaceDateModiBy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para Registrar los indicadores de Medicion de Espacios  seleccionados en un Planning")]
        public EMetadataSpaceMeasurement_Planning Get_Register_Indicator_Space_Planning(int iobjectid, string sidplanning, int iidindicador, int icolumn, string sSymbolName, string sOperating, string sFormula, string sReformulation, string sorigendatos, string smetaspaceCreateBy, DateTime tmetaspaceDateBy, string smetaspaceModiBy, DateTime tmetaspaceDateModiBy)
        {
            DPlanning odpindicator = new DPlanning();
            EMetadataSpaceMeasurement_Planning oesavepidicator = odpindicator.Crear_Indicarores_Space_Planning(iobjectid, sidplanning, iidindicador, icolumn, sSymbolName, sOperating, sFormula, sReformulation, sorigendatos, smetaspaceCreateBy, tmetaspaceDateBy, smetaspaceModiBy, tmetaspaceDateModiBy);
            oesavepidicator.objectid = iobjectid;
            oesavepidicator.idplanning = sidplanning;
            oesavepidicator.idindicador = iidindicador;
            oesavepidicator.columnid = icolumn;
            oesavepidicator.SymbolName = sSymbolName;
            oesavepidicator.Operating = sOperating;
            oesavepidicator.Formula = sFormula;
            oesavepidicator.Reformulation = sReformulation;
            oesavepidicator.OrigenDatos = sorigendatos;
            oesavepidicator.metaspaceCreateBy = smetaspaceCreateBy;
            oesavepidicator.metaspaceDateBy = tmetaspaceDateBy;
            oesavepidicator.metaspaceModiBy = smetaspaceModiBy;
            oesavepidicator.metaspaceDateModiBy = tmetaspaceDateModiBy;
            odpindicator = null;
            return oesavepidicator;
        }


        [WebMethod(Description = "Metodo para actualizar id_planning en contenedora de formatos")]
        public DataTable Get_Update_IP_Contenedora(int idplanning, string suser)
        {

            DataTable dtup = null;
            dtup = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_UPDATE_IP_CONTENEDORA", idplanning, suser);
            return dtup;
        }

        /// <summary>
        /// Descripción  : Método para Almacenar los Items Adicionales
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz    
        /// </summary>
        /// <param name="iidcod_Point"></param>
        /// <param name="sidplanning"></param>
        /// <param name="sitemadiCreateBy"></param>
        /// <param name="titemadiDateBy"></param>
        /// <param name="sitemadModiBy"></param>
        /// <param name="TitemadDateModiBy"></param>
        /// <returns oesaveitem></returns>
        [WebMethod(Description = "Metodo para Almacenar los Items Adicionales")]
        public EAdditionalItems__Management Get_Registration_Items_Aditional(int iidcod_Point, string sidplanning, string sitemadiCreateBy, DateTime titemadiDateBy, string sitemadModiBy, DateTime TitemadDateModiBy)
        {
            DPlanning odsaveitem = new DPlanning();
            EAdditionalItems__Management oesaveitem = odsaveitem.Crear_ItemsAditional_Planning(iidcod_Point, sidplanning, sitemadiCreateBy, titemadiDateBy, sitemadModiBy, TitemadDateModiBy);
            oesaveitem.idcod_Point = iidcod_Point;
            oesaveitem.idplanning = sidplanning;
            oesaveitem.itemadiCreateBy = sitemadiCreateBy;
            oesaveitem.itemadiDateBy = titemadiDateBy;
            oesaveitem.itemadModiBy = sitemadModiBy;
            oesaveitem.itemadDateModiBy = TitemadDateModiBy;
            odsaveitem = null;
            return oesaveitem;
        }

        /// <summary>
        /// Descripción  : Metodo para Registrar los Detalle de los Formatos de Levantamiento de Información
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz    
        /// </summary>
        /// <param name="siplanning"></param>
        /// <param name="iid_cod_Point"></param>
        /// <param name="icoditem"></param>
        /// <param name="iubicacion"></param>
        /// <param name="iiddesignFor"></param>
        /// <param name="bcontenstatus"></param>
        /// <param name="scontendorCreateBy"></param>
        /// <param name="tcontenedorDateBy"></param>
        /// <param name="scontenedorModiBy"></param>
        /// <param name="tcontenedorDateModiBy"></param>
        /// <returns oesaveitemforma></returns>
        [WebMethod(Description = "Metodo para Registrar los Detalle de los Formatos de Levantamiento de Información")]
        public EContenedoraFormatos Get_RegisterItemFormato(string siplanning, int iid_cod_Point, int icoditem, int iubicacion, int iiddesignFor, bool bcontenstatus, string scontendorCreateBy, DateTime tcontenedorDateBy, string scontenedorModiBy, DateTime tcontenedorDateModiBy)
        {
            DPlanning odsaveiteformato = new DPlanning();
            EContenedoraFormatos oesaveitemforma = odsaveiteformato.CrearDetalleitemformato(siplanning, iid_cod_Point, icoditem, iubicacion, iiddesignFor, bcontenstatus, scontendorCreateBy, tcontenedorDateBy, scontenedorModiBy, tcontenedorDateModiBy);
            oesaveitemforma.idPlanning = siplanning;
            oesaveitemforma.idcodPoint = iid_cod_Point;
            oesaveitemforma.codItem = icoditem;
            oesaveitemforma.ubicacion = iubicacion;
            oesaveitemforma.iddesignFor = iiddesignFor;
            oesaveitemforma.contenstatus = bcontenstatus;
            oesaveitemforma.contendorCreateBy = scontendorCreateBy;
            oesaveitemforma.contenedorDateBy = tcontenedorDateBy;
            oesaveitemforma.contenedorModiBy = scontenedorModiBy;
            oesaveitemforma.contenedorDateModiBy = tcontenedorDateModiBy;
            odsaveiteformato = null;
            return oesaveitemforma;
        }

        [WebMethod(Description = "Metodo para Realizar el Save de Plan de ventas")]
        public ESales_Plan Get_Register_SalesPlan(int icodstrategy, int icompanyid, string sPlanningCodChannel, int iidCityPri, decimal fValuePlanCityPri, string scodcountry, decimal fValuePlanCountry, string sSalesPlanUnit, int iidMonth, int iYearsid, bool bSalesPlan_Status, string sSalesPlanCreateBy, DateTime tSalesPlanDateBy, string sSalesPlanModiBy, DateTime tSalesPlanDateModiBy)
        {
            DPlanning odsalesplan = new DPlanning();
            ESales_Plan oesalesplan = odsalesplan.Crear_Plan_Ventas(icodstrategy, icompanyid, sPlanningCodChannel, iidCityPri, fValuePlanCityPri, scodcountry, fValuePlanCountry, sSalesPlanUnit, iidMonth, iYearsid, bSalesPlan_Status, sSalesPlanCreateBy, tSalesPlanDateBy, sSalesPlanModiBy, tSalesPlanDateModiBy);

            oesalesplan.codstrategy = icodstrategy;
            oesalesplan.companyid = icompanyid;
            oesalesplan.PlanningCodChannel = sPlanningCodChannel;
            oesalesplan.idCityPri = iidCityPri;
            oesalesplan.ValuePlanCityPri = fValuePlanCityPri;
            oesalesplan.codcountry = scodcountry;
            oesalesplan.ValuePlanCountry = fValuePlanCountry;
            oesalesplan.SalesPlanUnit = sSalesPlanUnit;
            oesalesplan.idMonth = iidMonth;
            oesalesplan.Yearsid = iYearsid;
            oesalesplan.SalesPlan_Status = bSalesPlan_Status;
            oesalesplan.SalesPlanCreateBy = sSalesPlanCreateBy;
            oesalesplan.SalesPlanDateBy = tSalesPlanDateBy;
            oesalesplan.SalesPlanModiBy = sSalesPlanModiBy;
            oesalesplan.SalesPlanDateModiBy = tSalesPlanDateModiBy;
            odsalesplan = null;
            return oesalesplan;




        }

        [WebMethod(Description = "Metodo para obtener y actualizar el planning asignado en Presupuesto")]
        public EPresupuesto obtenerPlanning(string spresupuesto)
        {

            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OBTENER_IDPLANNIG", spresupuesto);
            EPresupuesto oeopla = new EPresupuesto();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {

                        oeopla.idPlanning = Convert.ToInt32(dt.Rows[i]["id_planning"].ToString().Trim());


                    }
                    return oeopla;


                }
                else
                {

                    return null;

                }
            }
            else
            {
                return null;


            }











        }

        [WebMethod(Description = "Metodo para obtener numero de planning recien generado")]
        public DataTable ObtenerIdPlanning(string spresupuesto)
        {

            DataTable dtIdplanning = oCoon.ejecutarDataTable("UP_WEBSIGE_SEARCH_PLANNINGXPRESUPUESTO", spresupuesto);
            return dtIdplanning;

        }

        /// <summary>
        /// Descripción  : Método para obtener los ejecutivos de cuenta
        /// Creado por   : Ing. Mauricio Ortiz
        /// Fecha        : 10/08/2010
        /// Modificacion : SE agrega el parametro iCompany_id. Ing : Mauricio Ortiz 30/05/2011
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <returns dtEjecutivos></returns>
        [WebMethod(Description = "Metodo para obtener el personal ejecutivo de cuenta")]
        public DataTable ObtenerEjecutivos(int iCompany_id)
        {
            DataTable dtEjecutivos = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_CONSULTAEJECUTIVOSDECUENTA", iCompany_id);
            return dtEjecutivos;
        }

        /// <summary>
        /// Descripción  : Método para obtener los supervisores y los mercaderistas
        /// Creado por   : Ing. Mauricio Ortiz
        /// Fecha        : 10/08/2010        
        /// </summary>       
        /// <param name="sid_planning"></param>
        /// <returns dsPersonal></returns>
        [WebMethod(Description = "Metodo para obtener los supervisores y los mercadersitas")]
        public DataSet ObtenerPersonal(string sid_planning)
        {
            DataSet dsPersonal = oCoon.ejecutarDataSet("UP_WEBXPLORA_PLA_CONSULTAPERSONALXPRESUPUESTO_Y_PERSON", sid_planning);
            return dsPersonal;
        }

        [WebMethod(Description = "Metodo para Actulizar el Estado de un Presupuesto a sin Asignar cuando se presenta un error el el Guardado")]
        public DataTable Get_UpdatePresupuestoxUtilizar(string spresupuesto)
        {


            DataTable dtupp = null;
            dtupp = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNIG_UPDATESTATE", spresupuesto);
            return dtupp;




        }

        [WebMethod(Description = "Metdodo para obtener el control a dibujar dependiendo el Servicio")]
        public DataSet Get_ObtnerControles(int icodstrategy, int iiditem)
        {

            DataSet ds = null;
            ds = oCoon.ejecutarDataSet("UP_WEBSIGE_VIEWCONTROLS_STRATEGY", icodstrategy, iiditem);
            return ds;





        }

        [WebMethod(Description = "Metodo para Obtener los Formatos por Servicio")]
        public DataSet Get_ObtenerFormatosxServicios(int icodstrategy)
        {

            DataSet ds = null;
            ds = oCoon.ejecutarDataSet("UP_WEBSIGE_OBTENERREPORTSXSERVICE", icodstrategy);
            return ds;



        }

        [WebMethod(Description = "Metodo para Obtener los Controles de los Formatos de Levantamiento de Informacion")]
        public DataSet Get_ObtenerControlsFormatos(int icoditem, int idcodpoint, int icodstrategy)
        {

            DataSet ds = null;
            ds = oCoon.ejecutarDataSet("UP_WEBSIGE_VIEWFORMATOS", icoditem, idcodpoint, icodstrategy);
            return ds;




        }

        /// <summary>
        /// Descripción  : Metodo para registrar los objetivos de la campaña
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz    
        /// </summary>
        /// <param name="iidplanning"></param>
        /// <param name="sobsDescription"></param>
        /// <param name="sobjCreateBy"></param>
        /// <param name="tobjDateBy"></param>
        /// <param name="sobModyBy"></param>
        /// <param name="tobjDateModyBy"></param>
        /// <returns oeobjpla></returns>
        [WebMethod(Description = "Metodo para registrar los objetivos de la Campaña")]
        public EObjetivesPlanning Get_RegisterObjPlanning(string sidplanning, string sobsDescription, string sobjCreateBy, DateTime tobjDateBy, string sobModyBy, DateTime tobjDateModyBy)
        {
            DPlanning odsplanningobj = new DPlanning();
            EObjetivesPlanning oeobjpla = odsplanningobj.Crear_ObjPlanning(sidplanning, sobsDescription, sobjCreateBy, tobjDateBy, sobModyBy, tobjDateModyBy);
            oeobjpla.id_Planning = sidplanning;
            oeobjpla.objPlaDescription = sobsDescription;
            oeobjpla.objPlaCreateBy = sobjCreateBy;
            oeobjpla.objPlaDateBy = tobjDateBy;
            oeobjpla.objPlaModiBy = sobModyBy;
            oeobjpla.objPlaDatemodiBy = tobjDateModyBy;
            odsplanningobj = null;
            return oeobjpla;


        }


        /// <summary>
        /// Descripción  : Método para registrar los Mandatorios de la Campaña
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz    
        /// </summary>
        /// <param name="iidplanning"></param>
        /// <param name="sMandtoryDescription"></param>
        /// <param name="sMandtoryCreateBy"></param>
        /// <param name="tMandtoryDateBy"></param>
        /// <param name="sMandtoryModiBy"></param>
        /// <param name="tMandtoryDateModiBy"></param>
        /// <returns oemanda></returns>
        [WebMethod(Description = "Metodo para Registrar los Mandatorios de la campaña")]
        public EMandatoryPlanning Get_RegisterMandatoryPlanning(string sidplanning, string sMandtoryDescription, string sMandtoryCreateBy, DateTime tMandtoryDateBy, string sMandtoryModiBy, DateTime tMandtoryDateModiBy)
        {
            DPlanning odsplanningmada = new DPlanning();
            EMandatoryPlanning oemanda = odsplanningmada.Crear_MandatoriosPlanning(sidplanning, sMandtoryDescription, sMandtoryCreateBy, tMandtoryDateBy, sMandtoryModiBy, tMandtoryDateModiBy);
            oemanda.id_planning = sidplanning;
            oemanda.MandtoryDescription = sMandtoryDescription;
            oemanda.MandtoryCreateBy = sMandtoryCreateBy;
            oemanda.MandtoryDateBy = tMandtoryDateBy;
            oemanda.MandtoryModiBy = sMandtoryModiBy;
            oemanda.MandtoryDateModiBy = tMandtoryDateModiBy;
            odsplanningmada = null;
            return oemanda;
        }

        /// <summary>
        /// Descripción  : Método para Registrar Mecanica de la actividad
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz    
        /// </summary>
        /// <param name="iidplanning"></param>
        /// <param name="smecaDescription"></param>
        /// <param name="smecaCreateBy"></param>
        /// <param name="tmecaDateBy"></param>
        /// <param name="smecaModyBy"></param>
        /// <param name="tmecaDateModyBy"></param>
        /// <returns oemeca></returns>
        [WebMethod(Description = "Metodo para Registrar la Mecanica de la Actividad en una ccampaña")]
        public EMechanicalActivity Get_RegisterMecanicaPlanning(string sidplanning, string smecaDescription, string smecaCreateBy, DateTime tmecaDateBy, string smecaModyBy, DateTime tmecaDateModyBy)
        {
            DPlanning odmeca = new DPlanning();
            EMechanicalActivity oemeca = odmeca.Crear_MecanicaPlanning(sidplanning, smecaDescription, smecaCreateBy, tmecaDateBy, smecaModyBy, tmecaDateModyBy);
            oemeca.idPlanning = sidplanning;
            oemeca.MechanicalActivityDescription = smecaDescription;
            oemeca.MechanicalActivityCreateBy = smecaCreateBy;
            oemeca.MechanicalActivityDateBy = tmecaDateBy;
            oemeca.MechanicalActivityModyBy = smecaModyBy;
            oemeca.MechanicalActivityDateModyBy = tmecaDateModyBy;
            odmeca = null;
            return oemeca;
        }

        [WebMethod(Description = "Metodo para Registrar PDV Planning")]
        public DataTable Get_Insertar_PDV_Planning()
        {

            DataTable dtregi = null;
            dtregi = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_INSERTPDVPALNNING");
            return dtregi;



        }

        [WebMethod(Description = "Metodo para Registrar PDV en Consulta")]
        public DataTable Get_Insertar_PDV_PlanningUPD(int iidplanning)
        {

            DataTable dtregiupd = null;
            dtregiupd = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_INSERTPDVPALNNINGUPD", iidplanning);
            return dtregiupd;



        }

        [WebMethod(Description = "Metodo para obtener PDV Cargados en Pdv_tmp")]
        public DataTable Get_ObtenerPdvtmp(string snameuser)
        {

            DataTable dtpdvtmp = null;
            dtpdvtmp = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERPDVTMP", snameuser);
            return dtpdvtmp;




        }

        [WebMethod(Description = "Metodo para Obtener Puntos de venta a Actualizar")]
        public DataTable Get_ObtenerPDVxActulizar(string snameuser, string spdv)
        {

            DataTable dtopdv = null;
            dtopdv = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERPDVXACTUA", snameuser, spdv);
            return dtopdv;




        }

        [WebMethod(Description = "Metodo Para consultar Operativos no asignados a Planning")]
        public DataTable Get_Otener_OperativosAdd()
        {

            DataTable dtope = null;
            dtope = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENEROPERATIVOSSINASIGNAR");
            return dtope;



        }
        //Se Agrega el parametro pais para controlar la division politica en la carga de PDV
        [WebMethod(Description = "Metodo para Obtener Codigos de PDV no Actualizados")]
        public DataTable Get_ObtenercodPdvNoUpdate(string snameuser, string scodcountry)
        {

            DataTable dtcpna = null;
            dtcpna = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERDATECODENOACTULIZADOS", snameuser, scodcountry);
            return dtcpna;







        }
        [WebMethod(Description = "Metodo para Eliminar Datos de PDV_tmp cuando no son cargados correctamente")]
        public DataTable Get_DeletePDvtmpNoLoad(string snameuser)
        {

            DataTable dtdelpdv = null;
            dtdelpdv = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_DELETEPDVTMPNOVALIDOS", snameuser);
            return dtdelpdv;
        }

        [WebMethod(Description = "Metodo para validación carga masiva de puntos de venta")]
        public DataTable Get_ValidaCargaPDV(string sValidar, string sCountry, string sValor, string sValor2)
        {

            DataTable dtValidaDataPDV = null;
            dtValidaDataPDV = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_VALIDADATAPDV", sValidar, sCountry, sValor, sValor2);
            return dtValidaDataPDV;
        }


        #region Metodos para obtener filtros de asignaciones por Canal
        [WebMethod(Description = "Metodo para Consultar los Clientes con Campañas Activas")]
        public DataTable Get_ObtenerClientesxcampañasActivas()
        {

            DataTable dtcosucli = null;
            dtcosucli = oCoon.ejecutarDataTable("UP_WEB_ASIGNACIONECANAL_CLIENTESACTIVOS");
            return dtcosucli;

        }
        [WebMethod(Description = "Metodo para obtener canales x Clientes con Planning Activos")]
        public DataTable Get_ObtenerChannelxServicio(int icompanyid)
        {

            DataTable dtchannel = null;
            dtchannel = oCoon.ejecutarDataTable("UP_WEB_ASIGNACIONECANAL_CANALES", icompanyid);
            return dtchannel;

        }


        [WebMethod(Description = "Metodo para obtener Servicios con Base en Clientet Activos")]
        public DataTable Get_ObtenerServicesxClienteA(int icompanyid)
        {


            DataTable dtseervices = null;
            dtseervices = oCoon.ejecutarDataTable("UP_WEB_DIRECTOR_CUENTA_SERVICESXCLIENTE", icompanyid);
            return dtseervices;



        }

        [WebMethod(Description = "Metodo parra obtener Categorias para Planning")]
        public DataTable Get_ObtenerCategoriasPlanning(int icompanyid)
        {

            DataTable dtcategopla = null;
            dtcategopla = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_OBTENERCATEGORIAS_PARAPLA", icompanyid);
            return dtcategopla;
        }

        /// <summary>
        /// Descripción    : Método para obtener los competidores asociados a un cliente
        /// Creado por     : Ing. Mauricio Ortiz
        /// Fecha creación : 30/08/2010
        /// </summary>
        /// <param name="icompanyid"></param>
        /// <returns>dtCompetidores</returns>
        [WebMethod(Description = "Método para obtener los competidores asociados a un cliente")]
        public DataTable Get_ObtenerCompetidoresCliente(int icompanyid)
        {
            DataTable dtCompetidores = null;
            dtCompetidores = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_BUSCARCOMPETIDORES", icompanyid);
            return dtCompetidores;
        }

        [WebMethod(Description = "Metodo parra obtener categorias En Asignacion por Canal")]
        public DataTable Get_ObtenerCategoriasPla(int icompanyid, string scodchannel)
        {

            DataTable dtcatego = null;
            dtcatego = oCoon.ejecutarDataTable("UP_WESIGE_PLANNING_OBTENERCATEGORIAS", icompanyid, scodchannel);
            return dtcatego;



        }
        [WebMethod(Description = "Metodo para Obtener Presentaciones x Categoria")]
        public DataTable Get_Obtener_PresentacionesxCategoria(string scategoria)
        {

            DataTable dtprese = null;
            dtprese = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_CATEGORIAS_PRESENTACIONES", scategoria);
            return dtprese;




        }

        [WebMethod(Description = "Metodo para Obtener Presentaciones en Asignaciones xCanal")]
        public DataTable Get_ObtenerPresentacionesxCategoriaAsignacionCanal(int icocatego, int icompanyid, string scodchannel)
        {

            DataTable dtpresenta = oCoon.ejecutarDataTable("UP_WESIGE_PLANNING_OBTENERPRESENTACIONESPLANNING", icocatego, icompanyid, scodchannel);
            return dtpresenta;




        }
        [WebMethod(Description = "Metodo Para Obtener Fotografias en Asignaciones x Canal")]
        public DataTable Get_Obtener_Photos_Asignacionxcanal(int icompanyid, string scodchannel, DateTime tfechatoma, DateTime tfechatoma2, int iidplanning, int ipdv)
        {

            DataTable dtphotos = null;
            dtphotos = oCoon.ejecutarDataTable("UP_WEBSIGE_ASIGNACION_LOADPHOTOS", icompanyid, scodchannel, tfechatoma, tfechatoma2, iidplanning, ipdv);
            return dtphotos;
        }

        [WebMethod(Description = "Metodo Para Obtener cantidad de fotos en nivel general por cliente")]
        public DataTable Get_Obtener_Photos_general(int icompanyid, string sCodChannel)
        {

            DataTable dtphotos = null;
            dtphotos = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_GENERAL", icompanyid, sCodChannel);
            return dtphotos;
        }

        [WebMethod(Description = "Metodo Para Obtener cantidad de fotos en nivel detallado por cliente")]
        public DataTable Get_Obtener_Photos_detallado(int icompanyid, string sCodChannel)
        {

            DataTable dtphotos = null;
            dtphotos = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_DETALLADO", icompanyid, sCodChannel);
            return dtphotos;
        }


        [WebMethod(Description = "Metodo para obtner los planning por campaña")]
        public DataTable Get_ObtenerPlanningxCampaña()
        {

            DataTable dtplacampa = null;
            dtplacampa = oCoon.ejecutarDataTable("UP_WEB_DIRECTOR_CUENTA_CAMPAÑASASIGNADAS");
            return dtplacampa;



        }
        [WebMethod(Description = "Metodo para obtner los producto para plande ventas por planning")]
        public DataTable Get_ObtenerProductPlanventas(int icodecatego)
        {

            DataTable dtplan = null;
            dtplan = oCoon.ejecutarDataTable("UP_WEB_DIRECTOR_CUENTA_PRODUCTSPLANVENTAS", icodecatego);
            return dtplan;


        }

        [WebMethod(Description = "Metodo Para Obtener las fotografias de las Campañas")]
        public DataTable Get_ObtenerPhostos_Actividades(int icompanyid, int icodstrategy)
        {

            DataTable dtphotos = null;
            dtphotos = oCoon.ejecutarDataTable("UP_WEBSIGE_ASIGNACIONCANAL_LOADPHOTOS", icompanyid, icodstrategy);
            return dtphotos;





        }

        [WebMethod(Description = "Metodo para registrar las Presentaciones en Asignaciones por Canal")]

        public EAssignment__Presentations Get_Register_Presentaciones_Asignacionesxcanal(string sidProductCategory, int iidProduct, int iid_productprincipal, int icompanyid, int icodstrategy, string sPresentaCompetition1, string sPresentaCompetition2, string sPresentaCompetition3, string scod_Channel, bool bAssignment_Status, string sproductServiceCreateBy, DateTime tproductServiceDateBy, string sproductServiceModiBy, DateTime tproductServiceDateModiBy)
        {
            DPlanning odplapre = new DPlanning();
            EAssignment__Presentations oeapre = odplapre.Crear_Presentaciones_AsignacionCanal(sidProductCategory, iidProduct, iid_productprincipal, icompanyid, icodstrategy, sPresentaCompetition1, sPresentaCompetition2, sPresentaCompetition3, scod_Channel, bAssignment_Status, sproductServiceCreateBy, tproductServiceDateBy, sproductServiceModiBy, tproductServiceDateModiBy);
            oeapre.idProductCategory = sidProductCategory;
            oeapre.idProduct = iidProduct;
            oeapre.idproductprincipal = iid_productprincipal;
            oeapre.companyid = icompanyid;
            oeapre.codstrategy = icodstrategy;
            oeapre.PresentaCompetition1 = sPresentaCompetition1;
            oeapre.PresentaCompetition2 = sPresentaCompetition2;
            oeapre.PresentaCompetition3 = sPresentaCompetition3;
            oeapre.cod_Channel = scod_Channel;
            oeapre.Assignment_Status = bAssignment_Status;
            oeapre.productServiceCreateBy = sproductServiceCreateBy;
            oeapre.productServiceDateBy = tproductServiceDateBy;
            oeapre.productServiceModiBy = sproductServiceModiBy;
            oeapre.productServiceDateModiBy = tproductServiceDateModiBy;
            odplapre = null;
            return oeapre;




        }
        [WebMethod(Description = "Metodo Para registrar Ciudad Principal")]
        public ECity_Principal_Service Get_Register_City_Principal(string scod_City, int iCod_Strategy, string sCod_Channel, int icompany_id, bool bCityPri_Status, string sCityPri_CreateBy, DateTime tCityPri_DateBy,
                    string sCityPri_ModiBy, DateTime tCityPri_DateModiBy)
        {
            DPlanning odcp = new DPlanning();
            ECity_Principal_Service oecp = odcp.Crear_Ciudad_Principal(scod_City, iCod_Strategy, sCod_Channel, icompany_id, bCityPri_Status, sCityPri_CreateBy, tCityPri_DateBy, sCityPri_ModiBy, tCityPri_DateModiBy);
            oecp.cod_City = scod_City;
            oecp.CodStrategy = iCod_Strategy;
            oecp.CodChannel = sCod_Channel;
            oecp.company_id = icompany_id;
            oecp.CityPriStatus = bCityPri_Status;
            oecp.CityPriCreateBy = sCityPri_CreateBy;
            oecp.CityPriDateBy = tCityPri_DateBy;
            oecp.CityPriModiBy = sCityPri_ModiBy;
            oecp.CityPriDateModiBy = tCityPri_DateModiBy;
            odcp = null;
            return oecp;
        }

        [WebMethod(Description = "Metodo Para MODIFICAR estado de Ciudad Principal al decicir cambiarla")]
        public ECity_Principal_Service Get_Modify_City_Principal(string sCod_Channel, int icompany_id, bool bCityPri_Status, string sCityPri_ModiBy, DateTime tCityPri_DateModiBy)
        {
            DPlanning odcp = new DPlanning();
            ECity_Principal_Service oecp = odcp.Modify_Ciudad_Principal(sCod_Channel, icompany_id, bCityPri_Status, sCityPri_ModiBy, tCityPri_DateModiBy);

            oecp.CodChannel = sCod_Channel;
            oecp.company_id = icompany_id;
            oecp.CityPriStatus = bCityPri_Status;
            oecp.CityPriModiBy = sCityPri_ModiBy;
            oecp.CityPriDateModiBy = tCityPri_DateModiBy;
            odcp = null;
            return oecp;
        }


        [WebMethod(Description = "Metodo Para MODIFICAR estado de asignacion de presentaciones por categoria cliente y canal al decicir cambiarla")]
        public EAssignment__Presentations Get_Modify_Assignment__Presentations(string scod_Channel, string sidProductCategory, int icompanyid, bool bAssignment_Status, string sproductServiceModiBy, DateTime tproductServiceDateModiBy)
        {
            DPlanning odap = new DPlanning();
            EAssignment__Presentations oeap = odap.Modify_Assignment__Presentations(scod_Channel, sidProductCategory, icompanyid, bAssignment_Status, sproductServiceModiBy, tproductServiceDateModiBy);

            oeap.cod_Channel = scod_Channel;
            oeap.idProductCategory = sidProductCategory;
            oeap.companyid = icompanyid;
            oeap.Assignment_Status = bAssignment_Status;
            oeap.productServiceModiBy = sproductServiceModiBy;
            oeap.productServiceDateModiBy = tproductServiceDateModiBy;

            odap = null;
            return oeap;
        }

        [WebMethod(Description = "Metodo Para MODIFICAR estado de asignacion de la presentacion por categoria cliente y canal al decicir cambiarla")]
        public EAssignment__Presentations Get_Modify_Assignment__PresentationXCategoria(string scod_Channel, string sidProductCategory, int iidProduct, int icompanyid, bool bAssignment_Status, string sproductServiceModiBy, DateTime tproductServiceDateModiBy)
        {
            DPlanning odap = new DPlanning();
            EAssignment__Presentations oeap = odap.Modify_Assignment__PresentationXCategoria(scod_Channel, sidProductCategory, iidProduct, icompanyid, bAssignment_Status, sproductServiceModiBy, tproductServiceDateModiBy);

            oeap.cod_Channel = scod_Channel;
            oeap.idProductCategory = sidProductCategory;
            oeap.idProduct = iidProduct;
            oeap.companyid = icompanyid;
            oeap.Assignment_Status = bAssignment_Status;
            oeap.productServiceModiBy = sproductServiceModiBy;
            oeap.productServiceDateModiBy = tproductServiceDateModiBy;

            odap = null;
            return oeap;
        }


        [WebMethod(Description = "Metodo Para Obtener las presentaciones de la competencia del producto principal")]
        public DataTable Get_ObtenerPresentCompeXProductPrincipal(int iid_Product)
        {

            DataTable dt = null;
            dt = oCoon.ejecutarDataTable("UP_WEBSIGE_ASIGNACION_CANAL_CONSULTAPRESETENCOMPEXPRODUCTPRINCIPAL", iid_Product);
            return dt;
        }

        #endregion


        #region Metodos de Actualizacion Planning

        [WebMethod(Description = "Metodo para Actulizar Fechas en Presupuesto")]
        public DataTable Get_Update_Fechas_Presupuesto(DateTime tfecini, DateTime tfecfin, string snumbrepresu)
        {

            DataTable dtupfe = null;
            dtupfe = oCoon.ejecutarDataTable("UP_WEBSIGE_UPDATEFECHAS_PRESUPUESTO", tfecini, tfecfin, snumbrepresu);
            return dtupfe;



        }

        [WebMethod(Description = "Metodo para Actualizar los campos editables en Presupuesto")]
        public EPresupuesto Get_Update_Presupuesto(string sNumberbudget, string sprenew, string snamepresu, DateTime tFeciniPlanning, DateTime tFecFinPlanning, string sbudgetModiBy, DateTime tbudgetDateModiBy)
        {

            DPlanning oduppre = new DPlanning();
            EPresupuesto oePresupuesto = oduppre.Actualizar_Presupuestos(sNumberbudget, sprenew, snamepresu, tFeciniPlanning, tFecFinPlanning, sbudgetModiBy, tbudgetDateModiBy);

            oePresupuesto.Numberbudget = sprenew;
            oePresupuesto.Namebudget = snamepresu;
            oePresupuesto.FeciniPlanning = tFeciniPlanning;
            oePresupuesto.FecFinPlanning = tFecFinPlanning;
            oePresupuesto.budgetModiBy = sbudgetModiBy;
            oePresupuesto.budgetDateModiBy = tbudgetDateModiBy;
            oduppre = null;
            return oePresupuesto;
        }

        /// <summary>
        /// descripción  : Método para Actualizar Objetivos de Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz    
        /// </summary>
        /// <param name="sobjPlaDescription"></param>
        /// <param name="sobjPlaModiBy"></param>
        /// <param name="tobjPlaDatemodiBy"></param>
        /// <param name="sidplanning"></param>
        /// <returns oeupObjetivos ></returns>
        [WebMethod(Description = "Metodo para Actualizar Objetivos de Planning")]
        public EObjetivesPlanning Get_Update_Objetives_Planning(string sobjPlaDescription, string sobjPlaModiBy, DateTime tobjPlaDatemodiBy, string sidplanning)
        {
            DPlanning odupobj = new DPlanning();
            EObjetivesPlanning oeupObjetivos = odupobj.Actualizar_Objetivos_Planning(sobjPlaDescription, sobjPlaModiBy, tobjPlaDatemodiBy, sidplanning);
            oeupObjetivos.objPlaDescription = sobjPlaDescription;
            oeupObjetivos.objPlaModiBy = sobjPlaModiBy;
            oeupObjetivos.objPlaDatemodiBy = tobjPlaDatemodiBy;
            oeupObjetivos.id_Planning = sidplanning;
            odupobj = null;
            return oeupObjetivos;
        }

        /// <summary>
        /// Descripción  : Metodo para Actualizar Mecanica de la Actividad de Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz       
        /// </summary>
        /// <param name="sMechanicalActivityDescription"></param>
        /// <param name="sMechanicalActivityModyBy"></param>
        /// <param name="tMechanicalActivityDateModyBy"></param>
        /// <param name="sidplanning"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para Actualizar Mecanica de la Actividad de Planning")]
        public EMechanicalActivity Get_Update_Mecanica_Planning(string sMechanicalActivityDescription, string sMechanicalActivityModyBy, DateTime tMechanicalActivityDateModyBy, string sidplanning)
        {
            DPlanning odupmeca = new DPlanning();
            EMechanicalActivity oeupmeca = odupmeca.Actualizar_Mecanica_Planning(sMechanicalActivityDescription, sMechanicalActivityModyBy, tMechanicalActivityDateModyBy, sidplanning);
            oeupmeca.MechanicalActivityDescription = sMechanicalActivityDescription;
            oeupmeca.MechanicalActivityModyBy = sMechanicalActivityModyBy;
            oeupmeca.MechanicalActivityDateModyBy = tMechanicalActivityDateModyBy;
            oeupmeca.idPlanning = sidplanning;
            odupmeca = null;
            return oeupmeca;
        }

        /// <summary>
        /// Descripción  : Método para Actualizar Mandatorios de Planning
        /// Modificación : 29/07/2010 Se cambia tipo de dato en id_planning de int a string                
        ///                Ing. Mauricio Ortiz            
        /// </summary>
        /// <param name="sMandtoryDescription"></param>
        /// <param name="sMandtoryModiBy"></param>
        /// <param name="tMandtoryDateModiBy"></param>
        /// <param name="sidplanning"></param>
        /// <returns oeupmanda></returns>
        [WebMethod(Description = "Metodo para Actualizar Mandatorios de Planning")]
        public EMandatoryPlanning Get_Update_Mandatorios_Planning(string sMandtoryDescription, string sMandtoryModiBy, DateTime tMandtoryDateModiBy, string sidplanning)
        {
            DPlanning odupmanda = new DPlanning();
            EMandatoryPlanning oeupmanda = odupmanda.Actualizar_Mandatorios_Planning(sMandtoryDescription, sMandtoryModiBy, tMandtoryDateModiBy, sidplanning);
            oeupmanda.MandtoryDescription = sMandtoryDescription;
            oeupmanda.MandtoryModiBy = sMandtoryModiBy;
            oeupmanda.MandtoryDateModiBy = tMandtoryDateModiBy;
            oeupmanda.id_planning = sidplanning;
            odupmanda = null;
            return oeupmanda;




        }
        [WebMethod(Description = "Metodo para Actulizar codigos en Datos cargados en PDV_temp")]

        public DataSet Get_UpdatePDVTmpCod(string snamecountry, string snamedpto, string snameprovince, string snamedistrict, string snameComunity, string snamechannel, string snamenodetype, string snamenodeComercial, string snameSegmen)
        {

            DataSet dsupdv = null;
            dsupdv = oCoon.ejecutarDataSet("UP_WEBSIGE_PLANNING_UPDATECODPDV", snamecountry, snamedpto, snameprovince, snamedistrict, snameComunity, snamechannel, snamenodetype, snamenodeComercial, snameSegmen);
            return dsupdv;




        }

        /// <summary>
        /// Método para registrar puntos de venta desde planningstring spdvCode
        /// Módificación 25/08/2010 se quita paraemtro spdvCode ya que el campo ya no esta en la tabla. Ing. Mauricio Ortiz
        /// Modificacion 22/08/2011 se agrega la variable Alias. Carlos marin
        /// </summary>
        /// <param name="sid_typeDocument"></param>
        /// <param name="spdvRegTax"></param>
        /// <param name="spdvcontact1"></param>
        /// <param name="spdvposition1"></param>
        /// <param name="spdvcontact2"></param>
        /// <param name="spdvposition2"></param>
        /// <param name="spdvRazónSocial"></param>
        /// <param name="spdvName"></param>
        /// <param name="spdvPhone"></param>
        /// <param name="spdvAnexo"></param>
        /// <param name="spdvFax"></param>
        /// <param name="spdvcodCountry"></param>
        /// <param name="spdvcodDepartment"></param>
        /// <param name="spdvcodProvince"></param>
        /// <param name="spdvcodDistrict"></param>
        /// <param name="spdvcodCommunity"></param>
        /// <param name="spdvAddress"></param>
        /// <param name="spdvemail"></param>
        /// <param name="spdvcodChannel"></param>
        /// <param name="iidNodeComType"></param>
        /// <param name="sNodeCommercial"></param>
        /// <param name="iid_Segment"></param>
        /// <param name="bpdvstatus"></param>
        /// <param name="sPdvCreateBy"></param>
        /// <param name="tPdvDateBy"></param>
        /// <param name="sPdvModiBy"></param>
        /// <param name="tPdvDateModiBy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para registrar puntos de venta desde planning")]
        public EPuntosDV RegistrarPDV(string sid_typeDocument, string spdvRegTax,
         string spdvcontact1, string spdvposition1, string spdvcontact2, string spdvposition2, string spdvRazónSocial,
         string spdvName, string spdvPhone, string spdvAnexo, string spdvFax, string spdvcodCountry, string spdvcodDepartment,
         string spdvcodProvince, string spdvcodDistrict, string spdvcodCommunity, string spdvAddress, string spdvemail,
         string spdvcodChannel, int iidNodeComType, string sNodeCommercial, int iid_Segment, bool bpdvstatus, string sPdvCreateBy, DateTime tPdvDateBy,
         string sPdvModiBy, DateTime tPdvDateModiBy)
        {

            Lucky.Data.Common.Application.DPuntosDV odrPDV = new Lucky.Data.Common.Application.DPuntosDV();
            EPuntosDV oepdv = odrPDV.registrarPDVPK(sid_typeDocument, spdvRegTax,
             spdvcontact1, spdvposition1, spdvcontact2, spdvposition2, spdvRazónSocial,
             spdvName, spdvPhone, spdvAnexo, spdvFax, spdvcodCountry, spdvcodDepartment,
             spdvcodProvince, spdvcodDistrict, spdvcodCommunity, spdvAddress, spdvemail,
             spdvcodChannel, iidNodeComType, sNodeCommercial, iid_Segment,  bpdvstatus, sPdvCreateBy, tPdvDateBy,
             sPdvModiBy, tPdvDateModiBy);

            odrPDV = null;
            return oepdv;
        }

        /// <summary>
        /// Método que permite registrar Clientes del PDV
        /// Módificación : 26/08/2010 se agrega parametro sClientPDV_Code y iid_sector. Ing. Mauricio Ortiz
        ///                12/11/2010 se agrega parametro lcod_Oficina . Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="iid_PointOfsale"></param>
        /// <param name="sClientPDV_Code"></param>
        /// <param name="iid_sector"></param>
        /// <param name="lCod_Oficina"></param>
        /// <param name="bClientPDV_Status"></param>
        /// <param name="sClientPDV_CreateBy"></param>
        /// <param name="tClientPDV_DateBy"></param>
        /// <param name="sClientPDV_ModiBy"></param>
        /// <param name="tClientPDV_DateModiBy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para registrar cliente para los puntos de venta")]
        public EPuntosDV RegistrarClientPDV(int iCompany_id, int iid_PointOfsale, string sClientPDV_Code, int iid_sector, long lCod_Oficina,  int iId_Dex, bool bClientPDV_Status,
            string sClientPDV_CreateBy, DateTime tClientPDV_DateBy, string sClientPDV_ModiBy, DateTime tClientPDV_DateModiBy, string pdv_alias)
        {
            Lucky.Data.Common.Application.DPuntosDV odrPDV = new Lucky.Data.Common.Application.DPuntosDV();
            EPuntosDV oepdv = odrPDV.registrarClientPDVPK(iCompany_id, iid_PointOfsale, sClientPDV_Code, iid_sector, lCod_Oficina,iId_Dex, bClientPDV_Status,
             sClientPDV_CreateBy, tClientPDV_DateBy, sClientPDV_ModiBy, tClientPDV_DateModiBy, pdv_alias);
            odrPDV = null;
            return oepdv;
        }

        /// <summary>
        /// Descripción : Método para validar si existe un puntos de venta para un planning
        /// Creado por  : Ing. Mauricio Ortiz
        /// Fecha       : 26/08/2010
        /// </summary>
        /// <param name="iid_ClientPDV"></param>
        /// <param name="sid_Planning"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para validar si existe un puntos de venta para un planning")]
        public DataTable Get_DuplicadoPDVPlanning(int iid_ClientPDV, string sid_Planning)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_BUSCAR_DUPLICADO_PDVPLANNING", iid_ClientPDV, sid_Planning);
            return dt;
        }

        /// <summary>
        /// Método para registrar puntos de venta para un planning
        /// Modificación: 26/08/2010 se cambia tipo de dato del parametro @id_Planning de int a varchar(20),
        ///               se cambia parametro @id_PointOfSale por @id_ClientPDV . Ing. Mauricio Ortiz
        ///               15/11/2010 se adicionan nuevos parametros para almacenar cod_city, tipo de agrupacion y 
        ///               agrupacion, oficina  , malla y sector.  Ing. Mauricio Ortiz               
        /// </summary>        
        /// <param name="iid_ClientPDV"></param>
        /// <param name="sid_Planning"></param>
        /// <param name="scod_City"></param>
        /// <param name="iidNodeComType"></param>
        /// <param name="sNodeCommercial"></param>
        /// <param name="lcod_Oficina"></param>
        /// <param name="iid_malla"></param>
        /// <param name="iid_Sector"></param>
        /// <param name="bPointOfSalePlanning_Status"></param>
        /// <param name="sPointOfSalePlanning_CreateBy"></param>
        /// <param name="tPointOfSalePlanning_DateBy"></param>
        /// <param name="sPointOfSalePlanning_ModiBy"></param>
        /// <param name="tPointOfSalePlanning_DateModiBy"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para registrar puntos de venta para un planning")]
        public DataTable Get_registrarPDVPlanning(int iid_ClientPDV,
                string sid_Planning, string scod_City, int iidNodeComType, string sNodeCommercial,
            long lcod_Oficina, int iid_malla, int iid_Sector, bool bPointOfSalePlanning_Status, string sPointOfSalePlanning_CreateBy,
                     DateTime tPointOfSalePlanning_DateBy, string sPointOfSalePlanning_ModiBy, DateTime tPointOfSalePlanning_DateModiBy, string pdv_contact)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_PLANNING_INSERTARPDVPLANNING", 
                iid_ClientPDV,
                sid_Planning, 
                scod_City, 
                iidNodeComType, 
                sNodeCommercial, 
                lcod_Oficina, 
                iid_malla, 
                iid_Sector, 
                bPointOfSalePlanning_Status, 
                sPointOfSalePlanning_CreateBy,
                tPointOfSalePlanning_DateBy, 
                sPointOfSalePlanning_ModiBy, 
                tPointOfSalePlanning_DateModiBy, 
                pdv_contact);
            return dt;
        }



        #endregion

        /// <summary>
        /// Descripción : "Método para insertar información de carga de Reportes de Cliente"
        /// Creado por  : Ing.Carlos Alberto Hernández Rincón
        /// Fecha       : 06/05/2010
        /// Modificación : Se agrega el campo Report_Id Ing. Carlos Hernández
        ///                12/08/2010 Se modifica parametro id_planning de int a varchar(20)
        ///                se cambia nombre del store UP_WEBSIGE_PLANNING_CARGAREPORTESCAMPAÑAS
        ///                por UP_WEBXPLORA_PLA_CARGAREPORTESCAMPAÑAS de acuerdo a las nuevas
        ///                metricas .  Ing. Mauricio Ortiz
        ///                20/09/2010 se adiciona el parametro smesinforme para indicar a que mes 
        ///                corresponde el informe Ing. Mauricio Ortiz
        ///                Se agrega el parametro scodcity Ing. Carlos Hernandez 05/10/2010
        ///                13/04/2011 se adiciona escenario para cuando aplica subcanal y paraemtro @cod_subchannel. Ing. Mauricio Ortiz
        ///                18/04/2011 se adiciona el parametro @cod_Subnivel . Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="sescenario"></param>
        /// <param name="sidplanning"></param>
        /// <param name="icompanyid"></param>
        /// <param name="iReportId"></param>
        /// <param name="scodchannel"></param>
        /// <param name="scod_subchannel"></param>
        /// <param name="scod_Subnivel"></param>
        /// <param name="icodservice"></param>
        /// <param name="scountry"></param>
        /// <param name="scodcity"></param>
        /// <param name="snamereport"></param>
        /// <param name="smesinforme"></param>
        /// <param name="sruta"></param>
        /// <param name="bstatus"></param>
        /// <param name="sinfoCreateBy"></param>
        /// <param name="tinfoDateBy"></param>
        /// <param name="sinfoModyBy"></param>
        /// <param name="tinfoDateModiBy"></param>
        /// <returns dsinfo></returns>
        [WebMethod(Description = "Metodo para insertar información de carga de Reportes de Cliente")]
        public DataSet Get_InsertaInfoReportes(string sescenario ,string sidplanning, int icompanyid, int iReportId, string scodchannel, string scod_subchannel, 
            string scod_Subnivel, int icodservice, string scountry, string scodcity, string snamereport, string sruta, string smesinforme, bool bstatus, string sinfoCreateBy, DateTime tinfoDateBy, string sinfoModyBy, DateTime tinfoDateModiBy)
        {
            DataSet dsinfo = null;
            dsinfo = oCoon.ejecutarDataSet("UP_WEBXPLORA_PLA_CARGAREPORTESCAMPAÑAS", sescenario, sidplanning, icompanyid, iReportId, scodchannel, scod_subchannel, scod_Subnivel, icodservice, scountry, scodcity, snamereport, sruta, smesinforme, bstatus, sinfoCreateBy, tinfoDateBy, sinfoModyBy, tinfoDateModiBy);
            return dsinfo;
        }

        /// <summary>
        /// Descripción  : Método para obtener los reportes en estado habilitado
        /// Modificación : 30/07/2010 se cambia nombre al SP UP_WEBXPLORA_OBTENERREPORTS por 
        ///                UP_WEBXPLORA_PLA_OBTENERREPORTES de acuerdo a metricas establecidas.
        ///                Ing. Mauricio Ortiz
        /// </summary>
        /// <returns dtrp></returns>
        [WebMethod(Description = "Metodo para obtener los reportes en estado habilitado")]
        public DataTable Get_Obtener_Reportes_Cliente()
        {
            DataTable dtrp = null;
            dtrp = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_OBTENERREPORTES");
            return dtrp;
        }

        [WebMethod(Description = "Metodo para Obtener Campañas x Cliente")]
        public DataTable Get_ObtenerCampañasxCliente(int iperson_id)
        {

            DataTable dtpla = null;
            dtpla = oCoon.ejecutarDataTable("UP_WEBXPLORA_OBTENERCAMPAÑASXCLIETE", iperson_id);
            return dtpla;




        }

        /// <summary>
        /// Descripción  : Método para Obtener Clientes con planning por Pais seleccionado
        /// Modificación : 30/07/2010 se cambia nombre al SP UP_WEBSIGE_PLANNING_OBTENERCLIENTESCONPLANNING 
        ///                por UP_WEBXPLORA_PLA_OBTENERCLIENTESCONPLANNING  de acuerdo a metricas establecidas.
        ///                Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="scod_country"></param>
        /// <returns dt></returns>
        [WebMethod(Description = "Método para Obtener Clientes con planning por Pais seleccionado")]
        public DataTable Get_ObtenerClienteconPlanning(string scod_country, string snivel, int icompany)
        {
            DataTable dt = null;
            dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_OBTENERCLIENTESCONPLANNING", scod_country, snivel, icompany);
            return dt;
        }


        [WebMethod(Description = "Metodo para Obtener Datos usuarios Clientes")]
        public DataTable Get_Obtener_Datos_Cliente(int tipo_lista, int icompanyid, int iperson_id, string scod_channel, int icodstrategy, string sCreateBy)
        {
            DataTable dtcli = null;
            dtcli = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLANNING_OBTENEREMAILUSERS", tipo_lista, icompanyid, iperson_id, scod_channel, icodstrategy, sCreateBy);
            return dtcli;
        }

        /// <summary>
        /// Descripción : Método para actualizar el estado del envio de los correos electronicos con los informes 
        /// Creado por  : Ing. Mauricio Ortiz
        /// Fecha       : 07/10/2010
        /// Modificación: 20/10/2010 Ing. Mauricio Ortiz se cambia parametro de entrada sCreateBy por sfechavalida
        ///               29/10/2010 Ing. Mauricio Ortiz se adiciona parametros sModiBy y tDateModiBy para actualizar estos campos
        /// </summary>       
        /// <param name="sfechavalida"></param>
        /// <returns>dtestadoenvio</returns>
        [WebMethod(Description = "Metodo para Actualizar estado del envio mail ")]
        public DataTable Get_Actualiza_EstadoEnvioMail(string sfechavalida, string sModiBy, DateTime tDateModiBy)
        {
            DataTable dtestadoenvio = null;
            dtestadoenvio = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_ACTUALIZAESTADOENVIOMAIL", sfechavalida, sModiBy, tDateModiBy);
            return dtestadoenvio;
        }




        /// <summary>
        /// Description  : Consulta informes cargados
        /// Modificación : se cambia nombre del sp de acuerdo a las métricas establecidas
        ///                UP_WEBSIGE_PLANNING_CONSULTA_INFORMES por UP_WEBXPLORA_PLA_CONSULTAINFORMESCARGADOS
        ///                Modificacion: Se agrega el parametro slevel para suplir requerimiento de Lucky Operaciones por el cual debe existir
        ///                un usuario que pueda visualizar y eliminar reportes cargados Ing. Carlos Hernández 18/08/2010
        ///                20/09/2010 se adiciona parametro @info_mesinforme y se agregan caminos
        ///                que permitan filtrar por mes Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="scod_Channel"></param>
        /// <param name="sinfo_mesinforme"></param>
        /// <param name="sinfo_CreateBy"></param>
        /// <param name="ivalor"></param>
        /// <returns dt></returns>
        [WebMethod(Description = "Consulta informes cargados")]
        public DataTable Get_ConsultainformesCargados(int iCompany_id, string scod_Channel, string sinfo_mesinforme, string sinfo_CreateBy, int ivalor, string slevel)
        {

            DataTable dt = null;
            dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_CONSULTAINFORMESCARGADOS", iCompany_id, scod_Channel, sinfo_mesinforme, sinfo_CreateBy, ivalor, slevel);
            return dt;
        }

        [WebMethod(Description = "Eliminar información tabla Info_Planning")]
        public DataSet Get_EliminarInfoPlanning(string sruta_reporte, string scod_channel)
        {
            info_Planning binfo_Planning = new info_Planning();
            DataSet ds = null;
            ds = binfo_Planning.Eliminar_Info_Planning(sruta_reporte, scod_channel);
            return ds;

        }

        /// <summary>
        /// Metodo Para Buscar Informe a Eliminar
        /// Creado Por: Ing. Carlos Alberto Hernández Rincón
        /// Fecha de Creación: 19/08/2010
        /// Modificación : 23/08/2010 se cambia nombre al store UP_WEBXPLORA_OBTENERARCHIVO_A_ELIMINAR
        ///                por UP_WEBXPLORA_PLA_OBTENERARCHIVO_A_ELIMINAR de acuerdo a las métricas
        ///                establecidas . Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="scod_channel"></param>
        /// <param name="sruta_reporte"></param>
        /// <param name="icompanyid"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para obtener Informe a Eliminar del Servidor")]
        public DataTable Get_EliminarArchivoServer(string scod_channel, string sruta_reporte, int icompanyid)
        {
            DataTable dtdel = null;
            dtdel = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_OBTENERARCHIVO_A_ELIMINAR", scod_channel, sruta_reporte, icompanyid);
            return dtdel;
        }

        /// <summary>
        /// Metodo para validar duplicados en carga de informes .
        /// Ing. Mauricio Ortiz        
        /// </summary>
        /// <param name="scod_Channel"></param>
        /// <param name="sruta_reporte"></param>
        /// <returns></returns>
        [WebMethod(Description = "Consulta Duplicados Información tabla Info_Planning")]
        public DataTable Get_DuplicadosinfoPlanning(string scod_Channel, string sruta_reporte)
        {
            info_Planning binfo_Planning = new info_Planning();
            DataTable dt = null;
            dt = binfo_Planning.Duplicados_Info_Planning(scod_Channel, sruta_reporte);
            return dt;
        }

        /// <summary>
        /// Método para validar duplicado de informe cuando tenga subcanal
        /// </summary>
        /// <param name="scod_Channel"></param>
        /// <param name="sruta_reporte"></param>
        /// <returns></returns>
        [WebMethod(Description = "Consulta Duplicados Información tabla Info_Planning")]
        public DataTable Get_DuplicadosinfoPlanning_consubcanal(string scod_Channel, string sruta_reporte, string scod_SubChannel)
        {
            info_Planning binfo_Planning = new info_Planning();
            DataTable dt = null;
            dt = binfo_Planning.Duplicados_Info_Planning_consubcanal(scod_Channel, sruta_reporte,scod_Channel);
            return dt;
        }

        /// <summary>
        /// Description  : Método para obtener los servicios Lucky por país
        /// Modificación : 30/07/2010 se cambia nombre del sp 
        ///                UP_WEBXPLORA_PLANNING_OBTENERSERVICES por 
        ///                UP_WEBXPLORA_PLA_OBTENERSERVICIOSPORPAIS de acuerdo a
        ///                las métricas establecidas
        ///                Ing. Mauricio Ortiz
        /// </summary>
        /// <param name="scodcountry"></param>
        /// <returns dt></returns>
        [WebMethod(Description = "Método para obtener los servicios Lucky por país")]
        public DataTable Get_ObtenerServices(string scodcountry)
        {
            DataTable dt = null;
            dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_OBTENERSERVICIOSPORPAIS", scodcountry);
            return dt;
        }

        /// <summary>
        /// Descripción : Método para obtener los mercaderistas y supervisores de un planning
        /// Creado por  : Ing. Mauricio Ortiz       
        /// Fecha       : 18/08/2010 
        /// </summary>
        /// <param name="id_planning"></param>
        /// <returns>ds</returns>
        [WebMethod(Description = "Método para obtener los mercaderistas y supervisores de un planning")]
        public DataSet Get_Staff_Planning(string id_planning)
        {
            DataSet ds = oCoon.ejecutarDataSet("UP_WEBXPLORA_PLA_OBTENERSTAFFPLANNING", id_planning);
            return ds;
        }

        /// <summary>
        /// Descripción : Método para obtener las mallas y sectores de un cliente 
        /// Creado por  : Ing. Mauricio Ortiz       
        /// Fecha       : 24/08/2010 
        /// </summary>
        /// <param name="svalor"></param>
        /// <param name="iCompany_id"></param>
        /// <param name="iid_malla"></param>
        /// <returns>ds</returns>
        [WebMethod(Description = "Método para obtener las mallas y sectores de un cliente")]
        public DataSet Get_MallasSector(string svalor, int iCompany_id, int iid_malla)
        {
            DataSet ds = oCoon.ejecutarDataSet("UP_WEBXPLORA_PLA_CONSULTAMALLASYSECTORESCLIENTE", svalor, iCompany_id, iid_malla);
            return ds;
        }

        ///// <summary>
        ///// Descripción : Método para obtener los puntos de venta asignados a un planning
        ///// Autor       : Ing. Mauricio Ortiz
        ///// Fecha       : 03/09/2010      
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="imalla"></param>
        /// <param name="isector"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para obtener los puntos de venta asignados a un planning")]
        public DataTable Get_PDVPlanning(string sid_planning, int imalla, int isector)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_CONSULTARPDVPLANNING", sid_planning, imalla, isector);
            return dt;
        }


        /// <summary>
        /// Descripción : Método para verificar si un operativo ya tiene asignacion de supervisor dentro de un planning
        ///               sirve para quitarlo de la lista de personal disponible para asignación y evitar q lo reasigne.
        /// Autor       : Ing. Mauricio Ortiz
        /// Fecha       : 07/09/2010  
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="iPerson_idOpera"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para verificar si un operativo ya tiene asignacion de supervisor dentro de un planning")]
        public DataTable Get_VerficaAsignaOperativo(string sid_planning, int iPerson_idOpera)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_VERIFICAR_ASIGNACION_OPERATIVO_A_SUPERVISOR", sid_planning, iPerson_idOpera);
            return dt;
        }


        /// <summary>
        /// Descripción : Método para verificar duplicidad de información en asignación de puntos de venta a operativo
        /// Creado por  : Ing. Mauricio Ortiz
        /// Fecha       : 08/09/2010
        /// </summary>
        /// <param name="iid_MPOSPlanning"></param>
        /// <param name="iPerson_id"></param>
        /// <param name="sid_Planning"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para verificar duplicidad de información en asignación de puntos de venta a operativo")]
        public DataTable Get_AsignacionDuplicadaPDV(int iid_MPOSPlanning, int iPerson_id, string sid_Planning)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_DUPLICADOASIGNARPDVAOPERATIVO", iid_MPOSPlanning, iPerson_id, sid_Planning);
            return dt;
        }

        /// <summary>
        /// Descripción : Método para consulta los mercaderistas asignados a un supervisor
        /// Creado por  : Ing. Mauricio Ortiz
        /// Fecha       : 22/09/2010
        /// </summary>
        /// <param name="iPerson_idSupe"></param>
        /// <param name="sid_Planning"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para consulta los mercaderistas asignados a un supervisor")]
        public DataTable Get_ObtenerMercaderistasxSupervisor(int iPerson_idSupe, string sid_Planning)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_CONSULTARMERCADERISTAXSUPERVISOR", iPerson_idSupe, sid_Planning);
            return dt;
        }

        /// <summary>
        /// Método para crear reportes por planning
        /// Ing. Mauricio Ortiz 
        /// Modificación: Se adiciona el campo año , fecha inicio y fecha fin . Ing. Mauricio Ortiz . 03/02/2010
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="iReport_Id"></param>
        /// <param name="iid_Year"></param>
        /// <param name="sid_Month"></param>
        /// <param name="iReportsPlanning_Periodo"></param>
        /// <param name="tReportsPlanning_RecogerDesde"></param>
        /// <param name="tReportsPlanning_RecogerHasta"></param>
        /// <param name="bReportsPlanning_Status"></param>
        /// <param name="sReportsPlanning_CreateBy"></param>
        /// <param name="tReportsPlanning_DateBy"></param>
        /// <param name="sReportsPlanning_ModiBy"></param>
        /// <param name="tReportsPlanning_DateModiBy"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para crear los reportes por planning")]
        public DataTable Get_InsertaReportesPlanning(string sid_planning, int iReport_Id, int iid_Year, string sid_Month, int iReportsPlanning_Periodo,
            DateTime tReportsPlanning_RecogerDesde, DateTime tReportsPlanning_RecogerHasta, bool bReportsPlanning_Status, string sReportsPlanning_CreateBy, DateTime tReportsPlanning_DateBy, string sReportsPlanning_ModiBy,
            DateTime tReportsPlanning_DateModiBy)
        {
            DPlanning reportPlanning = new DPlanning();
            DataTable dt = null;
            dt = reportPlanning.Crear_ReportPlanning(sid_planning, iReport_Id, iid_Year, sid_Month, iReportsPlanning_Periodo,
             tReportsPlanning_RecogerDesde, tReportsPlanning_RecogerHasta, bReportsPlanning_Status, sReportsPlanning_CreateBy, tReportsPlanning_DateBy, sReportsPlanning_ModiBy,
             tReportsPlanning_DateModiBy);
            return dt;
        }

        /// <summary>
        /// Método para consultar reportes de un planning
        /// Ing. Mauricio Ortiz
        /// 09/11/2010
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para consultar los reportes por planning")]
        public DataTable Get_ConsultarReportesPlanning(string sid_planning)
        {
            DPlanning reportPlanning = new DPlanning();
            DataTable dt = null;
            dt = reportPlanning.Consulta_ReportPlanning(sid_planning);
            return dt;
        }

        /// <summary>
        /// Método para eliminar reportes de un planning
        /// Ing. Mauricio Ortiz
        /// 09/11/2010
        /// </summary>
        /// <param name="iid_ReportsPlanning"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para eliminar los reportes por planning")]
        public DataTable Get_EliminarReportesPlanning(int iid_ReportsPlanning)
        {
            DPlanning reportPlanning = new DPlanning();
            DataTable dt = null;
            dt = reportPlanning.Eliminar_ReportsPlanning(iid_ReportsPlanning);
            return dt;
        }

        [WebMethod(Description = "Método para actualizar los reportes por planning")]
        public DataTable Get_ActualizarReportesPlanning(int iid_ReportsPlanning, DateTime tReportsPlanning_RecogerDesde,
             DateTime tReportsPlanning_RecogerHasta, string sReportsPlanning_ModiBy, DateTime tReportsPlanning_DateModiBy)
        {
            DPlanning reportPlanning = new DPlanning();
            DataTable dt = null;
            dt = reportPlanning.Actualizar_ReportsPlanning(iid_ReportsPlanning, tReportsPlanning_RecogerDesde,
              tReportsPlanning_RecogerHasta, sReportsPlanning_ModiBy, tReportsPlanning_DateModiBy);
            return dt;
        }




        /// <summary>
        /// Método para consultar los productos asociados a un planning creado 
        /// Ing. Mauricio Ortiz
        /// 08/11/2010
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="icompany_id"></param>
        /// <returns>ds</returns>
        [WebMethod(Description = "Método para consultar productos del planning")]
        public DataSet Get_ObtenerProductosPlanning(string sid_planning, int icompany_id)
        {
            DPlanning ProductosPlanning = new DPlanning();
            DataSet ds = null;
            ds = ProductosPlanning.Consultar_ProductPlanning(sid_planning, icompany_id);
            return ds;
        }


        /// <summary>
        /// Método para eliminar los productos asociados a un planning creado 
        /// Ing. Mauricio Ortiz
        /// 08/11/2010
        /// </summary>
        /// <param name="lid_ProductsPlanning"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para eliminar productos del planning")]
        public DataTable Get_EliminarProductosPlanning(long lid_ProductsPlanning)
        {
            DPlanning ProductosPlanning = new DPlanning();
            DataTable dt = null;
            dt = ProductosPlanning.Eliminar_ProductPlanning(lid_ProductsPlanning);
            return dt;
        }


        /// <summary>
        /// Método para eliminar las marcas del planning
        /// Ing. Mauricio Ortiz
        /// 02/03/2011  
        /// </summary>
        /// <param name="lid_BrandPlanning"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para eliminar marcas del planning")]
        public DataTable Get_EliminarMarcasPlanning(long lid_BrandPlanning)
        {
            DPlanning MarcasPlanning = new DPlanning();
            DataTable dt = null;
            dt = MarcasPlanning.Eliminar_MarcasPlanning(lid_BrandPlanning);
            return dt;
        }

        [WebMethod(Description = "Método para eliminar familias del planning")]
        public DataTable Get_EliminarFamiliasPlanning(long lid_FamilyPlanning)
        {
            DPlanning MarcasPlanning = new DPlanning();
            DataTable dt = null;
            dt = MarcasPlanning.Eliminar_FamiliasPlanning(lid_FamilyPlanning);
            return dt;
        }



        /// <summary>
        /// Método para eliminar productos de la tabla TBL_PRODUCTO_CADENA
        /// Ing. Mauricio Ortiz
        /// 02/03/2011
        /// </summary>
        /// <param name="lid_ProductsPlanning"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para eliminar productos de la tabla TBL_PRODUCTO_CADENA")]
        public DataTable Get_EliminarProductosTBL_PRODUCTO_CADENA(long lid_ProductsPlanning)
        {
            DPlanning ProductosTBL_PRODUCTO_CADENA = new DPlanning();
            DataTable dt = null;
            dt = ProductosTBL_PRODUCTO_CADENA.Eliminar_ProductTBL_PRODUCTO_CADENA(lid_ProductsPlanning);
            return dt;
        }

        /// <summary>
        /// Método para eliminar marcas de la tabla TBL_EQUIPO_MARCAS
        /// Ing. Mauricio Ortiz
        /// 23/03/2011
        /// </summary>
        /// <param name="lid_BrandPlanning"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para eliminar marcas de la tabla TBL_EQUIPO_MARCAS")]
        public DataTable Get_EliminarMarcasTBL_EQUIPO_MARCAS(string sid_BrandPlanning)
        {
            DPlanning MarcasTBL_EQUIPO_MARCAS = new DPlanning();
            DataTable dt = null;
            dt = MarcasTBL_EQUIPO_MARCAS.Eliminar_MarcasTBL_EQUIPO_MARCAS(sid_BrandPlanning);
            return dt;
        }

        /// <summary>
        /// Método para eliminar familias de la tabla TBL_EQUIPO_FAMILIAS
        /// Ing. Mauricio Ortiz
        /// 24/03/2011
        /// </summary>
        /// <param name="sid_FamilyPlanning"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para eliminar Familias de la tabla TBL_EQUIPO_FAMILIAS")]
        public DataTable Get_EliminarFamiliasTBL_EQUIPO_FAMILIAS(string sid_FamilyPlanning)
        {
            DPlanning FamiliasTBL_EQUIPO_FAMILIAS = new DPlanning();
            DataTable dt = null;
            dt = FamiliasTBL_EQUIPO_FAMILIAS.Eliminar_FamiliasTBL_EQUIPO_FAMILIAS(sid_FamilyPlanning);
            return dt;
        }



        /// <summary>
        /// metodo para llenar filtros en asignacion de puntos de venta a mercaderistas
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <returns>dt</returns>
        [WebMethod(Description = "Método para llenar filtros en asignacion de puntos de venta a mercaderistas")]
        public DataSet Get_cityPointofsalePlanning(string sid_planning, string scod_city, int iidNodeComType, string sNodeCommercial, long lcod_Oficina, int imalla)
        {
            DataSet ds = oCoon.ejecutarDataSet("UP_WEBXPLORA_PLA_LLENAFILTROSASIGNACIONPDV", sid_planning, scod_city, iidNodeComType, sNodeCommercial, lcod_Oficina, imalla);
            return ds;
        }


        /// <summary>
        /// Método para insertar registros en PLA_Panel_Planning
        /// Ing. Mauricio Ortiz
        /// 03/03/2011
        /// </summary>
        /// <param name="sid_planning"></param>
        /// <param name="iid_MPOSPlanning"></param>
        /// <param name="sClientPDV_Code"></param>
        /// <param name="iReport_Id"></param>
        /// <param name="bStatus_PanelPlanning"></param>
        /// <param name="sPanelPlanning_CreateBy"></param>
        /// <param name="tPanelPlanning_DateBy"></param>
        /// <param name="sPanelPlanning_ModiBy"></param>
        /// <param name="tPanelPlanning_DateModiBy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para insertar registros en PLA_Panel_Planning")]
        public EPLA_Panel_Planning Registrar_PLA_Panel_Planning(string sid_planning, int iid_MPOSPlanning, string sClientPDV_Code, int iReport_Id, bool bStatus_PanelPlanning,
            string sPanelPlanning_CreateBy, DateTime tPanelPlanning_DateBy,
            string sPanelPlanning_ModiBy, DateTime tPanelPlanning_DateModiBy,int iid_ReportsPlanning)
        {
            DPlanning odplanning = new DPlanning();

            EPLA_Panel_Planning oeEPLA_Panel_Planning = new EPLA_Panel_Planning();
            oeEPLA_Panel_Planning = odplanning.Registrar_PLA_Panel_Planning(sid_planning, iid_MPOSPlanning, sClientPDV_Code, iReport_Id,
                bStatus_PanelPlanning, sPanelPlanning_CreateBy, tPanelPlanning_DateBy,
                sPanelPlanning_ModiBy, tPanelPlanning_DateModiBy, iid_ReportsPlanning);
            odplanning = null;
            return oeEPLA_Panel_Planning;
        }

        /// <summary>
        /// Método para consultar los registro de la tabla PLA_Panel_Planning de un planning para un reporte seleccinado
        /// Ing. Mauricio Ortiz
        /// 04/03/2011
        /// </summary>
        /// <param name="iid_planning"></param>
        /// <param name="iReport_Id"></param>
        /// <returns></returns>6
        [WebMethod(Description = "Método para consultar los registro de la tabla PLA_Panel_Planning de un planning para un reporte seleccinado")]
        public DataTable Consulta_Pla_paneles(string iid_planning, int iReport_Id,int iReportPlanning)
        {
            DPlanning odplanning = new DPlanning();
            DataTable dt = odplanning.Consulta_Pla_paneles(iid_planning, iReport_Id, iReportPlanning);
            return dt;
        }

        [WebMethod(Description = "Método para eliminar los registro de la tabla PLA_Panel_Planning de un planning para un reporte seleccinado")]
        public DataTable Eliminar_Pla_paneles(long lid_PanelPlanning)
        {
            DPlanning odplanning = new DPlanning();
            DataTable dt = odplanning.Eliminar_Pla_paneles(lid_PanelPlanning);
            return dt;
        }

        [WebMethod(Description="Método para obtener las familias al seleccionar marca y opcional submarca")]
        public DataTable Get_Obtener_Familias(int iid_Brand, int iid_SubBrand, int company_id)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_OBTENERFAMILIAS",iid_Brand,iid_SubBrand, company_id);
            return dt;
        }

        [WebMethod(Description="Método para obtener las subfamilias al seleccionar una determinada familia")]
        public DataTable Get_Obtener_SubFamilias(string id_familia, int company_id)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_OBTENERSUBFAMILIAS",id_familia, company_id);
            return dt;
        }

        [WebMethod(Description = "Método para obtener los productos")]
        public DataTable Get_Obtener_Productos(string id_categoria, string id_marca, string id_familia, string id_subfamilia, int company_id)
        {
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_PLA_OBTENERPRODUCTOS", id_categoria, id_marca, id_familia, id_subfamilia, company_id);
            return dt;
        }
    }
}
