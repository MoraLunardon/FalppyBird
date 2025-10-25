using UnityEngine;

public class CanoSobeDece : MonoBehaviour
{
    private float velocidade = 5f;
    public bool cima = true;

    // Update is called once per frame
    void Update()
    {
        MoverSobeDece();
    }

    private void MoverSobeDece()
    {
        transform.Translate(velocidade * Time.deltaTime * Vector3.left);

        if (transform.position.y > 1)
        {
            cima = false;
        }
        else if (transform.position.y < 3)
        {
            cima = true;
        }

        if (cima)
        {
            transform.Translate(velocidade * Time.deltaTime * Vector2.up);
        }
        else
        {
            transform.Translate(-velocidade * Time.deltaTime * Vector2.up);
        }

        if (transform.position.x < -30f) Destroy(gameObject);


    }


}
