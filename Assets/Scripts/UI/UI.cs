using System.Collections.Generic;
using System.Linq;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Behaviour = Gameplay.Behaviour;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerAction;
        [SerializeField] private TextMeshProUGUI _catReaction;

        [SerializeField] private Image _catView;
        [SerializeField] private MoodSpriteData _moodSpriteData;

        private List<Behaviour> _behaviours = new List<Behaviour>();
        private Cat _cat;
    
        private void OnEnable()
        {
            _behaviours = FindObjectsOfType<Behaviour>().ToList();
            _cat = FindObjectOfType<Cat>();
        
            foreach (var behaviour in _behaviours)
            {
                behaviour.OnAction += ChangeText;
            }
        }

        private void Start()
        {
            _catView.sprite = _moodSpriteData.GetCatSprite(_cat.Mood);
        }

        public void ChangeText(string action, string reaction)
        {
            _playerAction.text = "Вы попытались " + action;
            _catReaction.text = "В ответ она " + reaction;

            _catView.sprite = _moodSpriteData.GetCatSprite(_cat.Mood);
        }

        private void OnDisable()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.OnAction -= ChangeText;
            }
        }
    }
}
