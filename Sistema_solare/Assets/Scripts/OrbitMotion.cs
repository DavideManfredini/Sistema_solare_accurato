using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class OrbitMotion : MonoBehaviour
{

    public Transform orbitingObject;
    public Ellipse orbitingPath;
    [Range(0f,1f)]
    public float orbitProgress=0f;
    public float orbitPeriod;
    public bool orbitActive = true;

    [SerializeField]
    float gradiorari;
    // Start is called before the first frame update
    void Start()
    {
        if (orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        CalcolaGiorniTrascorsi();
        orbitProgress = (float)(orbitProgress - CalcolaGradi());
        if (orbitProgress < 0)
        {
            orbitProgress = 1f + orbitProgress;
        }
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

   

    void SetOrbitingObjectPosition()
    {
        Vector3 orbitPos = orbitingPath.Evaluate(orbitProgress);
        
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.z);
    }

    IEnumerator AnimateOrbit()
    {
        if (orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }
        float orbitalSpeed = 1f / orbitPeriod;
        while (orbitActive)
        {
            orbitProgress -= Time.deltaTime *orbitalSpeed;
            //orbitProgress %= 1f;
            if (orbitProgress < 0)
            {
                orbitProgress = 1;
            }
            SetOrbitingObjectPosition();
            yield return null;
        }
        
    }
    double CalcolaGiorniTrascorsi()
    {
        DateTime giornoAttuale = DateTime.Now;
        DateTime giornoFuturo = new DateTime(2357, 05, 6, 00, 00, 0);

        DateTime giorno0 = new DateTime(2022, 09, 14, 0, 0, 0);
        //TimeSpan tempoPassato = giornoAttuale - giorno0;
        TimeSpan tempoPassato = giornoFuturo - giorno0;
        double orePassate = tempoPassato.TotalHours;
        Debug.Log(orePassate);

        return orePassate;

    }

    double CalcolaGradi()
    {
        double gradiDaTogliere = CalcolaGiorniTrascorsi() * gradiorari;
        Debug.LogError(this.gameObject.name);
        Debug.LogError(gradiDaTogliere);
        while (gradiDaTogliere > 360)
        {
            gradiDaTogliere -= 360;
        }
        gradiDaTogliere = gradiDaTogliere / 360;

        return gradiDaTogliere;
    }





}
