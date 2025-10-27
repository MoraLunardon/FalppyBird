using UnityEngine;

public class CanoSobeDece : MonoBehaviour
{
    private float velocidade = 5f;
    public bool cima = true;
    public float velocidadeSD;

    // Update is called once per frame
    void Update()
    {
        MoverSobeDece();
    }

    private void MoverSobeDece()
    {
        velocidadeSD = Random.Range(1, 3);
        transform.Translate(velocidade * Time.deltaTime * Vector3.left);
        
        if (transform.position.y > 3.8f)
        {
            cima = false;
        } 
        else if (transform.position.y < -2.2f)
        {
            cima = true;
        }

        if (cima)
        {
            transform.Translate(velocidadeSD * Time.deltaTime * Vector3.up);
        }
        else
        {
            transform.Translate(-velocidadeSD * Time.deltaTime * Vector3.up);
        }
            
        if (transform.position.x < -30f) Destroy(gameObject);


    }


}