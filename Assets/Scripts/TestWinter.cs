using UnityEngine;
using System.Collections;

public class TestWinter : MonoBehaviour
{

    public Material[] leafs;

    public Color summerColor = Color.white;
    public Color winterColor = new Color(1, 1, 1, 0);

    
    void Start()
    {
        leafs[0].color = Color.red;

        foreach (Material m in leafs)
        {
            m.color = winterColor;
            
        }
	}
	

}
