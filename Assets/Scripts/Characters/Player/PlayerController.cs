using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModelo cmp_modelo_Ply;
    private GroundStatsUpdater cmp_grnd_Updater;
    private Movement cmp_mov;
    private Rotatement cmp_rot;

    //-----Escoger Teclas------//
    public KeyCode key_up;
    public KeyCode key_down;
    public KeyCode key_der;
    public KeyCode key_izq;
    public KeyCode key_jump;
    public KeyCode key_hability;
    //-------------------------//

    // Start is called before the first frame update
    void Start()
    {
        cmp_modelo_Ply = GetComponent<PlayerModelo>();
        cmp_grnd_Updater = GetComponent<GroundStatsUpdater>();
        cmp_mov = GetComponent<Movement>();
        cmp_rot = GetComponent<Rotatement>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundUpdater();
        PlayerJump();
        PlayerWalk();

        //cmp_rot.ForLoopRot(0, 1, 0, 1.5f, false);
    }
        
    void GroundUpdater()
    {
        cmp_modelo_Ply.grounded = cmp_grnd_Updater.grounded;
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(key_jump) && cmp_modelo_Ply.grounded==true)
        {
            
            cmp_mov.Jump(cmp_modelo_Ply.jmp_force);
        }
        
    }

    void PlayerWalk()
    {
        if (cmp_modelo_Ply.grounded == true)
        {
            if (Input.GetKey(key_der))
            {
                cmp_mov.Move_in_X(cmp_modelo_Ply.spd_mov, 1);
                cmp_rot.Rote_in_Y(cmp_modelo_Ply.spd_mov, 90);
            }
            if (Input.GetKey(key_izq))
            {
                cmp_mov.Move_in_X(cmp_modelo_Ply.spd_mov, -1);
                cmp_rot.Rote_in_Y(cmp_modelo_Ply.spd_mov, 270);
            }
            if (Input.GetKey(key_up))
            {
                cmp_mov.Move_in_Z(cmp_modelo_Ply.spd_mov, 1);
                cmp_rot.Rote_in_Y(cmp_modelo_Ply.spd_mov, 0);
            }
            if (Input.GetKey(key_down))
            {
                cmp_mov.Move_in_Z(cmp_modelo_Ply.spd_mov, -1);
                cmp_rot.Rote_in_Y(cmp_modelo_Ply.spd_mov, 180);
            }
        }


    }

    


}
