using System; 
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class FundoPassando : MonoBehaviour 
{ 

	[SerializeField] private float _velocidadeFundo = 0.1f; 
	[SerializeField] private Vector2 _posicaoInicial; 

	private void Start() 
	{ 
	
	_posicaoInicial = transform.position; 

	} 
	private void Update() 
	{ 
	
		transform.Translate(Vector2.left * _velocidadeFundo * Time.deltaTime);
		if (transform.position.x < -22.23589f)
			{
				transform.position = _posicaoInicial;
			}
	} 

}