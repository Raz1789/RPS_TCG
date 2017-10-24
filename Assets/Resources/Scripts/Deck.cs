using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deck Class contains one deck of cards.
/// </summary>
public class Deck {
    #region Fields
    /// <summary>
    /// CONSTANT with the default size of the deck
    /// </summary>
    public static int SIZEOFDECK = 40;

    /// <summary>
    /// No. of Cards Left in the deck
    /// </summary>
    public int CardsLeft
    {
        get
        {
            return cards.Count;
        }
    }

    /// <summary>
    /// List of Cards in the Deck
    /// </summary>
    List<Card> cards;

    #endregion

    #region Constructor 
    
    public Deck() : base()
    {
        cards = new List<Card>();

        System.Random random = new System.Random();
        for (int i = 0; i < SIZEOFDECK; i++)
        {
            AttackCard.CardType cardType = (AttackCard.CardType)random.Next(0, 3);
            cards.Add(new AttackCard(cardType));
        }
    }
    #endregion

    #region Member functions

    public Card getTopCard()
    {
        return cards[0];
    }

    #endregion

    #region Overridden Functions

    public override string ToString()
    {
        string list = "";
        for (int i = 0; i < cards.Count; i++)
        {
            list += ((AttackCard)cards[i]).ToString() + "\n";
        }

        return list;


    }

    #endregion  

}