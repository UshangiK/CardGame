using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI turnText;
    
    void Start()
    {
        Events.ScoredEvent += OnScoredEvent;  
        Events.TurnedEvent += OnTurnedEvent;
    }

    private void OnScoredEvent(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
    
    private void OnTurnedEvent(int newTurnCount)
    {
        turnText.text = "Turn: " + newTurnCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
