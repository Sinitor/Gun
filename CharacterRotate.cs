using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotate : MonoBehaviour
{
    [SerializeField] protected float sensetive = 1.5f;
    [SerializeField] protected float smooth = 10;
    [SerializeField] protected Transform character;
    protected float yRotation;
    protected float xRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    protected void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * sensetive;
        xRotation -= Input.GetAxis("Mouse Y") * sensetive;

        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
    }
    protected void RotateCharacter()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * smooth);
        character.rotation = Quaternion.Lerp(character.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime * smooth);
    }
}