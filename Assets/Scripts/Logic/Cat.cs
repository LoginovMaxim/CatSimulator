using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class Cat : MonoBehaviour
    {
        [SerializeField] private int _mood;
        [SerializeField] private string _reaction;
        public int Mood => _mood;
        public string Reaction => _reaction;

        public void SetMood(int mood) => _mood = mood;
        public void SetReaction(string reaction) => _reaction = reaction;
    }
}