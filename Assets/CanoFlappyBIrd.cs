using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanoFlappyBIrd : MonoBehaviour
{
    private float velocidade = 5f;
    
    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        transform.Translate(velocidade * Time.deltaTime * Vector3.left);

        if (transform.position.x < -20f) Destroy(gameObject);
    }
}
