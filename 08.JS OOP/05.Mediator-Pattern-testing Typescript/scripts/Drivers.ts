/// <reference path="./interfaces.ts" />
module Drivers  {
    import IDriver = Interfaces.IDriver;
    import IMachine = Interfaces.IMachine;
    import IMediator = Interfaces.IMediator;

    export class Driver implements IDriver{
        public listOfMachines : IMachine[];
        public Name : string;

        constructor(public licenseDepartment: IMediator) {
            this.listOfMachines = [];
            this.Name = '';
        }

        public CanDriveMachines() : IMachine[]{
            return this.licenseDepartment.getListOfMachines(this);
        }

        toString() {
            return this.Name
        }
    }

    export class CarDriver extends Driver {
        constructor(licenseDepartment: IMediator) {
            super(licenseDepartment);
            this.Name = 'carDriver';
        }

        CanDriveMachines() : IMachine[]{
            return super.CanDriveMachines.call(this);
        }
    }

    export class Pilot extends Driver {

        constructor(licenseDepartment: IMediator) {
            super(licenseDepartment);
            this.Name = 'pilot'
        }

        CanDriveMachines() : IMachine[]{
            return super.CanDriveMachines.call(this);
        }
    }

    export class MotorDriver extends Driver {

        constructor(licenseDepartment: IMediator) {
            super(licenseDepartment);
            this.Name = 'motorist';
        }

        CanDriveMachines() : IMachine[]{
        return super.CanDriveMachines.call(this);
        }
    }
}