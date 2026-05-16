namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Stub for future wallet / economy services. Implementations read <see cref="EconomyPhilosophyConfig"/>.
    /// </summary>
    public interface IEconomyPhilosophyProvider
    {
        EconomyPhilosophyConfig Config { get; }
        bool IsValid { get; }

        bool TryGetCurrency(CurrencyKind kind, out CurrencyDefinitionEntry entry);
    }
}
