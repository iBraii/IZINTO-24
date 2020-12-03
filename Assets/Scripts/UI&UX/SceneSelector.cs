using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour
{
    //public static int lvlValue;
    // Start is called before the first frame update
    public GameObject lvlSetObj;
    public GameObject scnManager;
    public string[] sceneNames;
    private int scnNum;
    void Start()
    {
        if (GameObject.Find("LvLStatic"))
        {
            lvlSetObj = GameObject.Find("LvLStatic");
        }
       if(lvlSetObj == null)
        {
            scnNum = 0;
        }
        else
        {
            
        scnNum = lvlSetObj.GetComponent<LvlSetValue>().lvlValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LvlBackScene()
    {
        scnManager.GetComponent<SceneChange>().Change(sceneNames[scnNum]);
    }
}
