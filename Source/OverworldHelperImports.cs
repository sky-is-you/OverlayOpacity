using System;
using Celeste.Mod.Meta;
using MonoMod.ModInterop;

namespace Celeste.Mod.OverlayOpacity;

[ModImportName("OverworldHelper")]
public static class OverworldHelperImports
{
    // deprecated methods not included for the sake of future compatibility
    // Event hook method imports
    public static Action<Action<AreaKey>> SubscribeToAreaChanged;
    public static Action<Action<AreaKey>> UnsubscribeFromAreaChanged;
    public static Action<Action<int>> SubscribeToAreaChangedID;
    public static Action<Action<int>> UnsubscribeFromAreaChangedID;
    public static Action<Action<Overworld>> SubscribeToOverworldCreated;
    public static Action<Action<Overworld>> UnsubscribeFromOverworldCreated;
    public static Action<Action<Overworld>> SubscribeToVanillaOverworldCreated;
    public static Action<Action<Overworld>> UnsubscribeFromVanillaOverworldCreated;
    public static Action<Action<Overworld>> SubscribeToCustomOverworldCreated;
    public static Action<Action<Overworld>> UnsubscribeFromCustomOverworldCreated;
    public static Action<Action<OuiTitleScreen>> SubscribeToTitleScreenEntry;
    public static Action<Action<OuiTitleScreen>> UnsubscribeFromTitleScreenEntry;
    public static Action<Action<OuiTitleScreen>> SubscribeToTitleScreenExit;
    public static Action<Action<OuiTitleScreen>> UnsubscribeFromTitleScreenExit;
    
    // Get status method imports
    public static Func<Overworld> GetOverworld;
    public static Func<bool> GetOverworldIsVanilla;
    
    // Get assets method imports
    public static Func<int, AreaData> GetAreaDataFromID;
    public static Func<int, AreaKey> GetAreaKeyFromID;
    public static Func<string, AreaData> FindAreaDataFromString;
    public static Func<string, AreaKey?> FindAreaKeyFromString;
    public static Func<int, Type, MapMeta> GetConfigFromAreaID;
    public static Func<AreaKey, Type, MapMeta> GetConfigFromAreaKey;
    public static Func<AreaData, Type, MapMeta> GetConfigFromAreaData;
    public static Func<string, Type, MapMeta> FindConfigFromString;
    
    public static AreaData FindAreaData(int areaID)
        => GetAreaDataFromID(areaID);
    public static AreaData FindAreaData(string area)
        => FindAreaDataFromString(area);
    public static AreaKey FindAreaKey(int areaID)
        => GetAreaKeyFromID(areaID);
    public static AreaKey? FindAreaKey(string area)
        => FindAreaKeyFromString(area);
    public static T FindConfig<T>(int areaID) where T : MapMeta
        => (T)GetConfigFromAreaID(areaID, typeof(T));
    public static T FindConfig<T>(AreaKey area) where T : MapMeta
        => (T)GetConfigFromAreaKey(area, typeof(T));
    public static T FindConfig<T>(AreaData area) where T : MapMeta
        => (T)GetConfigFromAreaData(area, typeof(T));
    public static T FindConfig<T>(string area) where T : MapMeta
        => (T)FindConfigFromString(area, typeof(T));

    // Event hooks (ease of access)
    public static event Action<AreaKey> AreaChanged
    {
        add => SubscribeToAreaChanged(value);
        remove => UnsubscribeFromAreaChanged(value);
    }
    public static event Action<int> AreaChangedID
    {
        add => SubscribeToAreaChangedID(value);
        remove => UnsubscribeFromAreaChangedID(value);
    }
    public static event Action<Overworld> OverworldCreated
    {
        add => SubscribeToOverworldCreated(value);
        remove => UnsubscribeFromOverworldCreated(value);
    }
    public static event Action<Overworld> VanillaOverworldCreated
    {
        add => SubscribeToVanillaOverworldCreated(value);
        remove => UnsubscribeFromVanillaOverworldCreated(value);
    }
    public static event Action<Overworld> CustomOverworldCreated
    {
        add => SubscribeToCustomOverworldCreated(value);
        remove => UnsubscribeFromCustomOverworldCreated(value);
    }
    public static event Action<OuiTitleScreen> TitleScreenEntry
    {
        add => SubscribeToTitleScreenEntry(value);
        remove => UnsubscribeFromTitleScreenEntry(value);
    }
    public static event Action<OuiTitleScreen> TitleScreenExit
    {
        add => SubscribeToTitleScreenExit(value);
        remove => UnsubscribeFromTitleScreenExit(value);
    }
}