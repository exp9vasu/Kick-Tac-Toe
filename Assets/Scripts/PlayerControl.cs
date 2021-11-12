using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

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

    public void StartShooting()
    {
        PlayerPrefs.SetInt("shoot",1);
    }

    public IEnumerator ExecuteAfterTime(float Time)
    {
        yield return new WaitForSeconds(Time);

        transform.GetComponent<Animator>().enabled = true;
    }
    
    
}
