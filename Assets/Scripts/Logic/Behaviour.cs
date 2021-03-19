using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Logic
{
    public class Behaviour : MonoBehaviour
    {
        public event UnityAction<string, string> OnAction;
        
        public ActionBehaviour ActionBehaviour;

        private Cat _cat;
        
        private void Start()
        {
            //ActionBehaviour.Actionable = GetComponent<IActionable>();
            _cat = GetComponentInParent<Cat>();
        }

        public void DoAction()
        {
            //ActionBehaviour.Actionable.Action(_cat, this);
            if (_cat.Mood > ActionBehaviour.MoodBehaviours.Count)
            {
                _cat.SetReaction("проигнорировала ваши попытки " + ActionBehaviour.ActionLabel);
                return;
            }
            
            _cat.SetReaction(ActionBehaviour.MoodBehaviours[_cat.Mood].Reaction);
            _cat.SetMood(ActionBehaviour.MoodBehaviours[_cat.Mood].NextMood);
            
            OnAction?.Invoke(ActionBehaviour.ActionLabel, _cat.Reaction);
        }
    }

    [Serializable]
    public struct ActionBehaviour
    {
        //public IActionable Actionable;
        public string ActionLabel;
        public List<MoodBehaviour> MoodBehaviours;
    }
    
    [Serializable]
    public struct MoodBehaviour
    {
        public string Reaction;
        public int NextMood;
    }
}