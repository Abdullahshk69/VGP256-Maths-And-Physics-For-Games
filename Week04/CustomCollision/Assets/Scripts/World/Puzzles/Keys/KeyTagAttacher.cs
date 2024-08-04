using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTagAttacher : MonoBehaviour, ICollision
{
    public SO_Key keyTag;

    void ICollision.OnCustomCollisionEnter(Shape shape)
    {
        Debug.Log("Collision Detected");
        if(shape.gameObject.tag == "Player")
        {
            Debug.Log("Collision With player");
            GameManager.Instance.ObtainKey(keyTag.keyTag);
            CollisionDetectionManager.instance.RemoveCollider(GetComponent<Shape>());
            Destroy(this.gameObject);
        }
    }
}
