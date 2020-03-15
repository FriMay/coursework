namespace University.Database.Models {

    public class NotificationStudent {

        public int Id { get; set; }

        public int? StudentId { get; set; }

        public int? NotificationId { get; set; }

        public User Student { get; set; }

        public Notification Notification { get; set; }

    }

}