using System;
using MonoMod.ModInterop;

namespace Celeste.Mod.OverlayOpacity;

public class OverlayOpacityModule : EverestModule {
    public static OverlayOpacityModule Instance { get; private set; }

    public override Type SettingsType => typeof(OverlayOpacityModuleSettings);
    public static OverlayOpacityModuleSettings Settings => (OverlayOpacityModuleSettings) Instance._Settings;

//    public override Type SessionType => typeof(OverlayOpacityModuleSession);
//    public static OverlayOpacityModuleSession Session => (OverlayOpacityModuleSession) Instance._Session;

//   public override Type SaveDataType => typeof(OverlayOpacityModuleSaveData);
//    public static OverlayOpacityModuleSaveData SaveData => (OverlayOpacityModuleSaveData) Instance._SaveData;

    public OverlayOpacityModule() {
        Instance = this;
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(OverlayOpacityModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(OverlayOpacityModule), LogLevel.Info);
#endif
    }
    
    public override void Load()
    {
        if (Settings.Enabled)
        {
            typeof(OverworldHelperImports).ModInterop();
            OverworldHelperImports.VanillaOverworldCreated += OverworldHooks.Attach;
            OverworldHelperImports.AreaChanged += OverworldHooks.AreaChanged;
        }
    }

    public override void Unload() {
        if (Settings.Enabled)
        {
            OverworldHelperImports.AreaChanged -= OverworldHooks.AreaChanged;
            OverworldHelperImports.VanillaOverworldCreated -= OverworldHooks.Attach;
        }
    }
}