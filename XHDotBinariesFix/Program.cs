using System;
using System.IO;

namespace XHDotBinariesFix
{
    /// <summary>
    /// 项目信息
    /// </summary>
    class ProjectInfo
    {
        /// <summary>项目名称</summary>
        public static string ProjectName = "XHDotBinariesFix";
        /// <summary>帮助文本</summary>
        public static string HelpText = "XHDotBinariesFix\n-Use -I or --Install to install.\n-Use -R or --Reinstall to reinstall or forced install.\n-User -D or --Download <Version> to download.(Not available yet)\n-Use -A or --About to see about document.\nUse -H or --Help to see help document.";
        /// <summary>版本号</summary>
        public static string Version = "v.1.1.0.0";
        /// <summary>更新日志</summary>
        public static string UpdateInfo = "v.1.1.0.0:\n-添加了ProjectInfo类,以此实现了部分功能\n-添加了Variables类,可以修改依赖包名称\n-未来会添加来自相互科技存储中心的下载功能";
        /// <summary>开发者信息</summary>
        public static string DeveloperInfo = "相互科技";
        /// <summary>开源许可证</summary>
        public static string LICENSE = "MIT OpenSource License";
        /// <summary>项目说明</summary>
        public static string AboutProject = ProjectName + " " + Version + "\nThis project is for users who have not install a .NET Core or a .NET Framework to run .NET Apps.\nYou can run this program as a .NET Core packet version without installing.";
        /// <summary>关于</summary>
        public static string About = "This project can be get in GitHub , Gitee and Each Studios'website.";
    }
    /// <summary>
    /// 变量类
    /// </summary>
    class Variables
    {
        public static string x86FileName = "ndr31_86.exe";
        public static string x64FileName = "ndr31_64.exe";
        public static string frameworkFileName = "ndp48_86_64.exe";
        public static string DepFolderPath = @".\dotnetDep\";
    }
    /// <summary>
    /// 程序主模块
    /// </summary>
    class Program
    {
        static string x86FileName = Variables.x86FileName;
        static string x64FileName = Variables.x64FileName;
        static string frameworkFileName = Variables.frameworkFileName;
        static string DepsPath = Variables.DepFolderPath;
        static string WrongArgsText = "This opration is not available or it is wrong.\nUse \"-H\" for help.\n\n\n" + ProjectInfo.HelpText;

        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Console.WriteLine(ProjectInfo.HelpText);
                    break;
                case 1:
                    switch (args[0])
                    {
                        case "-I":
                        case "--Install":
                            Install();
                            break;
                        case "-R":
                        case "--Reinstall":
                            Reinstall();
                            break;
                        case "-A":
                        case "--About":
                            Console.WriteLine(ProjectInfo.AboutProject+"\n"+ProjectInfo.About+"\n"+ProjectInfo.UpdateInfo);
                            break;
                        case "-H":
                        case "--Help":
                            Console.WriteLine(WrongArgsText);
                            break;
                        default:
                            Console.WriteLine(WrongArgsText);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine(WrongArgsText);
                    break;
            }

        }
        static void Reinstall()
        {
            bool lostCore86 = false;
            bool lostCore64 = false;
            bool lostFramework = false;
            Console.WriteLine("XHDotFix by EachStudios.\n");
            Console.WriteLine("Checking .NET Packages...");
            if (!Directory.Exists(DepsPath))
            {
                Console.WriteLine("Directory \""+ DepsPath + "\" not found . Creating it...");
                Directory.CreateDirectory(DepsPath);
            }
            if (!File.Exists(DepsPath + x86FileName))
            {
                Console.WriteLine(".NET Core \"" + x86FileName + "\" could not be found at \""+ DepsPath + x86FileName + "\".It might be lost , deleted , damaged or renamed.");
                lostCore86 = true;
            }
            if (!File.Exists(DepsPath + x64FileName))
            {
                Console.WriteLine(".NET Core \"" + x64FileName + "\" could not be found at \""+ DepsPath + x64FileName + "\".It might be lost , deleted , damaged or renamed.");
                lostCore64 = true;
            }
            if (!File.Exists(DepsPath + frameworkFileName))
            {
                Console.WriteLine(".NET Core \"" + frameworkFileName + "\" could not be found at \""+ DepsPath + frameworkFileName + "\".It might be lost , deleted , damaged or renamed.");
                lostFramework = true;
            }
            Console.WriteLine("Done.\nChecking System version...");
            bool ISx64 = Is64Bit();
            if (ISx64)
            {
                if (lostCore86)
                {
                    Console.WriteLine("Failed to install x86 package.Package lost.");
                }
                else
                {
                    InstallX86();
                }
                if (lostCore64)
                {
                    Console.WriteLine("Failed to install x64 package.Package lost.");
                }
                else
                {
                    InstallX64();
                }
                if (lostFramework)
                {
                    Console.WriteLine("Failed to install framework package.Package lost.");
                }
                else
                {
                    InstallFrameworkX64();
                    InstallFrameworkX86();
                }
            }

            else
            {
                if (lostCore86)
                {
                    Console.WriteLine("Failed to install x86 package.Package lost.");
                }
                else
                {
                    InstallX86();
                }
                if (lostFramework)
                {
                    Console.WriteLine("Failed to install framework package.Package lost.");
                }
                else
                {
                    InstallFrameworkX86();
                }
            }
        }
        static void Install()
        {
            bool lostCore86 = false;
            bool lostCore64 = false;
            bool lostFramework = false;
            Console.WriteLine("XHDotFix by EachStudios.\n");
            Console.WriteLine("Checking .NET Packages...");
            if (!Directory.Exists(DepsPath))
            {
                Console.WriteLine("Directory \"" + DepsPath + "\" not found . Creating it...");
                Directory.CreateDirectory(DepsPath);
            }
            if (!File.Exists(DepsPath + x86FileName))
            {
                Console.WriteLine(".NET Core \"" + x86FileName + "\" could not be found at \"" + DepsPath + x86FileName + "\".It might be lost , deleted , damaged or renamed.");
                lostCore86 = true;
            }
            if (!File.Exists(DepsPath + x64FileName))
            {
                Console.WriteLine(".NET Core \"" + x64FileName + "\" could not be found at \"" + DepsPath + x64FileName + "\".It might be lost , deleted , damaged or renamed.");
                lostCore64 = true;
            }
            if (!File.Exists(DepsPath + frameworkFileName))
            {
                Console.WriteLine(".NET Core \"" + frameworkFileName + "\" could not be found at \"" + DepsPath + frameworkFileName + "\".It might be lost , deleted , damaged or renamed.");
                lostFramework = true;
            }
            Console.WriteLine("Done.\nChecking System version...");
            bool ISx64 = Is64Bit();
            if (ISx64)
            {
                Console.WriteLine("System Version=x64.\nThe program will install Core-x64 and Framework.");
            }
            else
            {
                Console.WriteLine("System Version=x64.\nThe program will install Core-x86 and Framework");
            }
            Console.WriteLine("Done.\nChecking if the dotnet binary has already installed...");
            if (ISx64)
            {
                if (Directory.Exists(@"C:\Program Files (x86)\dotnet"))
                {
                    Console.WriteLine("There is one or more dotnet binary (binaries) has installed.If you want to reinstall it,add \"--Reinstall\" in the args.");
                }
                else
                {
                    Console.WriteLine("Done.Installing x86 package.");
                    if (lostCore86)
                    {
                        Console.WriteLine("Failed to install x86 package.Package lost.");
                    }
                    else
                    {
                        InstallX86();
                    }

                }
                if (Directory.Exists(@"C:\Program Files\dotnet"))
                {
                    Console.WriteLine("There is one or more dotnet binary (binaries) has installed.If you want to reinstall it,add \"--Reinstall\" in the args.");
                }
                else
                {
                    if (lostCore64)
                    {
                        Console.WriteLine("Failed to install x64 package.Package lost.");
                    }
                    else
                    {
                        InstallX64();
                    }
                }
                if (lostFramework)
                {
                    Console.WriteLine("Failed to install framework package.Package lost.");
                }
                else
                {
                    InstallFrameworkX64();
                    InstallFrameworkX86();
                }
            }

            else
            {
                if (Directory.Exists(@"C:\Program Files (x86)\dotnet"))
                {
                    Console.WriteLine("There is one or more dotnet binary (binaries) has installed.If you want to reinstall it,add \"--Reinstall\" in the args.");
                }
                else
                {
                    Console.WriteLine("Done.Installing x86 package.");
                    if (lostCore86)
                    {
                        Console.WriteLine("Failed to install x86 package.Package lost.");
                    }
                    else
                    {
                        InstallX86();
                    }

                }
                if (lostFramework)
                {
                    Console.WriteLine("Failed to install framework package.Package lost.");
                }
                else
                {
                    InstallFrameworkX86();
                }
            }
        }
        static void InstallX86()
        {
            UseCmd(DepsPath + x86FileName + " /q /norestart /ChainingPackage");
        }
        static void InstallX64()
        {
            UseCmd(DepsPath + x64FileName + " /q /norestart /ChainingPackage");
        }
        static void InstallFrameworkX86()
        {
            UseCmd(DepsPath + frameworkFileName + " /q /norestart /ChainingPackage FullX86Bootstrapper");
        }
        static void InstallFrameworkX64()
        {
            UseCmd(DepsPath + frameworkFileName + " /q /norestart /ChainingPackage FullX64Bootstrapper");
        }
        //IntPtr.Size在64位为8，在32位为4
        public static bool Is64Bit()
        {
            if (IntPtr.Size == 4)
                return false;
            else
                return true;
        }
        public static string UseCmd(string Command)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(Command + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令



            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


            return output;
        }
    }
}
