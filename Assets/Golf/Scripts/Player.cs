using Golf;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform Golf_Stick;

    private bool m_isDown = false;

    private Vector3 m_LastPosition;

    public float range = 40f;

    public float speed = 500f;

    public float power = 10f;

    public Transform helper;

    private void Update()
    {
        m_LastPosition = helper.position;

        m_isDown = Input.GetMouseButton(0);

        Quaternion rot = Golf_Stick.localRotation;

        Quaternion toRot = Quaternion.Euler (0,0, m_isDown ? range : -range);

        rot = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);

        Golf_Stick.localRotation = rot;

        
}

    public void OnCollisionGolf_Stick(Collider collider)
    {
        if (collider.TryGetComponent(out Rigidbody body))
        {
            var dir = (helper.position - m_LastPosition).normalized;
            body.AddForce (dir * power, ForceMode.Impulse);

            if (collider.TryGetComponent (out Ball ball))
            {
                ball.isAffect = true;
            }
        }


        Debug.Log(collider, this);
    }
}
