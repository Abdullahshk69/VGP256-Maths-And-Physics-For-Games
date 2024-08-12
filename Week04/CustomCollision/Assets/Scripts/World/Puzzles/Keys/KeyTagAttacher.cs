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
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
            CollisionDetectionManager.instance.RemoveCollider(GetComponent<Shape>());
        
    }
}
