using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeColor : MonoBehaviour
{
    public Light myPointLight;
    [SerializeField]
    float eulerAngX;
    [SerializeField]
    float eulerAngY;
    [SerializeField]
    float eulerAngZ;
    
    enum OrientationState
    {
        None,
        TurnedUp,
        TurnedDown
    }

    OrientationState orientationState = OrientationState.None;


    void Update(){

        var x = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x;
        var y = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;
        var z = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).z;
        if(x < -160 | x > 160){
            orientationState = OrientationState.TurnedDown;
        }
        if((x > 0 & x < 20) | (x < 0 & x > -20)){
            if(orientationState == OrientationState.TurnedDown){
                orientationState = OrientationState.TurnedUp;

                if (myPointLight.color == Color.red){
                    myPointLight.color = Color.blue;
                } else {
                    myPointLight.color = Color.red;
                }
            }
        }
    }
}
