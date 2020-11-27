using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class testscript : MonoBehaviour
{
    private float jumpHeight = 2.0f;
    private float spearDistance = 2f;
    private Vector3 playerVelocity;
    private float gravityValue = -10f;
    public bool groundedPlayer;
    public CharacterController plyChaController;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity, speed,spearTimer,mxTimer;
    public bool spAtk;
    // Update is called once per frame
    void Update()
    {
        groundedPlayer = plyChaController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if(spAtk == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                plyChaController.Move(direction * speed * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        if (Input.GetKeyDown(GameObject.Find("Player").GetComponent<PlayerController>().key_ability) && groundedPlayer && spAtk == false)
        {
            spAtk = true;
            playerVelocity = transform.forward * spearDistance;
        }
        if(spAtk == true)
        {
            spearTimer += Time.deltaTime;
            if(spearTimer >= mxTimer)
            {
                spAtk = false;
                spearTimer = 0;
            }
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        plyChaController.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(horizontal + " " + vertical);
    }
}
