using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollision
{
    public void OnCustomCollisionEnter(Shape shape) { }
    public void OnCustomCollisionStay(Shape shape) { }
    public void OnCustomCollisionExit(Shape shape) { }
    public void OnCustomTriggerEnter(Shape shape) { }
    public void OnCustomTriggerStay(Shape shape) { }
    public void OnCustomTriggerExit(Shape shape) { }
}
