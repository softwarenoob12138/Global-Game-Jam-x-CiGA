using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHot : MonoBehaviour
{

    public GameObject HotWind;

    private void Start()
    {
        HotWind.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Gun.instance.getHot = true;

            HotWind.SetActive(true);

            Destroy(gameObject);
        }
    }
}
