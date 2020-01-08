using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDEXERP
{
    public class Main
    {
        public bool CreateCabimento()
        {
            try
            {
                PDEXLib.PDEXRequester pDEXRequester = new PDEXLib.PDEXRequester();

                PDEXLib.Cabimento cabimento = pDEXRequester.GetCabimento();



                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
