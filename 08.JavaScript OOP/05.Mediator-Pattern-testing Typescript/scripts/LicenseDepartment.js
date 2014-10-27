/// <reference path="./interfaces.ts" />
var LicenseDepartment;
(function (LicenseDepartment) {
    var VehicleLicenseDepartment = (function () {
        function VehicleLicenseDepartment() {
            this.machines = [];
            this.drivers = [];
        }
        VehicleLicenseDepartment.prototype.getListOfDrivers = function (machine) {
            var machineStr = machine.toString();
            return this.drivers[machineStr];
        };

        VehicleLicenseDepartment.prototype.getListOfMachines = function (driver) {
            var driverStr = driver.toString();
            return this.machines[driverStr];
        };

        VehicleLicenseDepartment.prototype.addLicensedDriverToMachine = function (driver, machine) {
            if (!this.machines[driver]) {
                this.machines[driver] = [];
            }
            if (!this.drivers[machine]) {
                this.drivers[machine] = [];
            }

            this.machines[driver].push(machine);
            this.drivers[machine].push(driver);
        };
        return VehicleLicenseDepartment;
    })();
    LicenseDepartment.VehicleLicenseDepartment = VehicleLicenseDepartment;
})(LicenseDepartment || (LicenseDepartment = {}));
//# sourceMappingURL=LicenseDepartment.js.map
