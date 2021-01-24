using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarToTheTop : MonoBehaviour
{
    Scrollbar scroll;
    void Start()
    {
        scroll = gameObject.GetComponent<Scrollbar>();
        scroll. value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
