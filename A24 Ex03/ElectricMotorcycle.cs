using System;

namespace A24_Ex03
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        public const int k_ElectricMotorcycleWheels = 2;
        private eLicenseType m_LicenseType;
        private int m_EngineVolumeCC;
        public const int m_MaxWheelPressure = 29;
        public const float m_MaxBatteryAmount = 2.8f;

        public ElectricMotorcycle(string i_LicenseNumber, string i_ModelName, float i_AirPressure, eLicenseType i_License, int i_EngineVolumeCC, float i_CurrentBatteryAmount)
        {
            for (int i = 0; i < k_ElectricMotorcycleWheels; i++)
            {
                Wheels.Add(new Wheel { MaxAirPressure = 29, ManufacturerName = "Michelin" });
            }

            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = i_AirPressure;
            }

            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
            MaxBatteryTime = 2.8f;
            m_LicenseType = i_License;
            m_EngineVolumeCC = i_EngineVolumeCC;
            RemainingBatteryTime = i_CurrentBatteryAmount;
        }

        public eLicenseType LicenseType
        {
            get 
            {
                return m_LicenseType; 
            }
            set
            {
                m_LicenseType = value; 
            }
        }

        public int EngineVolumeCC
        {
            get
            {
                return m_EngineVolumeCC; 
            }
            set
            {
                m_EngineVolumeCC = value; 
            }
        }
    }
}
