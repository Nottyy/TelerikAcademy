var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
/// <reference path="./interfaces.ts" />
var Drivers;
(function (Drivers) {
    var Driver = (function () {
        function Driver(licenseDepartment) {
            this.licenseDepartment = licenseDepartment;
            this.listOfMachines = [];
            this.Name = '';
        }
        Driver.prototype.CanDriveMachines = function () {
            return this.licenseDepartment.getListOfMachines(this);
        };

        Driver.prototype.toString = function () {
            return this.Name;
        };
        return Driver;
    })();
    Drivers.Driver = Driver;

    var CarDriver = (function (_super) {
        __extends(CarDriver, _super);
        function CarDriver(licenseDepartment) {
            _super.call(this, licenseDepartment);
            this.Name = 'carDriver';
        }
        CarDriver.prototype.CanDriveMachines = function () {
            return _super.prototype.CanDriveMachines.call(this);
        };
        return CarDriver;
    })(Driver);
    Drivers.CarDriver = CarDriver;

    var Pilot = (function (_super) {
        __extends(Pilot, _super);
        function Pilot(licenseDepartment) {
            _super.call(this, licenseDepartment);
            this.Name = 'pilot';
        }
        Pilot.prototype.CanDriveMachines = function () {
            return _super.prototype.CanDriveMachines.call(this);
        };
        return Pilot;
    })(Driver);
    Drivers.Pilot = Pilot;

    var MotorDriver = (function (_super) {
        __extends(MotorDriver, _super);
        function MotorDriver(licenseDepartment) {
            _super.call(this, licenseDepartment);
            this.Name = 'motorist';
        }
        MotorDriver.prototype.CanDriveMachines = function () {
            return _super.prototype.CanDriveMachines.call(this);
        };
        return MotorDriver;
    })(Driver);
    Drivers.MotorDriver = MotorDriver;
})(Drivers || (Drivers = {}));
//# sourceMappingURL=Drivers.js.map
