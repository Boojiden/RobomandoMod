using RobomandoMod.Survivors.Robomando.SkillStates;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(Shoot));

            Modules.Content.AddEntityState(typeof(Zap));

            Modules.Content.AddEntityState(typeof(Roll));

            Modules.Content.AddEntityState(typeof(Hack));

            Modules.Content.AddEntityState(typeof(BouncyBomb));
        }
    }
}
