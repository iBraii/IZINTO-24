using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Txt : MonoBehaviour
{
    public Text elTexto;
    private GameObject baseTimer;
    // Start is called before the first frame update
    void Start()
    {
        elTexto = GetComponent<Text>();
        elTexto.text = ("");
        baseTimer = GameObject.Find("BaseReloj");
        baseTimer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Write();
    }
    void Write()
    {
        if(GameObject.Find("ChallengesController").GetComponent<ChallengeController>().numPivotChallenge == 1 && GameObject.Find("Desafio1"))
        {
            baseTimer.SetActive(true);
            elTexto.text = ("" + GameObject.Find("Desafio1").GetComponent<Desafio1>().timer.ToString("00"));
            
            
        }
        else if (GameObject.Find("ChallengesController").GetComponent<ChallengeController>().numPivotChallenge == 2 && GameObject.Find("Desafio2"))
        {
            baseTimer.SetActive(false);
            elTexto.text = ("");
        }
        else if (GameObject.Find("ChallengesController").GetComponent<ChallengeController>().numPivotChallenge == 3 && GameObject.Find("Desafio3"))
        {

            baseTimer.SetActive(true);
            elTexto.text = ("" + GameObject.Find("Desafio3").GetComponent<Desafio3>().timer.ToString("00"));
            
        }
        else if (GameObject.Find("ChallengesController").GetComponent<ChallengeController>().numPivotChallenge == 1 && GameObject.Find("Desafio1B"))
        {
            baseTimer.SetActive(true);
            elTexto.text = ("" + GameObject.Find("Desafio1B").GetComponent<Desafio1>().timer.ToString("00"));


        }
        else if (GameObject.Find("ChallengesController").GetComponent<ChallengeController>().numPivotChallenge == 2 && GameObject.Find("Desafio2B"))
        {
            baseTimer.SetActive(false);
            elTexto.text = ("");
        }
        else if (GameObject.Find("ChallengesController").GetComponent<ChallengeController>().numPivotChallenge == 3 && GameObject.Find("Desafio3B"))
        {

            baseTimer.SetActive(true);
            elTexto.text = ("" + GameObject.Find("Desafio3B").GetComponent<Desafio3>().timer.ToString("00"));

        }

    }
}
