using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] obj_spwn_Array;
    public int objActiveCounter;
    // Start is called before the first frame update
    void Start()
    {

        objActiveCounter = obj_spwn_Array.Length;
        for (int i = 0; i < obj_spwn_Array.Length; i++)
        {

            obj_spwn_Array[i].SetActive(false);

            objActiveCounter--;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ArraySpawnGeneretor(GameObject object_spawned, Vector3 spw_pos)
    {
        objActiveCounter = obj_spwn_Array.Length;
        for (int i = 0; i < obj_spwn_Array.Length; i++)
        {
            if (obj_spwn_Array[i].activeSelf == false)
            {
                objActiveCounter--;
            }
        }


        if (objActiveCounter < obj_spwn_Array.Length)
        {
            bool close_loop = false;
            while (close_loop == false)
            {
                for (int i = 0; i < obj_spwn_Array.Length; i++)
                {
                    if (obj_spwn_Array[i].activeSelf == false)
                    {
                        obj_spwn_Array[i].SetActive(true);
                        obj_spwn_Array[i].transform.position = spw_pos;
                        close_loop = true;
                        i = obj_spwn_Array.Length;
                        Debug.Log(i);
                    }
                }
            }
        }
        else
        {
            int array_size = obj_spwn_Array.Length;
            obj_spwn_Array = IncreaseArray(obj_spwn_Array, 1);
            obj_spwn_Array[array_size] = Instantiate(object_spawned);
            obj_spwn_Array[array_size].transform.position = spw_pos;
            if (obj_spwn_Array[array_size].activeSelf == false)
            {
                obj_spwn_Array[array_size].SetActive(true);
            }
        }
    }

    public void ArraySpawnGeneretor(GameObject object_spawned, Vector3 spw_pos, Vector3 obj_angl_rot)
    {
        objActiveCounter = obj_spwn_Array.Length;
        for (int i = 0; i < obj_spwn_Array.Length; i++)
        {
            if (obj_spwn_Array[i].activeSelf == false)
            {
                objActiveCounter--;
            }
        }


        if (objActiveCounter < obj_spwn_Array.Length)
        {
            bool close_loop = false;
            while (close_loop == false)
            {
                for (int i = 0; i < obj_spwn_Array.Length; i++)
                {
                    if (obj_spwn_Array[i].activeSelf == false)
                    {
                        obj_spwn_Array[i].SetActive(true);
                        obj_spwn_Array[i].transform.position = spw_pos;
                        obj_spwn_Array[i].transform.eulerAngles = obj_angl_rot;
                        close_loop = true;
                        i = obj_spwn_Array.Length;
                        Debug.Log(i);
                    }
                }
            }
        }
        else
        {
            int array_size = obj_spwn_Array.Length;
            obj_spwn_Array = IncreaseArray(obj_spwn_Array, 1);
            obj_spwn_Array[array_size] = Instantiate(object_spawned);
            if (obj_spwn_Array[array_size].activeSelf == false)
            {
                obj_spwn_Array[array_size].SetActive(true);
            }
        }
    }

    public void ArrayDespawn()
    {
        objActiveCounter = obj_spwn_Array.Length;
        for (int i = 0; i < obj_spwn_Array.Length; i++)
        {
            if (obj_spwn_Array[i].activeSelf == false)
            {
                objActiveCounter--;
            }
        }

        bool close_loop = false;
        if (objActiveCounter > 0)
        {
            while (close_loop == false)
            {
                for (int i = 0; i < obj_spwn_Array.Length; i++)
                {
                    if (obj_spwn_Array[i].activeSelf == true)
                    {
                        obj_spwn_Array[i].SetActive(false);
                        close_loop = true;
                        i = obj_spwn_Array.Length;
                    }
                }
            }
        }
        
    }
    public void ArrayDespawn(int obj_row)
    {
        if (obj_spwn_Array[obj_row].activeSelf == true)
        {
            obj_spwn_Array[obj_row].SetActive(false);
        }
        else
        {
            Debug.Log("Empty Slot");
        }
    }





    //----------------------------------------------------------//
    public void BasicInstantiate(GameObject spawn_obj, float pos_X, float pos_Y, float pos_Z)
    {
        GameObject spwn_obj = Instantiate(spawn_obj);
        spwn_obj.transform.position = new Vector3(pos_X, pos_Y, pos_Z);
    }

    // Need to be placed into an update
    public void BasicSpawner(GameObject spawn_obj, float pos_X, float pos_Y, float pos_Z, float max_timer)
    {
        float timer = 0;
        timer += Time.deltaTime;
        if (timer >= max_timer)
        {
            GameObject obj = Instantiate(spawn_obj);
            Vector3 position = new Vector3(pos_X, pos_Y, pos_Z);
            obj.transform.position = position;
            timer = 0;
        }
    }


    public GameObject[] IncreaseArray(GameObject[] values, int increment)
    {
        GameObject[] array = new GameObject[values.Length + increment];

        for(int i = 0; i < values.Length; i++)
        {
            array[i] = values[i];
        }

        return array;
    }
}
