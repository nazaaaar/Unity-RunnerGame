using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerMoveEvents
{
    event Action<float, float> OnPositionChanged;
    event Action<bool> OnRunChanged;
    event EventHandler OnPlayerDied;
}
public class PlayerMovement : MonoBehaviour, PlayerMoveEvents
{

    private readonly float speed = 3.5f;
    private readonly float runBoost = 2f;
    private bool isRunning = false;
    private readonly float mouseSensitivity = 4f;
    private bool isJumping = false;
    private float jumpHeight = 1000;

    private Rigidbody rb;

    public event Action<float, float> OnPositionChanged;
    public event Action<bool> OnRunChanged;
    public event EventHandler OnPlayerDied;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(CheckFall());
    }

    private bool isWasRunning = false;
    void Update()
    {
        #region mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        #endregion

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = speed * Time.deltaTime * new Vector3(horizontal, 0, vertical).normalized;

        
        if ((isRunning = Input.GetKey(KeyCode.LeftControl)))
        {
            direction *= runBoost;
        }
        if (isWasRunning != isRunning)
        {
            OnRunChanged(isRunning);
            isWasRunning = isRunning;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) 
        {
            isJumping = true;
            rb.AddForce(0, jumpHeight, 0);
        }

        OnPositionChanged?.Invoke(horizontal, vertical);

        transform.Translate(direction);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground" && isJumping == false)
        {
            isJumping = true;
        }
    }

    private IEnumerator CheckFall()
    {
        for (;;)
        {
            if (transform.position.y < -5)
            {
                OnPlayerDied?.Invoke(this,EventArgs.Empty);
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
