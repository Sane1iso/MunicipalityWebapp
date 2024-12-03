using System;

namespace prog
{
    // Add a priority and updated timestamp to your service request class
    public class ServiceRequest
    {
        public int RequestID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string Priority { get; set; }  
        public DateTime LastUpdated { get; set; } 

    }
}