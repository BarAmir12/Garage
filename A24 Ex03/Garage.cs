using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace A24_Ex03
{
    public class Garage
    {
        private readonly List<Vehicle> r_Vehicles ;

        public Garage()
        {
            r_Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            r_Vehicles.Add(vehicle);
        }

        public void ChangeVehicleCondition(string i_LicenseNumber, eVehicleCondition i_NewCondition)
        {
            try
            {
                Vehicle vehicle = GetVehicle(i_LicenseNumber);
                vehicle.Condition = i_NewCondition;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InflateWheels(string i_LicenseNumber)
        {
            try
            {
                Vehicle vehicle = GetVehicle(i_LicenseNumber);
                vehicle.InflateWheels();

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
 
        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    return vehicle;
                }
            }

            throw new FormatException($"Vehicle with license number {i_LicenseNumber} not found.");
        }

        public List<Vehicle> GetListOfVehiclesInGarage()
        {
            return r_Vehicles;
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            bool isValid;

            try
            {
                Vehicle vehicle = GetVehicle(i_LicenseNumber);
                isValid = (vehicle != null);
            }
            catch (FormatException)
            {
                isValid = false;
            }

            return isValid;
        }
    }

}
