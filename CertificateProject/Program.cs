var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//builder.Services.AddAuthentication(
//        CertificateAuthenticationDefaults.AuthenticationScheme)
//    .AddCertificate();

IServiceCollection services = new ServiceCollection();

services.AddControllers();

services.AddCertificateForwarding(options =>
{
    options.CertificateHeader = "X-SSL-CERT";
});


app.UseHttpsRedirection();

app.UseCertificateForwarding();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseAuthentication();


app.MapGet("/", () => "Hello World!");

app.Run();
