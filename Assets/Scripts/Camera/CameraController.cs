using Cinemachine;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool isElastic;
    [SerializeField] private float lerpSpeed;

    [SerializeField] private CinemachineVirtualCamera camera1;
    [SerializeField] private CinemachineVirtualCamera camera2;
    [SerializeField] private Transform house;

    public void Update()
    {
        // ManuallyMoveCamera();

        if (Input.GetKeyDown(KeyCode.Y))
        {
            //Camara 1
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            //Camara 2

            camera2.gameObject.SetActive(true);
            camera1.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            camera1.Follow = house;
            camera1.LookAt = house;
            camera2.Follow = house;
            camera2.LookAt = house;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            camera1.Follow = target.transform;
            camera2.Follow = target.transform;
            camera2.LookAt = target.transform;
            camera1.LookAt = target.transform;
        }
    }

    private void ManuallyMoveCamera()
    {
        Vector3 desiredCameraPosition = target.transform.position + offset;
        if (isElastic)
        {
            transform.position = Vector3.Lerp(transform.position, desiredCameraPosition, lerpSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = desiredCameraPosition;
        }
    }
}