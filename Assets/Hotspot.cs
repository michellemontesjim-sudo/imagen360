using UnityEngine;

public class Hotspot: MonoBehaviour
{
    [Header("Efectos Visuales")]
    public Renderer objetoRenderer;
    public Color colorNormal = Color.white;
    public Color colorIluminado = Color.yellow;

    [Header("Transición")]
    public Transform centroSegundaEsfera;
    public Transform camara;
    public float velocidadTransicion = 2.5f;

    private bool cambiandoDeEsfera = false;

    void Start()
    {
        if (objetoRenderer == null) objetoRenderer = GetComponent<Renderer>();
        if (camara == null) camara = Camera.main.transform;
        objetoRenderer.material.color = colorNormal;
    }

    void OnMouseEnter()
    {
        // Ilumina el objeto al pasar el cursor (o usa un material con Emission)
        objetoRenderer.material.color = colorIluminado;
    }

    void OnMouseExit()
    {
        // Regresa al estado normal
        objetoRenderer.material.color = colorNormal;
    }

    void OnMouseDown()
    {
        // Inicia el desplazamiento al hacer clic
        cambiandoDeEsfera = true;
    }

    void Update()
    {
        if (cambiandoDeEsfera)
        {
            camara.position = Vector3.Lerp(camara.position, centroSegundaEsfera.position, Time.deltaTime * velocidadTransicion);

            if (Vector3.Distance(camara.position, centroSegundaEsfera.position) < 0.05f)
            {
                camara.position = centroSegundaEsfera.position;
                cambiandoDeEsfera = false;
            }
        }
    }
}
