using System;
using System.IO;

namespace XHDotBinariesFix
{
    class Program
    {
        static string x86FileName = "ndr31_86.exe";
        static string x64FileName = "ndr31_64.exe";
        static string frameworkFileName = "ndp48_86_64.exe";
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Install();
                    break;
                case 1:
                    switch (args[0])
                    {
                        case "--Reinstall":
                            Reinstall();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
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
            if (!Directory.Exists(@".\dotnetDep\"))
            {
                Console.WriteLine("Directory \".\\dotnetDep\\\" not found . Creating it...");
                Directory.CreateDirectory(@".\dotnetDep\");
            }
            if (!File.Exists(@".\dotnetDep\" + x86FileName))
            {
                Console.WriteLine(".NET Core \"" + x86FileName + "\" could not be found at \".\\dotnetDep\\" + x86FileName + "\".It might be lost , deleted , damaged or renamed.");
                lostCore86 = true;
            }
            if (!File.Exists(@".\dotnetDep\" + x64FileName))
            {
                Console.WriteLine(".NET Core \"" + x64FileName + "\" could not be found at \".\\dotnetDep\\" + x64FileName + "\".It might be lost , deleted , damaged or renamed.");
                lostCore64 = true;
            }
            if (!File.Exists(@".\dotnetDep\" + frameworkFileName))
            {
                Console.WriteLine(".NET Core \"" + frameworkFileName + "\" could not be found at \".\\dotnetDep\\" + frameworkFileName + "\".It might be lost , deleted , damaged or renamed.");
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
            if (!Directory.Exists(@".\dotnetDep\"))
            {
                Console.WriteLine("Directory \".\\dotnetDep\\\" not found . Creating it...");
                Directory.CreateDirectory(@".\dotnetDep\");
            }
            if (!File.Exists(@".\dotnetDep\" + x86FileName))
            {
                Console.WriteLine(".NET Core \"" + x86FileName + "\" could not be found at \".\\dotnetDep\\" + x86FileName + "\".It might be lost , deleted , damaged or renamed.");
                lostCore86 = true;
            }
            if (!File.Exists(@".\dotnetDep\" + x64FileName))
            {
                Console.WriteLine(".NET Core \"" + x64FileName + "\" could not be found at \".\\dotnetDep\\" + x64FileName + "\".It might be lost , deleted , damaged or renamed.");
                lostCore64 = true;
            }
            if (!File.Exists(@".\dotnetDep\" + frameworkFileName))
            {
                Console.WriteLine(".NET Core \"" + frameworkFileName + "\" could not be found at \".\\dotnetDep\\" + frameworkFileName + "\".It might be lost , deleted , damaged or renamed.");
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
            UseCmd(@".\dotnetDep\" + x86FileName + " /q /norestart /ChainingPackage");
        }
        static void InstallX64()
        {
            UseCmd(@".\dotnetDep\" + x64FileName + " /q /norestart /ChainingPackage");
        }
        static void InstallFrameworkX86()
        {
            UseCmd(@".\dotnetDep\" + frameworkFileName + " /q /norestart /ChainingPackage FullX86Bootstrapper");
        }
        static void InstallFrameworkX64()
        {
            UseCmd(@".\dotnetDep\" + frameworkFileName + " /q /norestart /ChainingPackage FullX64Bootstrapper");
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
