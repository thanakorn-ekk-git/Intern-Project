using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class AOE : MonoBehaviour
    {
        enum State { Damage, Heal }
        private State state;
        private float duration;
        private IReadOnlyDictionary<Perk.Modifier, PerkData.Modifier> modifier;
        private bool isInitialized;

        public void Setup(IReadOnlyDictionary<Perk.Modifier, PerkData.Modifier> modifiers)
        {
            if (isInitialized) return;
            isInitialized = true;

            this.modifier = modifiers;

            duration = Time.frameCount + (modifier.GetValueOrDefault(Perk.Modifier.Duration, 1f) * Application.targetFrameRate);

            if (modifier.ContainsKey(Perk.Modifier.Damage))
            {
                state = State.Damage;
            }
        }

        private void Update()
        {
            if (Time.frameCount >= duration)
            {
                Destroy(gameObject);
                return;
            }

            switch (state)
            {
                case State.Damage:
                    // TODO : add damage to enemy logics
                    break;
            }
        }
    }
}