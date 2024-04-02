using System;

namespace A24_Ex03
{
    public class GasMotorcycle : GasVehicle
    {
        public const int k_GasMotorcycleWheels = 2;
        private eLicenseType m_LicenseType;
        private int m_EngineVolumeCC;
        public const int m_MaxWheelPressure = 29;
        public const float m_MaxFuelAmount = 5.8f;

        public GasMotorcycle(string i_LicenseNumber, string i_ModelName, float i_AirPressure, eLicenseType i_LicenseType, int i_EngineVolumeCC, float i_CurrentFuelAmount)
        {
            for (int i = 0; i < k_GasMotorcycleWheels; i++)
            {
                Wheels.Add(new Wheel { MaxAirPressure = 29, ManufacturerName = "Michelin" });
            }

            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
            FuelType = eFuelType.Octan98;
            MaxFuelAmount = 5.8f;

            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = i_AirPressure;
            }

            m_LicenseType = i_LicenseType;
            m_EngineVolumeCC = i_EngineVolumeCC;
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
