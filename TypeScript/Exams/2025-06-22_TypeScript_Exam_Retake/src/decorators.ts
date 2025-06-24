import { SolidRocketBooster } from "./contracts/implemented/solidRocketBooster.js";


export function decorator3<T extends { new(...args: any[]): SolidRocketBooster }>(superConstructor: T) {
    return class extends superConstructor {
        constructor(...args: any[]) {
            super(...args);
            this._optimalWeight = args[2];
        }

        getAltitudeChange(flyerWeight?: number): number {
            let totalLift = this.liftPerFuelUnit * this.fuelConsumptionRate;

            if (this._optimalWeight != undefined && flyerWeight != undefined && flyerWeight > this._optimalWeight) {
                totalLift *= 0.5;
            }
            
            return totalLift;
        }
    }
}


export function decorator1(target: object, propertyKey: string, descriptor: PropertyDescriptor) { }

export function decorator2(target: object, methodName: string, descriptor: PropertyDescriptor) { }

export function decorator4(target: object, propertyKey: string, descriptor: PropertyDescriptor) { }
