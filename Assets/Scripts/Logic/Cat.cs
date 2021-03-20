using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class Cat : MonoBehaviour
    {
        [SerializeField] private Mood _mood;
        [SerializeField] private string _reaction;
        [SerializeField] private Sprite[] _sprites;
        
        public Mood Mood => _mood;
        public string Reaction => _reaction;
        public Sprite[] Sprites => _sprites;

        public void SetMood(Mood mood) => _mood = mood;
        
        public void SetReaction(string reaction) => _reaction = reaction;
        
        public Sprite GetCurrentSprite()
        {
            int index = (int)_mood;

            if ((int)_mood > _sprites.Length - 1)
            {
                index = _sprites.Length - 1;
            }

            return _sprites[index];
        }
    }
}