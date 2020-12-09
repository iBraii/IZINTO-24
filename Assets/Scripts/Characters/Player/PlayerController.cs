using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerModelo cmp_modelo_Ply;
    private PlayerView cmp_plyView;
    private GroundStatsUpdater cmp_grnd_Updater;
    private Movement cmp_mov;
    private Rotatement cmp_rot;
    private Attacks cmp_atk;
    private TimersNTools cmp_timers;
    private Life cmp_life;
    private testscript cmp_test;

    public bool inmune, dying;
    public GameObject enemy_detect;
    public float timer, inmuneTimer;
    public bool protecting;
    public GameObject shield;
    public bool usingSpear, usingSword;
    public CharacterController plyChaController;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Animator Anim;
    public float dieAnimTimer;
    public float recoverLifeTimer;
    public bool recoverLife;

    public Vector3 rotatioProves;
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
        inmuneTimer = 0;
        cmp_test = GetComponent<testscript>();
        cmp_modelo_Ply = GetComponent<PlayerModelo>();
        cmp_plyView = GetComponent<PlayerView>();
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
    private void FixedUpdate()
    {
        if(dying == false)
        {
            PlayerWalk();
        }    
    }
    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(key_der) || Input.GetKey(key_izq) || Input.GetKey(key_down) || Input.GetKey(key_up))
        {
            Anim.SetBool("Walking", true);
        }
        else
        {
            Anim.SetBool("Walking", false);
        }*/
        if(cmp_atk.atacking && usingSword == true)
        {
            Anim.SetBool("SwordAtk", true);
        }
        else
        {
            Anim.SetBool("SwordAtk", false);
        }

        if (cmp_atk.atacking && usingSpear == true)
        {
            Anim.SetBool("SpearAtk", true);
        }
        else
        {
            Anim.SetBool("SpearAtk", false);
        }


        cmp_modelo_Ply.playerLife = cmp_life.life;
        protecting = cmp_life.protec;
        GroundUpdater();
        PlayerJump();
        
        if(recoverLife == true)
        {
            RecoverLife();
        }
        else
        {
            recoverLifeTimer += Time.deltaTime;
            if (recoverLifeTimer >= 15)
            {
                recoverLife = true;
            }
        }
        Die();
        EscudoUptater();
        AtackBoolUpdater();
        WeaponUpdater();
        if(cmp_plyView.damageIndicator.activeInHierarchy == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f)
            {
                timer = 0;
                cmp_plyView.damageIndicator.SetActive(false);   
            }
        }
        // Prueba energia del player
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GameObject.Find("Player").GetComponent<PlayerController>().inmune == false)
            {
                DamageItself(1);
            }
        }
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            Escudo();
        }*/
        if(inmune == true)
        {
            float mxtimer = 1.5f;
            inmuneTimer += Time.deltaTime;
            if(inmuneTimer >= mxtimer)
            {
                inmune = false;
                inmuneTimer = 0;
            }
        }
    }

    void GroundUpdater()
    {
        cmp_modelo_Ply.grounded = cmp_grnd_Updater.grounded;
        cmp_modelo_Ply.onHazzard = cmp_grnd_Updater.overHazard;
        if(cmp_modelo_Ply.grounded == false)
        {
            Anim.SetBool("Jump", true);
        }
        else
        {
            Anim.SetBool("Jump", false);
        }
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
            cmp_mov.Jump(600);
            cmp_mov.Move_in_transform(-6);
        }

    }

    void PlayerWalk()
    {
        if (cmp_modelo_Ply.grounded == true & cmp_modelo_Ply.walk_active == true)
        {
            
            float angl_rot = gameObject.transform.eulerAngles.y % 360;
            float hor = 0;
            float ver = 0;
            if (Input.GetKey(key_der))
            {

                /*if (hor < -1)
                {
                    hor -= Time.deltaTime * 0.1f;
                }
                else if (hor > -1)
                {*/
                    hor = -1;
                //}
                cmp_mov.Move_in_X(cmp_modelo_Ply.spd_mov, 1);
                angl_rot = 90;
            }
            else if (Input.GetKey(key_izq))
            {

                /*if (hor < 1)
                {
                    hor += Time.deltaTime * 0.1f;
                }
                else if (hor > 1)
                {*/
                    hor = 1;
                //}
                cmp_mov.Move_in_X(cmp_modelo_Ply.spd_mov, -1);
                angl_rot = 270;
            }
            else
            {
                hor = 0;
            }

            if (Input.GetKey(key_up))
            {

                /*if (ver < -1)
                {
                    ver -= Time.deltaTime * 0.1f;
                }
                else if (ver > -1)
                {*/
                    ver = -1;
                //}
                cmp_mov.Move_in_Z(cmp_modelo_Ply.spd_mov, 1);
                angl_rot = 0;
            }
            else if (Input.GetKey(key_down))
            {

                /*if (ver < 1)
                {
                    ver += Time.deltaTime * 0.1f;
                }
                else if (ver > 1)
                {*/
                    ver = 1;
                //}
                cmp_mov.Move_in_Z(cmp_modelo_Ply.spd_mov, -1);
                angl_rot = 180;
            }
            else
            {
                ver = 0;
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
            rotatioProves = new Vector3(hor, 0f, ver);
            //cmp_rot.Rote_in_Y(100, angl_rot);
            cmp_rot.Rote_Y_Two(/*new Vector3(hor, 0f, ver)*/rotatioProves.normalized,1.0f/*, 1.0f*/);
            if(hor != 0 || ver != 0)
            {
                Anim.SetBool("Walking", true);
            }
            else
            {
                Anim.SetBool("Walking", false);
            }
        }
        
        /*float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f,vertical).normalized;
        if(direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            plyChaController.Move(direction * cmp_modelo_Ply.spd_mov * Time.deltaTime);
        }*/

    }

    void AtqGiratorio()
    {
        if(Input.GetKeyDown(key_ability) && cmp_modelo_Ply.grounded == true)
        {
            cmp_atk.atacking = true;
            cmp_atk.WaitCounterCaller(1.04f, cmp_atk.sword_obj);
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
            cmp_atk.SpearAtk(2);
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
        recoverLife = false;
        recoverLifeTimer = 0;
        inmune = true;
        cmp_plyView.damageIndicator.SetActive(true);
    }
    void RecoverLife()
    { 
        cmp_life.GainLife(1);
        recoverLifeTimer = 0;
        recoverLife = false;  
    }

    void Die()
    {
        if (cmp_modelo_Ply.playerLife <= 0)
        {
            Anim.SetBool("Die", true);
            dieAnimTimer += Time.deltaTime;
            dying = true;

            if(dieAnimTimer >= 3)
            {
                dying = false;
                SceneManager.LoadScene("Derrota");
                dieAnimTimer = 0;
            }
            //gameObject.SetActive(false);
            //El problema de que el player se desactive o se destruya, es que el script no llama a la barra de vida para que baje
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
                cmp_modelo_Ply.weapon.transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z);
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
                cmp_modelo_Ply.weapon.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                cmp_modelo_Ply.weapon = other.gameObject;
            }
            usingSpear = true;
            usingSword = false;
            cmp_modelo_Ply.weapon = other.gameObject;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Shield") && Input.GetKeyDown(key_pickUp) && protecting == false)
        {
            Escudo();
            other.gameObject.SetActive(false);
        }
    }
    
}
