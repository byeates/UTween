using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	/// <summary>
	/// Simple wait system designed to allow you to add a key, and a callback. At some point in the code
	/// execution that key will be marked complete using <see cref="CompleteEvent"/>, at which point if
	/// the event name(s) has been satisfied the callback will be invoked.
	/// </summary>
	public static class Wait
    {
    	//====================
    	// PUBLIC
    	//====================
        public delegate void OnWaitComplete();
        
        //====================
        // PRIVATE
        //====================
        private static List<WaitEvent> waitEvents = new List<WaitEvent>();
        private static List<string> eventNames = new List<string>();
        private static List<string> completedEvents = new List<string>();
    
        //====================
        // CONST
        //====================
        //--------COMMON EVENT NAME--------
        public const string HEARTBEAT = "heartbeat";
        public const string STARTUP = "startup";

        /// <summary>
        /// Clears all the events
        /// </summary>
        public static void Destroy()
        {
	        foreach (var wait in waitEvents)
	        {
		        wait.callback = null;
	        }
	        
	        waitEvents?.Clear();
	        eventNames?.Clear();
	        completedEvents?.Clear();
        }
    
        /// <summary>
        /// Add an event or array of event strings, and a method to call when all of them have been marked
        /// completed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="events"></param>
        public static void AddWaitForEvent(OnWaitComplete callback, params string[] events)
        {
            for (int i = 0; i < events.Length; ++i)
            {
                if (!eventNames.Contains(events[i]))
                {
                    eventNames.Add(events[i]);
                }
            }
            
            waitEvents.Add(new WaitEvent(events, callback));
            CheckCompleteEvents();
        }
    
        /// <summary>
        /// Check if specified event is completed
        /// </summary>
        /// <param name="eventName"></param>
        public static void CompleteEvent(string eventName)
        {
            if (!completedEvents.Contains(eventName))
            {
                completedEvents.Add(eventName);
            }
    
            CheckCompleteEvents();
        }
    
        /// <summary>
        /// Check if events are completed
        /// </summary>
        private static void CheckCompleteEvents()
        {
            List<WaitEvent> finished = new List<WaitEvent>();
            for (int i = 0; i < waitEvents.Count; ++i)
            {
                if (IsEventComplete(waitEvents[i].events))
                {
                    waitEvents[i].callback?.Invoke();
                    finished.Add(waitEvents[i]);
                    waitEvents[i].callback = null;
                }
            }
            
            RemoveEvent(finished);
        }
        
        /// <summary>
        /// Removes event from the wait queue
        /// </summary>
        /// <param name="waitEvent"></param>
        private static void RemoveEvent(WaitEvent waitEvent)
        {
            waitEvents.Remove(waitEvent);
        }
    
        /// <summary>
        /// Removes an event from the wait queue
        /// </summary>
        /// <param name="finishedEvents"></param>
        private static void RemoveEvent(List<WaitEvent> finishedEvents)
        {
            for (int i = 0; i < finishedEvents.Count; ++i)
            {
                waitEvents.Remove(finishedEvents[i]);
            }
        }

        /// <summary>
        /// Allows for a removal of an event from the completed queue
        /// </summary>
        /// <param name="eventName"></param>
        public static void RemoveCompletedEvent(string eventName)
        {
	        if (completedEvents.Contains(eventName))
	        {
		        completedEvents.Remove(eventName);
	        }
        }
        
        /// <summary>
        /// Allows for a removal of an event from the completed queue
        /// </summary>
        /// <param name="events">events to remove</param>
        public static void RemoveCompletedEvents(string[] events)
        {
	        for (int i = 0; i < events.Length; i++)
	        {
		        if (completedEvents.Contains(events[i]))
		        {
			        completedEvents.Remove(events[i]);
		        }
	        }
        }
    
        /// <summary>
        /// Returns true if the specified event name is completed
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static bool IsEventComplete(string eventName)
        {
            for (int i = 0; i < completedEvents.Count; i++)
            {
                if (completedEvents[i].Contains(eventName))
                {
                    return true;
                }
            }
    
            return true;
        }
        
        /// <summary>
        /// Returns true if all the event names are marked completed
        /// </summary>
        /// <param name="eventNames"></param>
        /// <returns></returns>
        public static bool IsEventComplete(string[] eventNames)
        {
            for (int i = 0; i < eventNames.Length; i++)
            {
                if (!completedEvents.Contains(eventNames[i]))
                {
                    return false;
                }
            }
    
            return true;
        }
    
        /*================================================================================
		SIMPLE STRUCT FOR WAIT EVENTS        
        =================================================================================*/
        public class WaitEvent
        {
            public string[] events;
            public OnWaitComplete callback;
            
            public WaitEvent(string[] events, OnWaitComplete callback)
            {
                this.events = events;
                this.callback = callback;
            }
        }
    }
}