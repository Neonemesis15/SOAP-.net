using System;
using System.Data;
using System.Web.Services;
using Lucky.Data;
using Lucky.Entity.Common.Application;

namespace Facade_Planning
    {
        /// <summary>
        /// Descripción breve de Facade_Proceso_Cliente
        /// Creado por: Ing. Carlos Alberto Hernández
        /// Fecha:05/11/2009

        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
        [System.Web.Script.Services.ScriptService]
        public class Facade_Proceso_Cliente : System.Web.Services.WebService
        {
            Conexion oCoon = new Conexion();

            [WebMethod(Description = "Metodo para Autenticar Usuario")]
            public EUsuario Get_ObteneAccesoUser(string sUser, string sPassw)
            {
                Conexion oConn = new Conexion();
                DataSet dt = oConn.ejecutarDataSet("UP_WEB_ACEDER_USER", sUser, sPassw);
                if (dt != null)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        

                        EUsuario oeUsuario = new EUsuario();
                        oeUsuario.nameuser = sUser;
                        oeUsuario.UserPassword = sPassw;
                        oeUsuario.idtypeDocument = dt.Tables[0].Rows[0]["id_typeDocument"].ToString().Trim();
                        oeUsuario.Personnd = dt.Tables[0].Rows[0]["Person_nd"].ToString().Trim();
                        oeUsuario.PersonFirtsname = dt.Tables[0].Rows[0]["Person_Firtsname"].ToString().Trim();
                        oeUsuario.PersonLastName = dt.Tables[0].Rows[0]["Person_LastName"].ToString().Trim();
                        oeUsuario.PersonSurname = dt.Tables[0].Rows[0]["Person_Surname"].ToString().Trim();
                        oeUsuario.PersonSeconName = dt.Tables[0].Rows[0]["Person_SeconName"].ToString().Trim();
                        oeUsuario.PersonEmail = dt.Tables[0].Rows[0]["Person_Email"].ToString().Trim();
                        oeUsuario.PersonPhone = dt.Tables[0].Rows[0]["Person_Phone"].ToString().Trim();
                        oeUsuario.PersonAddres = dt.Tables[0].Rows[0]["Person_Addres"].ToString().Trim();
                        oeUsuario.codCountry = dt.Tables[0].Rows[0]["cod_Country"].ToString().Trim();
                        oeUsuario.Perfilid = dt.Tables[0].Rows[0]["Perfil_id"].ToString().Trim();
                        oeUsuario.companyid = dt.Tables[0].Rows[0]["Company_id"].ToString().Trim();
                        oeUsuario.companyName = dt.Tables[0].Rows[0]["Company_Name"].ToString().Trim();
                        oeUsuario.PersonStatus = Convert.ToBoolean(dt.Tables[0].Rows[0]["Person_Status"].ToString().Trim());
                        oeUsuario.Moduloid = dt.Tables[0].Rows[0]["Modulo_id"].ToString().Trim();
                        oeUsuario.idlevel = dt.Tables[0].Rows[0]["Id_level"].ToString().Trim();
                        oeUsuario.leveldescription = dt.Tables[0].Rows[0]["namelevel"].ToString().Trim();
                        return oeUsuario;
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
            [WebMethod(Description = "Metdodo para Obtener los niveles por usuario_Cliente")]
            public DataTable Get_ObtenerNivelesUSuario(string sperfilid) {
                Conexion oCoon = new Conexion();
                DataTable dtnivel = null;
                dtnivel = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENERNIVELES", sperfilid);
                return dtnivel;

            
            
            
            }


            [WebMethod(Description = "Metodo Para Obtener Servicios Servicios Activos para un Cliente")]
            public DataSet Get_Obtener_Servicios_Activos(int icompanyid, string scodcountry)
            {
                Conexion oCoon = new Conexion();
                DataSet dsservice = null;
               
                dsservice = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERSERVICESACTIVOS", icompanyid, scodcountry);
                               
                 
                return dsservice;






            }

            [WebMethod(Description = "Metodo para Obtener Canales x Servicio y Cliente")]
            public DataSet Get_Obtener_Channels_Client(int icodservice, int icompanyid)
            {
                Conexion oCoon = new Conexion();
                DataSet dsccanal = null;
                dsccanal = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERCNALXSERVICIO", icodservice, icompanyid);
                return dsccanal;





            }

            [WebMethod(Description = "Metodo para Obtener las Actividades en el Comercio asociados a un cliente")]
            public DataSet Get_Obtener_ActividadesComercio_Cliente(int iservice, int idcompany, string scodchannel) {
                Conexion oCoon = new Conexion();
                DataSet dsac = null;
                dsac = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENER_ACTIVIDADESCOMERCIO", iservice, idcompany, scodchannel);
                return dsac;
            
            
            
            
            
            }
            [WebMethod(Description = "Metodo para Obtener Paises donde tenga campañas el Cliente")]
            public DataSet Get_obtenerPaises_Cliente(int icompany) {

                Conexion oCoon = new Conexion();
                DataSet dscountry = null;
                dscountry = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERPAISESXCLIENTE", icompany);
                return dscountry;
            
            
            
            
            }

            [WebMethod(Description="Metodo para Obtener Departamentos x Pais")]
            public DataSet Get_ObtenerDepartamentos_Pais(string scodcountry){
              Conexion oCoon= new Conexion();
                DataSet dsdpa=null;
                dsdpa = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERDEPARTAMENTOSXPAIS", scodcountry);
                return dsdpa;
            
            
            
            
            }

            [WebMethod(Description="Metodo para Obtener Ciudades x Pais y Departamento")]
            public DataSet Get_ObtenerCiudadesxPais_Departamento(string scountry, string sdpto){
              Conexion oCoon= new Conexion();
                 DataSet dscity=null;
                  dscity = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERCITYCLIENTE", scountry, sdpto);
                return dscity;
            
            
            
            
            
            
            }

            [WebMethod(Description="Metodo para obtener Distritos Ciudades")]
            public DataSet Get_ObtenerDistritosCity(string scountry, string sdpto, string scity){
              Conexion oCoon = new Conexion();
                DataSet dsdistri=null;
                 dsdistri = oCoon.ejecutarDataSet("UP_WEBSIGE_OBTENERDISTRITOSCLIENTE", scountry, sdpto, scity);
                return dsdistri;
            
            
            }

            [WebMethod(Description = "Metodo para obtener Segmentos")]
            public DataSet Get_OtenerSegmentos() {
                Conexion oCoon = new Conexion();
                DataSet dsseg = null;
                dsseg = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERSEGMENTOS");
                return dsseg;
            
            
            
            
            
            }
            [WebMethod(Description = "Metodo para pbtener los PDV x cliente")]
            public DataSet Get_ObtenerPDVxCliente(int iidsegmen) {
                Conexion Ocoon = new Conexion();
                DataSet dspdv = null;
                dspdv = Ocoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERPDVCLIENTE", iidsegmen);
                return dspdv;
            
            
            
            }

            [WebMethod(Description = "Metodo para Obtener informes Tipo para un Cliente")]
            public DataSet Get_ObtenerInformes_tipo_cliente(int icodservice, int iidcompany) {
                Conexion oCoon = new Conexion();
                DataSet dsinfortip = null;
                dsinfortip = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENER_INFORMESTIPO", icodservice, iidcompany);
                return dsinfortip;
            
            
            
            
            }
            [WebMethod(Description = "Metodo para Obtener Informes Dinamicos para un cliente")]
            public DataSet Get_ObtenerInformes_Dinamico_cliente(int icodservice, int iidcompany) {
                Conexion oCoon = new Conexion();
                DataSet dsinfordi = null;
                dsinfordi = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENER_INFORMESDINAMICOS", icodservice, iidcompany);
                return dsinfordi;
            
            
            
            
            
            }
            [WebMethod(Description = "Metodo para Obtener los tipos de Agrupacion Comercial por Servicio y Cliente")]
            public DataSet Get_ObtenerTiposAgrupacionComercial(int icodservice, int iidcompany) {
                Conexion oCoon = new Conexion();
                DataSet dstac = null;
                dstac = oCoon.ejecutarDataSet("UP_WEBSIGE_OBTENERTUPOAGRUPACIONCOMERCIAL", icodservice, iidcompany);
                return dstac;
            
            
            
            }
            [WebMethod(Description = "Metodo para Obtener las Agrupaciones comerciales con base en los tipos de Agrupacion Comercial")]
            public DataSet Get_ObtenerAgrupacionesComerciales(int idnotype) {
                Conexion oCoon = new Conexion();
                DataSet dsagrup = null;
                dsagrup = oCoon.ejecutarDataSet("UP_WEBSIGE_OBTENERAGRUPACIONCOMERCIAL", idnotype);
                return dsagrup;

            
            
            
            }
            [WebMethod(Description = "Metodo para Obtener las Categorias por Cliente y Servicio")]
            public DataSet Get_ObtenercategoriasCliente_Servicio(int iidcompany, int icodservice) {
                Conexion oCoon = new Conexion();
                DataSet dscatego = null;
                dscatego = oCoon.ejecutarDataSet("UP_WEBSIGE_OBTENERCATEGORIASXCLIENTE_SERVICIO", iidcompany, icodservice);
                return dscatego;
            
            
            
            
            }

            [WebMethod(Description= "Metodo para Obtener las Marcas por Categoria del Cliente")]
            public DataSet Get_ObtenerMarcasCliente(int idcatego){
              Conexion oCoon= new Conexion();
              DataSet dsmarca= null;
                dsmarca = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERMARCASXCATEGORIA",idcatego);
                return dsmarca;

            
            
            
            }
            [WebMethod(Description = "Metodo para obtener las Submarcas de  una Marca del Cliente")]
            public DataSet Get_ObtenerSubmarcaCliente(string smarca) {
                Conexion oCoon = new Conexion();
                DataSet dssmarca = null;
                dssmarca = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERSUBMARCAXMARCACLIENTE", smarca);
                return dssmarca;
            
            
            
            
            }
            [WebMethod(Description = "Metodo para Obtener las Presentaciones del Cliente")]
            public DataSet Get_ObtenerPresentacionesClientte(string sidcatego, int iidmarca, string sidsubmarca) {
                Conexion oCoon = new Conexion();
                DataSet dspre = null;
                dspre = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERPRESENTACIONESCLIENTE", sidcatego, iidmarca, sidsubmarca);
                return dspre;

            
            
            }

            [WebMethod(Description = "Metodo para obtener Categorias x Cliente y Canal")]
            public DataSet Get_ObtenerCategoriasCliente(int icompanyid, string schannel) {
                Conexion oCoon = new Conexion();
                DataSet dscatego = null;
                dscatego = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERCATEGORIAS", icompanyid, schannel);
                return dscatego;
            
            
            
            }

            [WebMethod(Description = "Metodo para obtener presentaciones xCategoria en Cliente")]
            public DataSet Get_ObtenerPresentacionesxCategoria(int icatego1, int icatego2, int icatego3) {
                Conexion oCoon = new Conexion();
                DataSet dspresenta = null;
                dspresenta = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERPRESENTACIONESXCATEGORIA", icatego1,icatego2,icatego3);
                return dspresenta;
            
            
            
            }
            [WebMethod(Description = "Metodo para calcular Ventas  Nacional - Distribución %")]
            public DataSet Get_CalcularVentasNacionalDistribucion(int icatego, string scodchannel)
            {
                Conexion oCoon = new Conexion();
                DataSet dscalven = null;
                dscalven = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERDISTRIBUCIONACUMULADA", icatego,scodchannel);
                return dscalven;
              

           
            
            
            
            }
            [WebMethod(Description = "Metodo para calcular Ventas  Nacional - Distribución %_Dinamico")]
            public DataSet Get_CalcularVentasNacionalDistribucion_Dinamico(int icatego, string scodchannel, int idmarca, string ssubmarca, int icodpresenta)
            {
                Conexion oCoon = new Conexion();
                DataSet dscalven = null;
                dscalven = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERDISTRIBUCIONACUMULADA_DINAMICO", icatego, scodchannel, idmarca, ssubmarca, icodpresenta);
                return dscalven;






            }
            [WebMethod(Description = "Metodo para Obtener el Plan de Ventas x Cliente,canal y Servicio")]
            public DataSet Get_ObtenerPlanVentasCliente(int icompanyid, int icodservice, string scodchannel) {
                Conexion oCoon = new Conexion();
                DataSet dsplan = null;
                dsplan = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERPLANDEVENTAS", icompanyid, icodservice, scodchannel);
                return dsplan;
            
            
            
            
            
            
            }

            [WebMethod(Description = "Metodo Para Obtener los Comentarios del Director de Cuenta por Categoria y canal")]

            public DataSet Get_ObtenerComentariosxCategoria_Canal(int icatego, int icompanyid, string scodchannel) {
                Conexion oCoon = new Conexion();
                DataSet dscomnen = null;
                dscomnen = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERCOMENTARIOSDCUENTA", icatego, icompanyid, scodchannel);
                return dscomnen;
            
            
            
            
            
            
            }
            [WebMethod(Description="Metodo para Obtener el precio Promedio de los Competidores")]
            public DataSet Get_ObtenerPrecionProComeptidores(int icatego1, int icatego2, int icatego3) {
                Conexion oCoon = new Conexion();
                DataSet dscompe = null;
                dscompe = oCoon.ejecutarDataSet("UP_WEBSIGE_OBTENERPRECIOPROMEDIOCOMPETIDORES", icatego1, icatego2, icatego3);
                return dscompe;

            }

            [WebMethod(Description = "Metodo para Obtener el Espacio Lineal_Tipo")]
            public DataSet Get_ObtenerSOD_Tipo(string scodchanel, int icatego, int icatego1, int icatego2, int icompanyid, int icodservice) {
                Conexion oCoon = new Conexion();
                DataSet dssod = null;
                dssod = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERSOD",scodchanel, icatego, icatego1, icatego2, icompanyid, icodservice);
                return dssod;
            
            
            }
           /// <summary>
           /// Modificacion: Se agrega el parametro scompanydi  05/08/2010 Ing.Carlos Hernandez
           /// Modificación: Se agrega el parametro ipersonid  06/08/2010 Ing.Carlos Hernandez
           ///               16/11/2010 se quita string scodcity este parametro no aplica . Ing. Mauricio Ortiz 
           /// </summary> 
           /// <param name="ipersonid"></param>
           /// <param name="schannel"></param>
           /// <param name="scompanyid"></param>
            /// <returns>dtrp</returns>
            [WebMethod(Description = "Metodo para Obtener reporte X Canal en Cliente")]
            public DataTable Get_Obtener_reporteXCliente_Canal(int ipersonid, string schannel, int icompanyid)
            {
                Conexion oCoon = new Conexion();
                DataTable dtrp = null;
                dtrp = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENER_REPORTESXCANAL", ipersonid, schannel, icompanyid);
                return dtrp;
            }
         


            /// <summary>
            /// Creado por: Ing.Carlos Alberto Hernández Rincón
            /// Fecha: 07/08/2010
            /// 
            /// </summary>
            /// <param name="ireportid"></param>
            /// <returns></returns>

            [WebMethod(Description = "Metodo para Obtener Reportes No Contratados por el Cliente")]
            public DataTable Get_ObtenerReportesNoActivos(int ireportid,int icompanyid) {
                Conexion oCoon = new Conexion();
                DataTable dtrna = null;
                dtrna = oCoon.ejecutarDataTable("UP_WEBXPLORA_CLIE_OBTENERREPORINACTIVOS", ireportid, icompanyid);
                return dtrna;
            
            
            
            
            }

           /// <summary>
            /// Creado por: Ing.Carlos Alberto Hernández Rincón
            /// Fecha: 07/08/2010
           /// </summary>
           /// <param name="scountry"></param>
           /// <param name="icompanyid"></param>
           /// <param name="scanal"></param>
           /// <param name="ireportid"></param>
           /// <returns></returns>

            [WebMethod(Description = "Metodo para obtener Informes asociados a Reportes")]
            public DataTable Get_ObtenerurlInformes(string scountry,int icompanyid,string scanal, int ireportid, int ipersonid)
            {
                Conexion oCoon = new Conexion();
                DataTable dtiurl = null;
                dtiurl = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENER_URLINFORMES", scountry, icompanyid, scanal, ireportid, ipersonid);
                return dtiurl;




            }


            /// <summary>
            /// Metodo para consultar url de informes de aquellos clientes con subcanal habilitado
            /// </summary>
            /// <param name="scountry"></param>
            /// <param name="icompanyid"></param>
            /// <param name="scanal"></param>
            /// <param name="ssubcanal"></param>
            /// <param name="ireportid"></param>
            /// <param name="ipersonid"></param>
            /// <returns></returns>
            [WebMethod(Description = "Metodo para obtener Informes asociados a Reportes de clientes con subcanal")]
            public DataTable Get_ObtenerurlInformesconSubcanal(string scountry, int icompanyid, string scanal, string ssubcanal, int ireportid, int ipersonid)
            {
                Conexion oCoon = new Conexion();
                DataTable dtiurl = null;
                dtiurl = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENER_URLINFORMESCONSUBCANAL", scountry, icompanyid, scanal, ssubcanal, ireportid, ipersonid);
                return dtiurl;
            }

            /// <summary>
            ///  /// Creado por: Ing.Carlos Alberto Hernández Rincón
            /// Fecha: 10/08/2010
            /// </summary>
            /// <param name="icompanyid"></param>
            /// <returns></returns>

            [WebMethod(Description = "Metodo para Obtener canales x Cliente")]
            public DataTable Get_ObtenerCanalesxCliente(int icompanyid)
            {
                Conexion oCoon = new Conexion();
                DataTable dtcanal = null;
                dtcanal = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENERCNALXCLIENTE",  icompanyid);
                return dtcanal;




            }


            /// <summary>
            /// Creado por: Ing.Carlos Alberto Hernández Rincón
            /// Fecha: 10/08/2010
            /// </summary>
            /// <param name="scanal"></param>
            /// <param name="icompanyid"></param>
            /// <returns></returns>
            [WebMethod(Description = "Metodo para obtener Canales no Activos x Cliente")]
            public DataTable Get_ObtenercanalNoactivoxCliente(string scanal, int icompanyid)
            {
                Conexion oCoon = new Conexion();
                DataTable dtcanalna = null;
                dtcanalna = oCoon.ejecutarDataTable("UP_WEBXPLORA_CLIENTE_OBTENERCANALNOACTIVO", scanal, icompanyid);
                return dtcanalna;




            }


            /// <summary>
            /// Creado por: Angel Ortiz Rodríguez
            /// Fecha: 01/12/2011
            /// </summary>
            /// <returns></returns>
            [WebMethod(Description = "Metodo para obtener los Productos por año, mes, periodo, ciudad")]
            public DataTable Get_ObtenerProductos_Precios(string anio, string mes, int periodo, string ciudad, int companyid, string catego, Int64 subcatego, int marca, int submarca)
            {
                Conexion oCoon = new Conexion();
                DataTable dtcanalna = null;
                dtcanalna = oCoon.ejecutarDataTable("UP_WEBXPLORA_CLIE_V2_OBTENER_PRODUCTOS_PRECIOS", anio, mes, periodo, ciudad, companyid, catego, subcatego, marca, submarca);
                return dtcanalna;
            }

    #region Metodos Biblioteca POP

            /// <summary>
            /// Metodo para Obtener Categorias por Cliente
            /// Creado por:Ing.Carlos Alberto Hernnández Rincón
            /// Fecha de Creación: 24/06/2010
            /// </summary>
            /// <param name="icomppanyid"></param>
            /// <param name="schannel"></param>
            /// <returns></returns>
            [WebMethod(Description = "Metodo para obtener  Categorias")]
            public DataSet Get_ObtenerCategoriasPOP(int icomppanyid, string schannel)
            {
                Conexion oCoon = new Conexion();
                DataSet dscatego = null;
                dscatego = oCoon.ejecutarDataSet("UP_WEBXPLORA_BPOP_OBTENERCATEGORIAS", icomppanyid, schannel);
                return dscatego; 
            }
            
           /// <summary>
           /// Metodo para Obtener Marcas por Cateoria
           /// Creado por:Ing.Carlos Alberto Hernnández Rincón
           /// Fecha de Creación: 23/06/2010 
           /// </summary>
           /// <param name="scatego"></param>
           /// <param name="icompany_id"></param>
           /// <returns></returns>
            [WebMethod(Description = "Metodo para obtener Marcas x Categorias")]
            public DataSet Get_ObtenerMarcasPOP(string scatego, int icompany_id, string schannel) {
                Conexion oCoon = new Conexion();
                DataSet dsm = null;
                dsm = oCoon.ejecutarDataSet("UP_WEBXPLORA_BPOP_OBTENERMARCASXCATEGORIA", scatego, icompany_id, schannel);
                return dsm;            
            }
            /// <summary>
            ///  /// Metodo para Obtener Materiales por Marca
            /// Creado por:Ing.Carlos Alberto Hernnández Rincón
            /// Fecha de Creación: 23/06/2010
            /// </summary>
            /// <param name="scatego"></param>
            /// <param name="imarca"></param>
            /// <returns></returns>
            [WebMethod(Description = "Metodo para obtener Materiales x marcas")]
            public DataSet Get_ObtenerPOPxMarca(string scatego ,int icompany_id, int imarca, string sChannel)
            {
                Conexion oCoon = new Conexion();
                DataSet dspop = null;
               dspop= oCoon.ejecutarDataSet("UP_WEBXPLORA_BPOP_OBTENERMPOPXCATEGORIA_MARCA", scatego,icompany_id,imarca, sChannel);
               return dspop;
            }

            /// <summary>
            /// Metodo para Obtener las fotografias detallada del material pop 
            /// Creado por: Ing. Mauricio Ortiz
            /// Fecha de Creación: 06/07/2010 
            /// </summary>
            /// <param name="iid_infoPOP"></param>
            /// <returns></returns>
            [WebMethod(Description = "Método para obtener las fotografias de material pop detallado")]
            public DataSet Get_ObtenerPOPDetallado(int iid_infoPOP)
            {
                Conexion oCoon = new Conexion();
                DataSet dsPOPDetalle = null;
                dsPOPDetalle = oCoon.ejecutarDataSet("UP_WEBSIGE_CLIENTE_OBTENERFOTOSBIBLIOTECAPOPDETALLE", iid_infoPOP);
                return dsPOPDetalle;
            }

            /// <summary>
            /// Metodo para validar la opcion de Biblioteca POP por usuario
            /// Creado Por :Ing. Carlos Hernandez
            /// Fecha:10/08/2010
            /// modificación: 01/12/2010 se agrega parametro company_id para suplir requerimiento de acceso a varios clientes. Ing. Mauricio Ortiz
            /// 
            /// </summary>
            /// <param name="iPersonid"></param>
            /// <returns></returns>

            [WebMethod(Description = "Método para Obtener la Visualizacion del Boton de Biblioteca POP x Usuario")]
            public DataTable Get_obtnerBotonBlioteca(int iPersonid, int icompany_id )
            {
                Conexion oCoon = new Conexion();
                DataTable dtpop = null;
                dtpop = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENERBOTONPOP", iPersonid , icompany_id);
                return dtpop; ;
            }


            /// <summary>
            /// Metodo para validar la opcion de Información gerencial  por usuario
            /// Creado Por :Ing. Mauricio Ortiz
            /// Fecha:06/12/2010
            /// <param name="iPersonid"></param>
            /// <param name="icompany_id"></param>
            /// <returns></returns>
            [WebMethod(Description = "Método para Obtener la Visualizacion del Boton de información gerencial por usuario ")]
            public DataTable Get_obtnerBotonINfGerencial(int iPersonid, int icompany_id)
            {
                Conexion oCoon = new Conexion();
                DataTable dtbtnInfGerencial = null;
                dtbtnInfGerencial = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENERBOTONINFGERENCIAL", iPersonid, icompany_id);
                return dtbtnInfGerencial; ;
            }

            /// <summary>
            /// Metodo para validar la opcion de resumen ejecutivo  por usuario
            /// </summary>
            /// <param name="iPersonid"></param>
            /// <param name="icompany_id"></param>
            /// <returns></returns>
            [WebMethod(Description = "Método para Obtener la Visualizacion del Boton de Resumen Ejecutivo  por usuario ")]
            public DataTable Get_obtnerBotonResumen_Ejecutivo (int iPersonid, int icompany_id)
            {
                Conexion oCoon = new Conexion();
                DataTable dtbtnResumen_Ejecutivo  = null;
                dtbtnResumen_Ejecutivo = oCoon.ejecutarDataTable("UP_WEBSIGE_CLIENTE_OBTENERBOTONResumen_Ejecutivo", iPersonid, icompany_id);
                return dtbtnResumen_Ejecutivo; ;
            }

    #endregion

            #region Nuevos Metodos Version 2 Xplora
            /// <summary>
            /// Creado por Ing. Carlos Hernandez
            /// Fecha de Creacion: 15/10/2010
            /// </summary>
            /// <param name="icompanyid"></param>
            /// <param name="scanal"></param>
            /// <param name="ipath"></param>
            /// <returns></returns>
            [WebMethod(Description = "Método para llenar combos Cliente v.2")]
            public DataTable Get_Obtenerinfocombos(int icompanyid, string scanal,string scatego, int ipath)
            {
                DataTable dtcomb = oCoon.ejecutarDataTable("UP_WEXPLORA_CLIEN_V2_LLENACOMBOS", icompanyid, scanal,scatego, ipath);
                return dtcomb;
            }


            /// <summary>
            /// Creado Por: Ing. Carlos Hernandez
            /// Fecha: 07/07/2011
            /// </summary>
            /// <param name="icompanyid"></param>
            /// <param name="scanal"></param>
            /// <param name="scatego"></param>
            /// <param name="ipath"></param>
            /// <returns></returns>
            [WebMethod(Description = "Método para llenar combos Cliente v.2")]
            public DataTable Get_Obtenerinfocombos_F(int icompanyid, string scanal, int ireport, string scatego, int ipath)
            {
                DataTable dtcomb = oCoon.ejecutarDataTable("UP_WEXPLORA_CLIEN_V2_LLENACOMBOS_G", icompanyid, scanal, ireport, scatego, ipath);
                return dtcomb;
            }





            #endregion


}
}