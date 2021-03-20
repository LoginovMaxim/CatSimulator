using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Behaviour = Logic.Behaviour;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PlayerAction;
    [SerializeField] private TextMeshProUGUI CatReaction;

    [SerializeField] private Image CatView;

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
        CatView.sprite = _cat.GetCurrentSprite();
    }

    public void ChangeText(string action, string reaction)
    {
        PlayerAction.text = "Вы попытались " + action;
        CatReaction.text = "В ответ она " + reaction;

        CatView.sprite = _cat.GetCurrentSprite();
    }

    private void OnDisable()
    {
        foreach (var behaviour in _behaviours)
        {
            behaviour.OnAction -= ChangeText;
        }
    }
}
