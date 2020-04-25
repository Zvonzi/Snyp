using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D playerRB;
    [SerializeField] float playerSpeed = 2f;
    Vector2 movement;
    public Animator animator;
    public static PlayerController instance; // kreiranje instance igrača kako bi toj instanci mogli pristupiti drugi gameobjecti/skripte
    public string areaTransitionName;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    void Awake()
    {
        // make sure there are no multiple instances of player in game
        if (instance == null)
        {
            instance = this;
        } 
        else 
        { 
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        PlayerMovement();

        // keeping the player inside the map
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
        Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
        transform.position.z);
    }

    private void PlayerMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        playerRB.MovePosition(playerRB.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(0.5f, 0.8f, 0f);
        topRightLimit = topRight + new Vector3(-.5f, -0.85f, 0f);
    }
}
