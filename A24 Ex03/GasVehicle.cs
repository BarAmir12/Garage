using System;

namespace A24_Ex03
{
    public abstract class GasVehicle : Vehicle
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;

        public eFuelType FuelType
        {
            get 
            {
                return m_FuelType; 
            }
            set
            {
                m_FuelType = value; 
            }
        }

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmount; 
            }
            set
            {
                m_CurrentFuelAmount = value; 
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return m_MaxFuelAmount; 
            }
            set
            {
                m_MaxFuelAmount = value; 
            }
        }

        public void Refuel(float i_Amount, eFuelType i_FuelType)
        {
            
                if (i_Amount <= 0)
                {
                    throw new ArgumentException("Fuel amount must be greater than zero");
                }

                if (CurrentFuelAmount + i_Amount > MaxFuelAmount)
                {
                    throw new ArgumentException("Cannot refuel, amount exceeds maximum fuel capacity");
                }

                if (i_FuelType != FuelType)
                {
                    throw new ArgumentException("Invalid fuel type");
                }

                CurrentFuelAmount += i_Amount;
        }
    }
}
