using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INoiseFilters 
{
    float Evaluate(Vector3 point);    
}
