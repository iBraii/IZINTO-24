using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlSetValue : MonoBehaviour
{
    public static LvlSetValue lvlSetter;
    //public static int lvlValue;
    public int lvlValue;
    public int lvlNum;
    // Start is called before the first frame update
    private void Awake()
    {
        if(!lvlSetter)
        {
            lvlSetter = this;
        }
        else if (lvlSetter != this)
        {
            Destroy(lvlSetter.gameObject);
            lvlSetter = this;
        }
    }
    void Start()
    {

        lvlValue = lvlNum;
        Debug.Log(lvlValue);
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
