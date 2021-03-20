using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MoodSpriteData", order = 1)]
    public class MoodSpriteData : ScriptableObject
    {
        public SpriteData[] SpriteDatas;

        public Sprite GetCatSprite(Mood mood) => FindDataByMood(mood).CatSprite;
        
        public Sprite GetHandleSprite(Mood mood) => FindDataByMood(mood).HandleSprite;

        public SpriteData FindDataByMood(Mood mood)
        {
            List<SpriteData> spriteDatas = SpriteDatas.Where(m => m.Mood == mood).ToList();

            if (spriteDatas.Count == 0)
                return SpriteDatas[0];

            SpriteData chooseSpriteData = spriteDatas[Random.Range(0, spriteDatas.Count)];

            return chooseSpriteData;
        }
    }

    [Serializable]
    public struct SpriteData
    {
        public Mood Mood;
        public Sprite CatSprite;
        public Sprite HandleSprite;
    }
}