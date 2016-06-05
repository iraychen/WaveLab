using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;


using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using Newtonsoft.Json;

namespace WaveLab.Web
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SMTFileInduce : IHttpHandler
    {
        ISYSModuleTypeService SYSModuleTypeService;
       
        public void ProcessRequest(HttpContext context)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");

            string ModuleTypeId = context.Request.Params["ModuleTypeId"];
            SYSModuleTypeInfo entity = SYSModuleTypeService.GetDetail(ModuleTypeId);
            string output = JsonConvert.SerializeObject(entity);

            context.Response.ContentType = "application/json";
            context.Response.Write(output);   
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
