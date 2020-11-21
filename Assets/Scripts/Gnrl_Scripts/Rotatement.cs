using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Need to be placed into an update
    public void ForLoopRot(float rot_X, float rot_Y, float rot_Z, float loop_spd, bool typeRot_world)
    {
        if (typeRot_world == true)
        {
            transform.Rotate(new Vector3(rot_X, rot_Y, rot_Z) * loop_spd, Space.World);
        }
        else
        {
            transform.Rotate(new Vector3(rot_X, rot_Y, rot_Z) * loop_spd, Space.Self);
        }
    }

    // All stayNFreeze need to be placed into an update
    public void ForStayNFreeze_Rot_X(float stayNum_Axis)
    {
        //En reparación . . . [Proximamente]
    }


    public void Rote_in_X(float spd_mov, int dir_mov)
    {
        //En reparación . . . [Proximamente]

        //rb.velocity = new Vector3(spd_mov * dir_mov * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        //transform.Rotate(new Vector3(dir_mov,0,0) * Time.deltaTime * spd_mov, Space.World);
    }

    public void Rote_in_Y(float spd_mov, float angle)
    {
        float may_angle;
        float men_angle;
        int rot_dir;
        angle = angle % 360;

        if (gameObject.transform.eulerAngles.y % 360 >= angle)
        {
            may_angle = gameObject.transform.eulerAngles.y % 360;
            men_angle = angle;

            if (may_angle - men_angle >= 180)
            {
                rot_dir = -1;
            }
            else
            {
                rot_dir = 1;
            }

        }
        else
        {
            men_angle = gameObject.transform.eulerAngles.y;
            may_angle = angle;

            if (may_angle - men_angle >= 180)
            {
                rot_dir = 1;
            }
            else
            {
                rot_dir = -1;
            }
        }

        if (gameObject.transform.eulerAngles.y % 360 != angle)
        {
            transform.Rotate(new Vector3(0, (Time.deltaTime * spd_mov * rot_dir), 0));

        }

    }

    public void Rote_in_Z(float spd_mov, int dir_mov)
    {
        //En reparación . . . [Proximamente]
        //transform.Rotate(new Vector3(0, 0, dir_mov) * Time.deltaTime * spd_mov, Space.World);
    }

    public void InstantRotation(float x, float y, float z, Space rot_spc)
    {
        gameObject.transform.Rotate(x, y, z, rot_spc);
    }
    public void LookSmt(Vector3 targetPos, float angle)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos - transform.position), angle/* * Time.deltaTime*/);
    }
        
    public void Rote_in_Y_inverse(float spd_mov, float angle)
    {
        float may_angle;
        float men_angle;
        int rot_dir;
        angle = angle % 360;

        if (gameObject.transform.eulerAngles.y % 360 >= angle)
        {
            may_angle = gameObject.transform.eulerAngles.y % 360;
            men_angle = angle;

            if (may_angle - men_angle >= 180)
            {
                rot_dir = 1;
            }
            else
            {
                rot_dir = -1;
            }

        }
        else
        {
            men_angle = gameObject.transform.eulerAngles.y;
            may_angle = angle;

            if (may_angle - men_angle >= 180)
            {
                rot_dir = -1;
            }
            else
            {
                rot_dir = 1;
            }
        }

        if (gameObject.transform.eulerAngles.y % 360 != angle)
        {
            transform.Rotate(new Vector3(0, (Time.deltaTime * spd_mov * rot_dir), 0));

        }

    }
}
