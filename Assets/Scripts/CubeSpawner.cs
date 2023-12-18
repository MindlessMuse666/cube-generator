using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var newCube = Instantiate(_cube);
            newCube.transform.position = new Vector3(Random.Range(-15, 15), 30, 10);
        }
    }
}
