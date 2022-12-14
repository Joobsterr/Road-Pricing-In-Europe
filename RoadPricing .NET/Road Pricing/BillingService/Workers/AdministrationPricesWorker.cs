namespace BillingService.Workers
{
    public class AdministrationPricesWorker
    {

        //Mock price methods
        public double GetCarTypePrice(string carType)
        {
            switch (carType)
            {
                case "DEFAULT_VEHTYPE":
                    return 0.05;
                default:
                    return 0.01;
            }
        }

        public double GetRoadTypePrice(double maxSpeedLane)
        {
            switch (maxSpeedLane)
            {
                case < 7:  //20kmh
                    return 0.10;

                case < 9:  //30kmh
                    return 0.15;

                case < 15: //50kmh
                    return 0.25;

                case < 18: //60kmh
                    return 0.30;

                case < 20: //70kmh
                    return 0.35;

                case < 23: //80kmh
                    return 0.40;

                case < 29: //100kmh
                    return 0.50;

                case < 34: //120kmh
                    return 0.60;

                case < 37: //130kmh
                    return 0.65;

                case > 36:
                    return 1.00;

                default:
                    return 0.01;
            }
        }

        public double GetFuelTypePrice(string fuelType)
        {
            switch (fuelType)
            {
                case "Petrol":
                    return 0.05;
                case "Electric":
                    return 0.02;
                default:
                    return 0.01;
            }
        }

        public double GetTimeFramePrice(int hourMark)
        {
            switch (hourMark)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return 0.01;
                case 6:
                case 7:
                case 8:
                case 9:
                    return 0.05;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    return 0.02;
                case 16:
                case 17:
                case 18:
                case 19:
                    return 0.04;
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    return 0.03;
                default:
                    return 0.01;
            }

        }
    }
}
