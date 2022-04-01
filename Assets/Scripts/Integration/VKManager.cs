using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class VKManager : MonoBehaviour
{
    [DllImport(dllName: "__Internal")] 
    private static extern void Hello();

    [DllImport(dllName: "__Internal")]
    private static extern void HelloString(string str);

    [SerializeField] private Text info;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Hello();
        HelloString(str:"Hello, Daniil!");
    }
}
