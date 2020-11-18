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
    private TimersNTools cmp_timers;
    private Life cmp_life;

    public GameObject enemy_detect;

    public bool protecting;
    public GameObject shield;
    public bool usingSpear, usingSword;
    

    //-----Escoger Teclas------//
    public KeyCode key_up;
    public KeyCode key_down;
    public KeyCode key_der;
    public KeyCode key_izq;
    public KeyCode key_jump;
    public KeyCode key_ability;
    public KeyCode key_pickUp;
    //-------------------------//

    // Start is called before the first frame update
    void Start()
    {
        cmp_modelo_Ply = GetComponent<PlayerModelo>();
        cmp_grnd_Updater = GetComponent<GroundStatsUpdater>();
        cmp_mov = GetComponent<Movement>();
        cmp_rot = GetComponent<Rotatement>();
        cmp_atk = GetComponent<Attacks>();
        cmp_timers = GetComponent<TimersNTools>();
        cmp_life = GetComponent<Life>();
        cmp_life.life = cmp_modelo_Ply.playerLife;
        protecting = false;
        cmp_life.protec = protecting;
    }

    // Update is called once per frame
    void Update()
    {
        cmp_modelo_Ply.playerLife = cmp_life.life;
        protecting = cmp_life.protec;
        GroundUpdater();
        PlayerJump();
        PlayerWalk();
        Die();
        EscudoUptater();
        AtackBoolUpdater();
        WeaponUpdater();
        // Prueba energia del player
        if (Input.GetKeyDown(KeyCode.G))
        {
            DamageItself(1);
        }
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            Escudo();
        }*/
        
    }

    void GroundUpdater()
    {
        cmp_modelo_Ply.grounded = cmp_grnd_Updater.grounded;
        cmp_modelo_Ply.onHazzard = cmp_grnd_Updater.overHazard;
    }
    void AtackBoolUpdater()
    {
        cmp_modelo_Ply.atk_active = cmp_atk.atacking;
        if (cmp_modelo_Ply.atk_active == true)
        {
            cmp_modelo_Ply.walk_active = false;
        }
        else
        {
            cmp_modelo_Ply.walk_active = true;
        }
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(key_jump) && cmp_modelo_Ply.grounded == true && cmp_modelo_Ply.atk_active == false)
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

            cmp_rot.Rote_in_Y(200, angl_rot);
        }


    }

    void AtqGiratorio()
    {
        if(Input.GetKeyDown(key_ability) && cmp_modelo_Ply.grounded == true)
        {
            cmp_atk.atacking = true;
            cmp_atk.WaitCounterCaller(1, cmp_atk.sword_obj);
        }    
        if (cmp_modelo_Ply.atk_active==true)
        {
            cmp_atk.SwordAtk(2);
        }
    }

    void AtqLanza()
    {
        if (Input.GetKeyDown(key_ability) & cmp_modelo_Ply.grounded == true)
        {
            cmp_atk.atacking = true;
            cmp_mov.Move_in_transform(-10);
            cmp_atk.WaitCounterCaller(1, cmp_atk.spear_obj);
            /*if (enemy_detect != null)
            {
                //cmp_atk.SpearAtk(1, enemy_detect);
            }*/
        }

        if (cmp_modelo_Ply.atk_active == true)
        {
            cmp_atk.SpearAtk( 2);
        }
    }
    
    void WeaponUpdater()
    {
        if(cmp_modelo_Ply.using_weapon == true)
        {
            if (usingSword == true)
            {
                AtqGiratorio();       
                //Debug.Log("tengo una espada");
            }
            else if (usingSpear == true)
            {
                AtqLanza();
                //Debug.Log("tengo una lanza");
            }
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy_detect)
        {
            enemy_detect = null;
        }
    }*/

    void Escudo()
    {
        cmp_life.ProtectLife();
        protecting = true;
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

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Sword") && Input.GetKeyDown(key_pickUp))
        {
            cmp_modelo_Ply.using_weapon = true;
            if (cmp_modelo_Ply.weapon != other.gameObject && cmp_modelo_Ply.weapon != null)
            {
                cmp_modelo_Ply.weapon.SetActive(true);
                cmp_modelo_Ply.weapon.transform.position = new Vector3(transform.position.x + 3, transform.position.y,transform.position.z);
                cmp_modelo_Ply.weapon = other.gameObject;               
            }   
            usingSword = true;
            usingSpear = false;
            cmp_modelo_Ply.weapon = other.gameObject;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Spear") && Input.GetKeyDown(key_pickUp))
        {
            cmp_modelo_Ply.using_weapon = true;
            if (cmp_modelo_Ply.weapon != other.gameObject && cmp_modelo_Ply.weapon != null)
            {
                cmp_modelo_Ply.weapon.SetActive(true);
                cmp_modelo_Ply.weapon.transform.position = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);
                cmp_modelo_Ply.weapon = other.gameObject;
            }
            usingSpear = true;
            usingSword = false;
            cmp_modelo_Ply.weapon = other.gameObject;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Shield") && Input.GetKeyDown(key_pickUp))
        {
            Escudo();
            other.gameObject.SetActive(false);
        }
    }
}
