using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notification : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.High,
            Description = "Reminder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        NotificationsDailyLogin();
        NotificationsDailySpin();
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void NotificationsDailyLogin()
    {
        if (PlayerPrefs.GetInt("Notification") == 1)
        {
            AndroidNotification notification = new AndroidNotification();
            notification.Title = "Claim Daily Rewards";
            notification.Text = "Entering Culinary Emerald Equator and Claim Daily Rewards";
            notification.SmallIcon = "icon_0";
            notification.LargeIcon = "icon_1";
            notification.ShowTimestamp = true;
            notification.FireTime = System.DateTime.Now.AddHours(24);

            var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

            if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
            {
                AndroidNotificationCenter.CancelAllNotifications();
                AndroidNotificationCenter.SendNotification(notification, "channel_id");
            }
        }
            
    }

    public void NotificationsDailySpin()
    {
        if (PlayerPrefs.GetInt("Notification") == 1)
        {
            AndroidNotification notification = new AndroidNotification();
            notification.Title = "Claim Free Spin";
            notification.Text = "Free Spin Available! Spin Now! and Claim Spin Rewards";
            notification.SmallIcon = "icon_0";
            notification.LargeIcon = "icon_1";
            notification.ShowTimestamp = true;
            notification.FireTime = System.DateTime.Now.AddHours(12);

            var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

            if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
            {
                AndroidNotificationCenter.CancelAllNotifications();
                AndroidNotificationCenter.SendNotification(notification, "channel_id");
            }
        }
    }
}
