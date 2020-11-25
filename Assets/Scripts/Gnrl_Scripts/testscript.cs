using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    private float jumpHeight = 1.0f;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    public bool groundedPlayer;
    public CharacterController plyChaController;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity, speed;
    // Update is called once per frame
    void Update()
    {
        groundedPlayer = plyChaController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            Debug.Log("owow");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        plyChaController.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(horizontal + " " + vertical);
    }
}
