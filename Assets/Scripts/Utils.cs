using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Utils
    {
        public static IEnumerator RotateObject(Transform objectToRotate, Vector3 targetRotation, float rotationDuration, [CanBeNull] Action endCallback)
        {
            Vector3 newAngle = objectToRotate.transform.rotation.eulerAngles;
            float currentElapsed = 0f;

            while (objectToRotate.transform.rotation.eulerAngles != targetRotation)
            {
                newAngle = Vector3.Lerp(newAngle, targetRotation, currentElapsed / rotationDuration);
                objectToRotate.transform.rotation = Quaternion.Euler(newAngle);
                currentElapsed += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            newAngle = targetRotation;
            objectToRotate.transform.rotation = Quaternion.Euler(newAngle);
            endCallback?.Invoke();
        }
    }
}