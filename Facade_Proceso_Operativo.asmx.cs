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
    /// Descripción breve de Facade_Proceso_Operativo
    /// Permite a los usuarios del módulo operativo visualizar información para las actividades operativas en SIGE
    /// Create by: Ing. Mauricio Ortiz
    /// Date: 02-10-2009
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Facade_Proceso_Operativo : System.Web.Services.WebService
    {

        [WebMethod(Description = "Método para obtener los planning en estado diferente a finalizado")]

        public DataTable Get_Planning()
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERPLANNING");
            return dt;
        }

        [WebMethod(Description = "Método para obtener los formatos de levantamiento del planning seleccionado")]

        public DataTable Get_FormatosPlanning(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERFORMATOSPLANNING", iid_Planning);
            return dt;
        }


        [WebMethod(Description = "Método para obtener el personal operativo del planning seleccionado")]

        public DataTable Get_StaffPlanning(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERSTAFFPLANNING", iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método para obtener los formatos de activiades en el comercio del planning seleccionado")]

        public DataTable Get_ActivComercio(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERACTIVIDADCOMPLANNING", iid_Planning);
            return dt;
        }


        [WebMethod(Description = "Método para construir formato de levantamiento de activiades en el comercio")]

        public DataTable Get_FormatoActivComercio()
        {

            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_FORMATOACTIVIDADCOMERCIO");
            return dt;
        }

        [WebMethod(Description = "Método para obtener el último id registrado en Competition_ Information")]

        public DataTable Get_idCompetition_Information(string scinfo_CreateBy)
        {

            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERIDCompetition_Information", scinfo_CreateBy);
            return dt;
        }

        [WebMethod(Description = "Método para obtener las fotos de la última Actividad del comercio registrada ")]

        public DataTable Get_FotosCompetition_Information(int iid_cinfo)
        {

            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERFOTOSACTIVIDAD", iid_cinfo);
            return dt;
        }

        [WebMethod(Description = "Método para verificar registros duplicados en actividades del comercio")]

        public DataTable Get_DuplicadosCompetition_Information(string stable, DateTime tcampo, string scampo1, string scampo2, string scampo3)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCH_DUPLICA", stable, tcampo, scampo1, scampo2, scampo3);
            return dt;
        }

        [WebMethod(Description = "Método para consultar actividades del comercio registradas")]

        public DataTable Get_SearchCompetition_Information(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHFORMATOACTIVIDADCOMERCIO", iid_Planning);
            return dt;
        }


        [WebMethod(Description = "Método para consultar informacion de actividad del comercio seleccionada")]

        public DataTable Get_SearchInfoCompetition_Information(int iid_cinfo)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHINFOACTIVIDADCOMERCIO", iid_cinfo);
            return dt;
        }


        [WebMethod(Description = "Método para consultar el material POP de informacion de actividad del comercio seleccionada")]

        public DataTable Get_SearchInfoPOPCompetition_Information(int iid_cinfo)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHINFOPOPACTIVIDADCOMERCIO", iid_cinfo);
            return dt;
        }


        [WebMethod(Description = "Método para consultar el material POP de informacion de actividad del comercio a actualizar")]

        public DataTable Get_SearchInfoPOPActualCompetition_Information(int iid_cinfo, int iid_MPointOfPurchase)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHINFOPOPACTIVIDADCOMERCIOACTUAL", iid_cinfo, iid_MPointOfPurchase);
            return dt;
        }



        [WebMethod(Description = "Método para consultar las categorias de los productos del planning seleccionado")]

        public DataTable Get_SearchcategoryProductPlanning(int iid_Planning)
        {

            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERPRODUCTCATEGORYPLANNING", iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método para obtener el último id registrado en Photographs_Service")]

        public DataTable Get_idPhotographs_Service(string sPhoto_CreateBy)
        {

            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERIDPhotographs_Service", sPhoto_CreateBy);
            return dt;
        }

        [WebMethod(Description = "Método para obtener las fotos de la última Actividad Propia registrada ")]

        public DataTable Get_FotosPhotographs_Service(int iid_Photographs)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERFOTOSACTIVIDADPROPIA", iid_Photographs);
            return dt;
        }

        [WebMethod(Description = "Método para consultar actividades propias registradas")]

        public DataTable Get_SearchPhotographs_Service(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHFORMATOACTIVIDADPROPIA", iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método para consultar informacion de actividad del comercio seleccionada")]

        public DataTable Get_SearchInfoPhotographs_Service(int iid_Photographs)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHINFOACTIVIDADPROPIA", iid_Photographs);
            return dt;
        }

        [WebMethod(Description = "Método para consultar estructura de formatos propios")]

        public DataTable Get_SearchContenidoFormatosPropios(int iid_Planning, int iid_cod_Point, int iReport_Id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHCONTENIDOFORMATOS", iid_Planning, iid_cod_Point, iReport_Id);
            return dt;
        }

        [WebMethod(Description = "Método para consultar estructura de formatos para registro de datos de indicador")]

        public DataTable Get_SearchContenidoFormatosPropiosIndicador(int iid_Planning, int iReport_Id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHCONTENIDOFORMATOSINDICADOR", iid_Planning, iReport_Id);
            return dt;
        }

        [WebMethod(Description = "Método para consultar actividades de levantamiento propio registradas")]

        public DataTable Get_SearchActivLevantPropio(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHFORMATOLEVANTAMIENTOPROPIA", iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método para consultar informacion de actividad propia seleccionada")]

        public DataTable Get_SearchInfoLevantamientoPropia(int iid_Planning, string sdato_Date , string SRazónSocial, string SProduct_Name)
        { 
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHINFOLEVANTAMIENTOPROPIA", iid_Planning, sdato_Date, SRazónSocial,SProduct_Name);
            return dt;
        }

        [WebMethod(Description = "Método para consultar los datos registrados en cuanto a indicadores se refiere")]

        public DataTable Get_SearchInfoContenidoFormatosPropiosIndicador(int iReport_Id, int iid_Planning, string ssales_Date, string sProduct_Name, string spdv_RazónSocial)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHINFOCONTENIDOFORMATOSINDICADOR",iReport_Id,iid_Planning,ssales_Date,sProduct_Name,spdv_RazónSocial);
            return dt;
        }

        [WebMethod(Description = "Método para consultar los datos registrados en cuanto a indicadores se refiere del producto competidor")]

        public DataTable Get_SearchInfoContenidoFormatosPropiosIndicadorCompe(int iReport_Id, int iid_Planning, string ssales_Date, string sProduct_Name, string spdv_RazónSocial)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHINFOCONTENIDOFORMATOSINDICADORCOMPE", iReport_Id, iid_Planning, ssales_Date, sProduct_Name, spdv_RazónSocial);
            return dt;
        }

        [WebMethod(Description = "Método para obtener el personal supervisores del planning seleccionado")]

        public DataTable Get_StaffSupervisorPlanning(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_OBTENERSUPERVISORESFPLANNINGSEL", iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método para construir formato de levantamiento de activiades propias encabezado")]

        public DataTable Get_FormatoActivPropiaEncabezado(int iid_Planning, int iReport_id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_FORMATOACTIVIDADPROPIAENCABEZADO",iid_Planning, iReport_id);
            return dt;
        }

        [WebMethod(Description = "Método para construir formato de levantamiento de activiades propias detalle")]

        public DataTable Get_FormatoActivPropiaDetalle(int iDesign_Formats, int iid_Planning, int iReport_Id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_FORMATOACTIVIDADPROPIA",iDesign_Formats,iid_Planning,iReport_Id);
            return dt;
        }

        [WebMethod(Description = "Método para construir formato de levantamiento de activiades propias pie")]

        public DataTable Get_FormatoActivPropiaPie(int iid_Planning, int iReport_id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_FORMATOACTIVIDADPROPIAPIE", iid_Planning, iReport_id);
            return dt;
        }

        [WebMethod(Description = "Método para visualizar los puntos de venta asignados a c/operativo seleccionado")]

        public DataTable Get_PdvXOperativoSel(int Person_id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_PDVXOPERATIVOSEL", Person_id);
            return dt;
        }

        [WebMethod(Description = "Método para visualizar los productos por puntos de venta asignados a c/operativo seleccionado")]

        public DataTable Get_ProductosXPdvXOperativoSel(int Person_id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_PRODUCTOSXPDVXOPERATIVOSEL", Person_id);
            return dt;
        }

        [WebMethod(Description = "Método para consultar el codigo de canal para el formato")]

        public DataTable Get_CanalXFormato(string sChannel_Name )
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_CANALXFORMATO", sChannel_Name);
            return dt;
        }

        [WebMethod(Description = "Método para construir productos competidores por producto propio")]

        public DataTable Get_ProductoCompetidorXProducto(int iid_Planning)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_PRODUCTOCOMPETIDORXPRODUCTOPROPIO", iid_Planning);
            return dt;
        }

        [WebMethod(Description = "Método para buscar duplicados en informacion de levantamiento propia")]

        public DataTable Get_SearchDuplicadoInfopropia(int iid_Planning, string sfechaopera, string sPdvDigita, string sProdDigita)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBSIGE_OPERATIVO_SEARCHDUPLICADOINFOLEVANTAMIENTOPROPIA", iid_Planning,sfechaopera,sPdvDigita,sProdDigita);
            return dt;
        }

        /// <summary>
        /// Create by: Ing. Ditmar Estrada
        /// Date: 24-08-2010
        /// </summary>
        [WebMethod(Description = "Método para el reporte de exibicion")]

        public DataTable Get_ReporteExibicion(int iidperson, string sidplanning, string sidchanel, int cod_oficina, int id_NodeComercial, string ClientPDV_Code, string sid_categoriaproducto, string sidbrand, DateTime dfecha_inicio, DateTime dfecha_fin)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_REPORTE_EXHIBICION", iidperson, sidplanning, sidchanel,cod_oficina,id_NodeComercial,ClientPDV_Code, sid_categoriaproducto, sidbrand, dfecha_inicio, dfecha_fin);
            return dt;
        }

        //[WebMethod(Description = "Método para el reporte del detalle de exibicion")]

        //public DataTable Get_ReporteExibicionDetalle(int iidregexhibicion)
        //{
        //    Conexion oCoon = new Conexion();
        //    DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_REPORTE_EXHIBICION_DETALLE", iidregexhibicion);
        //    return dt;
        //}


        [WebMethod(Description = "Método para el reporte de competencia")]

        public DataTable Get_ReporteCompetencias(int iidperson, string sidplanning, string sidchanel, int cod_oficina, int id_NodeComercial, string ClientPDV_Code, string sidcategoriaProducto, string sidbrand, DateTime dfecha_inicio, DateTime dfecha_fin)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_COMPETENCIA", iidperson, sidplanning, sidchanel,cod_oficina,id_NodeComercial,ClientPDV_Code, sidcategoriaProducto, sidbrand,dfecha_inicio,dfecha_fin);
            return dt;
        }

        [WebMethod(Description = "Método para el reporte de precio")]

        public DataTable Get_ReportePrecio(int iidperson, string sidplanning, string sidchanel, int cod_oficina, int id_NodeComercial, string ClientPDV_Code, string sid_categoriaproducto, string sidbrand, string ssku, DateTime dfecha_inicio, DateTime dfecha_fin)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_PRECIO", iidperson, sidplanning, sidchanel,cod_oficina,id_NodeComercial,ClientPDV_Code, sid_categoriaproducto, sidbrand, ssku, dfecha_inicio, dfecha_fin);
            return dt;
        }

        //[WebMethod(Description = "Método para el reporte de precio detalle")]

        //public DataTable Get_ReportePrecioDetalle(int iidregprecio,string schannel)
        //{
        //    Conexion oCoon = new Conexion();
        //    DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_PRECIO_DETALLE", iidregprecio, schannel);
        //    return dt;
        //}

        /// <summary>
        /// Se Agrega el Parametro icompanyid
        /// Agregado por: Ing. Carlos Hernandez
        /// Fecha: 18/02/2011
        /// </summary>
        /// <param name="iidperson"></param>
        /// <param name="sidplanning"></param>
        /// <param name="sidchanel"></param>
        /// <param name="sid_categoriaproducto"></param>
        /// <param name="iidbrand"></param>
        /// <param name="ssku"></param>
        /// <param name="dfecha_inicio"></param>
        /// <param name="dfecha_fin"></param>
        /// <param name="icompanyid"></param>
        /// <returns></returns>
        [WebMethod(Description = "Método para el reporte de quiebre")]
        public DataTable Get_ReporteQuiebre(int iidperson, string sidplanning, string sidchanel, int cod_oficina, int id_NodeComercial, string ClientPDV_Code, string sid_categoriaproducto, int iidbrand, string ssku, DateTime dfecha_inicio, DateTime dfecha_fin, int icompanyid)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_QUIEBRE", iidperson, sidplanning, sidchanel,cod_oficina,id_NodeComercial,ClientPDV_Code, sid_categoriaproducto,iidbrand, ssku,dfecha_inicio, dfecha_fin,icompanyid);
            return dt;
        }

        //[WebMethod(Description = "Método para el reporte de quiebre detalle")]
        //public DataTable Get_ReporteQuiebreDetalle(int iidregquiebre)
        //{
        //    Conexion oCoon = new Conexion();
        //    DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_QUIEBRE_DETALLE", iidregquiebre);
        //    return dt;
        //}

        [WebMethod(Description = "Método para el reporte de SOD")]
        public DataTable Get_ReporteSOD(int iidperson, string sidplanning, string sidchanel, int cod_oficina, int id_NodeComercial, string ClientPDV_Code, string sid_categoriaproducto, string sidbrand, DateTime dfecha_inicio, DateTime dfecha_fin)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_SOD", iidperson, sidplanning, sidchanel,cod_oficina,id_NodeComercial,ClientPDV_Code, sid_categoriaproducto, sidbrand,dfecha_inicio,dfecha_fin);
            return dt;
        }

        //[WebMethod(Description = "Método para el reporte de SOD detalle")]
        //public DataTable Get_ReporteSODDetalle(int iidregsod)
        //{
        //    Conexion oCoon = new Conexion();
        //    DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_SOD_DETALLE", iidregsod);
        //    return dt;
        //}

        [WebMethod(Description = "Método para el reporte de stock")]
        public DataTable Get_ReporteStock(int iidperson, string sidplanning, string sidchanel, int cod_oficina, int id_NodeComercial, string ClientPDV_Code, string sid_categoriaproducto, string sidfamily, DateTime dfecha_inicio, DateTime dfecha_fin)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_STOCK", iidperson, sidplanning, sidchanel,cod_oficina,id_NodeComercial,ClientPDV_Code, sid_categoriaproducto, sidfamily, dfecha_inicio, dfecha_fin);
            return dt;
        }

        //[WebMethod(Description = "Método para el reporte de SOD detalle")]
        //public DataTable Get_ReporteStockDetalle(int iidregstock)
        //{
        //    Conexion oCoon = new Conexion();
        //    DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_STOCK_DETALLE", iidregstock);
        //    return dt;
        //}

        [WebMethod(Description = "Método para el reporte de layout")]
        public DataTable Get_ReporteLayout(int iidperson, string sidplanning, string sidchanel, string sid_categoriaproducto, string sidbrand, DateTime dfecha_inicio, DateTime dfecha_fin)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_LAYOUT", iidperson, sidplanning, sidchanel, sid_categoriaproducto, sidbrand,dfecha_inicio,dfecha_fin);
            return dt;
        }
             /// <summary>
             /// Modificacion: Se agrega el parametro Tipo Reporte Fotografico Ing. Carlos Hernandez 13/10/2010
             /// </summary>
             /// <param name="iidperson"></param>
             /// <param name="sidplanning"></param>
             /// <param name="sidchanel"></param>
             /// <param name="sidtiporeporte"></param>
             /// <param name="sid_categoriaproducto"></param>
             /// <param name="sidbrand"></param>
             /// <param name="stipreport"></param>
             /// <returns></returns>
        [WebMethod(Description = "Método para el reporte de fotografico")]
        public DataTable Get_ReporteFotografico(int iidperson, string sidplanning, string sidchanel, int cod_oficina, int id_NodeComercial, string ClientPDV_Code, string sidtiporeporte, string sid_categoriaproducto, string sidbrand, string stipreport, DateTime dfecha_inicio, DateTime dfecha_fin, int icompanyid)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = oCoon.ejecutarDataTable("UP_WEBXPLORA_OPE_CONSULTA_REPORTE_FOTOGRAFICO", iidperson, sidplanning, sidchanel,cod_oficina,id_NodeComercial,ClientPDV_Code, sidtiporeporte, sid_categoriaproducto, sidbrand, stipreport,dfecha_inicio,dfecha_fin, icompanyid);
            return dt;
        }

      
    }
}
     
