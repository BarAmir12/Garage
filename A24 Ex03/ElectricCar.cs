using System;

namespace A24_Ex03
{
    public class ElectricCar : ElectricVehicle
    {
        public const int k_ElectricCarWheels = 4;
        private eColor m_Color;
        private eNumberOfDoors m_VehicleNumberOfDoors;
        private int m_NumberOfDoors;
        public const int m_MaxWheelPressure = 30;
        public const float m_MaxBatteryAmount = 4.8f;

        public ElectricCar(string i_LicenseNumber, string i_ModelName, float i_AirPressure, eColor i_Color, eNumberOfDoors i_NumberOfDoors, float i_CurrentFuelAmount)
        {
            for (int i = 0; i < k_ElectricCarWheels; i++)
            {
                Wheels.Add(new Wheel { MaxAirPressure = 30, ManufacturerName = "Michelin" });
            }

            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = i_AirPressure;
            }

            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
            MaxBatteryTime = 4.8f;
            m_Color = i_Color;
            m_VehicleNumberOfDoors = i_NumberOfDoors;
            RemainingBatteryTime = i_CurrentFuelAmount;
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

        public int NumberOfDoors
        {
            get 
            {
                return m_NumberOfDoors; 
            }
            set
            {
                m_NumberOfDoors = value; 
            }
        }
    }
}
