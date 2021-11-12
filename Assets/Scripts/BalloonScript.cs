using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{

    public static BalloonScript Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Football"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.transform.GetChild(0).gameObject .SetActive(true);
;        }
    }
}
