module Interfaces {
    export interface IDriver {
        CanDriveMachines() : IMachine[];
    }

    export interface  IMachine {
        CanBeDrivenBy() : IDriver[];
    }

    export interface  IMediator {
        getListOfDrivers(machine: IMachine) : IDriver[];
        getListOfMachines(driver: IDriver) : IMachine[];
    }
}