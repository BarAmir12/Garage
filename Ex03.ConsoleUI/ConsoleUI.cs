using System;
using System.Collections.Generic;
using System.Linq;

namespace A24_Ex03
{

    public class ConsoleUI
    {
        private readonly Garage m_GarageLogic;
        private const int ZeroValue = 0;
        public ConsoleUI()
        {
            m_GarageLogic = new Garage();
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                ConsoleOutput.Message("");
                ConsoleOutput.Message("Menu:");
                ConsoleOutput.Message("1. Put a new vehicle in the garage");
                ConsoleOutput.Message("2. Show the list of vehicles in the garage");
                ConsoleOutput.Message("3. Change the status of a vehicle");
                ConsoleOutput.Message("4. Inflate the wheels of a vehicle");
                ConsoleOutput.Message("5. Refuel a vehicle");
                ConsoleOutput.Message("6. Charge an electric vehicle");
                ConsoleOutput.Message("7. Display complete vehicle data by license number");
                ConsoleOutput.Message("8. Exit");
                ConsoleOutput.Message("");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PutNewVehicleInGarage();
                        break;
                    case "2":
                        ShowListOfVehiclesInGarage();
                        break;
                    case "3":
                        ChangeVehicleStatus();
                        break;
                    case "4":
                        InflateWheels();
                        break;
                    case "5":
                        RefuelVehicle();
                        break;
                    case "6":
                        ChargeElectricVehicle();
                        break;
                    case "7":
                        DisplayVehicleDataByLicenseNumber();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        try
                        {
                            throw new ValueOutOfRangeException("Invalid choice.", 1, 8);
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            ConsoleOutput.Message(ex.Message);
                        }
                        break;
                }

            }
        }

        public void PutNewVehicleInGarage()
        {
            string licenseNumber, modelName, ownerName, ownerPhone;
            bool isLicenseValid, isTransportsHazardousMaterial;
            float airPressure, currentFuelAmount, currentBatteryAmount;
            int engineVolumeCC, cargoVolume;
            eVehicleType vehicleType;
            eColor e_Color;
            eLicenseType e_LicenseMotorCycle;
            eNumberOfDoors numberOfDoors;
            Vehicle newVehicle;

            isLicenseValid = ChooseNumberLicense(out licenseNumber);
            if (isLicenseValid)
            {
                vehicleType = ChooseVehicleType();
                modelName = ChooseModelName();
                ownerName = ChooseOwnerName();
                ownerPhone = ChooseOwnerPhone();

                switch (vehicleType)
                {
                    case eVehicleType.GasCar:


                        airPressure = ChooseAirPressure(ZeroValue, GasCar.m_MaxWheelPressure, eVehicleType.GasCar.ToString());
                        e_Color = ChooseColor();
                        numberOfDoors = ChooseDoor();
                        currentFuelAmount = ChooseAmount(ZeroValue, GasCar.m_MaxFuelAmount, eEnergy.Fuel.ToString());
                        newVehicle = new GasCar(licenseNumber, modelName, airPressure, e_Color, numberOfDoors, currentFuelAmount);

                        break;
                    case eVehicleType.ElectricCar:

                        airPressure = ChooseAirPressure(ZeroValue, ElectricCar.m_MaxWheelPressure, eVehicleType.ElectricCar.ToString());
                        e_Color = ChooseColor();
                        numberOfDoors = ChooseDoor();
                        currentBatteryAmount = ChooseAmount(ZeroValue, ElectricCar.m_MaxBatteryAmount, eEnergy.Battery.ToString());
                        newVehicle = new ElectricCar(licenseNumber, modelName, airPressure, e_Color, numberOfDoors, currentBatteryAmount);

                        break;
                    case eVehicleType.GasMotorcycle:

                        e_LicenseMotorCycle = ChooseTypeOfLicense();
                        currentFuelAmount = ChooseAmount(ZeroValue, GasMotorcycle.m_MaxFuelAmount, eEnergy.Fuel.ToString());
                        engineVolumeCC = ChooseEngineVolume();
                        airPressure = ChooseAirPressure(ZeroValue, GasMotorcycle.m_MaxWheelPressure, eVehicleType.GasMotorcycle.ToString());
                        newVehicle = new GasMotorcycle(licenseNumber, modelName, airPressure, e_LicenseMotorCycle, engineVolumeCC, currentFuelAmount);

                        break;
                    case eVehicleType.ElectricMotorcycle:

                        e_LicenseMotorCycle = ChooseTypeOfLicense();
                        currentBatteryAmount = ChooseAmount(ZeroValue, ElectricMotorcycle.m_MaxBatteryAmount, eEnergy.Battery.ToString());
                        engineVolumeCC = ChooseEngineVolume();
                        airPressure = ChooseAirPressure(ZeroValue, ElectricMotorcycle.m_MaxWheelPressure, eVehicleType.ElectricMotorcycle.ToString());
                        newVehicle = new ElectricMotorcycle(licenseNumber, modelName, airPressure, e_LicenseMotorCycle, engineVolumeCC, currentBatteryAmount);

                        break;
                    case eVehicleType.GasTruck:

                        currentFuelAmount = ChooseAmount(ZeroValue, GasTruck.m_MaxFuelAmount, eEnergy.Fuel.ToString());
                        cargoVolume = ChooseCargoVolume();
                        isTransportsHazardousMaterial = ChooseTransportsHazardousMaterial();
                        airPressure = ChooseAirPressure(ZeroValue, GasTruck.m_MaxWheelPressure, eVehicleType.GasTruck.ToString());
                        newVehicle = new GasTruck(licenseNumber, modelName, airPressure, cargoVolume, isTransportsHazardousMaterial, currentFuelAmount);

                        break;
                    default:
                        ConsoleOutput.Message("Invalid vehicle type.");

                        return;
                }

                eVehicleCondition condition = eVehicleCondition.UnderRepair;
                newVehicle.Condition = condition;
                newVehicle.OwnerName = ownerName;
                newVehicle.OwnerPhone = ownerPhone;
                m_GarageLogic.AddVehicle(newVehicle);
            }
        }

        public void ShowListOfVehiclesInGarage()
        {
            bool filterByCondition;
            List<Vehicle> vehicles;

            vehicles = m_GarageLogic.GetListOfVehiclesInGarage();
            ConsoleOutput.Message("List of Vehicles in the Garage:");
            foreach (Vehicle vehicle in vehicles)
            {
                string vehicleData = $"License Number: {vehicle.LicenseNumber}, Condition: {vehicle.Condition}";
                ConsoleOutput.Message(vehicleData);
            }

            filterByCondition = ChooseConfirmation("Do you want to filter by condition? (Y/N)");
            if (filterByCondition)
            {
                eVehicleCondition filterCondition = ChooseEnumValue<eVehicleCondition>("Enter condition to filter by:");
                List<Vehicle> filteredVehicles = vehicles.Where(v => v.Condition == filterCondition).ToList();
                ConsoleOutput.Message("Filtered Vehicles:");
                foreach (Vehicle vehicle in filteredVehicles)
                {
                    string vehicleData = $"License Number: {vehicle.LicenseNumber}, Condition: {vehicle.Condition}";
                    ConsoleOutput.Message(vehicleData);
                }
            }
        }

        public void ChangeVehicleStatus()
        {
            string licenseNumber;
            Vehicle vehicle;
            eVehicleCondition newCondition;

            ConsoleOutput.Message("Enter license number of the vehicle: ");
            licenseNumber = Console.ReadLine();
            try
            {
                vehicle = m_GarageLogic.GetVehicle(licenseNumber);
                if (vehicle == null)
                {
                    ConsoleOutput.Message("Invalid license number.");
                    return;
                }

                newCondition = ChooseEnumValue<eVehicleCondition>("Enter new status:");
                m_GarageLogic.ChangeVehicleCondition(licenseNumber, newCondition);
            }
            catch (FormatException ex)
            {
                ConsoleOutput.Message(ex.Message);
            }
        }

        public void InflateWheels()
        {
            string licenseNumber;

            ConsoleOutput.Message("Enter license number of the vehicle: ");
            licenseNumber = Console.ReadLine();
            m_GarageLogic.InflateWheels(licenseNumber);
        }

        public void RefuelVehicle()
        {
            string licenseNumber;
            string input;
            float amount;
            eFuelType fuelType;
            GasVehicle gasVehicle;
            Vehicle vehicle;

            ConsoleOutput.Message("Enter license number of the vehicle: ");
            licenseNumber = Console.ReadLine();

            try
            {
                vehicle = m_GarageLogic.GetVehicle(licenseNumber);
                CheckGasVehicle(vehicle);
                ConsoleOutput.Message("Enter amount of fuel to refuel: ");
                input = Console.ReadLine();
                if (CheckNumber(input))
                {
                    amount = Convert.ToSingle(input);
                    fuelType = ChooseEnumValue<eFuelType>("Enter fuel type:");
                    gasVehicle = vehicle as GasVehicle;
                    if (CheckGasNotNull(gasVehicle))
                    {
                        gasVehicle.Refuel(amount, fuelType);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                ConsoleOutput.Message(ex.Message);
            }
            catch (FormatException ex)
            {
                ConsoleOutput.Message(ex.Message);
            }
        }

        public void ChargeElectricVehicle()
        {
            string input;
            float minutes;
            string licenseNumber;
            Vehicle vehicle;
            ElectricVehicle electricVehicle;

            ConsoleOutput.Message("Enter license number of the vehicle: ");
            licenseNumber = Console.ReadLine();

            try
            {
                vehicle = m_GarageLogic.GetVehicle(licenseNumber);
                CheckElectricVehicle(vehicle);
                ConsoleOutput.Message("Enter charging time in minutes: ");
                input = Console.ReadLine();
                if (CheckNumber(input))
                {
                    minutes = Convert.ToSingle(input);
                    electricVehicle = vehicle as ElectricVehicle;
                    if (CheckElectricNotNull(electricVehicle))
                    {
                        electricVehicle.Charge(minutes);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                ConsoleOutput.Message(ex.Message);
            }
            catch (FormatException ex)
            {
                ConsoleOutput.Message(ex.Message);
            }
        }

        public static T ChooseEnumValue<T>(string i_Prompt) where T : Enum
        {
            bool isValidInput = false;
            T selectedEnum = default;
            string userInput;

            while (!isValidInput)
            {
                ConsoleOutput.Message(i_Prompt);
                foreach (var value in Enum.GetValues(typeof(T)))
                {
                    ConsoleOutput.Message($"{Convert.ToInt32(value)} - {value}");
                }

                try
                {
                    userInput = Console.ReadLine();
                    if(CheckNumber(userInput))
                    {
                        selectedEnum = (T)Enum.Parse(typeof(T), userInput);
                        if (CheckRangeEnum(selectedEnum))
                        {
                            isValidInput = true;
                        }
                    }
                }
                catch (FormatException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }
            }

            return selectedEnum;
        }

        public eColor ChooseColor()
        {
            eColor selectedColor = ChooseEnumValue<eColor>("Enter color:");

            return selectedColor;
        }

        public eLicenseType ChooseTypeOfLicense()
        {
            eLicenseType selectedLicense = ChooseEnumValue<eLicenseType>("Enter type of license:");

            return selectedLicense;
        }

        public eVehicleType ChooseVehicleType()
        {
            eVehicleType selectedVehicle = ChooseEnumValue<eVehicleType>("Enter vehicle type:");

            return selectedVehicle;
        }

        public eNumberOfDoors ChooseDoor()
        {
            eNumberOfDoors selectedDoors = ChooseEnumValue<eNumberOfDoors>("Enter doors:");

            return selectedDoors;
        }

        public string ChooseInput(string i_FieldName, Func<string, bool> i_Validation)
        {
            string input;
            bool validInput = false;

            do
            {
                ConsoleOutput.Message($"Enter {i_FieldName}: ");
                input = Console.ReadLine().Trim();
                try
                {
                    if (i_Validation(input) && CheckNotEmpty(input))
                    {
                        validInput = true;
                    }
                }
                catch (FormatException ex)
                {
                    ConsoleOutput.Message(ex.Message);

                }
            } while (!validInput);

            return input;
        }

        public string ChooseModelName()
        {
            string modelName = ChooseInput("Model Name", CheckModel);

            return modelName;
        }

        public string ChooseOwnerName()
        {
            string ownerName = ChooseInput("Owner Name", CheckOwnerName);

            return ownerName;
        }

        public string ChooseOwnerPhone()
        {
            string ownerPhone = ChooseInput("Owner Phone", CheckOwnerPhone);

            return ownerPhone;
        }

        public bool ChooseNumberLicense(out string io_LicenseNumber)
        {
            bool license = true;
            bool isRunnig = true;
            Vehicle vehicle;

            do
            {
                ConsoleOutput.Message("Enter the license number of the vehicle: ");
                io_LicenseNumber = Console.ReadLine().Trim();
                try
                {
                    if (CheckNotEmpty(io_LicenseNumber) && m_GarageLogic.IsVehicleInGarage(io_LicenseNumber))
                    {
                        vehicle = m_GarageLogic.GetVehicle(io_LicenseNumber);
                        if (CheckStatusPaid(vehicle))
                        {
                            m_GarageLogic.ChangeVehicleCondition(io_LicenseNumber, eVehicleCondition.UnderRepair);
                            ConsoleOutput.Message("Vehicle with the same license number already exists in the garage and has been changed to 'UnderRepair'.");
                            license = false;
                            isRunnig = false;
                        }
                    }
                    else
                    {
                        license = true;
                        isRunnig = false;
                    }
                }
                catch (ArgumentException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }
                catch (FormatException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }

            } while (isRunnig);

            return license;
        }

        public int ChooseVolume(string i_Prompt)
        {
            string chooseVolume;
            int volume =-1;
            bool valid;

            do
            {
                valid = false; 
                ConsoleOutput.Message(i_Prompt);
                chooseVolume = Console.ReadLine().Trim();
                try
                {
                    if (CheckNumber(chooseVolume))
                    {
                        volume = Convert.ToInt32(chooseVolume);
                        if (CheckRangeBigOfNumber(volume))
                        { 
                            return volume;
                        }
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }
                catch (FormatException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }
            } while (!valid); 

            return volume;
        }

        public int ChooseEngineVolume()
        {
            int engineVolume = ChooseVolume("Enter engine volume in cc: ");

            return engineVolume;
        }

        public int ChooseCargoVolume()
        {
            int cargoVolume = ChooseVolume("Enter cargo volume: ");

            return cargoVolume;
        }

        public float ChooseValue(int i_Min, float i_Max, string i_Name)
        {
            string chooseValue;
            bool validInput = false;
            float value = -1;

            do
            {
                ConsoleOutput.Message($"Enter current {i_Name}, the range is: ({i_Min} - {i_Max}): ");
                chooseValue = Console.ReadLine().Trim();
                try
                {
                    if (CheckNumber(chooseValue))
                    {
                        value = Convert.ToSingle(chooseValue);
                        if (CheckRangebetweenNumber(value, i_Min, i_Max, i_Name))
                        {
                            return value;
                        }
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }
                catch (FormatException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }
            } while (!validInput);

            return value;
        }

        public float ChooseAmount(int i_Min, float i_Max, string i_Name)
        {
            float fuelAmount = ChooseValue(i_Min, i_Max, i_Name);

            return fuelAmount;

        }

        public float ChooseAirPressure(int i_Min, float i_Max, string i_Name)
        {
            i_Name = "airpressure " + i_Name;
            float airPressure = ChooseValue(i_Min, i_Max, i_Name);

            return airPressure;

        }

        public bool ChooseTransportsHazardousMaterial()
        {
            bool validInput = true;
            bool isTransportsHazardousMaterial = false;

            while (validInput)
            {
                isTransportsHazardousMaterial = ChooseConfirmation("Does the truck transport hazardous materials? (Y/N)");
                validInput = false;
            }

            return isTransportsHazardousMaterial;
        }

        public bool ChooseConfirmation(string i_Message)
        {
            bool isValid = true;
            bool isRunning = true;
            string inputStr;
            char input;

            while (isRunning)
            {
                try
                {
                    ConsoleOutput.Message(i_Message);
                    inputStr = Console.ReadLine().Trim();
                    if (CheckNotEmpty(inputStr))
                    {
                        input = inputStr.ToUpperInvariant()[0];
                        if (CheckDigit(input))
                        {
                            if (input == 'Y')
                            {
                                isValid = true;
                                isRunning = false;
                            }
                            else
                            {
                                isValid = false;
                                isRunning = false;
                            }
                        }
                        
                    }
                }
                catch (FormatException ex)
                {
                    ConsoleOutput.Message(ex.Message);
                }
            }

            return isValid;
        }

        public void CheckGasVehicle(Vehicle i_Vehicle)
        {
            if (i_Vehicle is ElectricVehicle)
            {
                throw new ArgumentException("Cannot refuel an electric vehicle.");
            }
        }

        public void CheckElectricVehicle(Vehicle i_Vehicle)
        {
            if (i_Vehicle is GasVehicle)
            {
                throw new ArgumentException("Cannot charge a gas vehicle.");
            }
        }

        public bool CheckGasNotNull(GasVehicle i_ElectricVehicle)
        {
            bool isValid;

            if (i_ElectricVehicle == null)
            {
                throw new FormatException("Invalid vehicle type.");
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public bool CheckElectricNotNull(ElectricVehicle i_ElectricVehicle)
        {
            bool isValid;

            if (i_ElectricVehicle == null)
            {
                throw new FormatException("Invalid vehicle type.");
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public bool CheckModel(string i_Input)
        {
            bool isValid = true;

            if (!i_Input.All(char.IsLetterOrDigit))
            {
                throw new FormatException("Invalid input. Please enter a valid option.");
            }

            return isValid;
        }

        public bool CheckOwnerName(string i_Input)
        {
            foreach (char digit in i_Input)
            {
                if (!char.IsLetter(digit) && !char.IsWhiteSpace(digit))
                {
                    throw new FormatException("Invalid input. Please enter a valid option.");
                }
            }

            return true;
        }

        public bool CheckOwnerPhone(string i_Input)
        {
            bool isValid = true;

            if (i_Input.Length != 10 || !i_Input.All(char.IsDigit))
            {
                throw new FormatException("Invalid input. Please enter a valid option.");
            }

            return isValid;
        }

        public bool CheckNotEmpty(string i_Input)
        {
            bool isValid;

            if (string.IsNullOrWhiteSpace(i_Input))
            {
                throw new FormatException("The input cannot be empty. Please enter a valid input.");
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool CheckNumber(string i_UserInput)
        {
            bool isValid;

            if (!int.TryParse(i_UserInput, out _))
            {
                throw new FormatException("Invalid input. Please enter a valid option.");
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool CheckRangeEnum<T>(T selectedEnum)
        {
            bool isValid;

            if (!Enum.IsDefined(typeof(T), selectedEnum))
            {
                int minValue = Convert.ToInt32(Enum.GetValues(typeof(T)).Cast<T>().Min());
                int maxValue = Convert.ToInt32(Enum.GetValues(typeof(T)).Cast<T>().Max());
                throw new ValueOutOfRangeException("Invalid input. Please enter a valid option.", minValue, maxValue);
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public bool CheckStatusPaid(Vehicle vehicle)
        {
            bool isValid;

            if (!(vehicle.Condition == eVehicleCondition.Paid))
            {
                throw new ArgumentException("Vehicle with the same license number already exists in the garage and is already 'UnderRepair'. Please enter a different license number.");
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public bool CheckRangeBigOfNumber(int i_Number)
        {
            bool isValid;

            if (!(i_Number >= 0))
            {
                throw new ValueOutOfRangeException("The value must be greater than", 0);
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public bool CheckRangebetweenNumber(float i_Number, int i_Min, float i_Max, string i_Name)
        {
            bool isValid;

            if (!(i_Number >= i_Min && i_Number <= i_Max))
            {
                throw new ValueOutOfRangeException($"The {i_Name} value is out of range.", i_Min, i_Max);
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public bool CheckDigit(char i_Input)
        {
            bool isValid;

            if (!(i_Input == 'Y' || i_Input == 'N'))
            {
                throw new FormatException("Invalid input. Please enter 'Y' or 'N'.");
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public void DisplayVehicleDataByLicenseNumber()
        {
            ConsoleOutput.Message("Enter license number of the vehicle: ");
            string licenseNumber = Console.ReadLine();

            try
            {
                Vehicle vehicle = m_GarageLogic.GetVehicle(licenseNumber);

                if (vehicle != null)
                {
                    ConsoleOutput.Message($"Model: {vehicle.ModelName}");
                    ConsoleOutput.Message($"License Number: {vehicle.LicenseNumber}");
                    ConsoleOutput.Message($"Owner's Name: {vehicle.OwnerName}");
                    ConsoleOutput.Message($"Owner's Phone Number: {vehicle.OwnerPhone}");
                    ConsoleOutput.Message($"Condition: {vehicle.Condition}");

                    if (vehicle is GasCar gasCar)
                    {
                        ConsoleOutput.Message($"Color: {gasCar.Color}");
                        ConsoleOutput.Message($"Number of Doors: {gasCar.VehicleNumberOfDoors}");
                    }
                    if (vehicle is ElectricCar electricCar)
                    {
                        ConsoleOutput.Message($"Color: {electricCar.Color}");
                        ConsoleOutput.Message($"Number of Doors: {electricCar.VehicleNumberOfDoors}");
                    }
                    else if (vehicle is GasMotorcycle || vehicle is ElectricMotorcycle)
                    {
                        if (vehicle is GasMotorcycle gasMotorcycle)
                        {
                            ConsoleOutput.Message($"License Type: {gasMotorcycle.LicenseType}");
                            ConsoleOutput.Message($"Engine Volume: {gasMotorcycle.EngineVolumeCC}");
                        }
                        else if (vehicle is ElectricMotorcycle electricMotorcycle)
                        {
                            ConsoleOutput.Message($"License Type: {electricMotorcycle.LicenseType}");
                            ConsoleOutput.Message($"Engine Volume: {electricMotorcycle.EngineVolumeCC}");
                        }
                    }
                    else if (vehicle is GasTruck gasTruck)
                    {
                        ConsoleOutput.Message($"Transports Hazardous Materials: {gasTruck.TransportsHazardousMaterials}");
                        ConsoleOutput.Message($"Cargo Volume: {gasTruck.CargoVolume}");
                    }

                    foreach (Wheel wheel in vehicle.Wheels)
                    {
                        ConsoleOutput.Message($"Wheel Manufacturer: {wheel.ManufacturerName}");
                        ConsoleOutput.Message($"Wheel Air Pressure: {wheel.CurrentAirPressure}");
                    }


                    if (vehicle is GasVehicle fuelVehicle)
                    {
                        ConsoleOutput.Message($"Fuel Type: {fuelVehicle.FuelType}");
                        ConsoleOutput.Message($"Current Fuel Amount: {fuelVehicle.CurrentFuelAmount}");
                        ConsoleOutput.Message($"Maximum Fuel Amount: {fuelVehicle.MaxFuelAmount}");
                    }
                    else if (vehicle is ElectricVehicle electricVehicle)
                    {
                        ConsoleOutput.Message($"Remaining Battery Time: {electricVehicle.RemainingBatteryTime}");
                        ConsoleOutput.Message($"Maximum Battery Time: {electricVehicle.MaxBatteryTime}");
                    }
                }
                else
                {
                    ConsoleOutput.Message("Vehicle not found.");
                }
            }
            catch (FormatException ex)
            {
                ConsoleOutput.Message("Error: " + ex.Message);
            }
        }

    }
}
