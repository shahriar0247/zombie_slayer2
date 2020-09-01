using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_manager : MonoBehaviour
{

    public string platform;
    public FixedJoystick movement_joystick;
    public FixedTouchField touch_panal;

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
    public FixedJoystick get_movement_joystick()
    {
        return movement_joystick;
    }
    public FixedTouchField get_touch_panal()
    {
        return touch_panal;
    }
}
