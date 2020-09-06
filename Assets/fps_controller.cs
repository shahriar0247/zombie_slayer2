using UnityEngine;
using UnityEngine.Networking;

public class fps_controller : NetworkBehaviour
{

    public float speed = 10f;
    public float sensitivity = 100f;

    public GameObject graphics;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
            Movement();
            Rotate();
            Gravity();
       
     

    }

    void Movement()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float Vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        this.transform.Translate(new Vector3(Horizontal, 0, Vertical));

    }
    void Rotate()
    {
        float Horizontal = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float Vertical = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        graphics.transform.Rotate(new Vector3(-Vertical, 0, 0));
        this.transform.Rotate(new Vector3(0, Horizontal, 0));
    }

    void Gravity()
    {
        float force = 9.81f;
        if (this.transform.position.y > 1.46f) { 
        this.transform.Translate(new Vector3(0, (this.transform.position.y - force) * Time.deltaTime, 0));
        }
    }
}
