using System;
using System.Collections.Generic;
using System.Text;

namespace PDEXLib
{
    public class Token
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Token_Expires_In { get; set; }
    }
}
