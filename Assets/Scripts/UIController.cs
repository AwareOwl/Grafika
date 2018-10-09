using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    bool moveable;

    public Vector3 StartingPosition;
    public Vector3 EndingPosition;

    static int layerID;
    int layer;

    int type = 0;
    const int Line = 1;
    bool Pressed = true;

    private void OnMouseUp () {
    }

    private void OnMouseDrag () {
        if (Controller.MoveMode) {
            transform.Translate (Vector3.right * 0.01f * Time.deltaTime);
        }
    }

    public UIController () {

    }

    public UIController (int type) {
        this.type = type;
    }

    // Use this for initialization
    void Start () {
        layer = layerID++;
        StartingPosition = Input.mousePosition;
        UpdateIt ();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp (0)) {
            if (Pressed) {
                Pressed = false;
            }
        }
        UpdateIt ();
    }

    public void UpdateIt () {
        if (Pressed) {
            EndingPosition = Input.mousePosition;
            if (type == Line) {
                SetLineTransform ();
            } else {
                SetQuadTransform ();
            }
        }
    }


    public void SetQuadTransform () {
        Vector3 sPos = StartingPosition / Screen.height;
        Vector3 ePos = EndingPosition / Screen.height;
        Vector3 dPos = ePos - sPos;
        transform.localScale = new Vector3 (Mathf.Abs (dPos.x), Mathf.Abs (dPos.y), 1);
        Vector3 lPos = (sPos + ePos) / 2;
        transform.localPosition = new Vector3 (lPos.x, lPos.y, -0.0001f * layer);
    }

    public void SetLineTransform () {
        Vector3 sPos = StartingPosition / Screen.height;
        Vector3 ePos = EndingPosition / Screen.height;
        Vector3 dPos = ePos - sPos;
        float len = Vector3.Magnitude (dPos);
        transform.localScale = new Vector3 (len, 0.005f, 1);
        Vector3 lPos = (sPos + ePos) / 2;
        transform.localPosition = new Vector3 (lPos.x, lPos.y, -0.0001f * layer);
        transform.localEulerAngles = new Vector3 (0, 0, Mathf.Atan2 (dPos.y, dPos.x) * 180 / Mathf.PI);
    }


}
