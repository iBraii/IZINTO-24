using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool paused;
    public GameObject Pause_Menu;

    public bool Back_Button;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Back_Button = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused == true)
            {
                paused = false;
            }
            else if (paused == false)
            {
                paused = true;
            }
        }

        if (paused == false)
        {
            Pause_Menu.SetActive(false);
            Time.timeScale = 1;
        }
        if (paused == true)
        {
            Pause_Menu.SetActive(true);
            Time.timeScale = 0;
        }

        Button_false();

    }

    public void Button_false()
    {
        if (Back_Button==true)
        {
            Back_Button = false;
            paused = false;
        }
        
    }
}
