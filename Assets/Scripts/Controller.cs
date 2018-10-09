﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


    public Vector3 StartingPosition;
    public Vector3 EndingPosition;

    public GameObject Clone;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
            StartingPosition = Input.mousePosition;
            CreateQuad ();
        }
        if (Input.GetMouseButton (0)) {
            RefreshEndingPosition ();
        }
        if (Input.GetMouseButtonUp (0)) {
            RefreshEndingPosition ();
        }
    }

    public void RefreshEndingPosition () {
        EndingPosition = Input.mousePosition;
        SetQuadTransform ();
    }

    public void CreateQuad () {
        Clone = GameObject.CreatePrimitive (PrimitiveType.Quad);
    }

    public void SetQuadTransform () {
        Vector3 sPos = StartingPosition / Screen.height;
        Vector3 ePos = EndingPosition / Screen.height;
        Vector3 dPos = ePos - sPos;
        Clone.transform.localScale = new Vector3 (Mathf.Abs (dPos.x), Mathf.Abs (dPos.y), 1);
        Clone.transform.localPosition = (sPos + ePos) / 2;
    }
}