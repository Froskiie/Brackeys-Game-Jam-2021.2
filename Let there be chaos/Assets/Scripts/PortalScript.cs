using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    Transform shape1;
    Transform shape2;
    Transform shape3;

    void Start()
    {
        shape1 = GetComponentsInChildren<Transform>()[1];
        shape2 = GetComponentsInChildren<Transform>()[2];
        shape3 = GetComponentsInChildren<Transform>()[3];
    }

    // Update is called once per frame
    void Update()
    {
        shape1.rotation *= Quaternion.Euler(new Vector3(0, 0, 2f)); // Les quaternions peuvent �tre r�sum�s comme �tant des Vector4. Ils sont utilis�s dans pour les rotations.
        shape2.rotation *= Quaternion.Euler(new Vector3(0, 0, -2f)); // Les quaternions peuvent �tre r�sum�s comme �tant des Vector4. Ils sont utilis�s dans pour les rotations.
        shape3.rotation *= Quaternion.Euler(new Vector3(0, 0, 0.5f)); // Les quaternions peuvent �tre r�sum�s comme �tant des Vector4. Ils sont utilis�s dans pour les rotations.
    }
}
