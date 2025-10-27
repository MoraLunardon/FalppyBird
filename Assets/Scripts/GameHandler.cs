using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject posicaoTeto;
    [SerializeField] private GameObject posicaoChao;
    [SerializeField] private GameObject canoPrefab;
    [SerializeField] private GameObject canoSobeDecePrefab;

    [SerializeField] private float tempoSpawn = 4;
    [SerializeField] private float tempoSpawnSD = 2;
    [SerializeField] private float distancia;
    [SerializeField] private float distanciaMenor;
    private float _tempoAtualSpawn;
    private float _tempoSD;

    private void Start()
    {
        _tempoAtualSpawn = tempoSpawn;
        _tempoSD = tempoSpawnSD;
    }

    // Update is called once per frame
    void Update()
    {
        if(VerificarForaDoMapa()) PlayerFlappyBird.Instance.GameOver();

        SpawnCano();
        SpawnCanoSobedece();
    }

    private void SpawnCano()
    {
        _tempoAtualSpawn -= Time.deltaTime;
        
        if (_tempoAtualSpawn <= 0)
        {
            var novoCano = Instantiate(canoPrefab);
            
            novoCano.transform.position = new Vector3(13, Random.Range(distancia, distanciaMenor), 0);
            _tempoAtualSpawn = tempoSpawn;
        }
    }

    private void SpawnCanoSobedece()
    {
            _tempoSD -= Time.deltaTime;

            if (_tempoSD <= 0)
            {
                var novoCanoSobeDece = Instantiate(canoSobeDecePrefab);

                novoCanoSobeDece.transform.position = new Vector3(13, 0, 0); 
                _tempoSD = tempoSpawn;
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
