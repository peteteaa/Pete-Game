using UnityEngine;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    public InputActionReference Move;
    public InputActionReference Primary;
public InputActionReference Secondary;
    public GameObject BulletPrefab;
    public Transform hardpoint;  
      public Transform hardpoint1;
      public GameObject MisslePrefab;
      public float nextSecondaryDelay_ = 0.5f;
         public AudioClip primarySound;
         public AudioClip secondarySound;
    public AudioSource audioSource;

    public float moveSpeed = 0.01f;
public float nextPrimaryDelay_ = 0.5f;
    private bool primaryDown_ = false;
    private float nextPrimaryTime_ = 0f;
    private bool secondaryDown_ = false;
    private float nextSecondaryTime_ = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        Vector2 move = Move.action.ReadValue<Vector2>();

        Vector3 newPos = transform.position + (new Vector3(move.x*moveSpeed, 0.0f, move.y*moveSpeed) * Time.deltaTime);//use delta tiem to slow down movement by making it frame rate independent
        newPos.x = Mathf.Clamp(newPos.x, -7f, -4f);
        newPos.z = Mathf.Clamp(newPos.z, 0f, 7f); 
        transform.position = newPos; 
        if(primaryDown_ == true && Time.time > nextPrimaryTime_){
            Instantiate(BulletPrefab, hardpoint.transform.position, hardpoint.rotation);            
            Instantiate(BulletPrefab, hardpoint1.transform.position, hardpoint1.rotation);
            audioSource.clip = primarySound;
            audioSource.Play();
            nextPrimaryTime_ = Time.time + nextPrimaryDelay_;}
        else if(secondaryDown_ == true && Time.time > nextSecondaryTime_){
            Instantiate(MisslePrefab, hardpoint.transform.position, hardpoint.rotation);            
            Instantiate(MisslePrefab, hardpoint1.transform.position, hardpoint1.rotation);
            audioSource.clip = secondarySound;
            audioSource.Play();
            nextSecondaryTime_ = Time.time + nextSecondaryDelay_;}

    }
    void OnEnable()
    {
        Primary.action.performed += OnPrimaryPerformed;
        Primary.action.canceled += OnPrimaryCanceled;
        Secondary.action.performed += OnSecondaryPerformed;
        Secondary.action.canceled += OnSecondaryCanceled;
    }
    void OnDisable() 
    {
    Primary.action.performed -= OnPrimaryPerformed;
    Primary.action.canceled -= OnPrimaryCanceled;
    Secondary.action.performed -= OnSecondaryPerformed;
    Secondary.action.canceled -= OnSecondaryCanceled;
    primaryDown_ = false;
    nextPrimaryTime_ = 0f;
    secondaryDown_ = false;
    nextSecondaryTime_ = 0f;


    }

    public void OnPrimaryPerformed(InputAction.CallbackContext context)
    {
        primaryDown_ = true;

    }
    public void OnPrimaryCanceled(InputAction.CallbackContext context)
    {
        primaryDown_ = false;
    }
    public void OnSecondaryPerformed(InputAction.CallbackContext context)
    {
        secondaryDown_ = true;
    }
    public void OnSecondaryCanceled(InputAction.CallbackContext context)
    {
        secondaryDown_ = false;
    }

}
