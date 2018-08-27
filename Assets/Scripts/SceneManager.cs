using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    [SerializeField]
    private GameObject _ui;

	private void Start () {
        Application.runInBackground = true;
	}
	
	private void Update () {
        if (Input.GetKeyDown("escape")) _ui.SetActive(!_ui.activeSelf);
	}
}
