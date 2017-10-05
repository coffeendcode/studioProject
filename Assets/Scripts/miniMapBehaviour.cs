using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMapBehaviour : MonoBehaviour {

    public Transform Target;

    void LateUpdate()
    {
        if (Target)
            transform.position = new Vector3(Target.position.x, Target.position.y, -10);
    }
}
