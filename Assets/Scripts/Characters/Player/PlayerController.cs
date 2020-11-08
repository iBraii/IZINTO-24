using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModelo cmp_modelo_Ply;
    private GroundStatsUpdater cmp_grnd_Updater;
    private Movement cmp_mov;
    private Rotatement cmp_rot;
    private Attacks cmp_atk;
    private Timers cmp_timers;

    public GameObject enemy_detect;
    public bool Lanza_act;


    //-----Escoger Teclas------//
    public KeyCode key_up;
    public KeyCode key_down;
    public KeyCode key_der;
    public KeyCode key_izq;
    public KeyCode key_jump;
    public KeyCode key_ability;
    //-------------------------//

    // Start is called before the first frame update
    void Start()
    {
        cmp_modelo_Ply = GetComponent<PlayerModelo>();
        cmp_grnd_Updater = GetComponent<GroundStatsUpdater>();
        cmp_mov = GetComponent<Movement>();
        cmp_rot = GetComponent<Rotatement>();
        cmp_atk = GetComponent<Attacks>();
        cmp_timers = GetComponent<Timers>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundUpdater();
        PlayerJump();
        PlayerWalk();
        AtqGiratorio();
        AtqLanza();
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

    void AtqGiratorio()
    {
        /*if(Input.GetKey(key_ability))
        {
            cmp_atk.SwordAtk();
            cmp_rot.ForLoopRot(0, -1, 0, 20, true);
        }    */
    }

    void AtqLanza()
    {
        if (Input.GetKeyDown(key_ability))
        {
            cmp_mov.Move_in_transform(10);
            if (enemy_detect != null)
            {
                cmp_atk.SpearAtk(1, enemy_detect);
            }
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemy_detect = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy_detect)
        {
            enemy_detect = null;
        }
    }
}
