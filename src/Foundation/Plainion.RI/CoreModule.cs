﻿using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Plainion.RI.Dialogs;

namespace Plainion.RI
{
    [ModuleExport( typeof( CoreModule ) )]
    class CoreModule : IModule
    {
        [Import]
        public IRegionManager RegionManager { get; private set; }

        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion( RegionNames.Dialogs, typeof( SelectFolderDialogView ) );
        }
    }
}