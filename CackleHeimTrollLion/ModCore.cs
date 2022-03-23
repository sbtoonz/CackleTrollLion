using System.Reflection;
using BepInEx;
using CreatureManager;
using HarmonyLib;

namespace CackleHeimTrollLion
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class CackleHeimTrollMod : BaseUnityPlugin
    {
        internal const string ModName = "CackleHeimLionTroll";
        internal const string ModVersion = "0.0.1";
        private const string ModGUID = "come.cacklehieim.liontroll";
        private static Harmony harmony = null!;
        
        public void Awake()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            harmony = new(ModGUID);
            harmony.PatchAll(assembly);

            Creature LionTroll = new("liontroll", "Lion_Troll")
            {
                Biome = Heightmap.Biome.Meadows,
                GroupSize = new Range(1,3),
                CheckSpawnInterval = 600,
                RequiredWeather = Weather.Rain | Weather.Fog | Weather.None| Weather.ClearSkies,
                Maximum = 2
            };
            LionTroll.Localize().English("Lion Troll");
            LionTroll.Drops["Wood"].Amount = new Range(1, 10);
            LionTroll.Drops["Wood"].DropChance = 100f;
            LionTroll.Drops["Wood"].MultiplyDropByLevel = false;
            LionTroll.ConfigurationEnabled = true;
        }
    }
}
