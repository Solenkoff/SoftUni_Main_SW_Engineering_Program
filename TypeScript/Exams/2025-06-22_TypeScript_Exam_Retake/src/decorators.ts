import { SolidRocketBooster } from "./contracts/implemented/solidRocketBooster.js";


export function decorator1(target: object, propertyKey: string, descriptor: PropertyDescriptor) {}


export function decorator2(target: object, methodName: string, descriptor: PropertyDescriptor) {
    const originalMethod = descriptor.value;

    descriptor.value = function (flyerWeight?: number) {
        let originalResult = originalMethod.call(this);
        const optimalWeight = (this as SolidRocketBooster).optimalWeight;

        if (optimalWeight != undefined && flyerWeight != undefined && flyerWeight > optimalWeight) {
            originalResult *= 0.5;
        }

        return originalResult;
    }
}

export function decorator3(target: object, propertyKey: string, descriptor: PropertyDescriptor) {}

export function decorator4(target: object, propertyKey: string, descriptor: PropertyDescriptor) {}