﻿using UnityEngine;

namespace Logic
{
    public class GameWithCat : MonoBehaviour, IActionable
    {
        public void Action(Cat cat, Behaviour behaviour)
        {
            if (cat.Mood > behaviour.ActionBehaviour.MoodBehaviours.Count)
            {
                cat.SetReaction("проигнорировала ваши попытки поиграть с ней");
                return;
            }
            
            cat.SetReaction(behaviour.ActionBehaviour.MoodBehaviours[cat.Mood].Reaction);
            cat.SetMood(behaviour.ActionBehaviour.MoodBehaviours[cat.Mood].NextMood);
        }
    }
}