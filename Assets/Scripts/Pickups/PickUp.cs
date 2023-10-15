using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 10f;

    public virtual void Picked()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
    }
}
