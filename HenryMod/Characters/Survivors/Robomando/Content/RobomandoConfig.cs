using BepInEx.Configuration;
using RobomandoMod.Modules;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoConfig
    {
        public static ConfigEntry<bool> ShutHimUp;
        public static ConfigEntry<float> someConfigFloat;
        public static ConfigEntry<float> someConfigFloatWithCustomRange;

        public static void Init()
        {
            string section = "Robomando";
            ShutHimUp = Config.BindAndOptions(
                section,
                "Robomando Talks",
                false,
                "Whether or not Robomando will talk.");

           /*
            someConfigFloat = Config.BindAndOptions(
                section,
                "someConfigfloat",
                5f);//blank description will default to just the name

            someConfigFloatWithCustomRange = Config.BindAndOptions(
                section,
                "someConfigfloat2",
                5f,
                0,
                50,
                "if a custom range is not passed in, a float will default to a slider with range 0-20. risk of options only has sliders");
           */
        }
    }
}
