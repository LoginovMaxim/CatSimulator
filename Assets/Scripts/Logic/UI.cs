using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Behaviour = Logic.Behaviour;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PlayerAction;
    [SerializeField] private TextMeshProUGUI CatReaction;

    private List<Behaviour> _behaviours = new List<Behaviour>();
    
    private void OnEnable()
    {
        _behaviours = FindObjectsOfType<Behaviour>().ToList();
        
        foreach (var behaviour in _behaviours)
        {
            behaviour.OnAction += ChangeText;
        }
    }

    public void ChangeText(string action, string reaction)
    {
        PlayerAction.text = "Вы попытались " + action;
        CatReaction.text = "В ответ она " + reaction;
    }

    private void OnDisable()
    {
        foreach (var behaviour in _behaviours)
        {
            behaviour.OnAction -= ChangeText;
        }
    }
}
