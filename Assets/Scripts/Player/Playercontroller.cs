using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private int speed  = 1;
    bool Walking;
    void Update()
    {
        Vector3 Input_Vector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            Input_Vector.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Input_Vector.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Input_Vector.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Input_Vector.x -= 1;
        }

        Input_Vector = Input_Vector.normalized;
        //Debug.Log(Input_Vector);

        Vector3 movDirection = Input_Vector * Time.deltaTime * speed;
        transform.position += movDirection;
        transform.forward = Vector3.Lerp(transform.forward, movDirection, 1f);
        Walking = movDirection != Vector3.zero;
        //Debug.Log(Walking);
    }
    public bool Condition()
    {
        return Walking;
    }

}
