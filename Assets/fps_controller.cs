using UnityEngine;
using UnityEngine.Networking;

public class fps_controller : NetworkBehaviour
{

    [Header("Movement")]
    //How fast the weapon fires, higher value means faster rate of fire
    public float speed = 10f;

    [Header("Look")]
    public float sensitivity = 100f;

    [Header("Weapons")]
    public float firerate = 10f;
    private float nextActionTime = 0f;


    [Header("Others")]
    public GameObject graphics;
    public GameObject bullet;
    public GameObject barrel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {


        Movement();
        Rotate();
        Gravity();
        Fire();

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
        if (this.transform.position.y > 1.46f)
        {
            this.transform.Translate(new Vector3(0, (this.transform.position.y - force) * Time.deltaTime, 0));
        }
    }

    void Fire()
    {
        if (Input.GetMouseButton(0))
        {

            //if (Time.time > nextActionTime)
            //{
            //    nextActionTime = Time.time + (1 / firerate);
            //    Debug.Log("lol");
            //}

         


                if (Time.time - nextActionTime > 1 / firerate)
                {
                    nextActionTime = Time.time;
                    GameObject bullet_instance;
                    bullet_instance = Instantiate(bullet, Camera.main.transform.position, Camera.main.transform.rotation);
                    bullet_instance.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 20f);
                }

            
        }
    }
    


}
