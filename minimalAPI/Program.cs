//NOTE: https://youtu.be/RRrsFE6OXAQ

using minimalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();


/******************************************************************************************/
// Middleware ExceptionHandling
app.Use(async (ctx, next)=>
{
	try
	{
		await next();
	}
	catch (Exception)
	{
		ctx.Response.StatusCode = 500;
		await ctx.Response.WriteAsync("An error occured");
	}
});
/******************************************************************************************/

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();

