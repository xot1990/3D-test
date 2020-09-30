using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : ScriptableObject
{
    public List<Transform> visiblePoints;
    public float CurrentEyes;
    public float visibleAngle;
    public float visibleDistance;
    public LayerMask visibleMask;
}
