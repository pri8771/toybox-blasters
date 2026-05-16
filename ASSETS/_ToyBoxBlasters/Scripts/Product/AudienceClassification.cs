namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Regulatory / store positioning for audience (Task 003 subtask 7).
    /// </summary>
    public enum AudienceClassification
    {
        /// <summary>General audience (E10+/PEGI 3+ style); not COPPA child-directed.</summary>
        GeneralAudience = 0,

        /// <summary>Child-directed product (COPPA-style constraints). Not used for V1.</summary>
        ChildDirected = 1
    }
}
