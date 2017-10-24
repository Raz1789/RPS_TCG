using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckCardCount : MonoBehaviour {

    Text text;
    string defaultText;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        defaultText = "Cards Left :";
        text.text = defaultText + Deck.SIZEOFDECK;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        text.text = defaultText + Player.PlayerCardLeft();
	}
}