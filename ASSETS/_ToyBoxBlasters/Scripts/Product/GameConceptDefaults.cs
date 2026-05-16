namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Canonical Task 001 values. Keep in sync with PROJECT_DOCS/PRD.md.
    /// </summary>
    public static class GameConceptDefaults
    {
        public const string GameName = "ToyBox Blasters";
        public const string Genre = "Hybrid-casual squad shooter runner";
        public const string VisualStyle = "Animated 3D toy / chibi";
        public const string TargetPlatforms = "iOS, Android (portrait)";
        public const string EngineName = "Unity";
        public const string BackendPreference = "Firebase";

        public const string OneSentencePitch =
            "Run a growing squad of chibi toy blasters through a giant bedroom, shoot goofy intruders, " +
            "smash numbered cardboard obstacles, and defeat a dust-bunny boss to earn coins for permanent upgrades.";

        public const string CorePlayerFantasy =
            "You are the captain of a toy squad charging across a child's bedroom floor. Drag to steer, " +
            "pass +/- gates to grow or trade power, auto-fire as your squad swells, break numbered obstacles, " +
            "clear slime enemies, beat the boss, and spend coins on lasting upgrades.";

        public const string FirstWorldName = "Bedroom Floor";
        public const string FirstWorldTheme =
            "Oversized bedroom toy-room floor: rugs, floorboards, furniture silhouettes, cardboard forts, " +
            "under-bed shadows, and a fluffy dust-bunny boss.";

        public static readonly string[] DifferentiationPoints =
        {
            "Cohesive toy-room fantasy instead of abstract crowd runners",
            "Squad shooter with readable mobile portrait combat",
            "Positive and negative upgrade gates in one lane",
            "Numbered obstacles that teach squad DPS scaling",
            "Short sessions with a spectacle boss at hybrid-casual pace",
            "Clear coin meta loop with Firebase-ready live ops hooks"
        };
    }
}
