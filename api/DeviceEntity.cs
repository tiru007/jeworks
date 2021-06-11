using System;


namespace Device.Function
{
    public class Device
        {
            public string DeviceId { get; set; }

            public string DeviceName { get; set; }

            public string DeviceType { get; set; }

            public string RequestedDate { get; set; }

            public String CompletedDate { get; set; }

            public Int64 ApproximateAmount { get; set; }

            public Int64 ActualAmount { get; set; }

            public String Status { get; set; }

        }
}