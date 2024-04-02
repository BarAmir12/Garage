using System;

namespace A24_Ex03
{
    public class GasCar : GasVehicle
    {
        public const int k_GasCarWheels = 4;
        private eColor m_Color;
        private eNumberOfDoors m_VehicleNumberOfDoors;
        public const int m_MaxWheelPressure = 30;
        public const int m_MaxFuelAmount = 58;
        public GasCar(string i_LicenseNumber, string i_ModelName, float i_AirPressure, eColor i_Color, eNumberOfDoors i_NumberOfDoors, float i_CurrentFuelAmount)
        {
            for (int i = 0; i < k_GasCarWheels; i++)
            {
                Wheels.Add(new Wheel { MaxAirPressure = 30, ManufacturerName = "Michelin" });
            }

            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
            FuelType = eFuelType.Octan95;
            MaxFuelAmount = 58f;

            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = i_AirPressure;
            }

            m_Color = i_Color;
            m_VehicleNumberOfDoors = i_NumberOfDoors;
            CurrentFuelAmount = i_CurrentFuelAmount;
        }

        public eColor Color
        {
            get 
            {
                return m_Color; 
            }
            set
            {
                m_Color = value; 
            }
        }

        public eNumberOfDoors VehicleNumberOfDoors
        {
            get
            {
                return m_VehicleNumberOfDoors; 
            }
            set
            {
                m_VehicleNumberOfDoors = value; 
            }
        }
    }
}
