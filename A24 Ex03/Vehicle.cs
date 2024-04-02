using System.Collections.Generic;

namespace A24_Ex03
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleCondition m_Condition;

        public string ModelName
        {
            get
            {
                return m_ModelName; 
            }
            set
            {
                m_ModelName = value; 
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber; 
            }
            set
            {
                m_LicenseNumber = value; 
            }
        }

        public List<Wheel> Wheels
        {
            get 
            {
                return m_Wheels; 
            }
            set
            {
                m_Wheels = value; 
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName; 
            }
            set
            {
                m_OwnerName = value; 
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone; 
            }
            set
            {
                m_OwnerPhone = value; 
            }
        }

        public eVehicleCondition Condition
        {
            get
            {
                return m_Condition; 
            }
            set
            {
                m_Condition = value; 
            }
        }

        public Vehicle()
        {
            Wheels = new List<Wheel>();
        }

        public void InflateWheels()
        {
            foreach (Wheel wheel in Wheels)
            {
                float pressureToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.Inflate(pressureToAdd);
            }
        }
    }
}
