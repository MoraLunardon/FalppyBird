using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyChão : MonoBehaviour
{
    [SerializeField] private float _velocidadeChao = 1f;
    [SerializeField] private float _larguraChao = 6f;

    private SpriteRenderer _chaoSprite;
    private Vector2 _tamanhoInicial;

    private void Start()
    {
        _chaoSprite = GetComponent<SpriteRenderer>();
        _tamanhoInicial = new Vector2(_chaoSprite.size.x, _chaoSprite.size.y);
    }

    private void Update()
    {
        _chaoSprite.size = new Vector2(_chaoSprite.size.x + _velocidadeChao * Time.deltaTime, _chaoSprite.size.y);

        if (_chaoSprite.size.x > _larguraChao)
        {
            _chaoSprite.size = _tamanhoInicial;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var bird = other.gameObject.GetComponent<PlayerFlappyBird>();
        
        if(bird == null) return;
        
        bird.GameOver();
    }


}
