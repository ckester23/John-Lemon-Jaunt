using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Material light_cone;
    public GameObject john;
    public Transform garg;

    Rigidbody johnR;

    Color lerpedColor;

    float distance;
    float t;

    void Start()
    {
        //light_cone = GetComponentInChildren<SkinnedMeshRenderer>().material;
        johnR = john.GetComponent<Rigidbody>();
        light_cone.color = Color.green;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform joTran = johnR.transform;

        distance = Vector3.Distance(joTran.position, garg.position);

        Debug.Log("john's x = " + joTran.position.x);
        Debug.Log("Distance = " + distance);
        ChangeFlashColor(distance);

    }

    void ChangeFlashColor(float dist)
    {
        // If John is less than 3 but more than 2 away, yellow
        // If John is less than or equal to 2 away, red
        // If John is over 3 away, green

        if (dist >= 3.5f)
        {
            light_cone.color = Color.green;
        }
        else if (dist > 2.5f)
        {
            t = dist - 2.5f;
            DoLerping(Color.yellow, Color.green, t);
            light_cone.color = lerpedColor;
        }
        else
        {
            t = dist - 1.5f;
            DoLerping(Color.red, Color.yellow, t);
            light_cone.color = lerpedColor;
        }
    }

    void DoLerping(Color color1, Color color2, float t_val)
    {
        lerpedColor = Color.Lerp(color1, color2, t_val);
    }
}
