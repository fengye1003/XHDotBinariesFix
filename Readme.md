XHDotFix v.1.0.0.0

目标框架:基于x64与x86的未安装.NET的用户

文件说明:
32bin文件夹:32位.NET Core 3.1免安装便携运行库
64bin文件夹:64位.NET Core 3.1免安装便携运行库
dotnetDep文件夹:.NET Core与.NET Framework安装包
	-ndp48_86_64.exe:.NET Framework 4.8 32/64位通用安装包
	-ndr31_86.exe:.NET Core 3.1 32位安装包
	-ndr31_64.exe:.NET Core 3.1 64位安装包
	//缺失将导致无法安装相应运行库 错误信息:".NET Core "xxx" could not be found at ".\dotnetDep\xxx".It might be lost , deleted , damaged or renamed."
四个批处理文件说明:
!InstallWithBin32:以32位模式运行程序.此模式只能安装两个32位包,如果已经安装某版本.NET将跳过对应版本
!InstallWithBin64:以64位模式运行程序.此模式能安装32位与64位包,如果已经安装某版本.NET将跳过对应版本
!ReinstallWithBin32:以32位模式运行程序.此模式只能安装两个32位包
!ReinstallWithBin64:以64位模式运行程序.此模式能安装32位与64位包
其他文件缺一不可

使用MIT协议开源
相互科技保留所有权