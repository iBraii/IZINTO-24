using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Txt : MonoBehaviour
{
    public Text elTexto;
    // Start is called before the first frame update
    void Start()
    {
        elTexto = GetComponent<Text>();
        elTexto.text = ("");
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
            elTexto.text = ("" + GameObject.Find("Desafio1").GetComponent<Desafio1>().timer);
        }
        if (GameObject.Find("ChallengesController").GetComponent<ChallengeController>().numPivotChallenge == 2 && GameObject.Find("Desafio2"))
        {
            elTexto.text = ("");
        }
        if (GameObject.Find("ChallengesController").GetComponent<ChallengeController>().numPivotChallenge == 3 && GameObject.Find("Desafio3"))
        {
            elTexto.text = ("" + GameObject.Find("Desafio3").GetComponent<Desafio3>().timer);
        }
    }
}
