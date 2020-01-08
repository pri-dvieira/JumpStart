using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.BusinessEntities.ExtensibilityService.EventArgs;
using Primavera.Extensibility.Platform.Services;

namespace PDEX.Extensibility.Platform
{
    public class UiPlataforma : Plataforma
    {
        public override void DepoisDeAbrirEmpresa(ExtensibilityEventArgs e)
        {
            Globals.globalFunctions = new GlobalFunctions(BSO, PSO);
        }
    }
}
