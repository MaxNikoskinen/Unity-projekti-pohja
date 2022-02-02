using UnityEngine;

//Estää ettei gameobject tuhoudu skenen vaihdossa

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
