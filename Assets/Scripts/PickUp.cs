using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void Picked()
    {
        Destroy(this.gameObject);
    }
}
