using Chinook;
using ServiceStack;

Licensing.RegisterLicense("OSS BSD-3-Clause 2022 https://github.com/NetCoreApps/Chinook CkX/MACtdb/ZNeFHqQHZvkkm9O4u2Mu1L7jnEeZLd3Wxy7pgqp6EL/gvUexr+oTOxsu0QLIRHQe2UbWpyPZfogOsK62EFAWwRFejcxHOtFPw+hn2YQZuzUByBBR3emy8lFogzZclbaXCb0t2VAIuc33TsOfREjWL3tvWznf0VL8=");

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseServiceStack(new AppHost());

app.Run();