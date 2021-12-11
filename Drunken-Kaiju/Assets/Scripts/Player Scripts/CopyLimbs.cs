using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyLimbs : MonoBehaviour
{

    [SerializeField] private Transform targetLimb;
    [SerializeField] private ConfigurableJoint m_configurableJoint;

    public bool canCopy;

    Quaternion targetInitialRotation;
    // Start is called before the first frame update
    void Start()
    {
        this.m_configurableJoint = this.GetComponent<ConfigurableJoint>();
        this.targetInitialRotation = this.targetLimb.transform.localRotation;
    }

    private void FixedUpdate()
    {
        if (canCopy)
        {
            this.m_configurableJoint.targetRotation = copyRotation();
        }
    }

    private Quaternion copyRotation()
    {
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    }
}
