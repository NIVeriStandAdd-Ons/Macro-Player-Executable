## Macro Player Executable ##

**Macro Player Executable** is an exe that, when associated with NI VeriStand .nivsmacro files, plays them on double click.

To use:

1. Double click a .nivsmacro file
2. Windows will ask what application you want to use to open this file, pick \Built\MacroPlayer.exe
3. Check "always use this application for this file type"

Configuration settings:

MacroPlayer.exe.config is an XML file that contains two configuration settings for how the application behaves. It must sit next to the exe or the exe will throw an error when it runs. You can modify these two tags:
>     <add key="Gateway" value=""></add>
>     <add key="PlayWithTiming?" value="TRUE"></add>

If you specify something other than an empty string for "Gateway", then that will be the NIVS gateway that the macro is played to. "" means localhost.

If you specify something other than "TRUE" or "true" for "PlayWithTiming?", then the macro will be played as fast as possible.

### Version ###

Visual Studio 2010, NI VeriStand 2010

### Built Availability ###

No builds are provided

### Quality, Limitations ###

This IP was created against NI VeriStand 2010 and has not been tested since. If you wish to use it with a more modern version, you need to update the project to link to the most recent assembly versions and rebuild.

### Dependencies ###

NI VeriStand

### License ###

*This repository and any materials provided by NI therein are provided AS IS. NI DISCLAIMS ANY AND ALL LIABILITIES FOR AND MAKES NO WARRANTIES, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR  PARTICULAR PURPOSE, OR NON-INFRINGEMENT OF INTELLECTUAL PROPERTY. NI shall have no liability for any direct, indirect, incidental, punitive, special, or consequential damages for your use of the repository or any materials contained therein.*