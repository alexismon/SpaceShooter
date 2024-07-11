using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }
}
