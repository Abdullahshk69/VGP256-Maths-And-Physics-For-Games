using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTagAttacher : MonoBehaviour, ICollision
{
    public SO_Key keyTag;

    void ICollision.OnCustomCollisionEnter(Shape shape)
    {
        if(shape.gameObject.tag == "Player")
        {
            GameManager.Instance.ObtainKey(keyTag.keyTag);
            CollisionDetectionManager.instance.RemoveCollider(GetComponent<Shape>());
            Destroy(this.gameObject);
        }
    }
}
