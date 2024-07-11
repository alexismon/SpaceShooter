using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public Text ammoText;
    private int specialAmmo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSpecialAmmo(int toAdd)
    {
        specialAmmo += toAdd;
        ammoText.text = "Special: " + specialAmmo.ToString("D2");
    }

    public int GetSpecialAmmo()
    {
        return specialAmmo;
    }  
}
