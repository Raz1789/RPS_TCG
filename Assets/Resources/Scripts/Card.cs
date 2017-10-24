using UnityEngine;

/// <summary>
/// Card: This is the base class of all the card types.
/// </summary>
abstract public class Card {
    #region fields & properties
    /// <summary>
    /// faceUp: bool to get the flip status of the card (Private)
    /// </summary>
    bool faceUp;

    /// <summary>
    /// The current sprite for the card (Protected)
    /// </summary>
    protected GameObject cardSprite;

    /// <summary>
    /// Property for faceUp
    /// </summary>
    public bool IsFaceUp
    {
        get
        {
            return faceUp;
        }
    }

    /// <summary>
    /// Property for cardSprite
    /// </summary>
    public GameObject CardSprite
    {
        get
        {
            return cardSprite;
        }
    }


    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="Card"/> class.
    /// </summary>
    public Card() : base()
    {
        faceUp = false;
        cardSprite = Resources.Load("Prefab/Unflipped") as GameObject;
	}

    protected Card(bool faceUp)
    {
        this.faceUp = faceUp;
        cardSprite = Resources.Load("Prefab/Unflipped") as GameObject;
    }

    #endregion

    #region Helper Function
    /// <summary>
    /// A toggle function that is triggered 
    /// by some event by the user
    /// </summary>
    protected void ToggleCard(){
		faceUp = !faceUp;
	}

    #endregion
}