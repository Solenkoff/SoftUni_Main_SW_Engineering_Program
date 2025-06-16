export function decorator1<T extends new (...args: any[]) => {}>(constructor: T) { }

export function decorator2(target: any, propName: string, descriptor: PropertyDescriptor) {
    const originalGetter = descriptor.get;

    descriptor.get = function () {
        return originalGetter?.call(this) * 1.2;
    }

    return descriptor;
}

export const decorator3 = decorator2;

export function decorator4(target: Object, methodName: string, paramIndex: number) { }

export function decorator5<T extends (abstract new (...args: any[]) => {})>(constructor: T) {
    abstract class ExtendedPartialMonthlyMotel extends constructor {
        public static readonly MotelName = 'Monthly Motel';
    }

    return ExtendedPartialMonthlyMotel;
}