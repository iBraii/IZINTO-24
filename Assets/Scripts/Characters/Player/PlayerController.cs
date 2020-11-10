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
    private Life cmp_life;

    public GameObject enemy_detect;

    public bool protecting;
    public GameObject shield;

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
        cmp_life = GetComponent<Life>();
        cmp_life.life = cmp_modelo_Ply.playerLife;
        protecting = false;
        cmp_life.protec = protecting;
    }

    // Update is called once per frame
    void Update()
    {
        cmp_modelo_Ply.playerLife = cmp_life.life;
        GroundUpdater();
        PlayerJump();
        PlayerWalk();
        AtqGiratorio();
        AtqLanza();
        Die();
        EscudoUptater();

        // Prueba energia del player
        if(Input.GetKeyDown(KeyCode.G))
        {
            DamageItself(1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Escudo();
        }
    }

    void GroundUpdater()
    {
        cmp_modelo_Ply.grounded = cmp_grnd_Updater.grounded;
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(key_jump) && cmp_modelo_Ply.grounded == true)
        {

            cmp_mov.Jump(cmp_modelo_Ply.jmp_force);
        }

        if (cmp_grnd_Updater.overEnemy == true)
        {
            cmp_mov.Jump(50);
            cmp_mov.Move_in_transform(-3);
        }

    }

    void PlayerWalk()
    {
        if (cmp_modelo_Ply.grounded == true & cmp_modelo_Ply.walk_active == true)
        {
            float angl_rot = gameObject.transform.eulerAngles.y % 360;

            if (Input.GetKey(key_der))
            {
                cmp_mov.Move_in_X(cmp_modelo_Ply.spd_mov, 1);
                angl_rot = 90;
            }
            if (Input.GetKey(key_izq))
            {
                cmp_mov.Move_in_X(cmp_modelo_Ply.spd_mov, -1);
                angl_rot = 270;
            }
            if (Input.GetKey(key_up))
            {
                cmp_mov.Move_in_Z(cmp_modelo_Ply.spd_mov, 1);
                angl_rot = 0;
            }
            if (Input.GetKey(key_down))
            {
                cmp_mov.Move_in_Z(cmp_modelo_Ply.spd_mov, -1);
                angl_rot = 180;
            }
            //------------------------------------------------//
            if (Input.GetKey(key_der) & Input.GetKey(key_up))
            {
                angl_rot = 45;
            }
            else if (Input.GetKey(key_der) & Input.GetKey(key_down))
            {
                angl_rot = 135;
            }
            if (Input.GetKey(key_izq) & Input.GetKey(key_up))
            {
                angl_rot = 315;
            }
            else if (Input.GetKey(key_izq) & Input.GetKey(key_down))
            {
                angl_rot = 225;
            }

            cmp_rot.Rote_in_Y(cmp_modelo_Ply.spd_mov, angl_rot);
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
        if (Input.GetKeyDown(key_ability) & cmp_modelo_Ply.grounded == true)
        {
            cmp_modelo_Ply.walk_active = false;
            cmp_modelo_Ply.atk_active = true;

            cmp_mov.Move_in_transform(-10);
            if (enemy_detect != null)
            {
                cmp_atk.SpearAtk(1, enemy_detect);
            }
        }

        if (cmp_modelo_Ply.atk_active == true)
        {
            cmp_modelo_Ply.atk_active = cmp_timers.Timer_for_bools(true, 50);
            cmp_modelo_Ply.walk_active = cmp_timers.Timer_for_bools(false, 50);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
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

    void Escudo()
    {
        cmp_life.ProtectLife();

    }
    void EscudoUptater()
    {
        if (protecting == false)
        {
            shield.gameObject.SetActive(false);
        }

        else
        {
            shield.gameObject.SetActive(true);
        }
    }

    public void DamageItself(int dmg)
    {
        cmp_life.LoseLife(dmg);
    }

    void Die()
    {
        if(cmp_modelo_Ply.playerLife <= 0)
        {
            Debug.Log("Moriste");
            gameObject.SetActive(false);
        }
    }
}
