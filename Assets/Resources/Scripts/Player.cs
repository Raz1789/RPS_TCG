using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Helper Datatype
    /// <summary>
    /// Game Phase Enum
    /// 0: Draw Phase
    /// 1: Setup Phase
    /// 2: Reveal Phase
    /// 3: Attack Phase
    /// 4: Enemy Play Phase
    /// </summary>
    public enum GamePhase
    {
        Draw,
        Setup,
        Reveal,
        Attack,
        EnemyPlay
    }
    #endregion

    #region fields & Properties


    // Static variables
    /// <summary>
    /// Player Deck (static private)
    /// </summary>
    static Deck PlayerDeck;

    /// <summary>
    /// Variable to monitor the gamePhase
    /// </summary>
    static GamePhase gamePhase;

    /// <summary>
    /// Get Property for gamePhase
    /// </summary>
    public static GamePhase GetGamePhase
    {
        get
        {
            return gamePhase;
        }
    }

    //Hand Variables
    /// <summary>
    /// List of Cards in hand at any point in time
    /// </summary>
    List<Card> handCards;

    /// <summary>
    /// List of Card Game objects created
    /// </summary>
    List<GameObject> handCardsObject;

    /// <summary>
    /// Keep track whether hand content changed
    /// </summary>
    bool handChanged;


    // Draw Phase Variables
    /// <summary>
    /// A boolean to check if it is the first draw phase
    /// </summary>
    bool firstDraw;

    #endregion

    #region default function
    /// <summary>
    /// Run Once at start of the game
    /// </summary>
    void Start()
    {
        //Initializations
        PlayerDeck = new Deck(); // Automatically fill the Deck with Random cards (Only for Prototyping)
        handCards = new List<Card>(); //Initialize the hand List with null
        handCardsObject = new List<GameObject>(); //Initialize the corresponding HandCard Objects to null
        handChanged = false; //Initialize handChanged to false
        firstDraw = true; //Initialize first draw to true
        gamePhase = GamePhase.Draw; //Initialize gamePhase as Draw since the game just started
    }

    /// <summary>
    /// Update with fixed interval
    /// </summary>
    void FixedUpdate()
    {
        transform.position = new Vector3(TouchPoint.touch.x, TouchPoint.touch.y, 0f);
        if (handChanged)
        {
            DrawHand();
            handChanged = false;
        }
        
    }

    

    /// <summary>
    /// On Trigger Stay
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (gamePhase)
        {
            case GamePhase.Draw:
                DrawPhase(collision);
                break;
        }
    }

    #endregion

    #region Helper Functions
    
    /// <summary>
    /// Draw Phase functions
    /// </summary>
    private void DrawPhase(Collider2D other)
    {
        if(other.name == "Deck" && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (firstDraw)
            {
                for(int i = 0; i < 7; i++)
                {
                    handChanged = true;
                    handCards.Add(PlayerDeck.getTopCard());
                    ((AttackCard)handCards[i]).ToggleCard();
                    firstDraw = false;
                }
            }
            else
            {
                if(handCards.Count < 7)
                {
                    handChanged = true;
                    handCards.Add(PlayerDeck.getTopCard());
                    ((AttackCard)handCards[handCards.Count -1]).ToggleCard();
                }
            }
            NextPhase();
        }
    }

    /// <summary>
    /// Increment the player GamePhase to next Phase
    /// </summary>
    public void NextPhase()
    {
        if (gamePhase != GamePhase.Attack)
        {
            gamePhase++;
        }
        else
        {
            gamePhase = GamePhase.Draw;
        }
    }

    /// <summary>
    /// Returns the no.of cards left with the player
    /// </summary>
    /// <returns></returns>
    public static int PlayerCardLeft()
    {
        return PlayerDeck.CardsLeft;
    }

    /// <summary>
    /// Create the hand objects in correct positions
    /// </summary>
    private void DrawHand()
    {
        if(handCards != null)
        {
            if(handCardsObject != null)
            {
                for(int i = handCardsObject.Count - 1; i >=0; i--)
                {
                    Destroy(handCardsObject[i]);
                    handCardsObject.RemoveAt(i);
                }
                Debug.Log(handCardsObject.Count);
            }
            Debug.Log(handCards.Count);
            for (int i = 0; i < handCards.Count; i++)
            {
                handCardsObject.Add(Instantiate(((AttackCard)handCards[i]).CardSprite) as GameObject);
                Positions.SetPosition(handCardsObject[i], "Hand" + (i + 1));
            }
        }
    }

    #endregion

}