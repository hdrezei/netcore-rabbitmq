﻿using nyom.domain.core.Models;
using nyom.domain.Entities;
using nyom.domain.Interfaces;

namespace nyom.domain.Notifications
{
    public class NotificationService : ServiceBase<Notification> ,INotificationService
    {
	    private readonly INotificationRepository _notificationRepository;

	    public NotificationService(INotificationRepository notificationRepository) : base(notificationRepository)
	    {
		    _notificationRepository = notificationRepository;
	    }
    }
}
