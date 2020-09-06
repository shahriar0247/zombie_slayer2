using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_manager : MonoBehaviour
{

    public string platform;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string get_platform() {
        if (platform == null) {
            platform = "pc";
        }
        return platform;
    }
 
}
