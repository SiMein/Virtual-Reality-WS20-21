﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarExerciseScript : MonoBehaviour
{
    GameObject sun;
    GameObject earth;
    GameObject moon;

    public float speedchange12 = 0;
    public float speedchange3 = 0;


    // Start is called before the first frame update
    void Start()
    {
        // YOUR CODE - BEGIN
        earth = GameObject.Find("Earth");
        moon = GameObject.Find("Moon");
        sun = GameObject.Find("Sun");
        // YOUR CODE - END
    }

    // Update is called once per frame
    void Update()
    {
        // Exercise 1.9
        // Check if unity world matrix is the same as your own GetWorldTransform.
        if (!CompareMatrix(moon))
        {
            Debug.Log("not the same - solve exercise 1.9");
        } else
        {
            Debug.Log("the same - solved exercise 1.9");
        }

        // Control Speed with Arrow Buttons 
        // Exercise 1.7
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            // YOUR CODE - BEGIN

            Debug.Log("UpArrowButton : ");
            speedchange12 += 10.0f;
            speedchange3 += 1.0f;

            // YOUR CODE - END
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            // YOUR CODE - BEGIN

            Debug.Log("DownArrowButton : ");
            speedchange12 -= 10.0f;
            speedchange3 -= 1.0f;

            // YOUR CODE - END
        }


        // Comment in for exercise 1.8
        RotateAroundParent(earth, 20.0f);
        RotateAroundParent(moon, 10.0f);
    }

    // Exercise 1.8
    void RotateAroundParent(GameObject go, float rotationVelocity)
    {
        // YOUR CODE - BEGIN
        go.transform.RotateAround(go.transform.parent.position, Vector3.up, rotationVelocity * Time.deltaTime);  //set rotation speed with no hardware dependencies
        // YOUR CODE - END
    }

    // Exercise 1.9
    Matrix4x4 GetWorldTransform(GameObject go)
    {
        Matrix4x4 mat = new Matrix4x4();
        // YOUR CODE - BEGIN
        Matrix4x4 localMat = Matrix4x4.TRS(go.transform.position, go.transform.rotation, go.transform.lossyScale);
        int counter = go.transform.hierarchyCount;
        for (int i=0; i < counter; i++)
        {
            mat = localMat * Matrix4x4.TRS(go.transform.parent.position, go.transform.parent.rotation, go.transform.parent.lossyScale);
            localMat = mat;
        }
        // YOUR CODE - END
        return mat;
    }

    bool CompareMatrix(GameObject go)
    {
        Matrix4x4 unityWorldMat = Matrix4x4.TRS(go.transform.position, go.transform.rotation, go.transform.lossyScale);
        Matrix4x4 ownWorldMat = GetWorldTransform(go);
        if (unityWorldMat == ownWorldMat)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}