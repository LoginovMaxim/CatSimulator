using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Logic
{
    public class Behaviour : MonoBehaviour
    {
        public event UnityAction<string, string> OnAction;
        
        public ActionBehaviour ActionBehaviour;

        private Cat _cat;
        
        private void Start()
        {
            _cat = GetComponentInParent<Cat>();
        }

        public void DoAction()
        {
            List<MoodBehaviour> moodBehaviours = ActionBehaviour.MoodBehaviours.Where(m => m.Mood == _cat.Mood).ToList();
            
            Debug.Log("moodBehaviours " + moodBehaviours.Count);
            if (moodBehaviours.Count == 0)
            {
                _cat.SetReaction("проигнорировала ваши попытки " + ActionBehaviour.ActionLabel);
                return;
            }
            
            MoodBehaviour selectedBehaviour = moodBehaviours[Random.Range(0, moodBehaviours.Count)];
            Debug.Log("selectedBehaviour " + selectedBehaviour.Mood);
            
            _cat.SetReaction(selectedBehaviour.Reaction);
            _cat.SetMood(selectedBehaviour.NextMood);
            
            OnAction?.Invoke(ActionBehaviour.ActionLabel, _cat.Reaction);
        }
    }

    [Serializable]
    public struct ActionBehaviour
    {
        public string ActionLabel;
        public List<MoodBehaviour> MoodBehaviours;
    }
    
    [Serializable]
    public struct MoodBehaviour
    {
        public Mood Mood;
        public string Reaction;
        public Mood NextMood;
    }
}