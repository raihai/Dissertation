using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIcosphere : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Icosphere p = new Icosphere();
        p.InitAsIcosohedron();
        p.Subdivide(4);
    }
}
