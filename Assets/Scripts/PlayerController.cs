using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum PlayerState
    {
        idle,
        move
    }

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float speedChangTime = 0.8f;
    float timer;

    Vector2 playerInput;

    Rigidbody2D rb;
    PlayerState playerState;

    Coroutine smoothSpeedChangeCoroutine;

    #region Unity
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = PlayerState.idle;
    }

    void Update()
    {
        CheckInput();
        SwitchState();
    }
    #endregion

    void CheckInput()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
    }

    void SwitchState()
    {
        switch (playerState)
        {
            case PlayerState.idle:
                if (playerInput != Vector2.zero)
                {
                    playerState = PlayerState.move;
                    SmoothChangeSpeed(moveSpeed * playerInput.normalized);
                }
                break;
            case PlayerState.move:
                if (HaveInput())
                {
                    SmoothChangeSpeed(moveSpeed * playerInput.normalized);
                }
                else if (playerInput == Vector2.zero)
                {
                    playerState = PlayerState.idle;
                    SmoothChangeSpeed(Vector3.zero);
                }
                break;
        }
    }

    bool HaveInput() => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D);

    void SmoothChangeSpeed(Vector3 targetVelocity)
    {
        if (smoothSpeedChangeCoroutine != null)
        {
            StopCoroutine(smoothSpeedChangeCoroutine);
        }
        smoothSpeedChangeCoroutine = StartCoroutine(SmoothSpeedChangeCoroutine(targetVelocity));
    }
    IEnumerator SmoothSpeedChangeCoroutine(Vector3 targetVelocity)
    {
        timer = 0;
        Vector3 currentVelocity = rb.velocity;

        while (timer < speedChangTime)
        {
            timer += Time.deltaTime;
            rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, timer / speedChangTime);

            yield return null;
        }
    }
}
