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

        public const string ApplicationConfirmed =
            "Congratulations! your application has been approved! At this time you can go and reserve your spot in the litter of your choosing.";

        public const string ApplicationDenied =
            "After reviewing your application we have come to the decision to deny your request. We are very sorry but your application did not meet the proper requirements.";

        public const string SpotReserved = " has reserved a spot! Time to upgrade their account to 'Owner'";
    }
}