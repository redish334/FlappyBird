using UnityEngine;
using UnityEngine.InputSystem;
public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStremgth;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * 10;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
