using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A sealed class containing all the essential Card position saved in 2 constant variables
/// 1: playerPosition
/// 2: enemyPosition
/// </summary>
public sealed class Positions {

    #region Helper Datatype
    /// <summary>
    /// CardPosition index Enum
    /// 0: Deck
    /// 1: Hand1
    /// 2: Hand2
    /// 3: Hand3
    /// 4: Hand4
    /// 5: Hand5
    /// 6: Hand6
    /// 7: Hand7
    /// 8: Play
    /// 9: AttSupport
    /// 10: DefSupport
    /// 11: Trap
    /// 12: Spell1
    /// 13: Spell2
    /// 14: Spell3
    /// 15: Spell4
    /// 16: Spell5
    /// 17: Graveyard
    /// </summary>
    public enum CardPositions
    {
        Deck,
        Hand1,
        Hand2,
        Hand3,
        Hand4,
        Hand5,
        Hand6,
        Hand7,
        Play,
        AttSupport,
        DefSupport,
        Trap,
        Spell1,
        Spell2,
        Spell3,
        Spell4,
        Spell5,
        Graveyard

    };

    #endregion

    #region Player Card positions
    
    /// <summary>
    /// Vector2 Constant Array containing the Player side positions
    /// </summary>
    public static readonly Vector3[] playerPositions = new Vector3[18] {
        new Vector3(7.82f,-7.65f),                                          //Deck
        new Vector3(-7.08f,-10.74f),                                        //Hand1
        new Vector3(-4.73f, -10.74f),                                       //Hand2
        new Vector3(-2.38f, -10.74f),                                       //Hand3
        new Vector3(0.02f, -10.74f),                                        //Hand4
        new Vector3(2.38f, -10.74f),                                        //Hand5
        new Vector3(4.75f, -10.74f),                                        //Hand6
        new Vector3(7.11f, -10.74f),                                        //Hand7
        new Vector3(0.02f, -1.38f),                                         //Play
        new Vector3(-2.72f, -2.709f),                                       //Attack Support
        new Vector3(2.761f, -2.709f),                                       //Defence Support
        new Vector3(0.037f, -3.971f),                                       //Trap
        new Vector3(-4.87f, -5.091f),                                       //Spell1
        new Vector3(-2.646f, -6.763f),                                      //Spell2
        new Vector3(-0.074f, -7.34f),                                       //Spell3
        new Vector3(2.785f, -6.764f),                                       //Spell4
        new Vector3(4.97f, -5.11f),                                         //Spell5
        new Vector3(-7.8f, -7.64f)                                          //Graveyard
    };


    public static readonly Vector3[] playerRotationZ = new Vector3[18]
    {
        new Vector3(0f,0f,0f),                                         //Deck
        new Vector3(0f,0f,0f),                                        //Hand1
        new Vector3(0f,0f,0f),                                         //Hand2
        new Vector3(0f,0f,0f),                                         //Hand3
        new Vector3(0f,0f,0f),                                         //Hand4
        new Vector3(0f,0f,0f),                                         //Hand5
        new Vector3(0f,0f,0f),                                         //Hand6
        new Vector3(0f,0f,0f),                                        //Hand7
        new Vector3(0f,0f,0f),                                        //Play
        new Vector3(0f,0f,0f),                                         //Attack Support
        new Vector3(0f,0f,0f),                                         //Defence Support
        new Vector3(0f,0f,0f),                                         //Trap
        new Vector3(0f,0f,-48.8f),                                     //Spell1
        new Vector3(0f,0f,-24.642f),                                   //Spell2
        new Vector3(0f,0f,0f),                                         //Spell3
        new Vector3(0f,0f,24.193f),                                    //Spell4
        new Vector3(0f,0f,48.38f),                                      //Spell5
        new Vector3(0f,0f,0f)                                          //Graveyard
};

    #endregion

    #region Helper functions
    
    private static int StringToCardPosition(string position)
    {
        switch (position)
        {
            case "Deck":
                return (int)CardPositions.Deck;
            case "Hand1":
                return (int)CardPositions.Hand1;
            case "Hand2":
                return (int)CardPositions.Hand2;
            case "Hand3":
                return (int)CardPositions.Hand3;
            case "Hand4":
                return (int)CardPositions.Hand4;
            case "Hand5":
                return (int)CardPositions.Hand5;
            case "Hand6":
                return (int)CardPositions.Hand6;
            case "Hand7":
                return (int)CardPositions.Hand7;
            case "Play":
                return (int)CardPositions.Play;
            case "AttSupport":
                return (int)CardPositions.AttSupport;
            case "DefSupport":
                return (int)CardPositions.DefSupport;
            case "Trap":
                return (int)CardPositions.Trap;
            case "Spell1":
                return (int)CardPositions.Spell1;
            case "Spell2":
                return (int)CardPositions.Spell2;
            case "Spell3":
                return (int)CardPositions.Spell3;
            case "Spell4":
                return (int)CardPositions.Spell4;
            case "Spell5":
                return (int)CardPositions.Spell5;
            case "Graveyard":
                return (int)CardPositions.Graveyard;
            default:
                return (int)CardPositions.Deck;
        }
    }

    public static void SetPosition(GameObject gameObject, string position)
    {
        gameObject.transform.position = playerPositions[StringToCardPosition(position)];
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.Rotate(playerRotationZ[StringToCardPosition(position)]);
    }

    #endregion
}