using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Functions;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class MyProfileController : ApiController
    {
        MyProfileFunction function = new MyProfileFunction();

        [HttpPost]
        [Route("api/my-profile/save-my-profile")]

        public HttpResponseMessage SaveMyProfile([FromBody] MyProfileModel data)
        {
            if (function.SaveMyProfile(data))
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Server Error");
            }
        }

        [HttpGet]
        [Route("api/my-profile/get-my-profile")]

        public HttpResponseMessage GetMyProfile()
        {
            if (function.GetMyProfile(out List<MyProfileModel> data))
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Server Error");
            }
        }

        [HttpGet]
        [Route("api/my-profile/delete-my-profile/{id}")]

        public HttpResponseMessage DeleteMyProfile(int id)
        {
            if (function.DeleteMyProfile(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Server Error");
            }
        }

        [HttpGet]
        [Route("api/my-profile/update-my-profile/{id}")]

        public HttpResponseMessage UpdateMyProfile(MyProfileModel data, int id)
        {
            if (function.UpdateMyProfile(data, id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Server Error");
            }
        }
    }
}
