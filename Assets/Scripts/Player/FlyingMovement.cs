using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour {

    [SerializeField]
    private float _speed;

	private void Start () {
		
	}
	
	private void Update () {
        var moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("UpDown"), Input.GetAxis("Vertical"));

        moveDirection *= _speed;

        transform.Translate(moveDirection * Time.deltaTime);
	}
}
