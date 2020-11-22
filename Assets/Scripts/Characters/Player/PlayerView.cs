using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerView : MonoBehaviour
{
    private GameObject Barra;
    private PlayerModelo cmp_playerMod;
    public GameObject DamageIndicator;
    // Start is called before the first frame update
    void Start()
    {
        cmp_playerMod = GetComponent<PlayerModelo>();
        Barra = GameObject.FindGameObjectWithTag("Barra");
    }

    // Update is called once per frame
    void Update()
    {
        LiveChecker();
    }
    void LiveChecker ()
    {
        if (cmp_playerMod.playerLife >= 3)
        {
            Barra.transform.localScale = new Vector2(1.70f, 0.25f);
            Barra.transform.localPosition = new Vector2(-310f, 131f);
        }
        else if (cmp_playerMod.playerLife ==2)
        {
            Barra.transform.localScale = new Vector2(1.15f, 0.25f);
            Barra.transform.localPosition = new Vector2(-335f, 131f);
        }
        else if (cmp_playerMod.playerLife ==1)
        {
            Barra.transform.localScale = new Vector2(0.75f, 0.25f);
            Barra.transform.localPosition = new Vector2(-355f, 131f);
        }
        else if (cmp_playerMod.playerLife <=0)
        {
            Barra.transform.localScale = new Vector2(0f, 0.25f);
        }
    }
}
