using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Skylight
{
	// ����ֻ������д�߼������ݣ�������������Logic�Ĵ��롣
	// ��Ҫ���ⲿ�����Ļ�����Ҫ�����¼������ⲿ���Լ�ע�����Ȥ���¼�
	// �����ʱʹ�� MonoBehaviour ������� ���������ɾ������
	public class LogicBase : MonoBehaviour
	{
		public delegate bool LogicEventHandler (System.Object vars = null);


		public LogicBase ()
		{
			mhtEvent = new Dictionary<int, ArrayList> ();
		}

		public void RegisterCallback (int nEventID, LogicEventHandler handler)
		{
			ArrayList events;
			if (!mhtEvent.TryGetValue (nEventID, out events)) {
				events = new ArrayList ();
				mhtEvent.Add (nEventID, events);
			}
			events.Add (handler);
		}

		public void DoEvent (int nEventID, System.Object vars = null)
		{
			ArrayList events;
			if (!mhtEvent.TryGetValue (nEventID, out events)) {
				return;
			}
            List<object> readyForDelete = new List<object>();
            for(int i = 0; i < events.Count; i++)
            {

                LogicEventHandler handler = events[i]as LogicEventHandler;
                if (handler.Target.Equals(null))
                {
                    Debug.Log("handler.Target.Equals(null)");
                    readyForDelete.Add(events[i]);
                    
                    continue;
                }

                
                if (!handler(vars))
                    break;

                
            }
            if (readyForDelete.Count != 0)
            {
                for (int j = 0; j < readyForDelete.Count; j++)
                {
                    events.Remove(readyForDelete[j]);
                }
            }

        }


		virtual public void LogicInit () { }
		virtual public void LogicShow () { }
		virtual public void LogicClose () { }

		virtual public void Notify (int eventId, System.Object vars = null) { }

		virtual public void LogicStart (int eventId) { }

		Dictionary<int, ArrayList> mhtEvent;
	}
}