using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;



public class Program
{
    public static void Main()
    {
        byte[] shellcode = new byte[]{%s};
	File.WriteAllBytes("test1.txt",shellcode);
	
    }
}
