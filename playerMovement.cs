using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public bool guardWin, canMove, inLight;

    public Rigidbody2D playerBody;
    public float moveSpeed;
    public GameObject flashLight;

    private Quaternion _lookRot;
    private Vector2 _flashDir;

    public LayerMask thief, startMask;

    public float flashTurn;
    private float velRef = 0;

    public string moveH, moveV;

    public Camera myCam;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Thief")
        {
            
            guardWin = true;
            print("GUARD WINZ");
        }
    }


    void Start () {
        playerBody = GetComponent<Rigidbody2D>();
        startMask = myCam.cullingMask;

        canMove = true;

        if(this.gameObject.name == "guard")
        {
            myCam.cullingMask = ~thief;
        }
	}
	
	
	void Update () {




        if (canMove)
        {

            float h = Input.GetAxis(moveH);
            float v = Input.GetAxis(moveV);

            if (v > 0)
            {
                //print("FLASH UP");
                flashLight.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (h > 0)
            {
                //print("FLASH UP");
                flashLight.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (h < 0)
            {
                //print("FLASH UP");
                flashLight.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (v < 0)
            {
                //print("FLASH UP");
                flashLight.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            playerBody.velocity = new Vector2(h * moveSpeed, v * moveSpeed);
        }
	}

    
}
