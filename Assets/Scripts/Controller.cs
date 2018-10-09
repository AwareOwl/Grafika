using System.Collections;
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
        Clone.GetComponent <UIController>().SetQuadTransform (StartingPosition, EndingPosition);
    }

    public void CreateQuad () {
        float minF = 0.7f;
        Clone = GameObject.CreatePrimitive (PrimitiveType.Quad);
        Clone.GetComponent<Renderer> ().material.color = new Color (Random.Range (minF, 1), Random.Range (minF, 1), Random.Range (minF, 1));
        Clone.AddComponent<UIController> ();
    }
}
