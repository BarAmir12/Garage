using System;

namespace A24_Ex03
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public string ManufacturerName
        {
            get 
            {
                return m_ManufacturerName; 
            }
            set
            {
                m_ManufacturerName = value; 
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure; 
            }
            set
            {
                m_MaxAirPressure = value; 
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure; 
            }
            set
            {
                
                    if (value < 0)
                    {
                        throw new ArgumentException("Air pressure cannot be negative");
                    }
                    m_CurrentAirPressure = value;
                
            }
        }

        public void Inflate(float i_Amount)
        {
            
                if (CurrentAirPressure + i_Amount > MaxAirPressure)
                {
                    throw new ValueOutOfRangeException("Cannot inflate beyond maximum air pressure");
                }

                CurrentAirPressure += i_Amount;
            
        }
    }
}
