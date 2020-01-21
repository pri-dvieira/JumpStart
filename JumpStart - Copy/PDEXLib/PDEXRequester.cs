using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PDEXLib
{
    public class PDEXRequester : IPDEXRequester
    {
        readonly string baseURI = "https://api-pdex.gov.cv:8242/t/financas.gov/mfservicesexterno/1.0.0/";
        public static Token authToken;

        #region Authentication

        public void Authentication(string user, string password)
        {
            //using (WebClient client = new WebClient())
            //{
            //    client.BaseAddress = baseURI;

            //    NameValueCollection values = new NameValueCollection();
            //    values.Add("username", user);
            //    values.Add("password", password);
            //    values.Add("grant_type", "password");

            //    byte[] data = client.UploadValues("token", values);

            //    string strToken = Encoding.UTF8.GetString(data);

            //    authToken = JsonConvert.DeserializeObject<Token>(strToken);
            //}

            authToken.Access_Token = "160891a0-c761-377a-b922-a39a420929b4";
            authToken.Token_Type = "bearer";
            authToken.Token_Expires_In = 1199;
        }

        public Task<bool> AuthenticationAsync(string user, string password)
        {
            throw new NotImplementedException();
        }

        #endregion Authentication

        #region Cabimentação

        public Cabimento GetCabimento()
        {
            try
            {
                //using (WebClient client = new WebClient())
                //{
                //    client.BaseAddress = baseURI;
                //    client.Headers.Add(HttpRequestHeader.Authorization, authToken.Token_Type + " " + authToken.Access_Token);

                //    NameValueCollection values = new NameValueCollection();
                //    values.Add("p_cc_origem_id", "");
                //    values.Add("p_ent_dest_nif", "");
                //    values.Add("p_valor", "");
                //    values.Add("p_financiador", "");
                //    values.Add("p_economica_des_id", "");
                //    values.Add("p_descricao", "");
                //    values.Add("p_moeda", "");
                //    values.Add("P_CAB_DES_ID", "");
                //    values.Add("p_email", "");
                //    values.Add("P_ERR", "");
                //    values.Add("p_recuperacao", "");
                //    values.Add("p_origem", "");
                //    values.Add("p_id_origem", "");
                //    values.Add("p_tipo_documento", "");
                //    values.Add("p_id_documento", "");

                //    byte[] data = client.UploadValues("", values);

                //    string strCabimento = Encoding.UTF8.GetString(data);
                //    Cabimento cabimento = JsonConvert.DeserializeObject<Cabimento>(strCabimento);

                //    return cabimento;
                //}

                return new Cabimento { p_err = "", p_cab_des_id = 123456789 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<string> GetCabimentoAsync()
        {
            throw new NotImplementedException();
        }

        Task<Cabimento> IPDEXRequester.GetCabimentoAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Cabimentação
    }
}
