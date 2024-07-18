using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Card : MonoBehaviour
{
    public int ID { get; private set; }
    public MainLogic controller;
    
    [SerializeField] private GameObject cardBack;
    [SerializeField] private float rotationDuration = 0.5f;

    private bool _isClickable;

    private void Start()
    {
        Invoke(nameof(TurnCardFaceDown), 2f); // At the beginning cards are facing up for players to see and after 2 seconds they get turned face down
    }

    public void OnMouseDown() // If card is facing down, shows its front and reports to controller
    {
        if(cardBack.activeSelf && _isClickable)
        {
            controller.CardClicked(this);
            FlipCard(false);
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

    private void FlipCard(bool front)
    {
        _isClickable = false;
        if (front)
        {
            StartCoroutine(Utils.RotateObject(gameObject.transform, new Vector3(0, 90f, 0), rotationDuration,
                () =>
                {
                    cardBack.SetActive(true);
                    StartCoroutine(Utils.RotateObject(gameObject.transform, new Vector3(0, 179f, 0), rotationDuration, () => _isClickable = true));
                }));
        }
        else
        {
            StartCoroutine(Utils.RotateObject(gameObject.transform, new Vector3(0, 90f, 0), rotationDuration,
                () =>
                {
                    cardBack.SetActive(false);
                    StartCoroutine(Utils.RotateObject(gameObject.transform, new Vector3(0, 0, 0), rotationDuration, () => _isClickable = true));
                }));
        }
    }
    
    
    public void TurnCardFaceDown() // Turns card face down
    {
        FlipCard(true);
    }
    
    public void Destroy() // Destroys card
    {
        Destroy(gameObject);
    }
}
