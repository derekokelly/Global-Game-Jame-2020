using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    private int positionToLoad;

    public GameObject Player;
    public GameObject Door;
    public string type;
    public Camera oldCam, newCam;

    private Coroutine lastRoutine;

    //public Camera[] cameras;
    private int currentCameraIndex;


    void Start()
    {
        //currentCameraIndex = 0;

        //for (int i = 1; i < cameras.Length; i++)
        //{
        //    cameras[i].gameObject.SetActive(false);
        //}

        //if (cameras.Length > 0)
        //{
        //    cameras[0].gameObject.SetActive(true);
        //    Debug.Log("Camera with name: " + cameras[0].name + ", is now enabled");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel()
    {
        animator.SetBool("New Bool", false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (type == "door")
                lastRoutine = StartCoroutine(GoThroughDoor());
            else
                lastRoutine = StartCoroutine(GoPastBound());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(lastRoutine);
        }
    }

    IEnumerator GoThroughDoor()
    {
        while (true)
        {
            if (Input.GetKeyDown("z"))
            {
                StartCoroutine("ChangeRoom");
                break;
            }
            yield return null;
        }
    }

    IEnumerator GoPastBound()
    {
        StartCoroutine("ChangeRoom");
        yield return null;
    }

    IEnumerator ChangeRoom()
    {
        animator.SetBool("New Bool", true);
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector2(Door.transform.position.x, Door.transform.position.y - 1.5f);
        NextCamera();
    }

    void NextCamera()
    {
        newCam.gameObject.SetActive(true);
        oldCam.gameObject.SetActive(false);


        //currentCameraIndex++;
        //Debug.Log("Z button has been pressed. Switching to the next camera");
        //if (currentCameraIndex < cameras.Length)
        //{
        //    cameras[currentCameraIndex - 1].gameObject.SetActive(false);
        //    cameras[currentCameraIndex].gameObject.SetActive(true);
        //    Debug.Log("Camera with name: " + cameras[currentCameraIndex].name + ", is now enabled");
        //}
        //else
        //{
        //    cameras[currentCameraIndex - 1].gameObject.SetActive(false);
        //    currentCameraIndex = 0;
        //    cameras[currentCameraIndex].gameObject.SetActive(true);
        //    Debug.Log("Camera with name: " + cameras[currentCameraIndex].name + ", is now enabled");
        //}
    }
}
