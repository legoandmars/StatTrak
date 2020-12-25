# StatTrak
A Beat Saber mod that implements "StatTrak" sabers, tracking the amount of blocks sliced with that specific saber.

## For Users
The download for the latest version of this mod can be found in the [Releases tab](). 

This mod only works with StatTrak sabers - look for sabers with StatTrak in the name! There's one pair included with the mod if you download the ZIP.

## For Modelers
If you want to add StatTrak to your sabers, add `StatTrak.dll` to your custom saber unity project.

If it's not working properly, you may have to add TextMesh Pro through the Unity package manager located in `Windows -> Package Manager`

Set the `Stat Trak ID` property to something unique to avoid conflicting with other sabers. The ideal format is your name followed by the saber name: `BobbieTestSaber`, `BobbiePersonalSaber`, etc

If you'd like to add text on your saber that displays the amount of blocks sliced, add some TextMeshPro text somewhere and then add it to the `Stat Trak Text` array. If you don't want any text on your saber, just leave the array blank.

Optionally, if you'd like to indicate that your sabers have StatTrak ability, putting `(StatTrak)` at the end of your model's name is highly recommended.

## For Developers

In order to build this project, please create the file `StatTrak.csproj.user` and add your Beat Saber directory path to it in the project directory.
This file should not be uploaded to GitHub and is in the .gitignore.

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Set "YOUR OWN" Beat Saber folder here to resolve most of the dependency paths! -->
    <BeatSaberDir>C:\Program Files (x86)\Steam\steamapps\common\Beat Saber</BeatSaberDir>
  </PropertyGroup>
</Project>
```