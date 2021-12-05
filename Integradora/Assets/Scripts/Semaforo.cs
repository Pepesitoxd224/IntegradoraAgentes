using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    public static Semaforo Instance;
    public bool arriba, derecha;
    // Start is called before the first frame update

    void Awake(){
        if(!Instance){
            Instance = this;
        }
    }
    void Start()
    {
        StartCoroutine(Ciclo());
        arriba=false;
        derecha=true;
    }

    IEnumerator Ciclo(){
        while(true){
            arriba=!arriba;
            derecha=!derecha;
            yield return new WaitForSeconds(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
