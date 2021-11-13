using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

            StartCoroutine(ExecuteMoveIcon(5));
        }
    }

    IEnumerator ExecuteMoveIcon(float Time)
    {
        yield return new WaitForSeconds(Time);

        //this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        //GameManager.instance. NextLevel();

        GameManager.instance.GameOverPanel.SetActive(true);
    }
    

}
