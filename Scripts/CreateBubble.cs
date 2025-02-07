using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBubble : MonoBehaviour
{
    public GameObject bubble;

    public float BbounceForce;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" && PlayerController.instance.rb.velocity.y == 0)
        {
            GameObject Bubble = Instantiate(bubble, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
            Bubble.GetComponent<Bubble>().bounceForce = BbounceForce;
        }
    }
}
