using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Material light_cone;
    public Transform garg;

    GameObject john;
    Transform johnT;

    Color lerpedColor;

    float distance;
    float t;

    void Start()
    {
        //light_cone = GetComponentInChildren<SkinnedMeshRenderer>().material;
        
        light_cone.EnableKeyword("_EMISSION");
        bool my_bool = light_cone.IsKeywordEnabled("_EMISSION");

        //light_cone.SetColor("_EmissionColor", Color.green);
        Debug.Log(my_bool);
        Debug.Log("START");
        john = GameObject.Find("JohnLemon");

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        johnT = john.transform;

        distance = Vector3.Distance(johnT.position, garg.position);

        //Debug.Log("john's x = " + johnT.position.x);
        //Debug.Log("Distance = " + distance);

        ChangeFlashColor(distance);

    }

    void ChangeFlashColor(float dist)
    {
        Debug.Log("CHANGE");
        /* dist = 5, we want total green
         *  1 - ((5-5) / 2.5) = 1 - (0/2.5) = 1 - 0 = 1
         *  
         * dist = 2.5, we want total red
         *  1 - ((5-2) / 2.5) = 1 - (3/2.5) = 1 - 1 = 0
         */

        t = 1f - ((5f - dist) / 2.5f); 

        if (t < 0) { t = 0; }
        else if ( t > 1) { t = 1; }

        Debug.Log("t = " + t);
        DoLerping(Color.red, Color.green, t);
        light_cone.SetColor("_EmissionColor", lerpedColor);
        
        
    }

    void DoLerping(Color color1, Color color2, float t_val)
    {
        lerpedColor = Color.Lerp(color1, color2, t_val);
    }
}
