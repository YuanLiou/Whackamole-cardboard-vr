using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Camera mainCamera;
    public Hammer hammer;
    public int score = 0;

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) {
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, mainCamera.transform.forward, out raycastHit)) {
                if (raycastHit.transform.GetComponent<Mole>() != null) {
                    Mole mole = raycastHit.transform.GetComponent<Mole>();
                    mole.OnHit();
                    hammer.Hit(mole.transform.position);
                    score++;
                }
            }
        }
    }
}