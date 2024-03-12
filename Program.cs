﻿using RepoDb;
using Metaphor_Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
// using Metaphor_Backend.Hubs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Metaphor_Backend.Models;
using Metaphor_Backend.Controllers;
using Metaphor_Backend.Repositories;
using Microsoft.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration
 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
 .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
builder.Services.Configure<Setting>(builder.Configuration.GetSection("Setting"));
var setting = builder.Configuration.GetSection("Setting").Get<Setting>();
#pragma warning disable CS8604 // Possible null reference argument.
builder.Services.AddSingleton<Setting>(setting);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS0612 // Type or member is obsolete
setting.InitializeRepoDb();
#pragma warning restore CS0612 // Type or member is obsolete
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<EmployeeRepository>();
builder.Services.AddSingleton<EmployeeTypeRepository>();
builder.Services.AddSingleton<DepartmentRepository>();
builder.Services.AddSingleton<PatientRepository>();
builder.Services.AddSingleton<PatientFilesRepository>();
builder.Services.AddSingleton<SampleDetailRepository>();
builder.Services.AddSingleton<SamplePerServiceRepository>();

builder.Services.AddSingleton<CollectionSiteRepository>();

            // Register SampleTypeMasterRepository as a singleton
builder.Services.AddSingleton<SampleTypeMasterRepository>();

            // Register ReferralTypeRepository as a singleton
builder.Services.AddSingleton<ReferralTypeRepository>();

            // Register ServiceMasterRepository as a singleton
builder.Services.AddSingleton<ServiceMasterRepository>();
// builder.Services.AddSingleton<ShiftRepository>();
// builder.Services.AddSingleton<ApprovalRequestRepository>();
// builder.Services.AddSingleton<ApprovalRepository>();
builder.Services.AddScoped<UsersRolesRepository>();
// builder.Services.AddScoped<PatientRepository>();
// builder.Services.AddScoped<RequestFormPatientRepository>();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("CorsPolicy");


app.UseAuthorization();

app.MapRazorPages();


app.MapRazorPages();
app.MapControllers();
// app.MapHub<NotificationHub>("/notificationHub");
// app.MapHub<MetaphorApprovalHub>("/Hubs");

app.Run();
