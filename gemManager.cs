using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gemManager : MonoBehaviour {

    public Text winnerText, showText;

    public GameObject guard, thief;

    public itemPickup[] gems;

    public bool hasAllGems = false;

    public sceneManager sceneMan;

    private IEnumerator couroutine;

    public Animator sceneFader;

    //public Button restartButton, mainMenuButton;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Thief")
        {
            if (hasAllGems)
            {
                print("T WIN");
                couroutine = Win("THIEF");
                StartCoroutine(couroutine);
            }
        }
    }

    private void Start()
    {
        guard = GameObject.FindWithTag("Guard");
        thief = GameObject.FindWithTag("Thief");
        winnerText.enabled = false;
        showText.enabled = false;
        //restartButton.enabled = false;
        //mainMenuButton.enabled = false;

        sceneMan = GameObject.Find("sceneManager").GetComponent<sceneManager>();

        //restartButton.image.enabled = false;
       // mainMenuButton.image.enabled = false;

       // restartButton.transform.GetChild(0).GetComponent<Text>().enabled = false;
       // mainMenuButton.transform.GetChild(0).GetComponent<Text>().enabled = false;
    }

    private void Update()
    {
        if (sceneMan.timeUp)
        {
            couroutine = Win("THIEF");
            StartCoroutine(couroutine);
        }

        if(sceneMan.timer <= 20)
        {
            guard.GetComponent<playerMovement>().moveSpeed = 12;
        }

        if(gems[0].isCollected && gems[1].isCollected && gems[2].isCollected)
        {
            hasAllGems = true;
            //print("TIEF GET 2 EXIT");
        }

        if (guard.GetComponent<playerMovement>().guardWin)
        {
            couroutine = Win("GUARD");
            StartCoroutine(couroutine);
        }

        if (sceneFader.GetCurrentAnimatorStateInfo(0).IsName("fadeOut"))
        {
          //  restartButton.enabled = true;
          //  mainMenuButton.enabled = true;

          //  restartButton.image.enabled = true;
           // mainMenuButton.image.enabled = true;

           // restartButton.transform.GetChild(0).GetComponent<Text>().enabled = true;
           // mainMenuButton.transform.GetChild(0).GetComponent<Text>().enabled = true;
        }

    }

    public IEnumerator Win(string winner)
    {
        winnerText.text = winner;
        guard.GetComponent<playerMovement>().canMove = false;
        thief.GetComponent<playerMovement>().canMove = false;

        guard.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        thief.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        winnerText.enabled = true;
        showText.enabled = true;
        //Time.timeScale = 0;
        yield return new WaitForSeconds(2);
        sceneFader.SetTrigger("sceneFade");

    }


}
