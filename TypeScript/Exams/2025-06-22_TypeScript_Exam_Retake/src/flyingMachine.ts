import { Flyer } from "./contracts/flyer";
import { GasForMode, LiftDeviceForMode, LiftMode } from "./types";

export class FlyingMachine<T extends LiftMode> implements Flyer {

    private static _totalMetersMoved: number = 0;
    private _altitude!: number;
    private _weight!: number;
    private _liftDevice: LiftDeviceForMode<T>;
    private _gas: GasForMode<T>;

    constructor(
        liftDevice: LiftDeviceForMode<T>,
        _gas: GasForMode<T>,
        baseWeight: number,
        altitude: number,
    ) {
        this._liftDevice = liftDevice;
        this._gas = _gas;
        this._weight = baseWeight;
        this.altitude = altitude;
    }

    

}

