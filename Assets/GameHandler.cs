using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject posicaoTeto;
    [SerializeField] private GameObject posicaoChao;
    [SerializeField] private GameObject canoPrefab;

    [SerializeField] private float tempoSpawn = 3;
    private float _tempoAtualSpawn;

    private void Start()
    {
        _tempoAtualSpawn = tempoSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(VerificarForaDoMapa()) PlayerFlappyBird.Instance.GameOver();

        SpawnCano();
    }

    private void SpawnCano()
    {
        _tempoAtualSpawn -= Time.deltaTime;
        
        if (_tempoAtualSpawn <= 0)
        {
            var novoCano = Instantiate(canoPrefab);
            
            novoCano.transform.position = new Vector3(10,0,0);
            _tempoAtualSpawn = tempoSpawn;
        }
    }

    // Verifica se o jogador está acima do chão e abaixo do teto
    private bool VerificarForaDoMapa()
    {
        var verticalPos = PlayerFlappyBird.Instance.transform.position.y;
        
        if (verticalPos > posicaoTeto.transform.position.y) return true;
        if (verticalPos < posicaoChao.transform.position.y) return true;

        return false;
    }
}
