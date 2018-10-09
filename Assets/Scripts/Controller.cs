using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    

    public GameObject Clone;

    static public bool MoveMode = false;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!MoveMode) {
            if (Input.GetMouseButtonDown (0)) {
                CreateQuad ();
            }
        }
        if (Input.GetMouseButtonUp (0)) {
            MoveMode = true;
        }
    }

    public void CreateQuad () {
        float minF = 0.7f;
        Clone = GameObject.CreatePrimitive (PrimitiveType.Quad);
        Clone.GetComponent<Renderer> ().material.shader = Shader.Find ("Sprites/Default");
        //Clone.GetComponent<Renderer> ().material.mainTexture = Resources.Load ("Textures/Circle2") as Texture;
        Clone.GetComponent<Renderer> ().material.color = new Color (Random.Range (minF, 1), Random.Range (minF, 1), Random.Range (minF, 1));
        Clone.AddComponent<UIController> ();
    }
}
