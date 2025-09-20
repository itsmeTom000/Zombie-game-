using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    public float speed;
    public int rotateCount;
    public 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (rotateCount >= 10)
        //{
        //    transform.Rotate(Vector3.forward * Time.deltaTime * speed * 5);
        //    rotateCount++;
        //}
        
    }

    private void FixedUpdate()
    {
        for (int i = 0; i <= rotateCount; i++)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * speed * 5);
        }
    }
}