using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Common
{
    public static class ExceptionMessages
    {
        public const string NOT_ENOUGH_FUEL_MSG = "{0} needs refueling";
        public const string NEG_FUEL_MSG = "Fuel must be a positive number";
        public const string INV_VEHICLE_TYPE = "Invalid vehicle type!";
        public const string OVR_FUEL_MSG = "Cannot fit {0} fuel in the tank";
    }
}
