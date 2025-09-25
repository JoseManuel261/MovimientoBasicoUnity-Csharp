Move

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControladorEsfera : MonoBehaviour
{
    [Tooltip("La velocidad de movimiento de la esfera.")]
    public float velocidad = 40.0f;

    [Tooltip("La fuerza con la que la esfera saltar .")]
    public float fuerzaDeSalto = 15.0f;

    private Rigidbody rb;
    private bool estaEnElSuelo = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
            estaEnElSuelo = false;
        }
    }

    void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 direccionMovimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        rb.AddForce(direccionMovimiento * velocidad);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            estaEnElSuelo = true;
        }
    }
}
