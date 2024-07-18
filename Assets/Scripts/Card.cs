using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int ID { get; private set; }
    public MainLogic controller;
    
    [SerializeField] private GameObject cardBack;

    private void Start()
    {
        Invoke(nameof(TurnCardFaceDown), 2f); // At the beginning cards are facing up for players to see and after 2 seconds they get turned face down
    }

    public void OnMouseDown() // If card is facing down, shows its front and reports to controller
    {
        if(cardBack.activeSelf)
        {
            cardBack.SetActive(false);
            controller.CardClicked(this);
        }
    }

    public void GiveId(int id) // Gives ID
    {
        ID = id;
    }
    
    public void ChangeSprite(Sprite image) // Changes card sprite
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void TurnCardFaceDown() // Turns card face down
    {
        cardBack.SetActive(true);
    }
    
    public void Destroy() // Destroys card
    {
        Destroy(gameObject);
    }
}
