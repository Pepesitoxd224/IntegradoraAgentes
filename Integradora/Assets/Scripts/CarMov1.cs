using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMov1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxVel = 5;
    private float speed;
    void Start()
    {
        speed = maxVel;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy"))
        {
            Destroy(this.gameObject);
        }else if(other.CompareTag("Carro")){
            speed=0;
        }
    }

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Alto")){
            if(Semaforo.Instance.arriba == false && transform.rotation.y < 0){
                speed = 0;
            }else if(Semaforo.Instance.derecha == false && transform.rotation.y==0){
                speed = 0;
            }else{
                speed = maxVel;
            }
        }
    }
}
