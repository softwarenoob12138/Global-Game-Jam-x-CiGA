using System.Collections;
using UnityEngine;

public class CreateBubbleInPool : MonoBehaviour
{
    public GameObject bubble;

    public GameObject bubbleSlow;

    public bool canCreateBubble;

    public float createSpeed;

    public Vector3 scaleFactor;

    public float BbounceForce;

    void Start()
    {
        canCreateBubble = true;
    }

    void Update()
    {
        if (canCreateBubble)
        {
            StartCoroutine(CreateBubble());
        }
    }

    public IEnumerator CreateBubble()
    {
        canCreateBubble = false;

        yield return new WaitForSeconds(createSpeed);

        //Instantiate(bubble, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
        if (FindAnyObjectByType<Switch>() != null)
        {
            if (!Switch.Instance.TurnOff)
            {
                GameObject instantiatedPrefab = Instantiate(bubble, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
                instantiatedPrefab.transform.localScale = scaleFactor;
                instantiatedPrefab.GetComponent<Bubble>().bounceForce = BbounceForce;
            }

            else if (Switch.Instance.TurnOff)
            {
                GameObject instantiatedPrefab = Instantiate(bubbleSlow, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
                instantiatedPrefab.transform.localScale = scaleFactor;
                instantiatedPrefab.GetComponent<Bubble>().bounceForce = BbounceForce;
            }

        }

        else
        {
            GameObject instantiatedPrefab = Instantiate(bubble, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
            instantiatedPrefab.transform.localScale = scaleFactor;
            instantiatedPrefab.GetComponent<Bubble>().bounceForce = BbounceForce;
        }

        canCreateBubble = true;

    }
}
