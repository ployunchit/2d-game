using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _ammoPrefab;
    [SerializeField] Transform _ammoSpawn;
    [SerializeField] Transform _currentGun;

    public float jumpHeight = 5; 
    public float moveSpeed = 1;
    public float missileForce = 5f;

    private Vector3 diff;
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
         GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
         
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D ammo = Instantiate(_ammoPrefab, _ammoSpawn.position, _currentGun.rotation);
            ammo.AddForce(_currentGun.right * missileForce, ForceMode2D.Impulse);
            ammo.transform.Rotate(0, 90, 0);
        }

        RotateGun();
    }

    void RotateGun(){
        diff = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_Z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        _currentGun.rotation = Quaternion.Euler(0, 0, rot_Z + 180f);
    }
}
