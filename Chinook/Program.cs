using Chinook;
using ServiceStack;

ServiceStack.Licensing.RegisterLicense("OSS BSD-3-Clause 2023 https://github.com/NetCoreApps/Chinook DNRGgV4zhrOAPfM/c37Aqsnhl8T1637c0tHsjLnd0mHS/rNfrZ4ch2jTdRltNiZme7maFpk9rEZHCSce7VJU1bTVLLAirVF5ZXNhdvC+Tgg2Gt9N7tHVqLcA4kiuNts+ovb1PBhmFaWGAenWTbjDJKQFZspM5DNhzfCkLoHJhCc=");

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