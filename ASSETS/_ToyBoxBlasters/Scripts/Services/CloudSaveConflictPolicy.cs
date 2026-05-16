namespace ToyBoxBlasters.Services
{
    /// <summary>
    /// Documented merge rules for Firestore sync (Task 009). Implemented in Firebase layer later.
    /// </summary>
    public static class CloudSaveConflictPolicy
    {
        public const string ProgressRule = "server_wins";
        public const string CosmeticsRule = "merge_union";
    }
}
