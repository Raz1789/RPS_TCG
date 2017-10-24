using UnityEngine;

/// <summary>
/// Attack card Class
/// </summary>
public class AttackCard : Card {

    #region Helper Data Types
    /// <summary>
    /// Enum to keep track of the type of the Attack cards
    /// 0: Rock
    /// 1: Paper
    /// 2: Scissors
    /// </summary>
    public enum CardType
    {
        Rock,
        Paper,
        Scissors
    }

    #endregion

    #region Member Fields
    /// <summary>
    /// Private CardType object for storing the card type
    /// </summary>
    CardType cardType;

    /// <summary>
    /// Private Float variable for storing the card attack value
    /// </summary>
    private float cardAttack;

    /// <summary>
    /// Private Float variable for storing the card defence value
    /// </summary>
    private float cardDefense;

    

    #endregion

    #region Constructors
    /// <summary>
    /// Constructor for class AttackCard
    /// Sets the attack and defence value as per the card type passed as parameter
    /// </summary>
    /// <param name="cardType"></param>
    public AttackCard(CardType cardType) : base()
    {
        this.cardType = cardType;

        switch (this.cardType)
        {
            case CardType.Rock:
                cardAttack = 0f;
                cardDefense = 2f;
                break;
            case CardType.Paper:
                cardAttack = 1f;
                cardDefense = 1f;
                break;
            case CardType.Scissors:
                cardAttack = 2f;
                cardDefense = 0f;
                break;
        }
    }

    public AttackCard(CardType cardType, bool faceUp) : base(faceUp)
    {
        this.cardType = cardType;

        switch (this.cardType)
        {
            case CardType.Rock:
                cardAttack = 0f;
                cardDefense = 2f;
                cardSprite = Resources.Load("Prefab/Rock") as GameObject;
                break;
            case CardType.Paper:
                cardAttack = 1f;
                cardDefense = 1f;
                cardSprite = Resources.Load("Prefab/Paper") as GameObject;
                break;
            case CardType.Scissors:
                cardAttack = 2f;
                cardDefense = 0f;
                cardSprite = Resources.Load("Prefab/Scissors") as GameObject;
                break;
        }
    }
    #endregion

    #region Member Functions

    /// <summary>
    /// Function to Modify the Att and Def as per the Att Support and Def Support Cards
    /// </summary>
    /// <param name="supportCardLeft"></param>
    /// <param name="supportCardRight"></param>
    public void SupportModifiers(AttackCard supportCardLeft, AttackCard supportCardRight)
    {
        cardAttack = supportCardLeft.cardAttack / 2;
        cardDefense = supportCardRight.cardDefense / 2;
    }
    

    //Basic ToString Function Override
    public override string ToString()
    {
        return "" + cardType;
    }

    /// <summary>
    /// Toggle the face of the card and change the Sprite accordingly
    /// </summary>
    public new void ToggleCard()
    {
        if (!IsFaceUp)
        {
            switch (cardType)
            {
                case CardType.Rock:
                    cardSprite = Resources.Load("Prefab/Rock") as GameObject;
                    break;
                case CardType.Paper:
                    cardSprite = Resources.Load("Prefab/Paper") as GameObject;
                    break;
                case CardType.Scissors:
                    cardSprite = Resources.Load("Prefab/Scissors") as GameObject;
                    break;
            }
        }
        else
        {
            cardSprite = Resources.Load("Prefab/Unflipped") as GameObject;
        }
        base.ToggleCard();
    }
    #endregion
}