
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] private float movingSpeed;

    private static CameraFollow2D _inst;

    private void Awake()
    {

        if ( this.playerTransform == null)
        {
            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }

        this.transform.position = new Vector3()
        {
            x = playerTransform.position.x,
            z = playerTransform.position.z - 10,
        };
    }

    private void Update()
    {
        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = playerTransform.position.x,
                z = playerTransform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movingSpeed * Time.deltaTime);
            this.transform.position = pos;
        }
  
    }

}
