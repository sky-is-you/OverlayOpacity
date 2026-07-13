using Monocle;

namespace Celeste.Mod.OverlayOpacity;

public static class OverworldHooks
{
    private static Overworld currentOverworld;
    private static HiresSnow currentSnow => currentOverworld.Snow;
    private static Easer overlayAlphaEaser = new(.45f,1f);

    public static void Attach(Overworld ov)
    {
        if (ov == null)
        {
            Logger.Info("OverworldOpacity", "tf");
            return;
        }
        currentOverworld = ov;
        currentOverworld.OnEndOfFrame += Update;
    }
    public static void AreaChanged(AreaKey area)
    {
        if (currentOverworld == null) return;
        OverlayMeta meta = OverworldHelperImports.FindConfig<OverlayMeta>(area);
        if (meta!=null && meta.OverlayOpacity!=null) overlayAlphaEaser.Target = meta.OverlayOpacity.OverlayOpacity;
    }

    public static void Update()
    {
        overlayAlphaEaser.Update();
        currentSnow.overlayAlpha = overlayAlphaEaser.Ease;
        currentOverworld.OnEndOfFrame += Update;
    }

}