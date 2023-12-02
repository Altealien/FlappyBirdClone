using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidBody;
    public float flapStrength = 5;
    public LogicScript logic;
    public bool birdIsAlive = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y < -5.2 || transform.position.y > 5.2)
        {
            endGame();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       endGame();
    }

    void endGame()
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
