using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {

    public Animator playBtn, aboutBtn;
    private Vector3 refVel = Vector3.zero;
    public GameObject[] mapObjs;
    public GameObject fade;

    public GameObject aboutTab;

	public void OnPlayButton()
    {
        playBtn.SetTrigger("pBtnClick");
        aboutBtn.SetTrigger("aBtnClick");

        for(int i = 0; i < mapObjs.Length; i++)
        {
            mapObjs[i].SetActive(true);
            mapObjs[i].GetComponent<Animator>().SetTrigger("appear");

        }

        
        //cMap.GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(cMap.GetComponent<RectTransform>().anchoredPosition, new Vector3(272, 159, 0), ref refVel, 0.3f);
    }

    public void aboutBtnClick()
    {
        aboutTab.SetActive(true);
    }

    public void closeAbout()
    {
        aboutTab.SetActive(false);
    }

    public void trestSelect(string Level)
    {
        fade.GetComponent<Animator>().SetTrigger("lvlLoad");
        Application.LoadLevelAsync(Level);
    }
}
