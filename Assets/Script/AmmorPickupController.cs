using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmorPickupController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInChildren<FireBullet>().reload();
            AudioManager.instance.PlayeSoundAssaulReload();
            Destroy(transform.root.gameObject);
        }
    }
}
