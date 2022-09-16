using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotazioneOrbita : MonoBehaviour
{
    [SerializeField]
    float IRot;

    [SerializeField]
    float LNRot;

    [SerializeField]
    float PRot;
    private void Start()
    {
        RuotaPianeta();
    }
    

    void RuotaPianeta()
    {
        //this.transform.rotation = new Quaternion(transform.rotation.x , transform.rotation.y-PRot, transform.rotation.z,transform.rotation.w);
        Vector3 rotazione = new Vector3(IRot, LNRot, 0);
        //this.transform.localRotation= new Quaternion(transform.rotation.x, transform.rotation.y + LNRot, transform.rotation.z, transform.rotation.w);
        this.transform.rotation = Quaternion.Euler(rotazione);
        Vector3 ultimarot = new Vector3(transform.localRotation.x, transform.localRotation.y - PRot, transform.localRotation.z);
        this.transform.localRotation = Quaternion.Euler(ultimarot);
        //this.transform.Rotate(this.transform.up, -PRot);
        //LeanTween.rotateAroundLocal(this.gameObject, this.transform.up, -PRot, 1f);


    }
}
