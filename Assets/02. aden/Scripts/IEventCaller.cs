using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IEventCaller : IEventSystemHandler
{
    void KeyCall(string keyName);
}
