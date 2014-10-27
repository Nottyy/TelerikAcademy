/// <reference path="./interfaces.ts" />
module Machines {
    import IMediator = Interfaces.IMediator;
    import IDriver = Interfaces.IDriver;
    import IMachine = Interfaces.IMachine;

    export class Machine implements IMachine{
        public listOfDrivers : IMachine[];
        public Name : string;

        constructor(public licenseDepartment: IMediator) {
            this.listOfDrivers = [];
            this.Name = '';
        }

        CanBeDrivenBy() : IDriver[] {
            return this.licenseDepartment.getListOfDrivers(this);
        }

        toString() {
            return this.Name;
        }
    }

    export class Tank extends Machine{
        constructor(public licenseDepartment : IMediator) {
            super(licenseDepartment);
            this.Name = 'tank'
        }

        CanBeDrivenBy() : IDriver[] {
            return super.CanBeDrivenBy.call(this);
        }
    }

    export class Plane extends Machine{
        constructor(public licenseDepartment : IMediator) {
            super(licenseDepartment);
            this.Name = 'plane';
        }

        CanBeDrivenBy() : IDriver[] {
            return super.CanBeDrivenBy.call(this);
        }
    }

    export class Car extends Machine{
        constructor(public licenseDepartment : IMediator) {
            super(licenseDepartment);
            this.Name = 'car';
        }

        CanBeDrivenBy() : IDriver[] {
            return super.CanBeDrivenBy.call(this);
        }
    }

    export class Bike extends Machine{
        constructor(public licenseDepartment : IMediator) {
            super(licenseDepartment);
            this.Name = 'bike';
        }

        CanBeDrivenBy() : IDriver[] {
            return super.CanBeDrivenBy.call(this);
        }
    }
}