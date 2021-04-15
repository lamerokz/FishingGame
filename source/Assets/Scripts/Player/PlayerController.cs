using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject netPrefab;
    public Transform gunBarrelTrans;
    public float fireInterval = 1.0f;
    bool isFireCD = false;
    public GameObject gunAimLineGO;

    public Animator animator;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (AppController.Instance.isPause)
            return;

        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gunBarrelTrans.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


        gunAimLineGO.SetActive(Input.GetMouseButton(0));
        gunAimLineGO.GetComponent<SpriteRenderer>().color = isFireCD ? new Color(0.5f,  0.5f,  0.5f, 0.3f) : new Color(1.0f,0,0,0.6f);

        if (Input.GetMouseButtonUp(0))
        {
            if (!isFireCD)
            {
                animator.SetTrigger("Fish");
                FireNet();
            }
        }
    }

    void FireNet()
    {
        if (netPrefab)
        {
            GameObject netGO = GameObject.Instantiate(netPrefab);
            netGO.transform.position = gunBarrelTrans.position;
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - netGO.transform.position;
            dir.z = 0;
            netGO.GetComponent<NetController>().direction = dir.normalized;
        }

        isFireCD = true;
        StartCoroutine(FireCDTimer());
    }
    private IEnumerator FireCDTimer()
    { 
       yield return new WaitForSeconds(fireInterval);

        animator.ResetTrigger("Fish");
        isFireCD = false;

    }
}
