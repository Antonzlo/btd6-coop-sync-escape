using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using MelonLoader;
using Il2CppAssets.Scripts.Unity.UI_New.Coop;

[assembly: MelonInfo(typeof(CoopSyncEscape.Mod), CoopSyncEscape.ModHelperData.Name, CoopSyncEscape.ModHelperData.Version, CoopSyncEscape.ModHelperData.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CoopSyncEscape;

// Adds a Menu button to the co-op "waiting for other players" popup, so a stuck sync can be left.
public class Mod : MelonMod
{
    [HarmonyPatch(typeof(CoopSyncingPopup), nameof(CoopSyncingPopup.Init))]
    static class SyncPopupInit
    {
        static void Postfix(CoopSyncingPopup __instance)
        {
            if (__instance.transform.Find("MenuButton") != null) return;

            // Child of the popup, so it goes away with it
            var button = __instance.gameObject.AddModHelperComponent(ModHelperButton.Create(
                new Info("MenuButton", 0, -450, 550, 180), VanillaSprites.RedBtnLong,
                new Action(() => __instance.InGameQuit())));
            button.AddText(new Info("Text", InfoPreset.FillParent), "Меню", 70);
        }
    }
}
