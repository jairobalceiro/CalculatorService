using CalculatorService.Service;
using Serilog;
using System;
using System.Data;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;

namespace CalculatorService.Server.Response
{
    /// <summary>
    /// Respuesta 
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// TryAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static Response<T> Try<T>(Func<T> action, ILogger logger)
        {
            var response = new Response<T>();

            if (logger != null)
            {
                try
                {
                    response.Data = action();
                    response.Successful = true;
                    response.ErrorStatus = HttpStatusCode.OK;
                }
                catch (ServiceException businessEx)
                {
                    string error = string.Format(CultureInfo.CurrentCulture, "Message : {0} , StackTrace : {1} , Source : {2}, InnerException: {3}", businessEx.Message, businessEx.StackTrace, businessEx.Source, businessEx.InnerException == null ? "" : businessEx.InnerException.Message);
                    logger.Error(error);
                    response.ErrorMessage = "internal error";
                    response.ErrorStatus = HttpStatusCode.InternalServerError;

                }
                catch (DataException ex)
                {
                    string error = string.Format(CultureInfo.CurrentCulture, "Message : {0} , StackTrace : {1} , Source : {2}, InnerException: {3}", ex.Message, ex.StackTrace, ex.Source, ex.InnerException == null ? "" : ex.InnerException.Message);
                    logger.Error(error);
                    response.ErrorMessage = "internal error";
                    response.ErrorStatus = HttpStatusCode.InternalServerError;
                }
                catch (Exception ex)
                {
                    string error = string.Format(CultureInfo.CurrentCulture, "Message : {0} , StackTrace : {1} , Source : {2}, InnerException: {3}", ex.Message, ex.StackTrace, ex.Source, ex.InnerException == null ? "" : ex.InnerException.Message);
                    logger.Error(error);
                    response.ErrorMessage = "internal error";
                    response.ErrorStatus = HttpStatusCode.InternalServerError;
                }
            }

            return response;
        }
    }
}
