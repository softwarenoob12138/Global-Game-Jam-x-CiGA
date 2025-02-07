using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                PlayerController.instance.rb.velocity = new Vector2(PlayerController.instance.rb.velocity.x, 3);
            }
        }
    }
}
