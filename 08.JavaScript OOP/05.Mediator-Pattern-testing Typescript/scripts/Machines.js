var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
/// <reference path="./interfaces.ts" />
var Machines;
(function (Machines) {
    var Machine = (function () {
        function Machine(licenseDepartment) {
            this.licenseDepartment = licenseDepartment;
            this.listOfDrivers = [];
            this.Name = '';
        }
        Machine.prototype.CanBeDrivenBy = function () {
            return this.licenseDepartment.getListOfDrivers(this);
        };

        Machine.prototype.toString = function () {
            return this.Name;
        };
        return Machine;
    })();
    Machines.Machine = Machine;

    var Tank = (function (_super) {
        __extends(Tank, _super);
        function Tank(licenseDepartment) {
            _super.call(this, licenseDepartment);
            this.licenseDepartment = licenseDepartment;
            this.Name = 'tank';
        }
        Tank.prototype.CanBeDrivenBy = function () {
            return _super.prototype.CanBeDrivenBy.call(this);
        };
        return Tank;
    })(Machine);
    Machines.Tank = Tank;

    var Plane = (function (_super) {
        __extends(Plane, _super);
        function Plane(licenseDepartment) {
            _super.call(this, licenseDepartment);
            this.licenseDepartment = licenseDepartment;
            this.Name = 'plane';
        }
        Plane.prototype.CanBeDrivenBy = function () {
            return _super.prototype.CanBeDrivenBy.call(this);
        };
        return Plane;
    })(Machine);
    Machines.Plane = Plane;

    var Car = (function (_super) {
        __extends(Car, _super);
        function Car(licenseDepartment) {
            _super.call(this, licenseDepartment);
            this.licenseDepartment = licenseDepartment;
            this.Name = 'car';
        }
        Car.prototype.CanBeDrivenBy = function () {
            return _super.prototype.CanBeDrivenBy.call(this);
        };
        return Car;
    })(Machine);
    Machines.Car = Car;

    var Bike = (function (_super) {
        __extends(Bike, _super);
        function Bike(licenseDepartment) {
            _super.call(this, licenseDepartment);
            this.licenseDepartment = licenseDepartment;
            this.Name = 'bike';
        }
        Bike.prototype.CanBeDrivenBy = function () {
            return _super.prototype.CanBeDrivenBy.call(this);
        };
        return Bike;
    })(Machine);
    Machines.Bike = Bike;
})(Machines || (Machines = {}));
//# sourceMappingURL=Machines.js.map
