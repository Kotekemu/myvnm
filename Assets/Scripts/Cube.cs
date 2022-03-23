using UnityEngine;

// кубический класс //
public class Cube : MonoBehaviour
{
    private float count;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Awake()
    {
        Debug.Log(message: "Awake");
        count = 0;
        originalPosition = this.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message: "Start");
    }

    // Update is called once per frame
    void Update()
    {
        count += 0.1f;
        this.transform.rotation = Quaternion.Euler(count, count, count);
        this.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(100,100,100), Time.deltaTime);
    }
}
