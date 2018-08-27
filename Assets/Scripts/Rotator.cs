using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    [SerializeField]
    private Vector3 _rotationAxis;

	private void Start () {
		
	}
	
	private void Update () {
        transform.Rotate(_rotationAxis * Time.deltaTime);
	}
}
