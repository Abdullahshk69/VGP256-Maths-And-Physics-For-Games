using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTagAttacher : MonoBehaviour, ICollision
{
    public SO_DoorTag doorTag;

    void ICollision.OnCustomCollisionEnter(Shape shape)
    {
        //Debug.Log("Collision Detected");
        if (shape.gameObject.tag == "Player")
        {
            // Door can be opened
            if((DoorManager.instance.GetDoorKey(doorTag.doorTag) & GameManager.Instance.KeyInventory) != 0)
            {
                GameManager.Instance.KeyInventory &= ~DoorManager.instance.GetDoorKey(doorTag.doorTag);
                CollisionDetectionManager.instance.RemoveCollider(GetComponent<Shape>());
                Destroy(this.gameObject);
            }
        }
    }
}
