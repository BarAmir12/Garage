using System;

namespace A24_Ex03
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;

        public float RemainingBatteryTime
        {
            get 
            {
                return m_RemainingBatteryTime; 
            }
            set
            {
                m_RemainingBatteryTime = value; 
            }
        }

        public float MaxBatteryTime
        {
            get
            {
                return m_MaxBatteryTime; 
            }
            set
            {
                m_MaxBatteryTime = value; 
            }
        }

        public void Charge(float i_Minutes)
        {
            if (i_Minutes <= 0)
            {
                throw new ArgumentException("The amount of charge must be greater than zero");
            }

            if (RemainingBatteryTime + i_Minutes > MaxBatteryTime)
            {
                throw new ArgumentException("Unable to charge, the amount exceeds the maximum power capacity");
            }

            RemainingBatteryTime += i_Minutes;
        }
    }
}
