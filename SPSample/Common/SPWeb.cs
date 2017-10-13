using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPSample.WebServices;
using System.Xml;
using System.Xml.Linq;
namespace SPSample.Common
{
    internal class SPWeb
    {
        private Uri Url;
        private SPContext Context;
        
        public SPWeb(SPContext context, Uri url)
        {
            Context = context;
            Url = url;

        }
        public List<SPSite> GetSites()
        {

            List<SPSite> sites = new List<Common.SPSite>();
            using (SPWebWS web = new SPWebWS(Context.Credentials, Context.Cookies, this.Url))
            {
                try
                {
                    XElement xE = null;
                    XmlNode xNode = web.GetWebCollection();
                    if (xNode != null)
                    {
                        xE = xNode.GetXElement();
                        if (xE != null)
                        {
                            XNamespace defaultNS = xE.GetDefaultNamespace();
                            foreach (var element in xE.Elements(defaultNS + "Web"))
                            {
                                SPSite site = new SPSite();
                                site.Url = element.Attribute(WebSchemaAttributes.Url).Value;
                                site.Title = element.Attribute(WebSchemaAttributes.Title).Value;
                                //site.Desription = element.Attribute(WebSchemaAttributes.Description).Value;
                                sites.Add(site);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return sites;
            }

        }

    }
}
