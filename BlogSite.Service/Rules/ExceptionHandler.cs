using Core.Exceptions;
using Core.Responses;
using System.ComponentModel.DataAnnotations;


namespace BlogSite.Service.Rules
{
    public static class ExceptionHandler<T>
    {
        public static ReturnModel<T> HandleException(Exception ex)
        {
            if (ex.GetType() == typeof(NotFoundException))
            {
                return new ReturnModel<T>()
                {
                    Message = ex.Message,
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
     
            return new ReturnModel<T>()
            {
                Message = ex.Message,
                Success = false,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
