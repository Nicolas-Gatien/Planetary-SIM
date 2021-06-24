using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using OVR;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public Transform cameraTransform;
    public Vector3 zoomAmount;

    public List<GameObject> planets;
    public Transform target;
    public float movementTime;
    public int planetIndex;

    public float rotationAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
        Invoke("NextPlanet", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            planetIndex = 0;
            NextPlanet();
        }
        if (planets[planetIndex] == null)
        {
            NextPlanet();
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            NextPlanet();
        }
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            newZoom += zoomAmount;
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            newZoom -= zoomAmount;
        }

        if(target!= null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * movementTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
        }else
        {
            NextPlanet();
        }

    }

    void NextPlanet()
    {
        planets.Clear();
        planets.AddRange(GameObject.FindGameObjectsWithTag("Planet"));
        SortPlanetBySize();
        if (planetIndex >= planets.Count)
        {
            planetIndex = 0;
        }
        target = planets[planetIndex].transform;
        if(planets.Count == 1)
        {
            planetIndex = 0;

        }
        else
        {
            planetIndex++;

        }
    }

    void SortPlanetBySize()
    {
        planets = planets.OrderBy(x => x.transform.localScale.x).ToList();
        planets.Reverse();
    }
}
