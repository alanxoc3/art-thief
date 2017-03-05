using UnityEngine;
using System.Collections;

public class BenchScript : MonoBehaviour {

    public Transform playerTransform;
    public BoxCollider2D benchCollider;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        benchCollider.isTrigger = (playerTransform.position.y < -2.0f);
    }
}
