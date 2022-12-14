using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace TheCat.Domain.Notifications
{
    public class NotificationContext
    {

        private readonly List<Notification> notifications;
        public IReadOnlyCollection<Notification> Notifications => this.notifications;
        public bool HasNotifications => this.notifications.Any();


        public NotificationContext()
        {
            this.notifications = new List<Notification>();
        }


        public void AddNotification(string key, string message) => this.notifications.Add(new Notification(key, message));

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                this.AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
