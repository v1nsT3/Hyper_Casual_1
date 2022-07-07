using System.Collections;
using UnityEngine;

public class Spear : MonoBehaviour
{
    //public override void Attach(Rigidbody rigidbody)
    //{
    //    if (_isAttached)
    //        return;

    //    _hingeJoint.connectedBody = rigidbody;
    //    _currentRigidbody.isKinematic = false;
    //    _isAttached = true;
    //}

    //public override void Throwing()
    //{
    //    t += Time.deltaTime / _speed;
    //    transform.position = Bezier.GetPoint(_gunController.p0.position, _gunController.p1.position, _gunController.p2.position, _gunController.target.position, t);
    //    transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(_gunController.p0.position, _gunController.p1.position, _gunController.p2.position, _gunController.target.position, t));
    //}

    //public override void ReturnToStart()
    //{
    //    foreach (Joint joint in _joints)
    //    {
    //        joint.isConnected = false;

    //    }

    //    _isAttached = false;

    //    _currentRagdollConnect.Clear();

    //    _hingeJoint.connectedBody = null;
    //    _hingeJoint.connectedAnchor = Vector3.zero;

    //    t = 0f;

    //    transform.localPosition = Vector3.zero;
    //    transform.localRotation = Quaternion.Euler(0, 0, 0);

    //    _currentRigidbody.isKinematic = true;

    //}

    //public override void Throwing()
    //{
    //    StartCoroutine(ThrowDelay());
    //}

    //private IEnumerator ThrowDelay()
    //{
    //    Vector3[] pathf = _trajectory.GetTrajectory();

    //    int index = 0;

    //    while (index != pathf.Length)
    //    {
    //        Vector3 target = transform.position - pathf[index];
    //        if (Vector3.Distance(transform.position, target) < 0.1f)
    //            index++;

    //        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);

    //        yield return null;
    //    }
    //}
}
