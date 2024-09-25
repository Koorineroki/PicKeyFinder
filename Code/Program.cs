using Microsoft.AspNetCore.Builder;
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
            
            Console.WriteLine("デバッグモードを有効にしますか?（y/N）");

            var debugMode = Console.ReadLine() ?? string.Empty;
            debugMode = debugMode.ToLower();
            var debug = false;
            
            if (debugMode == "y" || debugMode == "yes")
            {
                debug = true;
                Console.WriteLine("DebugMode: On.");
            }
            else
            {
                debug = false;
                Console.WriteLine("DebugMode: off");
            }

            var builder = WebApplication.CreateBuilder(args);
            var taskDistributor = new TaskDistributor(5,debug);
            builder.Services.AddSingleton(taskDistributor);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(4988);  // 监听端口
            });

            //这部分是调整HTTP模块的输出的
            //测试上传
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