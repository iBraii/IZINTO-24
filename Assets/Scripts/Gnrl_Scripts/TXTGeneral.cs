using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TXTGeneral : MonoBehaviour
{
    public Text urText;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        //urText = GetComponent<Text>();
        //urText.text = ("");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    public void WriteSthTemporal(string myText/*, float maxtimer*/)
    {
        urText.text = (myText);
        /*if(timer >= maxtimer)
        {
            urText.text = ("");
            timer = 0;
        }*/
    }
}
