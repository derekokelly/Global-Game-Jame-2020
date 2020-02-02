using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    private int positionToLoad;

    public GameObject Player;
    public GameObject Door;

    private Coroutine lastRoutine;

    public Camera[] cameras;
    private int currentCameraIndex;


    void Start()
    {
        currentCameraIndex = 0;

        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            Debug.Log("Camera with name: " + cameras[0].name + ", is now enabled");
        }
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
            lastRoutine = StartCoroutine(Teleport());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(lastRoutine);
        }
    }

    IEnumerator Teleport()
    {
        while (true)
        {
            if (Input.GetKeyDown("z"))
            {
                animator.SetBool("New Bool", true);
                yield return new WaitForSeconds(1);
                Player.transform.position = new Vector2(Door.transform.position.x, Door.transform.position.y - 1.5f);
                NextCamera();
                break;
            }
            yield return null;
        }
    }

    void NextCamera()
    {
        currentCameraIndex++;
        Debug.Log("Z button has been pressed. Switching to the next camera");
        Debug.Log(currentCameraIndex);
        Debug.Log(cameras.Length);
        if (currentCameraIndex < cameras.Length)
        {
            Debug.Log("In if");
            cameras[currentCameraIndex - 1].gameObject.SetActive(false);
            cameras[currentCameraIndex].gameObject.SetActive(true);
            Debug.Log("Camera with name: " + cameras[currentCameraIndex].name + ", is now enabled");
        }
        else
        {
            Debug.Log("In else");
            cameras[currentCameraIndex - 1].gameObject.SetActive(false);
            currentCameraIndex = 0;
            cameras[currentCameraIndex].gameObject.SetActive(true);
            Debug.Log("Camera with name: " + cameras[currentCameraIndex].name + ", is now enabled");
        }
    }
}
