Something that i wrote to bypass the AV on a windows machine when it was flagging powershell based in memory techniques, regular msf payload EXES and Veil-Framework EXES. This is just to highlight the risk of AVs trusting payloads generated using .Net Assesmblies.

It is not a vulnerability, just another way to try to bypass the AV. The scenario is when the pen-tester cannot shutdown the remote av process or login using RDP into the remote machine and wants to execute a payload on the remote machine.

It is assumed that the pen-tester has the credentials for the remote windows machine.

The template file is based on subtee's https://gist.github.com/subTee/408d980d88515a539672

Read the wiki for detailed insructions for building the payload. There are also some pointers regarding payload delivery that can be ignored if you have your specific method.

The payload generated from the python script gets past all major AV solutions. 
If the shellcode is copied directly into the csharp script, then some AV solutions detect it as malicous (but even this is very few)