using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaser : MonoBehaviour
{
public float timepoEnDestruir;

    private void Update()
    {
        Destroy(gameObject, timepoEnDestruir);
    }
}
