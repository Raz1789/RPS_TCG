using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Helper Datatype

    public enum GamePhase
    {
        Draw,
        Setup,
        Reveal,
        Attack
    }
    #endregion

    #region fields & Properties

    /// <summary>
    /// Player Deck (static private)
    /// </summary>
    static Deck PlayerDeck;
    List<Card> handCards;
    GameObject pickedCardObject;

    GamePhase gamePhase;

    #endregion

    #region default function
    /// <summary>
    /// Run Once at start of the game
    /// </summary>
    void Start()
    {
        PlayerDeck = new Deck();
        handCards = new List<Card>();
        gamePhase = GamePhase.Draw;
    }

    /// <summary>
    /// Update with fixed interval
    /// </summary>
    void FixedUpdate()
    {
        transform.position = new Vector3(TouchPoint.touch.x, TouchPoint.touch.y, 0f);
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
        if(other.name == "Deck")
        {
            
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


    #endregion

}