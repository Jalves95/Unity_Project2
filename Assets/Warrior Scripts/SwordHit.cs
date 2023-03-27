using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Skeleton 1")
        {
            Destroy(other.gameObject);
        }

        else if (other.name == "Skeleton 2")
        {
            Destroy(other.gameObject);
        }

        else if (other.name == "Skeleton 3")
        {
            Destroy(other.gameObject);
        }

        else if (other.name == "Skeleton 4")
        {
            Destroy(other.gameObject);
        }
    }
}
