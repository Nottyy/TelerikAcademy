/// <reference path="./interfaces.ts" />
module  LicenseDepartment {
    import IDriver = Interfaces.IDriver;
    import IMachine = Interfaces.IMachine;
    import IMediator = Interfaces.IMediator;

    export class VehicleLicenseDepartment implements  IMediator{
        public machines: string[];
        public drivers: string[];

        constructor(){
            this.machines = [];
            this.drivers = [];
        }

        getListOfDrivers(machine: IMachine) : IDriver[] {
            var machineStr = machine.toString();
            return this.drivers[machineStr];
        }

        getListOfMachines(driver: IDriver) : IMachine[] {
            var driverStr = driver.toString();
            return this.machines[driverStr];
        }

        addLicensedDriverToMachine(driver: string, machine: string) : void {

            if (!this.machines[driver]) {
                this.machines[driver] = [];
            }
            if (!this.drivers[machine]) {
                this.drivers[machine] = [];
            }

            this.machines[driver].push(machine);
            this.drivers[machine].push(driver);
        }
    }
}