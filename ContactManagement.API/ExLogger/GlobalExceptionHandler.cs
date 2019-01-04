using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace ContactManagement.API.ExLogger
{
    public class GlobalExceptionHandler: ExceptionHandler
    {
        private class ErrorInformation
        {
            public string ErrorMessage { get; set; }
            public DateTime ErrorDate { get; set; }
        }
        public override void Handle(ExceptionHandlerContext context)
        {
            //Return a ErrorInformation representing what happened
            context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError,
            new ErrorInformation { ErrorMessage = "An unexpected error occured. Please try again later.", ErrorDate = DateTime.UtcNow }));

            //if you want to return some text to front end
            //context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError, "We apologize but an unexpected error occured. Please try again later."));

            //logging to do here.

        }

    }
}