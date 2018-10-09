using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    static int layerID;
    int layer;

	// Use this for initialization
	void Start () {
        layer = layerID++;
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void SetQuadTransform (Vector3 StartingPosition, Vector3 EndingPosition) {
        Vector3 sPos = StartingPosition / Screen.height;
        Vector3 ePos = EndingPosition / Screen.height;
        Vector3 dPos = ePos - sPos;
        transform.localScale = new Vector3 (Mathf.Abs (dPos.x), Mathf.Abs (dPos.y), 1);
        Vector3 lPos = (sPos + ePos) / 2;
        transform.localPosition = new Vector3 (lPos.x, lPos.y, -0.0001f * layer);
    }


}
