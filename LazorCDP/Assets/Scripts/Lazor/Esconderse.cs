using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esconderse : MonoBehaviour
{
    private GameObject playerController;
    private bool dentro;
    private bool arriba = true;
    private bool vibracion = true;
    private Vector3 pos;
    private Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.parent.position;
        rot = transform.parent.rotation;
        playerController = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (dentro && playerController.GetComponent<PlayerController>().escondido)
        {
            vibrar(); 
            transform.parent.position = pos;
            
            playerController.GetComponent<PlayerController>().enabled = false;
            playerController.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (dentro) 
        {
            MoveBox();
            playerController.GetComponent<PlayerController>().enabled = true;
            playerController.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            MoveBox();
        }
    }

    private void MoveBox()
    {
        transform.parent.Rotate (0, 10 * Time.deltaTime, 0);
        if (arriba)
        {
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 0.001f, transform.parent.position.z);
            if (transform.parent.position.y > pos.y + 0.7f)
                arriba = false;
        }
        else
        {
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y - 0.001f, transform.parent.position.z);
            if (transform.parent.position.y < pos.y)
                arriba = true;
        }
    }

    private void vibrar()
    {
        if(!vibracion) return;
        transform.parent.rotation = rot;
        vibracion = false;
        StartCoroutine(vibrarAlRato());
    }

    IEnumerator vibrarAlRato() {
        yield return new WaitForSeconds(3);
        vibracion = true;
        if (dentro && playerController.GetComponent<PlayerController>().escondido)
        {
            transform.parent.Rotate (5, 0, 5);
            yield return new WaitForSeconds(0.1f);
            transform.parent.Rotate (-5, 0, -5);
            yield return new WaitForSeconds(0.1f);
            transform.parent.Rotate (5, 0, 5);
            yield return new WaitForSeconds(0.1f);
            transform.parent.Rotate (-5, 0, -5);
            yield return new WaitForSeconds(0.1f);
            transform.parent.rotation = rot;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            {
                dentro = true;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            {
                dentro = false;
            }
    }
}
