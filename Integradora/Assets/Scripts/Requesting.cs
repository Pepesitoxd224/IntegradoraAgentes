using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Requesting : MonoBehaviour
{
    [SerializeField] GameObject[] Coches = new GameObject[2];
    private Data posiciones;

    void Start()
    {
        StartCoroutine(GetText());

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true){
            yield return new WaitForSeconds(2);
            int tipoCoche = Random.Range(0,2);
            Instantiate(Coches[tipoCoche], new Vector3(posiciones.data[tipoCoche].x,posiciones.data[tipoCoche].y, posiciones.data[tipoCoche].z), Quaternion.Euler(0, posiciones.data[tipoCoche].r,0));
        }
    }

    IEnumerator GetText()
    {
        float inicio = Time.time;

        print("haciendo request");
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }

        posiciones = JsonUtility.FromJson<Data>(www.downloadHandler.text);

        foreach (Position p in posiciones.data)
        {

            Debug.Log(p.x + ", " + p.y + ", " + p.z);
        }

        float total = Time.time - inicio;
        print("tomo: " + total);
    }
}
