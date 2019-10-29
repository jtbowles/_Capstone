using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Utilities
{
    public static class Email
    {
        public const string ApplicationMessage =
            " just submitted an adoption application. Please review to either confirm or deny.";

        public const string AppointmentMessage =
            " has requested an appointment. Please review to confirm or decline appointment time.";

        public const string AppointmentConfirmed = 
            " has confirmed your appointment. We look forward to seeing you!";

        public const string AppointmentDenied =
            "We are currently unavailable for an appointment at that time. Sorry for the inconvenience.";

    }
}