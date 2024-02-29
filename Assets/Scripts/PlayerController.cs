using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPhysicalObject
{
    [SerializeField] float speed = 1.1f;
    [SerializeField] float maxStamina = 100f;
    [SerializeField] float currentStamina = 100f;
    [SerializeField] float decreaseRate = 0.1f;
    [SerializeField] float regenarate = 0.1f;
    [SerializeField] float staminaDelay = 2f;
    [SerializeField] float boost = 2;
    [SerializeField] float powerJump = 200f;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] float length = 1f;
    bool isInvoke = false;
    bool regenerateStamina = false;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && currentStamina > 0) 
        {
            regenerateStamina = false;
            transform.position += transform.forward * speed * 2 * Time.deltaTime;
            currentStamina -= decreaseRate * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, length))
            {
                rigidbody.AddForce(transform.up * powerJump * 10);
            }
        }
        if (!isInvoke && currentStamina != maxStamina && !regenerateStamina)
        {
            isInvoke = true;
            Invoke("RegenerateStaminaTrue", staminaDelay);
        }
        if (regenerateStamina)
        {
            currentStamina += regenarate * Time.deltaTime;
            if(currentStamina >= 100)
            {
                regenerateStamina = false;
                currentStamina = 100;
            }
        }
    }
    private void RegenerateStaminaTrue()
    {
        isInvoke = false;
        regenerateStamina = true;
    }
    public void AddImpulse(Vector3 direction, float force, Vector3 hit_point)
    {
        rigidbody.AddForceAtPosition(direction * force, hit_point);
    }
}
