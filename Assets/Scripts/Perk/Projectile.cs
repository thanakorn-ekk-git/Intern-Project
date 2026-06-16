using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class Projectile : MonoBehaviour
    {
        private IReadOnlyDictionary<Perk.Modifier, PerkData.Modifier> modifier;

        public void Setup(IReadOnlyDictionary<Perk.Modifier, PerkData.Modifier> modifiers)
        {
            this.modifier = modifiers;
        }
    }
}