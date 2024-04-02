using System;
using System.Collections.Generic;

namespace A24_Ex03
{
    public class GasTruck : GasVehicle
    {
        public const int k_GasTruckWheels = 12;
        private bool m_TransportsHazardousMaterials;
        private float m_CargoVolume;
        public const int m_MaxWheelPressure = 28;
        public const int m_MaxFuelAmount = 110;


        public GasTruck(string i_LicenseNumber, string i_ModelName, float i_AirPressure, float i_CargoVolume, bool i_TransportsHazardousMaterials, float i_CurrentFuelAmount)
        {
            for (int i = 0; i < k_GasTruckWheels; i++)
            {
                Wheels.Add(new Wheel { MaxAirPressure = 28, ManufacturerName = "Michelin" });
            }

            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
            FuelType = eFuelType.Soler;
            MaxFuelAmount = 110f;

            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = i_AirPressure;

            }

            m_CargoVolume = i_CargoVolume;
            m_TransportsHazardousMaterials = i_TransportsHazardousMaterials;
            CurrentFuelAmount = i_CurrentFuelAmount;
        }

        public bool TransportsHazardousMaterials
        {
            get
            {
                return m_TransportsHazardousMaterials; 
            }
            set
            {
                m_TransportsHazardousMaterials = value; 
            }
        }

        public float CargoVolume
        {
            get 
            {
                return m_CargoVolume; 
            }
            set
            {
                m_CargoVolume = value; 
            }
        }
    }
}
