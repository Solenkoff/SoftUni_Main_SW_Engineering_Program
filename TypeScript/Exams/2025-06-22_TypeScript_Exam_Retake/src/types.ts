import { LiftingGas } from "./contracts/gasses/liftingGas";
import { Propellant } from "./contracts/gasses/propellant";
import { ActiveLift } from "./contracts/lift/activeLift";
import { PassiveLift } from "./contracts/lift/passiveLift";

export type LiftMode = 'Active' | 'Passive';
export type LiftDeviceForMode<T extends LiftMode> = T extends 'Active' ? ActiveLift : PassiveLift;
export type GasForMode<T extends LiftMode> = T extends 'Active' ? Propellant : LiftingGas;