using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    private Transform characterTransform;
    private Camera mainCamera;
    public int vidaPlayer;
    public Text textoVida;

   private void Awake()
   {
      characterTransform = GetComponent<Transform>();
      mainCamera = Camera.main;

   }

   private void Update()
   {
       // Movement
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");

       Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
       characterTransform.Translate(movement, Space.World);

       // Rotation
       Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;

       if (Physics.Raycast(ray, out hit))
       {
          Vector3 targetPosition = new Vector3(hit.point.x, characterTransform.position.y, hit.point.z);
          Vector3 direction = targetPosition - characterTransform.position;

          if (direction != Vector3.zero)
          {
             Quaternion toRotation = Quaternion.LookRotation(direction);
             characterTransform.rotation = Quaternion.RotateTowards(characterTransform.rotation, toRotation, rotationSpeed * Time.deltaTime);
          }
       }

        textoVida.text = "vida: " + vidaPlayer.ToString("00");

        if (vidaPlayer <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }

   }
    public void restarVida(int vidaRestar)
    {
        vidaPlayer -= vidaRestar;
    }

}