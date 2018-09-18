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
    /// Descripción breve de Facade_Procesos_Administrativos
    /// Crado Por: Ing. Carlos Alberto Hernandez Rincón
    /// Fecha:05/04/2009
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class Facade_Procesos_Administrativos : System.Web.Services.WebService
    {

        [WebMethod(Description = "Metodo para Generar nueva Clave ante un olvido de Usuario")]
        public DataSet Get_GenerarPasswordOlvido(string semail, string snameuser)
        {
            DataSet ds = null;
            Conexion oCoon = new Conexion();
            ds = oCoon.ejecutarDataSet("UP_WEBSIGE_GENERACLAVEOLVIDO", semail,snameuser);
            return ds;
        }

        [WebMethod(Description = "Método para Consultar el ultimo producto registrado")]
        public DataTable Get_ObtenerIdProduct(string sProduct_Name, string sProduct_CreateBy)
        {
            DataTable dt = null;
            Conexion oCoon = new Conexion();
            dt = oCoon.ejecutarDataTable("UP_WEBSIGE_ADMIN_OBTENER_IDPRODUCT", sProduct_Name, sProduct_CreateBy);
            return dt;
        }

        [WebMethod(Description = "Método para Consultar el ultimo tipo de segmento registrado")]
        public DataTable Get_ObteneridSegmentsType(string sSegment_Type, string sSegmentType_CreateBy)
        {
            DataTable dt = null;
            Conexion oCoon = new Conexion();
            dt = oCoon.ejecutarDataTable("UP_WEBSIGE_ADMIN_OBTENER_IDSEGMENTSTYPE", sSegment_Type, sSegmentType_CreateBy);
            return dt;
        }

        [WebMethod(Description = "Método para crear el gridview de los clientes asociados a un pdv")]
        public DataTable Get_CrearGrid(int ivalor)
        {
            DataTable dt = null;
            Conexion oCoon = new Conexion();
            dt = oCoon.ejecutarDataTable("UP_WEBSIGE_ADMIN_LLENACLIEPDV", ivalor);
            return dt;
        }

        [WebMethod(Description = "Método para Consultar el ultimo pdv registrado")]
        public DataTable Get_ObteneridPdv(string spdv_Code, string sPdv_CreateBy)
        {
            DataTable dt = null;
            Conexion oCoon = new Conexion();
            dt = oCoon.ejecutarDataTable("UP_WEBSIGE_ADMIN_OBTENER_IDPDV", spdv_Code, sPdv_CreateBy);
            return dt;
        }

        [WebMethod(Description = "Metodo para Obtener Años")]
        public DataTable Get_ObtenerYears() {
            Conexion oCoon = new Conexion();
            DataTable dtyear = null;
            dtyear = oCoon.ejecutarDataTable("UP_WEBSIGE_GENERAL_OBTENEYEARS");
            return dtyear;
        
        
        
        
        }

        [WebMethod(Description = "Metodo para obtener los meses de un respectivo año")]
        public DataTable Get_ObtenerMeses() {
            Conexion oCoon = new Conexion();
            DataTable dtmes = null;
            dtmes = oCoon.ejecutarDataTable("UP_WEBSIGE_GENERAL_OBTENERMESES");
            return dtmes;
        
        }
        [WebMethod(Description = "Metodo para obtener Mes Seleccionado")]
        public DataTable Get_obtener_Mes_Selecionado(int imes) {
            Conexion oCoon = new Conexion();
            DataTable dtmsel = null;
            dtmsel = oCoon.ejecutarDataTable("UP_WEBSIGE_GENERAL_OBTENER_MES_SELECCIONADO", imes);
            return dtmsel;
        
        
        
        
        }
        /// <summary>
        /// Metodo Para Obtener los Dias de Un Periodo
        /// Creado por: Ing. Carlos Hernández R.
        /// Fecha:25/05/2011
        /// </summary>
        /// <param name="icompanyid"></param>
        /// <param name="scanal"></param>
        /// <param name="ireporte"></param>
        /// <param name="saño"></param>
        /// <param name="smes"></param>
        /// <param name="iperiodo"></param>
        /// <returns></returns>
        [WebMethod(Description = "Metodo para obtener Dias x Periodo")]
        public DataTable Get_obtener_Dias_Periodo(int icompanyid, string scanal, int ireporte,string saño, string smes, int iperiodo)
        {
            Conexion oCoon = new Conexion();
            DataTable dtdia = null;
            dtdia = oCoon.ejecutarDataTable("UP_WEBXPLORA_OBTENERDIASXPERIODO", icompanyid, scanal, ireporte, saño, smes, iperiodo);
            return dtdia;




        }

        [WebMethod(Description = "Metodo para obtener la descripción del informe seleccionado")]
        public DataTable Get_ObtenerReport_Description(int iReport_Id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = null;
            dt = oCoon.ejecutarDataTable("UP_WEBSIGE_ADMIN_OBTENER_Report_Description", iReport_Id);
            return dt;
        }

        [WebMethod(Description = "Metodo para actualizar modulos en person cuando se ha modificado el maestro de perfiles")]
        public DataTable Get_Actualiza_ModuloPerson(string sPerfil_id, string sModulo_id)
        {
            Conexion oCoon = new Conexion();
            DataTable dt = null;
            dt = oCoon.ejecutarDataTable("UP_WEBSIGE_ADMIN_ACTUALZAMODULPERSON", sPerfil_id, sModulo_id);
            return dt;
        }

        [WebMethod(Description = "Metodo para  Insertar Secciones")]
        public DataTable Get_Insertar_Sesion_User(string sname_user) {
            Conexion oCoon = new Conexion();
            DataTable dtsesion = null;
            dtsesion = oCoon.ejecutarDataTable("UP_WEBSIGE_GENERAL_CONTROLSESION", sname_user);
            return dtsesion;
        
        
        
        
        
        
        }
        //[WebMethod(Description="Metodo para Autenticar Usuario")]
        //public EUsuario Get_ObteneAccesoUser(string sUser, string sPassw)
        //{
        //    Conexion oConn = new Conexion();
        //    DataTable dt = oConn.ejecutarDataTable("UP_WEB_ACEDER_USER", sUser, sPassw);
        //    if (dt != null)
        //    {
        //        if (dt.Rows.Count > 0)
        //        {

        //            EUsuario oeUsuario = new EUsuario();
        //            oeUsuario.nameuser = sUser;
        //            oeUsuario.UserPassword = sPassw;
        //            oeUsuario.idtypeDocument = dt.Rows[0]["id_typeDocument"].ToString().Trim();
        //            oeUsuario.Personnd = dt.Rows[0]["Person_nd"].ToString().Trim();
        //            oeUsuario.PersonFirtsname = dt.Rows[0]["Person_Firtsname"].ToString().Trim();
        //            oeUsuario.PersonLastName = dt.Rows[0]["Person_LastName"].ToString().Trim();
        //            oeUsuario.PersonSurname = dt.Rows[0]["Person_Surname"].ToString().Trim();
        //            oeUsuario.PersonSeconName = dt.Rows[0]["Person_SeconName"].ToString().Trim();
        //            oeUsuario.PersonEmail = dt.Rows[0]["Person_Email"].ToString().Trim();
        //            oeUsuario.PersonPhone = dt.Rows[0]["Person_Phone"].ToString().Trim();
        //            oeUsuario.PersonAddres = dt.Rows[0]["Person_Addres"].ToString().Trim();
        //            oeUsuario.codCountry = dt.Rows[0]["cod_Country"].ToString().Trim();
        //            oeUsuario.Perfilid = dt.Rows[0]["Perfil_id"].ToString().Trim();
        //            oeUsuario.companyid = dt.Rows[0]["Company_id"].ToString().Trim();
        //            oeUsuario.companyName = dt.Rows[0]["Company_Name"].ToString().Trim();
        //            oeUsuario.PersonStatus = Convert.ToBoolean(dt.Rows[0]["Person_Status"].ToString().Trim());
        //            oeUsuario.Moduloid = dt.Rows[0]["Modulo_id"].ToString().Trim();
        //            oeUsuario.idlevel = dt.Rows[0]["Id_level"].ToString().Trim();
        //            oeUsuario.leveldescription = dt.Rows[0]["namelevel"].ToString().Trim();
        //            return oeUsuario;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //[WebMethod(Description = "Metodo Para Obtener Servicios Servicios Activos para un Cliente")]
        //public DataTable Get_Obtener_Servicios_Activos(int icompanyid) {
        //    Conexion oCoon = new Conexion();
        //    DataTable dtservice = null;
        //    dtservice = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENERSERVICESACTIVOS", icompanyid);
        //    return dtservice;
            
        
        
        
        
        
        //}

        //[WebMethod(Description = "Metodo para Obtener Canales x Servicio y Cliente")]
        //public DataTable Get_Obtener_Channels_Client(int icodservice, int icompanyid) {
        //    Conexion oCoon = new Conexion();
        //    DataTable dtccanal = null;
        //    dtccanal = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENERCNALXSERVICIO", icodservice, icompanyid);
        //    return dtccanal;    
       
        
        
        
        
        //}

        [WebMethod(Description = "Metodo para Obtener Numero de sesiones SIGE por usuario")]

        public DataTable Get_User_Sesion_Conteo(string susername) {
            Conexion oCoon = new Conexion();
            DataTable dtcountuser = null;
            dtcountuser = oCoon.ejecutarDataTable("UP_WEBSIGE_GENERAL_CONTEO_SESION", susername);
            return dtcountuser;
        
        
        
        
        }

        [WebMethod(Description = "Metodo para Obtener Usuarios en sesión")]
        public DataTable Get_Obtener_User_Sesion(string susername) {
            Conexion oCoon = new Conexion();
            DataTable dtuser = null;
            dtuser = oCoon.ejecutarDataTable("UP_WEBSIGE_GENERAL_CONTROLSESION", susername);
            return dtuser;
        
        
        
        
        
        }

        [WebMethod(Description = "Metodo para Eliminar la seccion de usuario cuando cierra sesion")]
        public DataTable Get_Delete_Sesion_User(string susername) {
            Conexion oCoon = new Conexion();
            DataTable dtuserdel = null;
            dtuserdel = oCoon.ejecutarDataTable("UP_WEBSIGE_GENERAL_ELIMINASESION", susername);
            return dtuserdel;
        
        
        
        }

        [WebMethod(Description = "Metodo para consultaR paises de los directores de cuenta activos en SIGE")]
        public DataTable Get_SearchCountryDirCuenta()
        {
            Conexion oCoon = new Conexion();
            DataTable dtCountry = null;
            dtCountry = oCoon.ejecutarDataTable("UP_WEBSIGE_ADMIN_CONSULTAPAISDIRCUENTA");
            return dtCountry;
        }

        [WebMethod(Description = "Metodo para consultar los directores de cuenta activos en SIGE para un país seleccionado")]
        public DataSet Get_SearchDirCuentaxPais(string sCod_Country)
        {
            Conexion oCoon = new Conexion();
            DataSet dsDirCuenta = null;
            dsDirCuenta = oCoon.ejecutarDataSet("UP_WEBSIGE_ADMIN_CONSULTADIRCUENTAXPAIS",sCod_Country);
            return dsDirCuenta;
        }

        [WebMethod(Description = "Metodo para consultar los directores de cuenta activos en SIGE para un país seleccionado y que tienen asignacion de personal ejecutivo de cuenta")]
        public DataTable Get_SearchDirCuentaconAsingacion(string sCod_Country)
        {
            Conexion oCoon = new Conexion();
            DataTable dtDirCuenta = null;
            dtDirCuenta = oCoon.ejecutarDataTable("UP_WEBSIGE_ADMIN_CONSULTADIRCUENTACONASIGNACION", sCod_Country);
            return dtDirCuenta;
        }

        [WebMethod(Description = "Metodo para consultar los ejecutivos de cuenta activos en SIGE para un país seleccionado y que no estan asignados a un director de cuenta")]
        public DataSet Get_SearchEjeCuentaxPais(string sCod_Country)
        {
            Conexion oCoon = new Conexion();

            return oCoon.ejecutarDataSet("UP_WEBSIGE_ADMIN_CONSULTAEJECUTIVOCUENTAXPAIS", sCod_Country);;
        }

        [WebMethod(Description = "Metodo para llenar combos")]
        public DataSet Get_Llenar_Combos(string svalor)
        {
            Conexion oCoon = new Conexion();
            return oCoon.ejecutarDataSet("UP_WEB_LLENACOMBOS", svalor);
        }
        [WebMethod(Description = "Metodo para  verificar Estado de División Politica")]
        public DataSet Get_DivPolitica(string scod_Country)
        {
            Conexion oCoon = new Conexion();

            DataSet dsDivPolitica = null;
            dsDivPolitica = oCoon.ejecutarDataSet("UP_WEBSIGE_DIVISIONCOUNTRY", scod_Country);
            return dsDivPolitica;
        }
        [WebMethod(Description = "Metodo para  llenar departamento segun país seleccionado")]
        public DataTable Get_llenar_ComboDpto(string sCODCOUNTRY)
        {
            Conexion oCoon = new Conexion();

            DataTable dtGet_llenar_ComboDpto = null;
            dtGet_llenar_ComboDpto = oCoon.ejecutarDataTable("UP_WEBSIGE_LLENACOMBOSCOUNTRY", sCODCOUNTRY);
            return dtGet_llenar_ComboDpto;
        }
        /// <summary>
        /// Descripción : se agrega consulta de país de usuario.
        /// Fecha       : 06/08/2010
        /// Creado por  : Ing. Magaly Jiménez
        /// </summary>
        /// <param name="iPerson_id"></param>
        /// <returns> ConsultaPaísdeUsuario</returns>
        [WebMethod(Description = "Consulta usuarios por Pais")]
        public DataTable ConsultaPaísdeUsuario(int iPerson_id)
        {
            Conexion oCoon = new Conexion();

            DataTable ConsultaPaísdeUsuario = null;
            ConsultaPaísdeUsuario = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_CONSULTAPAISDEUSUARIO", iPerson_id);
            return ConsultaPaísdeUsuario;
        }
        /// <summary>
        /// Descripción : se agrega metodo para llenar combo de servicio segun usuario en el maestro de Asignación de informe por usuario.
        /// Fecha       : 06/08/2010
        /// Creado por  : Ing. Magaly Jiménez
        /// </summary>
        /// <param name="sCODCOUNTRY"></param>
        /// <returns> LlenaComServicio</returns>
        [WebMethod(Description = "llena combo servicio por usuario en maestro Asignación informe a Usuario")]
        public DataTable LlenaComServicio(string sCODCOUNTRY)
        {
            Conexion oCoon = new Conexion();

            DataTable LlenaComServicio = null;
            LlenaComServicio = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACOMBOSERVICIOPORUSUARIO", sCODCOUNTRY);
            return LlenaComServicio;
        }

        /// <summary>
        /// Descripción : Consulta Informe de Asignación de informe a Usuario"
        /// Fecha       : 06/08/2010
        /// Creado por  : Ing. Magaly Jiménez
        /// modificación se agrega parametro de consulta iCompany_id
        /// 12/10/2010 Magaly Jiménez
        /// </summary>
        /// <param name="icod_Strategy"></param>
        /// <param name="iPerson_id"></param>
        /// <param name="scod_Channel"></param>
        /// <returns ConsultaInformedeInfoUsu>ConsultaInformedeInfoUsu</returns>
        [WebMethod(Description = "Consulta Informe de Asignación de informe a Usuario")]
        public DataSet ConsultaInformedeInfoUsu(int iCompany_id, int iPerson_id, string scod_Channel, int icod_Strategy, int iid_userinforme)
        {
            Conexion oCoon = new Conexion();
            DataSet ConsultaInformedeInfoUsu = null;
            ConsultaInformedeInfoUsu = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_CONSULTAINFORMES_CLIE_USERS_REPORTS", iCompany_id, iPerson_id, scod_Channel, icod_Strategy, iid_userinforme);
            return ConsultaInformedeInfoUsu;
        }

        /// <summary>

        /// Descripción : se agrega metodo para consulta y llenar combo de subcategoria segun categoria en el maestro de Presentación
        /// Fecha       : 24/08/2010
        /// Creado por  : Ing. Magaly Jiménez
        /// </summary>
        /// <param name="sidProductCategory"></param>
        /// <returns>LlenaComSubcategoria</returns>
        [WebMethod(Description = "Consulta llena combo de Subcategoria en maestro de presentación")]
        public DataTable LlenaComboSubCategoriaPresent(string sidProductCategory)
        {
            Conexion oCoon = new Conexion();

            DataTable LlenaComSubcategoria = null;
            LlenaComSubcategoria = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACOMBOSUBCATEGORIAPRESENT", sidProductCategory);
            return LlenaComSubcategoria;
        }
        /// <summary>
        /// creado:Consulta llena combo de cliente en maestro de producto
        /// 31/08/2010 Magaly jimenez
        /// </summary>
        /// <param name="iidBrand"></param>
        /// <returns>LlenaComCliente</returns>
        [WebMethod(Description = "Consulta llena combo de cliente en maestro de producto")]
        public DataTable LlenaComboClienteenProducto(int iidBrand)
        {
            Conexion oCoon = new Conexion();

            DataTable LlenaComCliente = null;
            LlenaComCliente = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACOMBOCLIENTEPRODUCT", iidBrand);
            return LlenaComCliente;
        }
        /// <summary>
        /// creado:Consulta llena combo de cliente en maestro de producto
        /// 31/08/2010 Magaly jimenez
        /// </summary>
        /// <param name="sidProductCategory"></param>
        /// <param name="iidBrand"></param>
        /// <returns>LlenaCompresentacion</returns>
        [WebMethod(Description = "Consulta llena combo  de presentación en producto")]
        public DataTable LlenaComboPresentProduct(string sidProductCategory, int iidBrand)
        {
            Conexion oCoon = new Conexion();

            DataTable LlenaCompresentacion = null;
            LlenaCompresentacion = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACOMBOPRESENTPRODUCT", sidProductCategory, iidBrand);
            return LlenaCompresentacion;
        }
        /// <summary>
        /// llena todos los combos del maestro de productos ancla.
        /// 07/09/2010 Magaly jimenez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="sid_ProductCategory"></param>
        /// <param name="lid_Subcategory"></param>
        /// <param name="iid_Brand"></param>
        /// <param name="scod_Product"></param>
        /// <returns></returns>
        [WebMethod(Description = "llena combos del maestro de productos Ancla")]
        public DataSet llenaCombosPAncla(int iCompany_id, string sid_ProductCategory, long lid_Subcategory, int iid_Brand, string scod_Product)
        {
            Conexion oCoon = new Conexion();
            DataSet llenacombosAncla = null;
            llenacombosAncla = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOSPRODUCANCLA", iCompany_id, sid_ProductCategory, lid_Subcategory, iid_Brand, scod_Product);
            return llenacombosAncla;
        }
        /// <summary>
        /// llena combos de consulta del maestro productos ancla
        /// 07/09/2010 Magaly jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="iid_Brand"></param>
        /// <returns>llenacombosBuscarAncla</returns>
        [WebMethod(Description = "llena combos de Busqueda del maestro de productos Ancla")]
        public DataSet llenaConsultaCombosPAncla(int iCompany_id)
        {
            Conexion oCoon = new Conexion();
            DataSet llenacombosBuscarAncla = null;
            llenacombosBuscarAncla = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOSCONSULTASPRODUCTANCLA", iCompany_id);
            return llenacombosBuscarAncla;
        }

        /// <summary>
        /// Metodo para llenar combos de maestro Sector
        /// 15/09/2010 Magaly Jiménez
        /// modificación se agrega parametro company_id
        /// 10/11/2010 Magaly Jiménez
        /// </summary>
        /// <param name="iid_malla"></param>
        /// <returns>llenacombosSector</returns>
        [WebMethod(Description = "llena combos de Malla en maestro Sector")]
        public DataSet llenaCombosSector(int iCompany_id)
        {
            Conexion oCoon = new Conexion();
            DataSet llenacombosSector = null;
            llenacombosSector = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMALLAS", iCompany_id);
            return llenacombosSector;
        }
      /// <summary>
      /// Metodo para llenar conmbos filtro para llenar Puntos de Venta en el maestro de relación de Puntos de venta a cliente.
      /// 22/09/2010 Magaly Jiménez
      /// </summary>
      /// <param name="scod_country"></param>
      /// <param name="scod_channel"></param>
      /// <param name="iidNodeComType"></param>
      /// <param name="sNodeCommercial"></param>
        /// <returns>llenaCombosPDVCliente</returns>
        [WebMethod(Description = "llena combos de filtro en maestro de realción de PDV a Cliente")]
        public DataSet llenaCombosPDVCliente(int iCompany_id, string scod_country , string scod_channel , int iidNodeComType,  string sNodeCommercial)
        {
            Conexion oCoon = new Conexion();
            DataSet llenaCombosPDVCliente = null;
            llenaCombosPDVCliente = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOSPDVCLIENTE",iCompany_id, scod_country, scod_channel, iidNodeComType, sNodeCommercial);
            return llenaCombosPDVCliente;
        }

        /// <summary>
        /// 31/01/2011 Magaly Jiménez
        /// trae la consulta de PDV con relación a un cliente.
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="scod_country"></param>
        /// <param name="scod_channel"></param>
        /// <param name="iidNodeComType"></param>
        /// <param name="sNodeCommercial"></param>
        /// <returns></returns>
        [WebMethod(Description = "llena PDV en la consulta de maestro PDV_CLiente")]
        public DataSet llenaPDVClienteConsulta(int iCompany_id, string scod_country, string scod_channel, int iidNodeComType, string sNodeCommercial)
        {
            Conexion oCoon = new Conexion();
            DataSet llenaPDVClienteConsulta = null;
            llenaPDVClienteConsulta = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACONSULAPDVCLIENTE", iCompany_id, scod_country, scod_channel, iidNodeComType, sNodeCommercial);
            return llenaPDVClienteConsulta;
        }
        /// <summary>
        /// llena combos de check de informes por cod_Channel, company_id y Cod_Strategy
        /// 08/10/2010 Magaly Jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="scod_channel"></param>
        /// <param name="icod_Strategy"></param>
        /// <returns>llenaCheckInformes</returns>
        [WebMethod(Description = "llena combos de check de informes por cod_Channel, company_id y Cod_Strategy")]
        public DataSet llenaCheckInformes(int iCompany_id, string scod_channel, int icod_Strategy)
        {
            Conexion oCoon = new Conexion();
            DataSet llenaCheckInformes= null;
            llenaCheckInformes = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACHECKINFORMEUSERREPORT", iCompany_id, scod_channel, icod_Strategy);
            return llenaCheckInformes;
        }
        /// <summary>
        /// Consulta llena combo de usuario por cliente en el maestro de asignación de informes a usuario
        /// 08/10/2010 Magaly jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <returns>LlenaComboUsuarioXCliente</returns>
        [WebMethod(Description = "Consulta llena combo de usuario por cliente en el maestro de asignación de informes a usuario")]
        public DataTable LlenaComboUsuarioXCliente(int iCompany_id)
        {
            Conexion oCoon = new Conexion();

            DataTable LlenaComboUsuarioXCliente = null;
            LlenaComboUsuarioXCliente = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACOMBOUSUARIOXCLIENTE", iCompany_id);
            return LlenaComboUsuarioXCliente;
        }
        /// <summary>
        /// Consulta id de la tambla asignación de informes a usuario para insertar ciudades por registro
        /// 08/10/2010 Magaly jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <returns>consultaidClieUserReport</returns>
        [WebMethod(Description = "Consulta id de la tambla asignación de informes a usuario para insertar ciudades por registro")]
        public DataTable ConsultaUltimoiddeClieInfoUser()
        {
            Conexion oCoon = new Conexion();

            DataTable consultaidClieUserReport= null;
            consultaidClieUserReport = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_CONSULTA_ID_USERINFORME");
            return consultaidClieUserReport;
        }
        /// <summary>
        /// LLENA LOS CANALES POR CLIENTE en maestro de asignación de informes a usuario
        /// 08/10/2010 Magaly Jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <returns>LLenacomboCanalporCliente</returns>
        [WebMethod(Description = "LLENA LOS CANALES POR CLIENTE en maestro de asignación de informes a usuario")]
        public DataTable LLenacomboCanalporCliente(int iCompany_id)
        {
            Conexion oCoon = new Conexion();

            DataTable LLenacomboCanalporCliente = null;          
            LLenacomboCanalporCliente = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACANALXCLIENTE",  iCompany_id);
            return LLenacomboCanalporCliente;
        }
        /// <summary>
        /// llena combos de consulta Cliente, Usuario, Canal y servicio en maestro de asignación informes a usuarios
        /// 12/10/2010 Magaly Jimenez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="iPerson_id"></param>
        /// <param name="scod_channel"></param>
        /// <returns></returns>
        [WebMethod(Description = "llena combos de consulta Cliente, Usuario, Canal y servicio en maestro de asignación informes a usuarios")]
        public DataSet llenaCombosConsultaInfoUser(int iCompany_id, int iPerson_id, string scod_channel)
        {
            Conexion oCoon = new Conexion();
            DataSet llenaCombosConsultaInfoUser = null;
            llenaCombosConsultaInfoUser = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOSCONSULTASASIGNACIONREPORTUSERS", iCompany_id, iPerson_id, scod_channel);
            return llenaCombosConsultaInfoUser;
        }
        /// <summary>
        /// Consulta ciudades de Asignación de informe a Usuario
        /// 12/10/2010 Magaly Jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="iPerson_id"></param>
        /// <param name="scod_Channel"></param>
        /// <param name="icod_Strategy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Consulta ciudades de Asignación de informe a Usuario")]
        public DataSet ConsultaCiudadesdeInfoUsu(int iCompany_id,  int iPerson_id, string scod_Channel,int icod_Strategy)
        {
            Conexion oCoon = new Conexion();
            DataSet ConsultaCiudadesdeInfoUsu = null;
            ConsultaCiudadesdeInfoUsu = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_CONSULTACIUDADES_CITY_USERS_REPORTS", iCompany_id, iPerson_id, scod_Channel, icod_Strategy);
            return ConsultaCiudadesdeInfoUsu;
        }
        /// <summary>
        /// LLENA combo de marca en consulta de maestro familia
        /// 19/10/2010 Magaly Jiménez
        /// </summary>
        /// <returns>LLenacomboBMarcaFamily</returns>
        /// Modificación: se agrega parametro sid_ProductCategory.
        /// 01/12/2010 Magaly Jiménez
        [WebMethod(Description = "LLENA combo de marca en consulta de maestro familia")]
        public DataSet LLenacomboBuscarMarcaFamily(int iCompany_id, string sid_ProductCategory)
        {
            Conexion oCoon = new Conexion();

            DataSet LLenacomboBMarcaFamily = null;
            LLenacomboBMarcaFamily = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOMARCABUSCARFAMILY", iCompany_id, sid_ProductCategory);
            return LLenacomboBMarcaFamily;
        }
        /// <summary>
        /// llena combos de maestro asignación de cobertura
        /// 26/10/2010 Magaly Jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="iPerson_id"></param>
        /// <returns></returns>
        [WebMethod(Description = "llena combos  de maestro asignación de cobertura")]
        public DataSet llenaCombosAsignacionCobertura(int iCompany_id, int iPerson_id, string scod_Channel, int icod_Strategy, int iReport_Id)
        {
            Conexion oCoon = new Conexion();
            DataSet llenaCombosAsignacionCobertura = null;
            llenaCombosAsignacionCobertura = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOSASIGNARCOBERTURA", iCompany_id, iPerson_id, scod_Channel, icod_Strategy, iReport_Id);
            return llenaCombosAsignacionCobertura;
        }
        /// <summary>
        /// llena combos de consulta de maestro de asignación de cobertura
        /// 27/10/2010 Magaly Jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <param name="iPerson_id"></param>
        /// <param name="scod_Channel"></param>
        /// <param name="icod_Strategy"></param>
        /// <param name="iReport_Id"></param>
        /// <returns>llenaCombosConsultaAsignacionCobertura</returns>
        [WebMethod(Description = "llena combos de consulta de maestro asignación de cobertura")]
        public DataSet llenaCombosConsultaAsignacionCobertura(int iCompany_id, int iPerson_id, string scod_Channel, int icod_Strategy, int iReport_Id)
        {
            Conexion oCoon = new Conexion();
            DataSet llenaCombosConsultaAsignacionCobertura = null;
            llenaCombosConsultaAsignacionCobertura = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOSCONSULTAASIGNARCOBERTURA", iCompany_id, iPerson_id, scod_Channel, icod_Strategy, iReport_Id);
            return llenaCombosConsultaAsignacionCobertura;
        }
        /// <summary>
        /// llena combos de maestro asignación de Reporte a Oficinas
        /// 04/11/2010 Magaly Jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <returns></returns>
        [WebMethod(Description = "llena combos de maestro asignación de Reporte a Oficinas")]
        public DataSet llenaCombosAsignacionReportOficina(int iCompany_id)
        {
            Conexion oCoon = new Conexion();
            DataSet llenaCombosAsignacionReportOficina = null;
            llenaCombosAsignacionReportOficina = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOSASIGNAROFICINASAREPORTES", iCompany_id);
            return llenaCombosAsignacionReportOficina;
        }
        /// <summary>
        /// llena combos  de consulta de maestro asignación de Reporte a Oficinas
        /// 04/11/2010 Magaly Jiménez
        /// </summary>
        /// <param name="iCompany_id"></param>
        /// <returns></returns>
        [WebMethod(Description = "llena combos  de consulta de maestro asignación de Reporte a Oficinas")]
        public DataSet llenaCombosConsultaAsignacionReportOficina(int iCompany_id)
        {
            Conexion oCoon = new Conexion();
            DataSet llenaCombosConsultaAsignacionReportOficina = null;
            llenaCombosConsultaAsignacionReportOficina = oCoon.ejecutarDataSet("UP_WEBXPLORA_AD_LLENACOMBOSCONSULTA_ASIGNARREPORTOFICINA", iCompany_id);
            return llenaCombosConsultaAsignacionReportOficina;
        }
        /// <summary>
        /// llena las categorias en la consulta del maestro de Marca
        /// 30/11/2010 Magaly Jiménez
        /// </summary>
        /// <returns></returns>
         [WebMethod(Description = "llena las categorias en la consulta del maestro de Marca")]
        public DataTable LLenacomboCategoriaConsultaMarca()
        {
            Conexion oCoon = new Conexion();

            DataTable LLenacomboCategoriaConsultaMarca = null;
            LLenacomboCategoriaConsultaMarca = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACOMBOBUSCARCATEGORIA");
            return LLenacomboCategoriaConsultaMarca;
        }
        /// <summary>
        /// llena combo de marca por categoria.
        /// </summary>
        /// <param name="sid_ProductCategory"></param>
        /// <returns></returns>
         [WebMethod(Description = "llena las marcas segun categoria")]
        public DataTable LLenacomboMarcaporCategoria(string  sid_ProductCategory)
        {
            Conexion oCoon = new Conexion();

            DataTable LLenacomboMarcaporCategoria = null;
            LLenacomboMarcaporCategoria = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACOMBOMARCASEGUNCATEGORIA", sid_ProductCategory);
            return LLenacomboMarcaporCategoria;
        }
        /// <summary>
        /// Consulta id_Lavel para realizar la insericón en la taba AD_PErson_Modulo
        /// 03/12/2010  Magaly Jiménez
        /// </summary>
        /// <returns></returns>
         [WebMethod(Description = "Consulta id de la tabla nivel relacionadolo a un modulo")]
         public DataTable ConsultaUltimoiddeNivel()
         {
             Conexion oCoon = new Conexion();

             DataTable ConsultaUltimoiddeNivel = null;
             ConsultaUltimoiddeNivel = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_CONSULTA_ID_LEVEL");
             return ConsultaUltimoiddeNivel;
         }
        /// <summary>
         /// llena combo de cosnulta en el maestro de nivel
         /// 07/12/2010 MAgaly Jiménez
        /// </summary>
        /// <returns></returns>
         [WebMethod(Description = "llena combo de cosnulta en el maestro de nivel")]
         public DataTable ConsultallenarcomboNivel()
         {
             Conexion oCoon = new Conexion();

             DataTable ConsultallenarcomboNivel = null;
             ConsultallenarcomboNivel = oCoon.ejecutarDataTable("UP_WEBXPLORA_AD_LLENACOMBOCONSULTANIVEL");
             return ConsultallenarcomboNivel;
         }
        /// <summary>
         /// Obtine NodeComercial por id_planning
         /// 22/03/2011 Ditmar Estrada
        /// </summary>
        /// <returns></returns>
         [WebMethod(Description = "Obtine NodeComercial por id_planning")]
         public List<ENodeComercial> Get_NodeComercialBy_idPlanning(string sidPlanning)
         {
             try
             {
                 NodeComercial oNodeComercial = new NodeComercial();
                 return oNodeComercial.Get_NodeComercialBy_idPlanning(sidPlanning);
             }
             catch (Exception)
             {
                 return null;
             }
         }

         /// <summary>
         /// Obtiene lista de tipos de material POP
         /// 27/05/2011 Angel Ortiz
         /// </summary>
         /// <returns></returns>
         [WebMethod(Description = "Obtine lista de tipos de material POP")]
         public DataTable get_tipo_material_pop()
         {
             try
             {
                Conexion oCoon = new Conexion();
                DataTable get_tipo_material_pop = null;
                get_tipo_material_pop = oCoon.ejecutarDataTable("UP_WEBEXPLORA_AD_OBTENER_TIPOMATERIALPOP");
                return get_tipo_material_pop;
             }
             catch (Exception)
             {
                 return null;
             }
         }
       
    }
}