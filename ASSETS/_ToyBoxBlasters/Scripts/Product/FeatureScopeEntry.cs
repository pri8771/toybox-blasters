using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    [Serializable]
    public sealed class FeatureScopeEntry
    {
        [Tooltip("Stable id, e.g. runner_forward")]
        public string id;

        public string displayName;
        public FeaturePriority priority = FeaturePriority.P0;
        public ReleasePhase releasePhase = ReleasePhase.Mvp;
        public bool mustHave = true;

        [Tooltip("Ids of features that must ship before this one")]
        public List<string> dependencies = new();
    }
}
