using UnityEngine;

public class WaterInputController : MonoBehaviour
{
    private WaterBehaviour _waterBehaviour;
    
    private void Start()
    {
        _waterBehaviour = GetComponent<WaterBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _waterBehaviour.Fill();
        }
    }
}
