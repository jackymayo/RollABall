using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    System.Random randomGen;
    private Vector3 randomRotationVector;
    private void Start()
    {        
        // Given boundary of X is from -10 to 10, we can use a range of -21
        randomGen = new System.Random((int)(this.gameObject.transform.position.x* 214748));
        randomRotationVector = new Vector3(randomGen.Next(0, 90), randomGen.Next(0, 90), randomGen.Next(0, 90));


    }
    // Update is called once per frame
    void Update () {
        transform.Rotate(randomRotationVector * Time.deltaTime);
	}
}
