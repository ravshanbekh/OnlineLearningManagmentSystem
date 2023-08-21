using OnlineLearningManagmentSystem.Models;
using Service.Exeptions;

namespace OnlineLearningManagmentSystem.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (NotFoundException exception)
            {
                context.Response.StatusCode=exception.StatusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = context.Response.StatusCode,
                    Message = exception.Message
                });
            }
            catch(AllReadyExistException exception) 
            {
                context.Response.StatusCode=exception.StatusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = context.Response.StatusCode,
                    Message = exception.Message
                }) ;
            }
            catch (Exception exception)
            {
                this.logger.LogError($"{exception}\n\n");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
        }
    }
}
