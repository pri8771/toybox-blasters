using System;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// One currency in the Task 006 economy stack (soft, premium, or event).
    /// </summary>
    [Serializable]
    public sealed class CurrencyDefinitionEntry
    {
        [SerializeField] CurrencyKind kind = CurrencyKind.SoftCoins;
        [SerializeField] string displayName = string.Empty;
        [SerializeField] string shortCode = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string purpose = string.Empty;

        [SerializeField] ReleasePhase firstImplementedPhase = ReleasePhase.Mvp;
        [SerializeField] bool expiresAfterEvent;
        [SerializeField] bool requiredToProgressV1;

        [Tooltip("Firebase Remote Config key prefix for tuning, e.g. economy_coins_")]
        [SerializeField] string remoteConfigKeyPrefix = string.Empty;

        public CurrencyKind Kind => kind;
        public string DisplayName => displayName ?? string.Empty;
        public string ShortCode => shortCode ?? string.Empty;
        public string Purpose => purpose ?? string.Empty;
        public ReleasePhase FirstImplementedPhase => firstImplementedPhase;
        public bool ExpiresAfterEvent => expiresAfterEvent;
        public bool RequiredToProgressV1 => requiredToProgressV1;
        public string RemoteConfigKeyPrefix => remoteConfigKeyPrefix ?? string.Empty;

#if UNITY_EDITOR
        public CurrencyDefinitionEntry(
            CurrencyKind currencyKind,
            string name,
            string code,
            string currencyPurpose,
            ReleasePhase phase,
            bool eventExpires,
            bool requiredV1,
            string rcPrefix)
        {
            kind = currencyKind;
            displayName = name;
            shortCode = code;
            purpose = currencyPurpose;
            firstImplementedPhase = phase;
            expiresAfterEvent = eventExpires;
            requiredToProgressV1 = requiredV1;
            remoteConfigKeyPrefix = rcPrefix;
        }
#endif
    }
}
