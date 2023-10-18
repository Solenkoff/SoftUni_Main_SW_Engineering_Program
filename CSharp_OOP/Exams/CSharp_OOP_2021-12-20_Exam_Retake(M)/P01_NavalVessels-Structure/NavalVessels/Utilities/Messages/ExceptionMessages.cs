namespace NavalVessels.Utilities.Messages
{
    public static class ExceptionMessages
    {
        //  Captain
        public const string CaptainNotFound = "Captain {0} could not be found.";
        public const string CaptainIsAlreadyHired = "Captain {0} is already hired.";                       
        public const string InvalidCaptainName = "Captain full name cannot be null or empty string.";
        //   Vessel
        public const string AttackVesselArmorThicknessZero = "Unarmored vessel {0} cannot attack or be attacked.";
        public const string InvalidVesselType = "Invalid vessel type.";       
        public const string VesselNotFound = "Vessel {0} could not be found.";
        public const string VesselOccupied = "Vessel {0} is already occupied.";
        public const string VesselIsAlreadyManufactured = "{0} vessel {1} is already manufactured.";
        public const string InvalidVesselName = "Vessel name cannot be null or empty.";
        //   Mix
        public const string InvalidVesselForCaptain = "Null vessel cannot be added to the captain.";
        public const string InvalidCaptainToVessel = "Captain cannot be null.";
        public const string InvalidTarget = "Target cannot be null.";

    }
}
