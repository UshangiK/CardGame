using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    public int cardRows = 2;
    public int cardColumns = 3;
    
    [SerializeField] private Card cardPrefab;
    [SerializeField] private Sprite[] cardImages;

    private const float MaxOffsetX = 12f;
    private const float MaxOffsetY = 5f;
    private const int DefaultRows = 2;
    private const int DefaultCols = 3;
    
    private int _score = 0;
    private int _turn = 0;
    private Card _firstClickedCard;
    private Card _secondClickedCard;
    private int[] _uniqueIds;
    private bool _clickedFirst;
    private float _offsetX;
    private float _offsetY;
    private float _scale;

    private void Start()
    {
        Vector3 startPos = cardPrefab.transform.position;
        

        PopulateUniqueIds();

        InstantiateCards(_uniqueIds, startPos);
    }

    private void ScaleCard(Card card) // Scales cards and distance between them in accordance to number of rows and columns
    {
        _offsetX = MaxOffsetX / (cardColumns - 1);
        _offsetY = MaxOffsetY / (cardRows - 1);

        _scale = (float)DefaultCols / cardColumns;
        if (_scale > (float)DefaultRows / cardRows)
        {
            _scale = (float)DefaultRows / cardRows;
        }

        card.transform.localScale *= _scale;
    }

    private void PopulateUniqueIds() // Populates an array with pairs of unique IDs
    {
        _uniqueIds = new int[cardColumns * cardRows];

        for (int i = 0; i < cardColumns * cardRows; i++)
        {
            _uniqueIds[i] = i / 2;
        }

        _uniqueIds = ShuffleArray(_uniqueIds);
    }

    private void GiveCardId(int id, Card card) // Gives card unique id and changes its sprite according to the id
    {
        card.GiveId(id);
        card.ChangeSprite(cardImages[id]);
    }
    
    private void InstantiateCards(int[] numbers, Vector3 startPos) // Instantiates cards and puts them in their position
    {
        for(int i = 0; i < cardColumns; i++)
        {
            for(int j = 0; j < cardRows; j++)
            {
                var card = Instantiate(cardPrefab);
                card.GetComponent<Card>().controller = this;
                ScaleCard(card);
                
                int index = j * cardColumns + i;
                int id = numbers[index];
                
                GiveCardId(id, card);
    
                float posX = (_offsetX * i) + startPos.x;
                float posY = (_offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private static int[] ShuffleArray(int[] numbers) // Randomizes array's contents
    {
        for(int i = 0; i < numbers.Length; i++)
        {
            int temp = numbers[i];
            int random = Random.Range(i, numbers.Length);
            numbers[i] = numbers[random];
            numbers[random] = temp;
        }
        return numbers;
    }
    

    public void CardClicked(Card card) // Checks if current clicked card is first or second and if it's second starts coroutine to check if they match
    {
        if(!_clickedFirst)
        {
            _firstClickedCard = card;
        }
        else
        {
            _turn += 1;
            Events.InvokeTurnedEvent(_turn);
            _secondClickedCard = card;
            StartCoroutine(CheckPairs(_firstClickedCard, _secondClickedCard));
        }
        _clickedFirst = !_clickedFirst;
    }

    private IEnumerator CheckPairs(Card first, Card second) // Checks a pair of cards to see if they are the same
    {
        if(first.ID == second.ID)
        {
            _score += 1;
            Events.InvokeScoredEvent(_score);
            yield return new WaitForSeconds(1f);
            first.Destroy();
            second.Destroy();
        }
        else
        {
            yield return new WaitForSeconds(1f);

            first.TurnCardFaceDown();
            second.TurnCardFaceDown();
        }
        

    }
}
