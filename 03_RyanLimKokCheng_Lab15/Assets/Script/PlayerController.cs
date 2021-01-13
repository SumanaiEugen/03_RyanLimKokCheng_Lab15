using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Redtext;
    public Rigidbody PlayerRb;

    private AudioSource audioSource;
    public AudioClip[] audioClipArray;

    private int jumpcounter;
    int JumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && JumpCount == 0)
        {
            PlayerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);

            JumpCount = 1;

            //Text Counter
            jumpcounter++;
            Redtext.GetComponent<Text>().text = "Jump Count : " + jumpcounter;

            //Random Audio plays on jump
            int rand = Random.Range(0, audioClipArray.Length);
            audioSource.PlayOneShot(audioClipArray[rand]);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            JumpCount = 0;
        }
    }
}
