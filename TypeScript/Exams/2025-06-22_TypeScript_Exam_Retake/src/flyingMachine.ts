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

    static get TotalMetersMoved(){
        return FlyingMachine._totalMetersMoved;
    }

    get weight(): number {
        if (this.isActive()) {
            return this._weight + this._gas.fuelWeight;
        } else {
            return this._weight;
        }
    }

    get altitude(): number {
        return this._altitude;
    }

    private set altitude(value: number) {
        if (value < 0) {
            this._altitude = 0;
        } else if (this.isPassive() && value > this._liftDevice.maxHeight) {
            this._altitude = this._liftDevice.maxHeight;
        } else {
            this._altitude = value;
        }
    }




    private isActive(): this is FlyingMachine<'Active'> {
        return 'fuelConsumptionRate' in this._liftDevice && typeof this._liftDevice.fuelConsumptionRate === 'number' && 'liftPerFuelUnit' in this._liftDevice && typeof this._liftDevice.liftPerFuelUnit === 'number' &&
            'getAltitudeChange' in this._liftDevice && typeof this._liftDevice.getAltitudeChange === 'function';
    }

    private isPassive(): this is FlyingMachine<'Passive'> {
        return 'maxHeight' in this._liftDevice && typeof this._liftDevice.maxHeight === 'number' &&
            'getAltitudeChange' in this._liftDevice && typeof this._liftDevice.getAltitudeChange === 'function';
    }

}

