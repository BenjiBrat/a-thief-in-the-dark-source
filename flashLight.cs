using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour {

    public GameObject guard, thief;

    public Transform gT, tT;

    public Transform thiefIndicator;

    public bool N, E;

    public Animator pointer;

    private void Start()
    {
        guard = GameObject.FindWithTag("Guard");
        thief = GameObject.FindWithTag("Thief");

        gT = guard.transform;
        tT = thief.transform;

        N = true;
        E = true;

        thiefIndicator = GameObject.FindGameObjectWithTag("Pointer").transform;
        thiefIndicator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D thierf)
    {
        if (thierf.tag == "Thief")
        {
            print("HEY I SEE A THIERF");
            guard.GetComponent<playerMovement>().myCam.cullingMask = guard.GetComponent<playerMovement>().startMask;

            thierf.GetComponent<playerMovement>().moveSpeed = 6;
            thierf.GetComponent<playerMovement>().inLight = true;

            thiefIndicator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D thierf)
    {
        if (thierf.tag == "Thief")
        {
            print("HEY I DON SEE A THIERF");
            guard.GetComponent<playerMovement>().myCam.cullingMask = ~guard.GetComponent<playerMovement>().thief;

            thierf.GetComponent<playerMovement>().moveSpeed = 8;
            thierf.GetComponent<playerMovement>().inLight = true;

            thiefIndicator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    public void Update()
    {
        Vector3 thiefPos = thief.transform.position;

        Vector3 thiefPosWorld = new Vector3(thiefPos.x, thiefPos.y, thiefIndicator.position.z);

        thiefIndicator.transform.right = thiefPosWorld - thiefIndicator.position;



    }
}
