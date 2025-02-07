using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCold : MonoBehaviour
{

    public GameObject ColdWind, Mouse1;

    private void Start()
    {
        ColdWind.SetActive(false);
        Mouse1.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Gun.instance.getCold = true;

            ColdWind.SetActive(true);

            Mouse1.SetActive(true);

            Destroy(gameObject);
        }
    }
}
