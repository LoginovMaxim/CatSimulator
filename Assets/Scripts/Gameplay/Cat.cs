using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class Cat : MonoBehaviour
    {
        public event UnityAction<Mood> OnMoodChanged;
        
        [SerializeField] private Mood _mood;
        [SerializeField] private string _reaction;
        
        public Mood Mood => _mood;
        public string Reaction => _reaction;

        private void Start()
        {
            SetMood(_mood);
        }

        public void SetMood(Mood mood)
        { 
            _mood = mood;
            OnMoodChanged?.Invoke(_mood);
        }
        
        public void SetReaction(string reaction) => _reaction = reaction;
    }
}