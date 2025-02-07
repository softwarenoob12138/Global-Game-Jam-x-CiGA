using UnityEngine;

public class Switch : MonoBehaviour
{
    public static Switch Instance;

    public GameObject switch1, switch2;

    public GameObject pushE;

    public bool TurnOff;

    public GameObject wind;

    public Animator anim;

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        switch2.SetActive(false);
        pushE.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!TurnOff)
            {
                pushE.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    Fans.instance.cd.enabled = false;
                    TurnOff = true;
                    switch1.SetActive(false);
                    switch2.SetActive(true);
                    pushE.SetActive(false);

                    wind.SetActive(false);

                    anim.SetBool("Stop", true);

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (pushE.activeSelf)
            {
                pushE.SetActive(false);

            }
        }
    }
}
