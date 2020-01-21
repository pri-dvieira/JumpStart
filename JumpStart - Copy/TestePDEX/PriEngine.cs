using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpBS100;
using Primavera.Extensibility.Engine;
using StdBE100;
using StdPlatBS100;
using static StdBE100.StdBETipos;

namespace TestePDEX
{
    static class PriEngine
    {
        static ErpBS _BSO { get; set; }
        static StdPlatBS _Plataforma { get; set; }

        static EnumTipoPlataforma _TipoPlataforma = EnumTipoPlataforma.tpEmpresarial;
        enum TipoImpressao { PreVisualizacao = 1, Impressao = 2, Exportacao = 3 }

        static string _Instancia = "Default";
        static string _Utilizador = "daniel.vieira";
        static string _Password = "";
        static string _Company = "DEMOV10";

        public static ErpBS BSO
        {
            get
            {
                if (_BSO == null)
                {
                    try
                    {
                        Debug.WriteLine("A instanciar motor.");
                        _BSO = new ErpBS();
                        _BSO.AbreEmpresaTrabalho(_TipoPlataforma, _Company, _Utilizador, _Password, strInstancia: _Instancia);

                        // Use this service to trigger the API events.
                        ExtensibilityService service = new ExtensibilityService();

                        service.Initialize(_BSO);

                        // Check if service is operational
                        if (service.IsOperational)
                        {
                            // Inshore that all extensions are loaded.
                            service.LoadExtensions();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Erro ao instanciar o motor :( \r\n{0}\r\n{1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "");

                        throw;
                    }

                    Debug.WriteLine("Motor instanciado");
                }

                return _BSO;
            }
        }

        public static StdPlatBS Plataforma
        {
            get
            {
                if (_Plataforma == null)
                {
                    Debug.WriteLine(string.Format("A inicializar a plataforma com o user {0}", _Utilizador));

                    _Plataforma = new StdPlatBS();

                    StdBSConfApl stdConfApl = new StdBSConfApl
                    {
                        Instancia = _Instancia,
                        AbvtApl = "ERP",
                        Utilizador = _Utilizador,
                        PwdUtilizador = _Password,
                        LicVersaoMinima = "10.00"
                    };

                    StdBETransaccao objStdTransac = new StdBETransaccao();

                    _Plataforma.AbrePlataformaEmpresa(_Company, objStdTransac, stdConfApl, _TipoPlataforma);

                    Debug.WriteLine("Plataforma inicializada.");

                    return _Plataforma;
                }
                else
                {
                    return _Plataforma;
                }
            }
        }

        public static void Terminate()
        {
            try
            {
                if (_Plataforma != null)
                {
                    _Plataforma.FechaPlataformaEmpresa();
                    _Plataforma = null;
                }
            }
            catch
            { }

            try
            {
                if (_BSO != null)
                {
                    _BSO.FechaEmpresaTrabalho();
                    _BSO = null;
                }
            }
            catch
            { }
        }
    }
}
