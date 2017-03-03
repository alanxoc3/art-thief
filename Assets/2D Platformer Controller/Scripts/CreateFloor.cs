using UnityEngine;
using System.Collections;

public class CreateFloor : MonoBehaviour {

    //public GameObject floorBlock;
    //public GameObject ceilingBlock;
    public int numBlocks;
    public Transform floorTile;
    public Transform ceilingTile;
    public float length = 0.58f;

    // Use this for initialization
    void Start () {
        //ArrayList someArray = new ArrayList();

        var half = numBlocks / 2;
        for (int i = 0; i < numBlocks; i++)
        {
            if (i < half)
            {
                Instantiate(floorTile, new Vector3(transform.position.x + length * (i + 1), floorTile.transform.position.y, 0.5f), Quaternion.identity);
                Instantiate(ceilingTile, new Vector3(transform.position.x + length * (i + 1), ceilingTile.transform.position.y, -0.5f), Quaternion.identity);
            }
            else
            {
                Instantiate(floorTile, new Vector3(transform.position.x - length * (i - half), floorTile.transform.position.y, 0.5f), Quaternion.identity);
                Instantiate(ceilingTile, new Vector3(transform.position.x - length * (i - half), ceilingTile.transform.position.y, -0.5f), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
