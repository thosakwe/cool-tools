using System;
using System.Text.RegularExpressions;
					
public class Program
{
	static string path = @"%SystemRoot%\system32;%SystemRoot%;%SystemRoot%\system32\wbem;C:\ProgramData\Oracle\Java\javapath;C:\Ruby21-x64\bin;C:\Python27\Lib\site-packages\PyQt4;C:\Perl\site\bin;C:\Perl\bin;C:\apps\PHP;C:\oraclexe\app\oracle\product\11.2.0\server\bin;C:\Program Files\Common Files\Microsoft Shared\Windows Live;C:\Program Files (x86)\Common Files\Microsoft Shared\Windows Live;%SYSTEMROOT%\System32\WindowsPowerShell\v1.0;C:\Program Files\Intel\WiFi\bin;C:\Program Files\Common Files\Intel\WirelessCommon;C:\Program Files (x86)\Windows Live\Shared;%JAVA_HOME%/bin;C:\apps\apache-maven-3.0.3\bin;C:\apps\android-sdk-windows\tools;c:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn;c:\Program Files\Microsoft SQL Server\100\Tools\Binn;c:\Program Files\Microsoft SQL Server\100\DTS\Binn;c:\Program Files (x86)\Microsoft ASP.NET\ASP.NET Web Pages\v1.0;C:\Program Files\TortoiseSVN\bin;%DERBY_HOME%\bin;C:\apps\apache-ant-1.8.4\bin;c:\Program Files (x86)\Microsoft SQL Server\90\Tools\binn;C:\apps\gSOAP\gsoap-2.8\gsoap\bin\win32;\bin;C:\Program Files\VASCO\Identikey 3.4\bin;C:\Program Files (x86)\QuickTime\QTSystem;C:\MinGW\bin;C:\Program Files (x86)\GnuWin32\bin;C:\apps\wamp2.4-x86\bin\php\php5.4.16;C:\apps\wamp2.4-x86\bin\php\php5.4.16\ext;C:\Program Files (x86)\Windows Kits\8.1\Windows Performance Toolkit;C:\Program Files\Microsoft SQL Server\110\Tools\Binn;C:\Program Files (x86)\Microsoft SDKs\TypeScript\1.0;C:\Program Files (x86)\GtkSharp\2.12\bin;C:\ProgramData\ComposerSetup\bin;C:\D\dmd2\windows\bin;C:\Program Files (x86)\Heroku\bin;C:\Program Files (x86)\git\cmd;C:\Program Files\nodejs\;C:\Users\tobe\Downloads;C:\Users\tobe\Downloads\ANTLR;C:\Program Files (x86)\Skype\Phone\;C:\Program Files (x86)\Mono\bin;C:\Users\tobe\Downloads\tcc-0.9.24-win32-bin\tcc;C:\Program Files (x86)\Git\cmd;%USERPROFILE%\.dnx\bin;C:\Program Files\Microsoft DNX\Dnvm\;C:\Program Files\Microsoft SQL Server\120\Tools\Binn\;C:\Program Files (x86)\Windows Kits\10\Windows Performance Toolkit\;C:\Users\tobe\Downloads\i686-elf-gcc\bin;;%systemroot%\System32\WindowsPowerShell\v1.0\";
	
	public static void Main()
	{
		Regex rgx = new Regex("([^;]+)");
		string newPath = string.Empty;
		int pathCount = 0;
		int newPathCount = 0;
		
		Console.WriteLine("Current path is {0} characters long. It's {1}too long.", path.Length, path.Length > 2048 ? "" : " ");
		
		foreach (Match match in rgx.Matches(path))
		{
		    pathCount++;
		    if (!newPath.Contains(match.Groups[1].Value))
		    {
		        newPath += match.Groups[1].Value;
		        newPathCount++;
		    }
	        else
	        {
	            Console.WriteLine("Repeated path {0} was removed.", match.Groups[1].Value);
	        }
		}
		
		Console.WriteLine("New path is {0} characters long. It's {1}too long.", newPath.Length, newPath.Length > 2048 ? "" : "NOT ");
		Console.WriteLine("The old path contained {0} path(s), while the new one contains {1}.", pathCount, newPathCount);
		Console.WriteLine("Press ENTER to see the new path. It will be copied to your clipboard.");
		Console.ReadLine();
		Console.WriteLine(newPath);
		System.Windows.Forms.SetText(newPath);
	}
}