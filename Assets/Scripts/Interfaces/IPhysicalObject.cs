using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPhysicalObject
{ 
    public void AddImpulse(Vector3 direction, float force, Vector3 hit_point);
}

