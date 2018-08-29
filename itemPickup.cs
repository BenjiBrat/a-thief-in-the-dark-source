using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPickup : MonoBehaviour {

    public Image[] gems;
    public int gemNumber;

    public bool isCollected;

    public SpriteRenderer thisSprite;

    public BoxCollider2D thisCollider;

    public void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D thief)
    {
        if(thief.tag == "Thief")
        {
            print("Thief stole Gem " + gemNumber);

            gems[gemNumber].enabled = false;
            isCollected = true;
            thisSprite.enabled = false;
            thisCollider.enabled = false;
        }
    }
}
