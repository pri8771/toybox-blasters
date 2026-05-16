namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// When a loop layer is expected to ship vs. design-only documentation.
    /// </summary>
    public enum LoopImplementationPhase
    {
        /// <summary>Playable in MVP vertical slice.</summary>
        Mvp = 0,

        /// <summary>Interfaces + tuning hooks; full behavior soft launch+.</summary>
        SoftLaunch = 1,

        /// <summary>Production polish and scale content.</summary>
        Production = 2,

        /// <summary>Documented and config-encoded; no runtime implementation yet.</summary>
        DesignedOnly = 3
    }
}
