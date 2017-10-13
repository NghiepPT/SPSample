using System;
using System.Net;
namespace SPSample.WebServices
{
    internal class SPAuthenticationWS : Authentication.Authentication
    {
        #region Properties
        new internal Uri Url
        {
            get
            {
                return new Uri(base.Url);
            }
            set
            {
                base.Url = value != null ? value.ToString() : String.Empty;
            }
        }
        #endregion
        internal SPAuthenticationWS(NetworkCredential credentials, Uri url)
        {
            if(credentials == null)
            {
                throw new ArgumentNullException("credentials");
                if (url == null)
                    throw new ArgumentNullException("url");
                string sUrlService = url.ToString().TrimEnd('/') + "/" + SiteRelativeSharePointWebServiceUrls.AuthenticationWSUrlEnding;
                //update properties of Soap web client
                this.Credentials = credentials;
                this.Url = new Uri(sUrlService);
                this.CookieContainer = new CookieContainer();

            }
        }
    }
}
