using Furion.SpecificationDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSY.Web.Core.Controllers
{
    [Route("Swagger")]
    public class SwaggerController : IDynamicApiController
    {
        [HttpPost, AllowAnonymous, NonUnify]
        public int CheckUrl()
        {
            return 401;
        }

        [HttpPost, AllowAnonymous, NonUnify]
        public int SubmitUrl([FromForm] SpecificationAuth auth)
        {
            // 读取配置信息
            var userName = App.Configuration["SpecificationDocumentSettings:LoginInfo:UserName"];
            var password = App.Configuration["SpecificationDocumentSettings:LoginInfo:Password"];

            if (auth.UserName == userName && auth.Password == password)
            {
                return 200;
            }
            else
            {
                return 401;
            }
        }

    }
}
