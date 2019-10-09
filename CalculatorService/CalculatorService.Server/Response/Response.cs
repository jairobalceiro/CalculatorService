using System.Net;

namespace CalculatorService.Server.Response
{
    public class Response<TEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        public TEntity Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode ErrorStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode ErrorCode { get; set; }

        /// <summary>
        /// constructor's method
        /// </summary>
        public Response()
        {
            this.Successful = false;
        }
    }
}
