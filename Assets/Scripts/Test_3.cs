using UnityEngine;

public class Test_3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public string playerName = "saurabh";
    private void Awake()
    {
        Debug.Log("Awake ");
    }

    public void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void Start() // called when script is active, it called before the first frame.
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update() 
    {
        Debug.Log("Update");
    }

    void FixedUpdate()
    {
        Debug.Log("FIxedUpdate");
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    public void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    public void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
