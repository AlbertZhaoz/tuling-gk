using System.IO.Compression;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Furion;
using VOL.Test.Tool.Common;

namespace VOL.Test.Tool.Services
{
    [Command("publish",Description = "Auto publish")]
    public class AutoPublish:ICommand
    {
        [CommandOption("save",'s',Description = "please choose a dir to save")]
        public string? SaveCommand { get; set; }

        public string? SaveDirPath { get; set; } = @"E:\publish\";

        public async ValueTask ExecuteAsync(IConsole console)
        {
            var webApiCollectionPath = App.GetConfig<string>("VOL.WebApi.Collection.Path");
            var webApiPath = App.GetConfig<string>("VOL.WebApi.Path");
            var webApiFontPath = App.GetConfig<string>("VOL.WebApi.Font.Path");
            var webApiDbPath = App.GetConfig<string>("VOL.WebApi.Db.Path");
            var destDir = "";

            if (string.IsNullOrEmpty(App.GetConfig<string>("DestDir")))
            {
                SaveDirPath = @"E:\publish\";
                destDir = SaveDirPath + DateTime.Now.ToString("yyMMddhhmmss");
                
            }
            else
            {
                SaveDirPath = App.GetConfig<string>("DestDir");
                destDir = SaveDirPath + DateTime.Now.ToString("yyMMddhhmmss");
            }

            // 文件夹存在，清空所有内容
            DirectoryInfo di = new DirectoryInfo(SaveDirPath);

            // 删除所有文件
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            // 删除所有子目录及其内容
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            console.Output.WriteLine("Folder contents cleared.");

            // 判断文件夹是否存在如果不存在则创建
            if (!Directory.Exists(destDir))
            {
                // 文件夹不存在，创建它
                Directory.CreateDirectory(destDir);
                console.Output.WriteLine("Folder created!");
            }

            console.Output.WriteLine($"保存路径{destDir}");

            try
            {
                // 开始 dotnet publish 
                List<string> cmdList = new();
                cmdList.Add($"cd {webApiCollectionPath}");
                cmdList.Add($"dotnet publish -o {destDir}\\webapi-collection");
                cmdList.Add($"cd {webApiPath}");
                cmdList.Add($"dotnet publish -o {destDir}\\webapi");
                cmdList.Add($"cd {webApiFontPath}");
                cmdList.Add($"npm run build");
                CommandHelper.ExecuteCmd(cmdList);

                Directory.Move($"{webApiFontPath}\\dist", $"{destDir}\\dist");

                // 拷贝 Db 到 dest 目录下
                File.Copy(webApiDbPath, destDir + "\\mes.sql");

                // 等待文件系统完成所有操作
                // WaitForFileOperationsToComplete(destDir);

                // 获取上一级文件夹开始压缩
                ZipHelper zip = new ZipHelper();
                zip.CreateZip(SaveDirPath, destDir + ".zip");

                console.Output.WriteLine("Zip file created successfully.");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        private void WaitForFileOperationsToComplete(string directory)
        {
            bool isLocked = true;
            int retries = 5;
            while (isLocked && retries > 0)
            {
                try
                {
                    // 尝试创建一个文件，如果成功则表明没有锁定
                    using (var fs = File.Create(Path.Combine(directory, "tempfile.tmp"), 1, FileOptions.DeleteOnClose))
                    {
                        isLocked = false;
                    }
                }
                catch
                {
                    // 等待一段时间再重试
                    Thread.Sleep(1000);
                }
                retries--;
            }
            if (isLocked)
            {
                throw new IOException("Directory is locked by another process.");
            }
        }


        public void ZipFileDirectory(string sourcePath, string destinationName)
        {
            // 创建一个 zip 存档文件
            ZipFile.CreateFromDirectory(sourcePath, destinationName);
        }
    }
}
