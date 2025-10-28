using System; 
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;

public class FlappyChão : MonoBehaviour
{

    [SerializeField] private float _velocidadeChao = 5f;
    [SerializeField] private Vector2 _posicaoInicialC;

    private void Start()
    {

        _posicaoInicialC = transform.position;

    }

    private void Update()
    {

        transform.Translate(Vector2.left * _velocidadeChao * Time.deltaTime);
        if (transform.position.x < -12.48f)
        {
            transform.position = _posicaoInicialC;
        }
    }

}
