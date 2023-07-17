using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("gotonextscean",4f);
    }

    void gotonextscean()
    {
        AudioManger.instance.Stop("menu");
        SceneManager.LoadScene(3);
    }
    
}
