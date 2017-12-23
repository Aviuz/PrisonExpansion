:: ========= Build ==========

devenv "D:\Git Repository\Prison Expansion Mod\Source\Prison Expansion.sln" /build Debug



:: ========= Copy ==========
 
rd "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion" /s /q
mkdir "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion"

:: About
mkdir "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\About"
xcopy "D:\Git Repository\Prison Expansion Mod\About\*.*" "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\About" /e

:: Assemblies
mkdir "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\Assemblies"
xcopy "D:\Git Repository\Prison Expansion Mod\Assemblies\*.*" "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\Assemblies" /e

:: Defs 
mkdir "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\Defs"
xcopy "D:\Git Repository\Prison Expansion Mod\Defs\*.*" "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\Defs" /e

:: Languages
mkdir "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\Languages"
xcopy "D:\Git Repository\Prison Expansion Mod\Languages\*.*" "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\Languages" /e

:: Textures
mkdir "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\Textures"
xcopy "D:\Git Repository\Prison Expansion Mod\Textures\*.*" "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\Textures" /e

:: changelog.txt
copy "D:\Git Repository\Prison Expansion Mod\changelog.txt" "D:\Games\SteamLibrary\SteamApps\common\RimWorld\Mods\PrisonExpansion\changelog.txt"



:: ========= Run ==========

start steam://rungameid/294100