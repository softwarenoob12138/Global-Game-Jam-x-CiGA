using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGun : MonoBehaviour
{
    public GameObject Mouse0, normalWind, jiantou;

    private void Start()
    {
        Mouse0.SetActive(false);
        normalWind.SetActive(false);
        jiantou.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Gun.instance.getGun = true;

            PlayerController.instance.gun.SetActive(true);

            Mouse0.SetActive(true);
            normalWind.SetActive(true);
            jiantou.SetActive(true);

            Destroy(gameObject);

        }
    }
}
