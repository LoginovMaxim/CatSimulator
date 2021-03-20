using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Visual
{
    public class VFXContainer : MonoBehaviour
    {
        [SerializeField] private Cat _cat;
        [SerializeField] private MoodVFX[] _moodVFXs;

        private void OnEnable() => _cat.OnMoodChanged += ChangeVisualEffect;

        public void ChangeVisualEffect(Mood mood)
        {
            List<MoodVFX> moodVFXs = _moodVFXs.Where(m => m.Mood == mood).ToList();

            if (moodVFXs.Count == 0)
                return;
            
            MoodVFX moodVFX = moodVFXs[Random.Range(0, moodVFXs.Count)];
        
            HideAllVisualEffects(moodVFX);
            moodVFX.EffectContainer.SetActive(true);
        }

        public void HideAllVisualEffects(MoodVFX moodVfx)
        {
            foreach (var moodVFX in _moodVFXs)
            {
                if (moodVfx.EffectContainer == moodVFX.EffectContainer)
                    continue;
                
                moodVFX.EffectContainer.SetActive(false);
            }
        }
    
        private void OnDisable() => _cat.OnMoodChanged -= ChangeVisualEffect;
    }

    [Serializable]
    public struct MoodVFX
    {
        public Mood Mood;
        public GameObject EffectContainer;
    }
}