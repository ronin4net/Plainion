﻿using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

[assembly: AssemblyTitle( "Plainion.Windows" )]
[assembly: ComVisible( false )]

[assembly: XmlnsPrefix( "http://plainion.codeplex.com/windows/", "pn" )]
[assembly: XmlnsDefinition( "http://plainion.codeplex.com/windows/", "Plainion.Windows" )]
[assembly: XmlnsDefinition( "http://plainion.codeplex.com/windows/", "Plainion.Windows.Controls" )]
[assembly: XmlnsDefinition( "http://plainion.codeplex.com/windows/", "Plainion.Windows.Interactivity" )]
[assembly: XmlnsDefinition( "http://plainion.codeplex.com/windows/", "Plainion.Windows.Interactivity.DragDrop" )]


// Specifies the location in which theme dictionaries are stored for types in an assembly.
[assembly: ThemeInfo(
    // Specifies the location of system theme-specific resource dictionaries for this project.
    // The default setting in this project is "None" since this default project does not
    // include these user-defined theme files:
    //     Themes\Aero.NormalColor.xaml
    //     Themes\Classic.xaml
    //     Themes\Luna.Homestead.xaml
    //     Themes\Luna.Metallic.xaml
    //     Themes\Luna.NormalColor.xaml
    //     Themes\Royale.NormalColor.xaml
    ResourceDictionaryLocation.None,

    // Specifies the location of the system non-theme specific resource dictionary:
    //     Themes\generic.xaml
    ResourceDictionaryLocation.SourceAssembly )]

