using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float speedbuff = 30.0f;

    public float duration = 5.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {
        //apply buff
        PlayerController speed = player.GetComponent<PlayerController>();
        
        speed.speed = speedbuff;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        speed.speed = 20.0f;


        //remove object
        Destroy(gameObject);
    }
}
