﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PicKeyFinder.Code.Core;
using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.LogSystemMessage(LogLevel.None, "====================================================");
            Logger.LogSystemMessage(LogLevel.None, "System Start");


            var builder = WebApplication.CreateBuilder(args);
            var taskDistributor = new TaskDistributor(5);
            builder.Services.AddSingleton(taskDistributor);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(4988);  // 监听端口
            });

            //builder.Logging.ClearProviders(); // 清除默认的日志提供者
            //builder.Logging.AddConsole();     // 添加控制台日志
            //builder.Logging.SetMinimumLevel(LogLevel.Warning); // 设置最小日志级别为 Warning

            // 添加控制器服务
            builder.Services.AddControllers();

            var app = builder.Build();

            // 配置HTTP请求管道
            // app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers(); // 映射控制器路由

            Console.WriteLine("Pregame is running");
            app.Run();
        }
    }

}